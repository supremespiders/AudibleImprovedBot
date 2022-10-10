using airbnb.comLister.Models;
using airbnb.comLister.Services;
using AudibleImprovedBot.Models;
using Microsoft.Playwright;
using Newtonsoft.Json.Linq;

namespace AudibleImprovedBot.Services;

public class AudibleService :BrowserBase
{
    private Input _input;
    private IBrowser _browser;

    public AudibleService(Input input, IBrowser browser)
    {
        _input = input;
        _browser = browser;
    }
    private async Task VerifyIp()
    {
        await p.GotoAsync("https://api.ipify.org?format=json");
        var json = await p.TextContentAsync("//body");
        var ip = (string)JObject.Parse(json).SelectToken("ip");
        var proxyIp = _input.Proxy.Split(":")[0];
        if (proxyIp != ip) throw new KnownException($"the ip we found is not the one of proxy");
    }

    private async Task LoginToAmazon()
    {
        await p.GotoAsync(_input.Link);
        await Click("//*[@id='truste-consent-button']", 3000, true);
        await Click("//a[@id='att_lightbox_close']",3000, true);
        await Task.Delay(10000);
        await Click("//a[text()='Sign In']");
         await Fill("//input[@id='ap_email']",_input.MailAccountAudible,5000);
        await Fill("//input[@id='ap_password']",_input.AudiblePassword);
        await Click("//input[@id='signInSubmit']");
        if (!await Exist("//a[contains(@href,'/signout')]")) throw new KnownException("Not logged in");
    }
    
    public async Task Work()
    {
        await StartContext(_browser, _input.Proxy);
      //  await VerifyIp();
        await LoginToAmazon();

        //  await _page2.GotoAsync("https://api.ipify.org?format=json");
    }
}