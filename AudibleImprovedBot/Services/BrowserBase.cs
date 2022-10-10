using System.Diagnostics;
using airbnb.comLister.Models;
using airbnb.comLister.Services;
using Microsoft.Playwright;

namespace AudibleImprovedBot.Services;

public class BrowserBase
{
    protected readonly string _path = Application.StartupPath;
    protected IPage p;
    
    public async Task<IPage> StartContext(IBrowser browser, string proxy)
    {
        Notifier.Display("starting context");
        var pr = proxy.Split(":");
        var context = await browser.NewContextAsync(new BrowserNewContextOptions()
        {
            Proxy = new Proxy()
            {
                Server = $"{pr[0]}:{pr[1]}",
                Username = pr[2],
                Password = pr[3]
            }
        });
        p = await context.NewPageAsync();
        // _page2 = await _browser2.NewPageAsync();
        Notifier.Display("context started");
        return p;
    }
    
    protected async Task<bool> Exist( string selector, int timeout = 5000)
    {
        try
        {
            await p.Locator(selector).WaitForAsync(new LocatorWaitForOptions { Timeout = timeout, State = WaitForSelectorState.Attached });
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    protected async Task Fill( string selector, string value, int timeout = 500)
    {
        try
        {
            await p.Locator(selector).FillAsync(value, new LocatorFillOptions { Timeout = timeout });
        }
        catch (Exception)
        {
            throw new KnownException($"Failed to find {selector}");
        }
    }

    protected async Task Click(string selector, int timeout = 5000, bool suppressException = false)
    {
        try
        {
            await p.Locator(selector).ClickAsync(new LocatorClickOptions { Timeout = timeout });
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            if (!suppressException)
                throw new KnownException($"Failed to find {selector}");
        }
    }

}