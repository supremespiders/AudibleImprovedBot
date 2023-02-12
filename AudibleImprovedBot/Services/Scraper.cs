using airbnb.comLister.Models;
using AudibleImprovedBot.Models;
using ExcelHelperExe;
using Microsoft.Playwright;

namespace AudibleImprovedBot.Services;

public class Scraper
{
    private List<AudibleService> _audibleServices = new();
    private IPlaywright _playwright;
    private IBrowser _browser;
    private readonly string _path = Application.StartupPath;
    private Config _config;
    private List<Input> _inputs;
    private string _currentFile;
    private Static _static = new Static();
    public EventHandler<Static> OnStaticChange;

    async Task WaitForScheduledDate()
    {
        if (_config.DoRunAt)
        {
            var next = _config.RunAt;
            if (next < DateTime.Now)
                throw new KnownException("Error,  the scheduled date has passed");

            await Delay(next, "Waiting for Scheduled Run");
        }
    }

    private async Task StartBrowser()
    {
        if (_playwright != null) return;
        Notifier.Display($"Stating browser");
        _playwright = await Playwright.CreateAsync();
        _browser = await _playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions()
        {
            Channel = "chrome",
            Headless = false,
            Proxy = new Proxy
            {
                Server = $"194.163.175.24:808",
                Username = "user",
                Password = "puser"
            }
        });
    }

    public async Task Attach()
    {
        _playwright = await Playwright.CreateAsync();
        _browser = await _playwright.Chromium.ConnectOverCDPAsync("http://localhost:9222", new BrowserTypeConnectOverCDPOptions() { Timeout = 3000 });
        Notifier.Display("Attached");
    }

    public async Task Dispose()
    {
        if (_inputs != null)
            await _inputs.SaveToExcel(_currentFile);
        // if (_playwright == null) return;
        // foreach (var p in _pages)
        //     await p.Context.DisposeAsync();  
        //_playwright.Dispose();
    }

    async Task<bool> LoopFileIfNeeded()
    {
        var success = 0;
        var loop = 1;
        do
        {
            Notifier.Log($"working on file {Path.GetFileName(_currentFile)}, Loop {loop}");
            var targetSuccess = _config.TargetSuccessPerFile - success;
            var (s, f) = await ParallelWork(targetSuccess);
            success += s;

            if (_config.DoLimitRedeem && success == _config.TargetSuccessPerFile)
            {
                Notifier.Display($"Reached the target success per file : {_config.TargetSuccessPerFile}");
                break;
            }

            if (!_config.DoLoop)
            {
                return f == 0;
            }

            if (f == 0)
            {
                Notifier.Display("Loop is On , but there is no failed entries, so we going to break");
                return true;
            }
        } while (true);

        return false;
    }

    void GetStatistic()
    {
        _static = new Static();
        var files = Directory.GetFiles(_config.InputFolder).ToList();
        foreach (var t in files)
        {
            var inputs = t.ReadFromExcel<Input>();
            _static.TotalEntries += inputs.Count;
            foreach (var input in inputs)
            {
                if (string.IsNullOrEmpty(input.Result))
                    _static.ToProcess++;
                else if (input.Result == "success")
                    _static.Success++;
                else
                    _static.Failed++;
            }
        }

        OnStaticChange?.Invoke(this, _static);
    }

    async Task Delay(DateTime nextWakeUp, string message)
    {
        Notifier.Display($"{message},We will continue At {nextWakeUp:G}");
        do
        {
            var d = DateTime.Now;
            if (d >= nextWakeUp)
                break;
            await Task.Delay(1000);
        } while (true);
    }

    async Task ProcessFiles()
    {
        await WaitForScheduledDate();
        var files = Directory.GetFiles(_config.InputFolder).ToList();
        GetStatistic();
        do
        {
            var completed = 0;
            for (var f = 0; f < files.Count; f++)
            {
                _currentFile = files[f];
                var success = await LoopFileIfNeeded();
                if (success)
                    completed++;

                if (completed == files.Count)
                {
                    Notifier.Display("We finished all files with 0 error on each");
                    return;
                }

                if (f != files.Count - 1)
                {
                    if (_config.DoLoopFiles)
                    {
                        await Delay(DateTime.Now.AddHours(_config.HoursBetweenFiles), "Waiting for next file");
                    }
                }
                else
                {
                    if (!_config.DoLoopFiles)
                        return;
                    await Delay(DateTime.Now.AddHours(_config.HoursBetweenFiles), "Waiting for next Loop");
                }
            }
        } while (true);
    }

    async Task<(int success, int fails)> ParallelWork(int targetSuccess)
    {
        _inputs = _currentFile.ReadFromExcel<Input>();
        //var inputs = _inputs.Skip(6).Take(3).ToList();
        var threads = _config.MaxThreads;
        if (_config.DoLimitRedeem && targetSuccess < threads)
            threads = targetSuccess;
        var success = 0;
        var fails = 0;
        var tasks = new List<Task<bool>>();
        var i = 0;
        do
        {
            if (i < _inputs.Count)
            {
                var item = _inputs[i];
                i++;
                if (item.Result == "success" || (item.Result == "failed" && _config.SkipFailedEntries)) continue;
                var s = new AudibleService(item, _browser, _config);
                tasks.Add(s.Work());
            }

            if (tasks.Count != threads && i < _inputs.Count) continue;
            if (tasks.Count == 0) break;
            var t = await Task.WhenAny(tasks).ConfigureAwait(false);
            tasks.Remove(t);
            var b = await t;
            if (b) success++;
            else fails++;
            await _inputs.SaveToExcel(_currentFile);
            GetStatistic();
            if (_config.DoLimitRedeem && targetSuccess == success) break;
            if (tasks.Count == 0 && i == _inputs.Count) break;
        } while (true);

        return (success, fails);
    }

    public async Task ClearResults(Config config)
    {
        _config = config;
        Notifier.Display($"start clearing all results");
        var files = Directory.GetFiles(_config.InputFolder).ToList();
        foreach (var t in files)
        {
            var inputs = t.ReadFromExcel<Input>();
            foreach (var input in inputs)
            {
                input.Result = null;
                input.Message = null;
            }

            await inputs.SaveToExcel(t);
        }

        GetStatistic();
        Notifier.Display($"Completed");
    }

    public async Task MainWork(Config config)
    {
        Notifier.Display("Start working");
        _config = config;
        CaptchaService.TwoCaptchaKey = config.TwoCaptchaKey;
        // if (!_config.Test)
        //     await StartBrowser();
        await ProcessFiles();
        Notifier.Display("Work completed");
    }
}