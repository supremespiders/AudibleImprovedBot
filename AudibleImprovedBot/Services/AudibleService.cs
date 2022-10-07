using airbnb.comLister.Services;
using Microsoft.Playwright;

namespace AudibleImprovedBot.Services;

public class AudibleService :BrowserBase
{
    
    public async Task StartSpecial()
    {
        Notifier.Display("Starting browser");
        _playwright = await Playwright.CreateAsync();
        var b = await _playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions()
        {
            Headless = false,
            Proxy = new Proxy()
            {
                Server = "194.163.175.24:808",
                Username = "user",
                Password = "puser"
            }
        });
        _browser = await b.NewContextAsync(new BrowserNewContextOptions()
        {
            Proxy = new Proxy()
            {
                Server = "194.163.175.24:808",
                Username = "user",
                Password = "puser"
            }
        });
        // _browser2 = await b.NewContextAsync(new BrowserNewContextOptions()
        // {
        //     Proxy = new Proxy()
        //     {
        //         Server = "194.163.175.24:808",
        //         Username = "user",
        //         Bypass = "puser"
        //     }
        // });
        _page = await _browser.NewPageAsync();
        // _page2 = await _browser2.NewPageAsync();
        Notifier.Display("browser started");
    }
    public async Task Work()
    {
        await StartSpecial();
        await _page.GotoAsync("https://api.ipify.org?format=json");
      //  await _page2.GotoAsync("https://api.ipify.org?format=json");
    }
}