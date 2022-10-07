using airbnb.comLister.Models;
using airbnb.comLister.Services;

namespace AudibleImprovedBot.Services;

public class Scraper
{
    private bool _shouldRunAt;
    private DateTime _RunAt;
    private string _inputDir;
    private int _completed;
    private bool _loopFiles;
    private int _delayBetweenfiles;
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
    
    public async Task MainWork()
    {
        await WaitForScheduledDate();

        var files = Directory.GetFiles(_inputDir).ToList();
        do
        {
            _completed = 0;
            for (var f = 0; f < files.Count; f++)
            {
                var file = files[f];
                Notifier.Display($"Working on input file {f + 1} / {files.Count} : {Path.GetFileName(file)}");

                await WorkOneFile(file);

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