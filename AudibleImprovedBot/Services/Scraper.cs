using airbnb.comLister.Models;
using AudibleImprovedBot.Models;
using ExcelHelperExe;
using Microsoft.Playwright;

namespace AudibleImprovedBot.Services;

public class Scraper
{
    private bool _shouldRunAt;
    private DateTime _RunAt;
    private string _inputDir;
    private int _completed;
    private bool _loopFiles;
    private int _delayBetweenfiles;
    private  List<AudibleService> _audibleServices=new ();
    protected IPlaywright _playwright;
    protected List<IPage> _pages;
    protected IBrowser _browser;
    private readonly string _path = Application.StartupPath;
    async Task WaitForScheduledDate()
    {
        if (_shouldRunAt)
        {
            var next = _RunAt;
            if (next < DateTime.Now)
                throw new KnownException("Error,  the scheduled date has passed");

            var toSleep = (int)(next - DateTime.Now).TotalMilliseconds;
            Notifier.Display($"Will start the run at {next:G}");
            await Task.Delay(toSleep);
        }
    }

    public async Task StartBrowser()
    {
        if (_playwright != null) return;
        Notifier.Display($"Stating browser");
        _playwright = await Playwright.CreateAsync();
        _browser = await _playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions()
        {
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
        _browser = await _playwright.Chromium.ConnectOverCDPAsync("http://localhost:9222", new BrowserTypeConnectOverCDPOptions(){Timeout = 3000});
        Notifier.Display("Attached");
    }
    
    public async Task Dispose()
    {
        if (_playwright == null) return;
        // foreach (var p in _pages)
        //     await p.Context.DisposeAsync();  
        //_playwright.Dispose();
    }
    
    public async Task MainWork(Config config)
    {
        Notifier.Log("Started working");
        CaptchaService.TwoCaptchaKey = config.TwoCaptchaKey;
        await StartBrowser();
       //await Attach();
        var inputs = "input.xlsx".ReadFromExcel<Input>();
         //_audibleServices.Add(new AudibleService(inputs[0],_browser,config));
          // _audibleServices.Add(new AudibleService(inputs[1],_browser,config));
         _audibleServices.Add(new AudibleService(inputs[0],_browser,config));
        //_audibleServices.Add(new AudibleService(inputs[1],_browser));
        var t = new List<Task>();
        foreach (var audibleService in _audibleServices)
        {
            t.Add(audibleService.Work());
        }

        await Task.WhenAll(t);
        Notifier.Log("completed");
        await inputs.SaveToExcel("input.xlsx");
        return;
        await WaitForScheduledDate();

        var files = Directory.GetFiles(_inputDir).ToList();
        do
        {
            _completed = 0;
            for (var f = 0; f < files.Count; f++)
            {
                var file = files[f];
                Notifier.Display($"Working on input file {f + 1} / {files.Count} : {Path.GetFileName(file)}");

               // await WorkOneFile(file);

                if (_completed == files.Count)
                {
                    Notifier.Display("We finished all files with 0 error on each");
                    return;
                }

                if (f != files.Count - 1)
                {
                    if (!_loopFiles)
                    {
                        Notifier.Display($"We will wait for {_delayBetweenfiles} hours till next file");
                        await Task.Delay(_delayBetweenfiles * 1000 * 60 * 60);
                    }
                }
                else
                {
                    if (!_loopFiles)
                        return;
                    else
                    {
                        Notifier.Display($"We will wait for {_delayBetweenfiles} hours till next file (loop)");
                        await Task.Delay(_delayBetweenfiles * 1000 * 60 * 60);
                    }
                }
            }
        } while (true);
    }
}