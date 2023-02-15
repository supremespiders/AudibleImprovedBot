using System.Diagnostics;
using System.Text;
using airbnb.comLister.Models;
using AudibleImprovedBot.Extensions;
using Microsoft.Playwright;

namespace AudibleImprovedBot.Services;

public class BrowserBase
{
    protected readonly string _path = Application.StartupPath;
    protected IPage p;
    protected Process proc;
    protected IPlaywright _playwright;
    
    private string _files = @"utils.js
magic-arrays.js
navigator.webdriver.js
navigator.vendor.js
navigator.plugins.js
navigator.permissions.js
navigator.languages.js
navigator.platform.js
navigator.userAgent.js
navigator.hardwareConcurrency.js
media.codecs.js
chrome.runtime.js
chrome.loadtimes.js
chrome.csi.js
chrome.app.js
iframe.contentWindow.js
window.outerdimensions.js
webgl.vendor.js
hairline.js";
    
    public async Task StartContext(IBrowser browser, string proxy)
    {
        if (p != null) return;
        var pr = proxy.Split(":");
        var o = new BrowserNewContextOptions()
        {
            Proxy = new Proxy()
            {
                Server = $"{pr[0]}:{pr[1]}",
                Username = pr[2],
                Password = pr[3]
            }
        };
        if (File.Exists("state.json"))
            o.StorageStatePath = "state.json";
        var context = await browser.NewContextAsync(o);
        var files = _files.Split("\n");
        foreach (var file in files)
        {
            var script = await File.ReadAllTextAsync($"js/{file.Replace("\r", "")}");
            await context.AddInitScriptAsync(script);
        }
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
    
      private static async Task CreateProxyExtension(string proxy, string prefix)
        {
            var pr = proxy.Split(":");
            if (pr.Length != 4) throw new KnownException($"Unknown format of proxy : {proxy}");
            var ip = pr[0];
            var port = pr[1];
            var username = pr[2];
            var pass = pr[3];
            var dir = $"{prefix}Ex";
            if (Directory.Exists(dir)) await dir.DeleteDirectory();
            Directory.CreateDirectory(dir);
            var manifest = "{\r\n        \"version\": \"0.1.0\",\r\n        \"manifest_version\": 2,\r\n        \"name\": \"%proxy%\",\r\n        \"permissions\": [\r\n            \"proxy\",\r\n            \"tabs\",\r\n            \"unlimitedStorage\",\r\n            \"storage\",\r\n            \"<all_urls>\",\r\n            \"webRequest\",\r\n            \"webRequestBlocking\"\r\n        ],\r\n        \"background\": {\r\n            \"scripts\": [\"background.js\"]\r\n        },\r\n        \"minimum_chrome_version\":\"22.0.0\"\r\n    }";
            var js = "var config = {\r\n    mode: \"fixed_servers\",\r\n    rules: {\r\n      singleProxy: {\r\n        scheme: \"http\",\r\n        host: \"" + ip + "\",\r\n        port: parseInt(" + port + ")\r\n      },\r\n      bypassList: [\"foobar.com\"]\r\n    }\r\n  };\r\n\r\nchrome.proxy.settings.set({value: config, scope: \"regular\"}, function() {});\r\n\r\nfunction callbackFn(details) {\r\n    return {\r\n        authCredentials: {\r\n            username: \"" + username + "\",\r\n            password: \"" + pass + "\"\r\n        }\r\n    };\r\n}\r\n\r\nchrome.webRequest.onAuthRequired.addListener(\r\n        callbackFn,\r\n        {urls: [\"<all_urls>\"]},\r\n        ['blocking']\r\n);";
            await File.WriteAllTextAsync($"{dir}/manifest.json", manifest);
            await File.WriteAllTextAsync($"{dir}/background.js", js);
        }

        protected async Task StartBrowser(string prefix, int port, string url, string proxy = null, bool deleteTemp = false)
        {
            if(deleteTemp && Directory.Exists(prefix))
               await prefix.DeleteDirectory();
            
            proc = new Process();
            if (proxy != null)
            {
                await CreateProxyExtension(proxy, prefix);
            }
            
            Directory.CreateDirectory(prefix);
            proc.StartInfo.FileName = @"C:\Program Files\Google\Chrome\Application\chrome.exe";
            if (!File.Exists(proc.StartInfo.FileName))
                proc.StartInfo.FileName = @"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe";
            var arg = $"{url} --start-maximized --remote-debugging-port={port}{(proxy == null ? "" : $" --load-extension=\"{Path.GetFullPath($"{prefix}Ex")}\"")} --user-data-dir=\"{Path.GetFullPath(prefix)}\"";
            proc.StartInfo.Arguments = arg;
            proc.Start();
            await Task.Delay(3000);
            _playwright = await Microsoft.Playwright.Playwright.CreateAsync();
            var browser = await _playwright.Chromium.ConnectOverCDPAsync($"http://localhost:{port}", new BrowserTypeConnectOverCDPOptions() { Timeout = 10000 });
            var context = browser.Contexts[0];
            p = context.Pages[0];
            //Notifier.Display("Attached");
        }

    protected async Task Click(string selector, int timeout = 5000, bool suppressException = false)
    {
        try
        {
            await p.Locator(selector).ClickAsync(new LocatorClickOptions { Timeout = timeout});
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