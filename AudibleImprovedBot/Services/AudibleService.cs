﻿using System.Diagnostics;
using System.Net;
using airbnb.comLister.Models;
using AudibleImprovedBot.Models;
using Microsoft.Playwright;
using Newtonsoft.Json.Linq;

namespace AudibleImprovedBot.Services;

public class AudibleService : BrowserBase
{
    private readonly Input _input;
    private readonly IBrowser _browser;
    private readonly string _libLink;
    private readonly Config _config;
    private readonly Random _random = new();

    private HttpClient _client = new HttpClient(new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.All })
    {
        Timeout = TimeSpan.FromSeconds(20)
    };

    public AudibleService(Input input, IBrowser browser, Config config)
    {
        _input = input;
        _browser = browser;
        _config = config;
        _libLink = input.Link.Contains(".co.uk") ? "https://www.audible.co.uk/library/titles" : "https://www.audible.com/library/titles";
    }

    private async Task VerifyIp()
    {
        await p.GotoAsync("https://api.ipify.org?format=json");
        var json = await p.TextContentAsync("//body");
        var ip = (string)JObject.Parse(json).SelectToken("ip");
        var proxyIp = _input.Proxy.Split(":")[0];
        if (proxyIp != ip) throw new KnownException($"{_input.MailAccountAudible} the ip we found is not the one of proxy");
    }

    private async Task LoginToAmazon()
    {
        Notifier.Log($"{_input.MailAccountAudible} Opening amazon page");
        await p.GotoAsync(_input.Link, new PageGotoOptions() { Timeout = 60000 });
        Notifier.Log($"{_input.MailAccountAudible} Start login");
        await Click("//*[@id='truste-consent-button']", 3000, true);
        await Click("//a[@id='att_lightbox_close']", 1000, true);
        // await Task.Delay(10000);
        await Click("//*[contains(translate(text(), 'ABCDEFGHIJKLMNOPQRSTUVWXYZ', 'abcdefghijklmnopqrstuvwxyz'),'sign in')]", 30000);
        await SolveImageCaptchaIfNeeded();
        await Fill("//input[@id='ap_email']", _input.MailAccountAudible, 30000);
        if (!await Exist("//input[@id='ap_password']", 2000))
        {
            await Click("(//input[@id='continue'])[1]");
        }
        await Fill("//input[@id='ap_password']", _input.AudiblePassword);
        await Click("//input[@id='signInSubmit']", 60000);
        if (await Exist("(//*[@id='auth-error-message-box'])[1]"))
        {
            var text = await Text("(//*[@id='auth-error-message-box'])[1]//div[@class='a-alert-content']");
            throw new KnownException($"{_input.MailAccountAudible} {text}");
        }

        await SolveCaptchaIfNeeded();
        await VerifyByEmailIfNeeded();
        if (!await Exist("//a[contains(@href,'/signout')]")) throw new KnownException($"{_input.MailAccountAudible} Not logged in");
        Notifier.Display($"{_input.MailAccountAudible} logged in");
    }

    private async Task SolveImageCaptchaIfNeeded()
    {
        if (!await Exist("//input[@id='captchacharacters']", 3000)) return;
        Notifier.Log($"{_input.MailAccountAudible} captcha detected");
        var src = await p.Locator("//img[contains(@src,'captcha')]").GetAttributeAsync("src");
        var solution = await CaptchaService.SolveCaptcha(src, $"{_path}/{_input.PromoCode}");
        await Fill("//input[@id='captchacharacters']", solution);
        await Click("//button[@type='submit']", 30000);
        if (await Exist("//input[@id='ap_email']", 2000))
        {
            await p.Context.StorageStateAsync(new()
            {
                Path = "state.json"
            });
        }
    }

    private async Task SolveCaptchaIfNeeded()
    {
        if (!await Exist("//*[@id='auth-captcha-image-container']", 500)) return;
        Notifier.Log($"{_input.MailAccountAudible} Captcha detected");
        var src = await p.Locator("//*[@id='auth-captcha-image-container']").GetAttributeAsync("src");
        if (src == null)
            src = await p.Locator("//img[@id='auth-captcha-image']").GetAttributeAsync("src");
        var solution = await CaptchaService.SolveCaptcha(src, $"{_path}/{_input.PromoCode}");
        await Fill("//input[@id='ap_password']", _input.AudiblePassword);
        await Fill("//input[@id='auth-captcha-guess']", solution);
        await Click("//input[@id='signInSubmit']");
    }

    private async Task VerifyByEmailIfNeeded()
    {
        if (!await Exist("#resend-transaction-approval")) return;
        Notifier.Display($"{_input.MailAccountAudible} Verification by email needed, we will wait 5 sec just in case");
        await Task.Delay(10000);
        var p2 = p;
        p = await p.Context.NewPageAsync();
        await p.GotoAsync("https://cloud-e83ca2.managed-vps.net/webmail");
        await Click("//a[@data-nav-rel='webmail']", 2000, true);
        await Fill("//input[@name='email']", _input.MailAccountAudible);
        await Fill("//fieldset[@data-rel='webmail']//input[@name='password']", _input.EmailPassword);
        await Click("//button[text()='Login']");
        var firstEmailS = "(//span[@class='subject'])[1]";
        if (!await Exist(firstEmailS, 15000))
        {
            if (!await Exist("//div[@data-sitekey]")) throw new KnownException($"Failed to login to email service and can't find captcha");
            var key = await p.Locator("//div[@data-sitekey]").GetAttributeAsync("data-sitekey");
            Notifier.Display($"{_input.MailAccountAudible} Recaptcha detected : {key}");
            var response = await CaptchaService.SolveReCaptcha(key, _input.Proxy);
            if (response.Equals("ERROR_KEY_DOES_NOT_EXIST")) throw new KnownException($"recaptcha ERROR_KEY_DOES_NOT_EXIST");
            await p.EvaluateAsync($"document.getElementById('g-recaptcha-response').innerHTML='{response}';");
            await p.EvaluateAsync("onSubmit();");
        }

        var message = await p.Locator(firstEmailS).TextContentAsync();
        if (message == null || !message.Contains("Sign-in")) throw new KnownException($"{_input.MailAccountAudible} Last message is not Amazon security alert: Sign-in attempt");
        await Click(firstEmailS);

        await Task.Delay(3000);
        // if (!await Exist("//a[text()=' Approve or Deny.']")) 
        //     throw new KnownException($"{_input.MailAccountAudible} Could not locate the approve link");
        var frame = p.FrameLocator("#messagecontframe");
        var code = (await frame.Locator("//td[contains(@style,'background-color: #D3D3D3')]/p").TextContentAsync()).Trim();
        // var link = await frame.Locator("//a[text()=' Approve or Deny.']").GetAttributeAsync("href", new LocatorGetAttributeOptions() { Timeout = 15000 });
        // if (link == null) throw new KnownException($"{_input.MailAccountAudible} Failed to retrieve link from approved link node");
        // await Navigate(link);
        // await Click("//input[@name='customerResponseApproveButton']");
        // if (!await Exist("//span[text()='Thank you. Sign-in attempt was approved.']", 15000) &&
        //     !await Exist("//span[text()='Grazie, Tentativo di accesso è stato approvato.']", 3000) &&
        //     !await Exist("//a[contains(@href,'/signout')]", 3000))
        //     throw new KnownException("Failed to approve the access");
        // Notifier.Log($"{_input.MailAccountAudible} Access approved");
        p = p2;
        for (int i = 1; i < 7; i++)
        {
            await Fill($"//input[@name='otc-{i}']", code[i - 1].ToString());
        }
        await Click("//span[@id='cvf-submit-otp-button']");
    }

    private async Task Navigate(string url)
    {
        try
        {
            await p.GotoAsync(url);
        }
        catch (Exception e)
        {
            await p.GotoAsync(url);
        }
    }

    private async Task<string> Redeem()
    {
        Notifier.Log($"{_input.MailAccountAudible} Start redeeming");
        await Fill("//input[@id='redeem-text-box']", _input.PromoCode);
        await Click("//*[@id='redeem-button']");
        //await ForAnyCondition(10000, "//div[@data-asin]", "//*[@id='error-text']");
        if (await Exist("//input[@name='fullName']"))
        {
            Notifier.Log($"{_input.MailAccountAudible} Start filling address");
            var address = await GetAddress(_input.Link);
            await Fill("//input[@name='fullName']", _input.Name);
            await Fill("//input[@name='addressLine1']", address.Street);
            await Fill("//input[@name='zipCode']", address.Zip);
            if (await Exist("//input[@name='phoneNumber']", 2000))
                await Fill("//input[@name='phoneNumber']", address.Phone);
            await Task.Delay(1000);
            await Fill("//input[@name='city']", address.City);
            await Click("//span[@class='bc-button bc-button-primary adbl-save-button payments-widget-wider-button payments-widget-save-and-close bc-button-inline']");
        }

        if (await Exist("//div[@data-asin]", 10000)) return await p.Locator("//div[@data-asin]").GetAttributeAsync("data-asin");
        if (!await Exist("//*[@id='error-text']", 2000, true)) throw new KnownException($"{_input.MailAccountAudible} something went wrong with redeeming");
        var redeemMessage = (await p.Locator("#error-text").TextContentAsync())?.Replace("\r", "").Replace("\n", "").Trim();
        if (redeemMessage == null) throw new KnownException($"{_input.MailAccountAudible} something went wrong with redeeming");
        if (redeemMessage.Contains("This promotional code has already been claimed")) throw new KnownException($"Already redeemed and the Asin is not provided on input file");
        throw new KnownException($"{_input.MailAccountAudible} Error redeeming : {redeemMessage}");
    }

    private async Task MarkAsFinish()
    {
        if (string.IsNullOrEmpty(_input.Asin)) throw new KnownException($"{_input.MailAccountAudible} Empty asin after redeem!");
        var tries = 0;
        do
        {
            await p.GotoAsync(_libLink);
            if (!await Exist($"//div[@id='adbl-library-content-row-{_input.Asin}']"))
            {
                tries++;
                if (tries == 5)
                    throw new KnownException($"{_input.MailAccountAudible} Failed to lookup the book ({_input.Asin})");
                await Task.Delay(3000);
                continue;
            }

            var markAsFinishedS = $"//span[@id='mark-as-finished-button-{_input.Asin}']";
            var buttonClass = await p.Locator(markAsFinishedS).GetAttributeAsync("class");
            if (buttonClass == null) throw new KnownException($"{_input.MailAccountAudible} Null class for mark as finished");
            if (buttonClass.Contains("bc-pub-hidden"))
            {
                Notifier.Log(tries == 0 ? $"{_input.MailAccountAudible} {_input.Asin} already Marked as finished" : $"{_input.MailAccountAudible} {_input.Asin} Marked as finished");
                break;
            }

            tries++;
            if (tries == 20) throw new KnownException($"{_input.MailAccountAudible} Tried 20 times to refresh and mark {_input.Asin} as finish but failed");
            await Click(markAsFinishedS);
            await Task.Delay(3000);
        } while (true);
    }

    private int GetRate()
    {
        return _config.Stars == 0
            ? _random.Next(4, 6)
            : 5;
    }

    private async Task Rate()
    {
        var tries = 0;
        var x = GetRate();
        do
        {
            await p.GotoAsync(_libLink);
            if (!await Exist($"//div[@id='adbl-library-content-row-{_input.Asin}']"))
            {
                tries++;
                if (tries == 5)
                    throw new KnownException($"{_input.MailAccountAudible} Failed to lookup the book ({_input.Asin})");
                await Task.Delay(3000);
                continue;
            }

            var starS = $"//div[@id='adbl-library-content-row-{_input.Asin}']//span[@data-index='{x}']";
            var isChecked = (await p.Locator(starS).GetAttributeAsync("aria-checked")) != "false";
            if (isChecked)
            {
                Notifier.Log(tries == 0 ? $"{_input.MailAccountAudible} {_input.Asin} already rated" : $"{_input.Asin} Rated");
                break;
            }

            tries++;
            if (tries == 20) throw new KnownException($"{_input.MailAccountAudible} tried 20 times to rate {_input.Asin} but failed");
            await Click(starS);
            if (await Exist("//h3[text()='Review not available for this title']", 1000, true))
                throw new KnownException($"{_input.MailAccountAudible} This book need listening first");
            await Task.Delay(3000);
        } while (true);
    }

    private async Task ListenToBook()
    {
        if (!await Exist($"//div[@id='adbl-library-content-row-{_input.Asin}']",15000)) throw new KnownException($"{_input.MailAccountAudible} Failed to lookup the book");
        var reviewLinkS = $"//div[@id='adbl-library-content-row-{_input.Asin}']//a[contains(@href,'/write-review?')]";
        if (await Exist(reviewLinkS, 1000))
        {
            var link = await p.Locator(reviewLinkS).GetAttributeAsync("href");
            if (!string.IsNullOrEmpty(link))
            {
                Notifier.Log($"{_input.MailAccountAudible} {_input.Asin} no need to listened to this book");
                return;
            }
        }

        Notifier.Log($"{_input.MailAccountAudible}  {_input.Asin} started listening to the book");
        await Click($"//div[@id='adbl-library-content-row-{_input.Asin}']//span[contains(@class,'adbl-library-listen-now-button')]");
        var p2 = p;
        await Task.Delay(5000);
        p = p.Context.Pages.First(x => x.Url.Contains("/webplaye"));
        //p = p.Context.Pages.Last();
        await Click("//div[contains(@class,'adblCloudPlayerSpeedNarration')]", 10000);
        //await Task.Delay(3000);
        //await Click("(//div[@class='bc-radio'])[last()]");
        await Click("(//div[@class='bc-radio'])[last()]", 10000);

        string lastChapter = null;
        if (await Exist("//button[@class='chapterMenuIcon']", 5000, true))
        {
            await Click("//button[@class='chapterMenuIcon']");
            lastChapter = (await Text("(//span[@id='chapter-menu-trigger'])[last()]", 1000, false)).Replace("\n", "").Trim();
            await Click("//a[@id='adbl-cp-chapters-close-icon']");
        }

        Notifier.Log($"Last chapter : {lastChapter}");
        bool weAreOnLastChapter = false;
        string last = null;
        var started=DateTime.Now;
        do
        {
            var chapterTitle = await Text("//span[@id='cp-Top-chapter-display']");
            var timeLeft = await Text("//div[@id='adblMediaBarTimeLeft']");
            if (lastChapter == null || chapterTitle == lastChapter) weAreOnLastChapter = true;
            Notifier.Display($"{_input.MailAccountAudible} Chapter title : {chapterTitle} , Time Left : {timeLeft}", false);
            await Task.Delay(5000);
            if (chapterTitle == null || timeLeft == last || (weAreOnLastChapter && chapterTitle != lastChapter) || (chapterTitle == lastChapter && timeLeft == "– 00:00"))
            {
                Notifier.Log($"{_input.MailAccountAudible} we listened to the end,closing the window..");
                await p.CloseAsync();
                p = p2;
                break;
            }
            if (_config.StopListen && (DateTime.Now-started).TotalMinutes>_config.ListenDuration)
            {
                Notifier.Log($"{_input.MailAccountAudible} we will stop listening because we listened for {_config.ListenDuration} min");
                await p.CloseAsync();
                p = p2;
                Notifier.Log($"Refreshing the page 3 times..");
                await p.ReloadAsync();
                await Task.Delay(10000);
                await p.ReloadAsync();
                await Task.Delay(10000);
                await p.ReloadAsync();
                await Task.Delay(10000);
                Notifier.Log($"Refreshing completed, i hope it works :)");
                break;
            }
            last = timeLeft;
        } while (true);
    }

    private async Task WriteReview()
    {
        if (!await Exist($"//div[@id='adbl-library-content-row-{_input.Asin}']")) throw new KnownException($"{_input.MailAccountAudible} Failed to lookup the book");
        if (await Exist($"//div[@id='adbl-library-content-row-{_input.Asin}']//a[text()='Edit review']", 500, true))
        {
            Notifier.Display($"{_input.MailAccountAudible} already reviewed");
            return;
        }

        var reviewLinkS = $"//div[@id='adbl-library-content-row-{_input.Asin}']//a[contains(@href,'/write-review?')]";
        if (!await Exist(reviewLinkS)) throw new KnownException($"{_input.MailAccountAudible} Review link not present , probably we need to listen to audio first!");
        var reviewLink = await p.Locator(reviewLinkS).GetAttributeAsync("href");
        if (string.IsNullOrEmpty(reviewLink)) throw new KnownException($"{_input.MailAccountAudible} Review link not present , probably we need to listen to audio first!");
        Notifier.Display($"{_input.MailAccountAudible} start review the book");
        await p.GotoAsync(BaseUrl() + reviewLink, new PageGotoOptions());
        if (await Exist("(//div[@class='bc-rating-stars '])[2]//span[@data-index='2' and @aria-checked='true']"))
        {
            Notifier.Display($"{_input.MailAccountAudible} already reviewed");
            return;
        }

        var r1 = GetRate();
        var r2 = GetRate();
        await Click($"(//div[@class='bc-rating-stars '])[2]//span[@data-index='{r1}']");
        await Click($"(//div[@class='bc-rating-stars '])[3]//span[@data-index='{r2}']");
        await Fill("#review-title", _input.TitleReview);
        await Fill("#review-body", _input.TextReview);
        await Click("#preview-button");
        await Click("//span[@id='submit-review-button']");
        await Click("//span[@id='confirmReviewSuccess']");
        Notifier.Display($"{_input.MailAccountAudible} review succeed");
    }

    public async Task<bool> TestWork()
    {
        var t = _random.Next(0, 2);
        Notifier.Log($"{_input.MailAccountAudible} Start working");
        await Task.Delay(3000);
        if (t == 0)
        {
            _input.Result = "success";
            Notifier.Log($"{_input.MailAccountAudible} success");
            _input.Message = DateTime.Now.ToString("G");
        }
        else
        {
            Notifier.Error($"{_input.MailAccountAudible} failed");
            _input.Result = "failed";
            _input.Message = "test";
        }

        return t == 0;
    }

    private Random _rnd = new Random();

    private async Task<Address> GetAddress(string link)
    {
        var html = await _client.GetStringAsync(link.Contains(".co.uk") ? "https://www.fakexy.com/fake-address-generator-uk" : "https://www.fakexy.com/");
        var doc = new HtmlAgilityPack.HtmlDocument();
        doc.LoadHtml(html);
        var street = doc.DocumentNode.SelectSingleNode("//td[text()='Street']/following-sibling::*").InnerText;
        var city = doc.DocumentNode.SelectSingleNode("//td[text()='City/Town']/following-sibling::*").InnerText;
        var state = doc.DocumentNode.SelectSingleNode("//td[text()='State/Province/Region']/following-sibling::*")?.InnerText ?? "";
        var zip = doc.DocumentNode.SelectSingleNode("//td[text()='Zip/Postal Code']/following-sibling::*").InnerText;
        var phone = doc.DocumentNode.SelectSingleNode("//td[text()='Phone Number']/following-sibling::*").InnerText;
        return new Address()
        {
            City = city,
            State = state,
            Phone = phone,
            Street = street,
            Zip = zip
        };
    }

    public async Task<bool> Work()
    {
        //if (_input.MailAccountAudible != "BarbaraAWarkentin@thxcompany.com") return false;
        if (_config.Test)
        {
            Notifier.Log($"{_input.MailAccountAudible} start working");
            await Task.Delay(1000);
            var t = _rnd.Next(0, 2);
            _input.Result = (t == 0 ? "success" : "failed");
            Notifier.Log($"{(t == 0 ? "success" : "failed")}");
            return t == 0;
        }

        try
        {
            // await StartContext(_browser, _input.Proxy);
            await StartBrowser("temp",Debugger.IsAttached ? 9288 : int.Parse(await File.ReadAllTextAsync("port.txt")), "https://api.ipify.org?format=json", _input.Proxy, false);
            await p.Context.ClearCookiesAsync();
            //await GetContext(_browser); 

            await VerifyIp();
            await LoginToAmazon();
            // return;
            //await p.ReloadAsync();
            if (string.IsNullOrEmpty(_input.Asin))
            {
                _input.Asin = await Redeem();
            }

            await MarkAsFinish();
            await ListenToBook();
            await Rate();
            if (!string.IsNullOrEmpty(_input.TextReview))
                await WriteReview();
            _input.Result = "success";
            _input.Message = DateTime.Now.ToString("G");
            return true;
        }
        catch (KnownException ex)
        {
            await HandleError(ex.Message);
        }
        catch (Exception ex)
        {
            await HandleError(ex.ToString());
        }
        finally
        {
            if (p != null)
            {
                _playwright.Dispose();
                proc?.Kill(true);
                await Task.Delay(5000);
                //await p.Context.DisposeAsync();
            }
        }

        return false;
    }

    private async Task HandleError(string error)
    {
        Notifier.Error(error);
        _input.Result = "failed";
        _input.Message = DateTime.Now.ToString("G") + " " + error;
        if (p == null) return;
        try
        {
            await p.ScreenshotAsync(new()
            {
                Path = $"{_path}/screenshots/{_input.PromoCode}-error.png",
                FullPage = true
            });
            var html = await p.ContentAsync();
            await p.WaitForLoadStateAsync();
            await File.WriteAllTextAsync($"{_path}/screenshots/{_input.PromoCode}-error.html", html);
        }
        catch (Exception e)
        {
            Notifier.Error($"{_input.MailAccountAudible} Failed to take screenshot or html : " + e.ToString());
        }
    }
}