using System.Diagnostics;
using System.Text;
using airbnb.comLister.Models;
using Microsoft.Playwright;

namespace AudibleImprovedBot.Services;

public class BrowserBase
{
    protected readonly string _path = Application.StartupPath;
    protected IPage p;
    
    public async Task StartContext(IBrowser browser, string proxy)
    {
        if (p != null) return;
        var pr = proxy.Split(":");
        var context = await browser.NewContextAsync(new BrowserNewContextOptions()
        {
            Proxy = new Proxy()
            {
                Server = $"{pr[0]}:{pr[1]}",
                Username = pr[2],
                Password = pr[3]
            },
            StorageStatePath = "state.json"
        });
        p = await context.NewPageAsync();
        p.SetDefaultNavigationTimeout(60000);
        // _page2 = await _browser2.NewPageAsync();
    }

    public async Task GetContext(IBrowser browser)
    {
        var context = browser.Contexts.First();
        p = context.Pages.FirstOrDefault(x => x.Url.StartsWith("https://www.amazon.com/") || x.Url.StartsWith("https://www.audible.com/") || x.Url.StartsWith("https://cloud-e83ca2.managed-vps.net/"));
       // p = context.Pages.FirstOrDefault(x => x.Url.StartsWith("https://cloud-e83ca2.managed-vps.net/"));
        if (p == null)
            p = context.Pages.First();
    }

    protected async Task<bool> Exist( string selector, int timeout = 5000,bool visible=false)
    {
        try
        {
            await p.Locator(selector).WaitForAsync(new LocatorWaitForOptions { Timeout = timeout, State =visible ? WaitForSelectorState.Visible: WaitForSelectorState.Attached });
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }
    
    protected async Task<string> Text( string selector, int timeout = 1000,bool suppressException=true)
    {
        try
        {
            return await p.Locator(selector).TextContentAsync(new LocatorTextContentOptions() { Timeout = timeout});
        }
        catch (Exception e)
        {
            if (suppressException)
                return null;
            throw new KnownException($"Failed to get text for : {selector} : {e.Message}");
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
                throw new KnownException($"Failed to find {selector} : {ex.Message}");
        }
    }

    protected string BaseUrl()
    {
        var u = new Uri(p.Url);
        return $"{u.Scheme}://{u.Host}";
    }
    
    protected async Task ForAnyCondition(int timeOut,params string[] selectors)
    {
        var s = new StringBuilder();
        for (var i = 0; i < selectors.Length; i++)
        {
            var selector = selectors[i];
            s.Append(selector);
            if (i < selectors.Length-1)
                s.Append('|');
        }

        try
        {
            await p.Locator(s.ToString()).WaitForAsync(new LocatorWaitForOptions(){Timeout = timeOut,State = WaitForSelectorState.Attached});
        }
        catch (Exception)
        {
            throw new KnownException($"Failed to locate any of the selectors : {s}");
        }        
    }

}