using System.Diagnostics;
using System.Text;
using System.Text.Json;
using airbnb.comLister.Models;
using AudibleImprovedBot.Extensions;
using Microsoft.Playwright;

namespace AudibleImprovedBot.Services;

public class BrowserBase
{
    protected readonly string _path = Application.StartupPath;
    protected IPage p;
    protected Process proc;
    protected IPlaywright Playwright;
    protected IBrowserContext Context;
    private IBrowser _browser;

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

    public async Task StartPlaywright(string proxy)
    {
        Playwright = await Microsoft.Playwright.Playwright.CreateAsync();
        var browser = await Playwright.Chromium.LaunchAsync(new()
        {
            Channel = "chrome",
            Headless = false,
            Args = ["--start-maximized", "--disable-popup-blocking"]
        });

        var o = new BrowserNewContextOptions(new BrowserNewContextOptions()
        {
            ViewportSize = new ViewportSize(){Width = 1920, Height = 1080}
        });
        if (!string.IsNullOrEmpty(proxy))
        {
            var pr = proxy.Split(":");
            o.Proxy = new Proxy()
            {
                Server = $"{pr[0]}:{pr[1]}",
                Username = pr[2],
                Password = pr[3]
            };
        }
        Context = await browser.NewContextAsync(o);
        p = await Context.NewPageAsync();
         await p.GotoAsync("https://api.ipify.org?format=json");
    }

    protected async Task TakeScreenshot(string path)
    {
        await p.ScreenshotAsync(new PageScreenshotOptions()
        {
            Path = path,
            FullPage = false,
        });
    }

    public async Task GetContext(IBrowser browser)
    {
        var context = browser.Contexts.First();
        p = context.Pages.FirstOrDefault(x => x.Url.StartsWith("https://www.amazon.com/") || x.Url.StartsWith("https://www.audible.com/") || x.Url.StartsWith("https://cloud-e83ca2.managed-vps.net/"));
        // p = context.Pages.FirstOrDefault(x => x.Url.StartsWith("https://cloud-e83ca2.managed-vps.net/"));
        if (p == null)
            p = context.Pages.First();
    }

