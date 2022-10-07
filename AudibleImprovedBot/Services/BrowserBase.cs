using airbnb.comLister.Services;
using Microsoft.Playwright;

namespace AudibleImprovedBot.Services;

public class BrowserBase
{
    protected IPlaywright _playwright;
    protected IBrowserContext _browser;
    protected IBrowserContext _browser2;
    protected IPage _page;
    protected IPage _page2;
    protected readonly string _path = Application.StartupPath;
    
    public async Task AttachToBrowser()
    {
        Notifier.Display("Attaching Browser Engine");
        _playwright = await Playwright.CreateAsync();
        var b = await _playwright.Chromium.ConnectOverCDPAsync("http://localhost:9222", new BrowserTypeConnectOverCDPOptions() { Timeout = 3000 });
        _browser = b.Contexts.First();
        _page = _browser.Pages.FirstOrDefault(x => x.Url.StartsWith("https://www.airbnb.com/"));
        if (_page == null)
            _page = _browser.Pages.First();
        Notifier.Display("Attached");
    }
    
    public async Task StartBrowser(bool headless=false,bool persisted=false)
    {
        Notifier.Display("Starting browser");
        _playwright = await Playwright.CreateAsync();
        Directory.CreateDirectory("temp");
        var userDataDir = $"{_path}/tmp";
        if (persisted)
        {
            _browser = await _playwright.Chromium.LaunchPersistentContextAsync(userDataDir, new BrowserTypeLaunchPersistentContextOptions()
            {
                Headless = headless,
                //  Args = new []{$"--disable-extensions-except={_path}/ext"} //$"--load-extension={_path}/ext", ,{_path}/ext2
            });
        }
        else
        {
            var b = await _playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions()
            {
                Headless = headless
            });
            _browser = await b.NewContextAsync(new BrowserNewContextOptions());
        }
      
        //  var context = await _browser.NewContextAsync();
        _page = _browser.Pages[0];
        Notifier.Display("browser started");
    }
    
    
    
    public async Task Dispose()
    {
        if (_browser == null) return;
        await _browser.DisposeAsync();
        _playwright.Dispose();
    }
}