    protected async Task<bool> Exist(string selector, int timeout = 5000, bool visible = false)
    {
        try
        {
            await p.Locator(selector).WaitForAsync(new LocatorWaitForOptions { Timeout = timeout, State = visible ? WaitForSelectorState.Visible : WaitForSelectorState.Attached });
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    protected async Task<string> Text(string selector, int timeout = 1000, bool suppressException = true)
    {
        try
        {
            return await p.Locator(selector).TextContentAsync(new LocatorTextContentOptions() { Timeout = timeout });
        }
        catch (Exception e)
        {
            if (suppressException)
                return null;
            throw new KnownException($"Failed to get text for : {selector} : {e.Message}");
        }
    }

    protected async Task Fill(string selector, string value, int timeout = 500)
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

    private static void CreateProxyExtension(string proxy, string prefix)
    {
        var pr = proxy.Split(":");
        if (pr.Length != 4) throw new KnownException($"Unknown format of proxy : {proxy}");
        var ip = pr[0];
        var port = pr[1];
        var username = pr[2];
        var pass = pr[3];
        var dir = $"{Global.AppPath}/{prefix}Ex";
        if (Directory.Exists(dir))
        {
            Directory.Delete(dir, true);
        }

        Directory.CreateDirectory(dir);
        var manifest = @"{
  ""manifest_version"": 3,
  ""version"": ""0.1.0"",
  ""name"": ""%proxy%"",
  ""permissions"": [
    ""proxy"",
    ""webRequest"",
    ""webRequestAuthProvider"",
    ""alarms"",
    ""extraHeaders""
  ],
  ""host_permissions"": [
    ""<all_urls>""
  ],
  ""background"": {
    ""service_worker"": ""background.js"",
    ""type"": ""module""
  },
  ""minimum_chrome_version"": ""96.0""
}
";
        var js = $@"const USER = ""{username}"";
const PASS = ""{pass}"";
const HOST = ""{ip}"";
const PORT = parseInt(""{port}"", 10);

function applyProxy() {{
  const config = {{
    mode: ""fixed_servers"",
    rules: {{
      singleProxy: {{ scheme: ""http"", host: HOST, port: PORT }},
      bypassList: [""foobar.com""]
    }}
  }};
  chrome.proxy.settings.set({{ value: config, scope: ""regular"" }});
}}

chrome.runtime.onInstalled.addListener(() => {{
  applyProxy();
  chrome.alarms.create(""warmup"", {{ delayInMinutes: 0.1, periodInMinutes: 0.5 }});
}});

chrome.alarms.onAlarm.addListener(alarm => {{
  if (alarm.name === ""warmup"") {{
    applyProxy();
  }}
}});

// 4) Register auth listener at top‑level
chrome.webRequest.onAuthRequired.addListener(
  (details, callback) => {{
    if (!details.isProxy) return;
    callback({{ authCredentials: {{ username: USER, password: PASS }} }});
  }},
  {{ urls: [""<all_urls>""] }},
  [""asyncBlocking"", ""extraHeaders""]
);";
        File.WriteAllText($"{dir}/manifest.json", manifest);
        File.WriteAllText($"{dir}/background.js", js);
    }

    public async Task AttachToChrome(int port)
    {
        for (int i = 0; i < 3; i++)
        {
            try
            {
                Playwright = await Microsoft.Playwright.Playwright.CreateAsync();
                _browser = await Playwright.Chromium.ConnectOverCDPAsync($"http://localhost:{port}", new BrowserTypeConnectOverCDPOptions() { Timeout = 5000 });
                var context = _browser.Contexts[0];
                Context = context;
                p = context.Pages[0];
                break;
            }
            catch (Exception e)
            {
                if (i == 2)
                    throw new KnownException($"Failed to attach to chrome");
                await Task.Delay(1000);
                Playwright?.Dispose();
            }
        }

        Console.WriteLine($"attached to {port}");
    }

    protected async Task DisposePlaywright()
    {
        try
        {
            if (p?.Context == null)
            {
                proc?.Kill();
                return;
            }

            if (_browser != null)
            {
                var cdpSession = await _browser.NewBrowserCDPSessionAsync();
                await cdpSession.SendAsync("Browser.close");
            }
            else
            {
                await p.Context.CloseAsync();
                await p.Context.DisposeAsync();
            }

            Playwright.Dispose();
        }
        finally
        {
            proc = null;
        }
    }

   protected async Task StartBrowser(string prefix, int cdpPort, string url, string proxy = null, bool deleteTemp = false)
{
    proc = new Process();

    var profilePath = Path.Combine(Global.AppPath, prefix);
    if (Directory.Exists(profilePath) && deleteTemp) Directory.Delete(profilePath, true);
    Directory.CreateDirectory(profilePath);

    proc.StartInfo.FileName = @"C:\Program Files\Google\Chrome\Application\chrome.exe";
    if (!File.Exists(proc.StartInfo.FileName)) proc.StartInfo.FileName = @"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe";

    var finalUrl = Directory.Exists(profilePath) ? "" : $"{url} ";
    var args = new List<string>
    {
        finalUrl.Trim(),
        $"--remote-debugging-port={cdpPort}",
        $"--user-data-dir=\"{profilePath}\"",
        "--no-first-run",
        "--no-default-browser-check",
        "--disable-session-crashed-bubble"
    };

    if (!string.IsNullOrWhiteSpace(proxy))
    {
        var (host, port, user, pass) = ParseProxy(proxy);
        args.Add($"--proxy-server=http://{host}:{port}");
        ProxyUser = user; ProxyPass = pass;
    }

    proc.StartInfo.Arguments = string.Join(" ", args);
    proc.Start();
    await Task.Delay(2500);

    if (!string.IsNullOrEmpty(ProxyUser))
        await AttachAndAnswerProxyAuth(cdpPort, ProxyUser!, ProxyPass!);
}

async Task AttachAndAnswerProxyAuth(int cdpPort, string user, string pass)
{
    Playwright ??= await Microsoft.Playwright.Playwright.CreateAsync();
    _browser = await Playwright.Chromium.ConnectOverCDPAsync($"http://127.0.0.1:{cdpPort}");
    var ctx = _browser.Contexts.First();

    var authHandled = new HashSet<string>();

    async Task Hook(IPage page)
    {
        var cdp = await ctx.NewCDPSessionAsync(page);
        
        await cdp.SendAsync("Network.enable");
        await cdp.SendAsync("Fetch.enable", new Dictionary<string, object>
        {
            ["handleAuthRequests"] = true,
            ["patterns"] = new[] { new { urlPattern = "*" } }
        });

        cdp.Event("Fetch.authRequired").OnEvent += async (_, ev) =>
        {
            if (!ev.HasValue) return;
            var json = ev.Value;
            var reqId = json.GetProperty("requestId").GetString();
            
            if (authHandled.Contains(reqId)) return;
            authHandled.Add(reqId);

            var src = json.GetProperty("authChallenge").GetProperty("source").GetString();
            var resp = src == "Proxy"
                ? new Dictionary<string, object> 
                { 
                    ["response"] = "ProvideCredentials", 
                    ["username"] = user, 
                    ["password"] = pass 
                }
                : new Dictionary<string, object> { ["response"] = "CancelAuth" };
                
            try
            {
                await cdp.SendAsync("Fetch.continueWithAuth", new Dictionary<string, object>
                {
                    ["requestId"] = reqId,
                    ["authChallengeResponse"] = resp
                });
            }
            catch { }
        };

        cdp.Event("Fetch.requestPaused").OnEvent += async (_, ev) =>
        {
            if (!ev.HasValue) return;
            var reqId = ev.Value.GetProperty("requestId").GetString();
            
            try
            {
                await cdp.SendAsync("Fetch.continueRequest", new Dictionary<string, object> 
                { 
                    ["requestId"] = reqId 
                });
            }
            catch { }
        };
    }

    foreach (var p in ctx.Pages) await Hook(p);
    ctx.Page += async (_, p) => await Hook(p);
    p = ctx.Pages[0];
}

static (string host, int port, string? user, string? pass) ParseProxy(string p)
{
    var pr = p.Split(":");
    if (pr.Length != 4) throw new KnownException($"Unknown format of proxy : {p}");
    return (pr[0], int.Parse(pr[1]), pr[2], pr[3]);
}
    async Task AttachAndAnswerProxyAuthOld(int cdpPort, string user, string pass)
    {
        Playwright ??= await Microsoft.Playwright.Playwright.CreateAsync();
        _browser = await Playwright.Chromium.ConnectOverCDPAsync($"http://127.0.0.1:{cdpPort}");
        var ctx = _browser.Contexts.First();

        async Task Hook(IPage page)
        {
            var cdp = await ctx.NewCDPSessionAsync(page);
            await cdp.SendAsync("Fetch.enable", new Dictionary<string, object> { ["handleAuthRequests"] = true });
            cdp.Event("Fetch.authRequired").OnEvent += async (_, json) =>
            {
                if (!json.HasValue) return;
                var ev = json.Value;
                var src = ev.GetProperty("authChallenge").GetProperty("source").GetString();
                var reqId = ev.GetProperty("requestId").GetString();
                var resp = src == "Proxy"
                    ? new Dictionary<string, object> { ["response"] = "ProvideCredentials", ["username"] = user, ["password"] = pass }
                    : new Dictionary<string, object> { ["response"] = "Default" };
                await cdp.SendAsync("Fetch.continueWithAuth", new Dictionary<string, object>
                {
                    ["requestId"] = reqId,
                    ["authChallengeResponse"] = resp
                });
            };
        }

        foreach (var p in ctx.Pages) await Hook(p);
        ctx.Page += async (_, p) => await Hook(p);
        p = ctx.Pages[0];
    }
    static string? ProxyUser, ProxyPass;
    
    protected async Task StartBrowserOld(string prefix, int port, string url, string proxy = null, bool deleteTemp = false)
    {
        proc = new Process();
        if (proxy != null)
        {
            CreateProxyExtension(proxy, prefix);
        }

        var profilePath = Path.Combine(Global.AppPath, prefix);
        if (Directory.Exists(profilePath) && deleteTemp)
            Directory.Delete(profilePath, true);
        Directory.CreateDirectory(profilePath);

        proc.StartInfo.FileName = @"C:\Program Files\Google\Chrome\Application\chrome.exe";
        if (!File.Exists(proc.StartInfo.FileName))
            proc.StartInfo.FileName = @"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe";

        var exPath = Path.GetFullPath(Path.Combine(Global.AppPath, $"{prefix}Ex"));
        var finalUrl = Directory.Exists(profilePath) ? "" : $"{url} ";
        var baseDir = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            "ms-playwright"
        );

        string chromiumPath = null;
        for (var i = 0; i < 2; i++)
        {
            chromiumPath = Directory.Exists(baseDir)
                ? Directory.GetDirectories(baseDir, "chromium-*")
                    .OrderByDescending(dir =>
                        int.TryParse(Path.GetFileName(dir).Split('-').Last(), out var v) ? v : 0)
                    .Select(dir => Path.Combine(dir, "chrome-win", "chrome.exe"))
                    .FirstOrDefault(File.Exists)
                : null;
            if (chromiumPath == null)
            {
                if (i == 1) throw new KnownException("Chromium is not installed");
                Notifier.Log("Chromium is not installed, installing it now..");
                var buildDir = $@"{Global.AppPath}";
                var playwrightPs1 = Path.Combine(buildDir, "playwright.ps1");

                var psi = new ProcessStartInfo
                {
                    FileName = "powershell.exe",
                    Arguments = $"-NoProfile -ExecutionPolicy Bypass -Command \"& '{playwrightPs1}' install chromium;\"",
                    UseShellExecute = true,
                    WorkingDirectory = buildDir,
                    Verb = "runas"
                };
                var process = Process.Start(psi);
                process.WaitForExit();
                var exitCode = process.ExitCode;
            }
            else
                break;
        }

        // proc.StartInfo.FileName = chromiumPath;
        var argBuilder = new List<string>
        {
            finalUrl.Trim(),
            $"--remote-debugging-port={port}",
            $"--user-data-dir={profilePath}",
            "--no-first-run",
            "--no-default-browser-check",
            "--disable-session-crashed-bubble"
        };

        if (proxy != null)
        {
            argBuilder.Add($"--load-extension={exPath}");
            argBuilder.Add($"--disable-extensions-except={exPath}");
        }

        proc.StartInfo.Arguments = string.Join(" ", argBuilder);
        proc.Start();
        Console.WriteLine($"chromium started at {port}");
        await Task.Delay(5000);
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

    public async Task<int> WaitForAnyXPathAsync(int timeout, params string[] xpaths)
    {
        var tasks = xpaths.Select((xpath, index) => WaitForXPathAsync(p, xpath, timeout, index)).ToList();
        while (tasks.Any())
        {
            var finishedTask = await Task.WhenAny(tasks);
            tasks.Remove(finishedTask);
            var (index, found) = await finishedTask;
            if (found)
            {
                return index;
            }
        }

        return -1;
    }

    private async Task<(int, bool)> WaitForXPathAsync(IPage page, string xpath, int timeout, int index)
    {
        try
        {
            var element = await page.WaitForSelectorAsync(xpath, new() { Timeout = timeout, State = WaitForSelectorState.Attached });
            return (index, true);
        }
        catch (TimeoutException)
        {
            return (index, false);
        }
    }
}