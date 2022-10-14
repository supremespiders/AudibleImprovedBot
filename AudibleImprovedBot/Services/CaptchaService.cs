using System.Diagnostics;
using System.Net;
using System.Text;
using AudibleImprovedBot.Extensions;

namespace AudibleImprovedBot.Services;

public static  class CaptchaService
{
    private static readonly HttpClient Client = new HttpClient(new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.All });
    private static readonly string Path = Application.StartupPath;
    public static  string TwoCaptchaKey;
    
    public static async Task<string> SolveCaptcha(string src,string path)
    {
        var f1 = $"{path}-1.gif";
        var f2 = $"{path}-2.gif";
        try
        {
            await Client.DownloadFile(src, f1);
            var p = new Process();
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.CreateNoWindow = true;
            p.EnableRaisingEvents = true;
            var sb = new StringBuilder();
            p.OutputDataReceived += (s, e) => sb.AppendLine(e.Data);
            p.ErrorDataReceived += (s, e) => sb.AppendLine(e.Data);
            p.StartInfo.FileName = $"{Path}/ffmpeg.exe";
            p.StartInfo.Arguments = $"-i \"{f1}\" -r 3 \"{f2}\"";
            p.Start();
            p.BeginOutputReadLine();
            p.BeginErrorReadLine();
            // string output = await p.StandardOutput.ReadToEndAsync();
            await p.WaitForExitAsync();
            if (!File.Exists(f2))
                throw new Exception($"Failed to compress file :\n{sb.ToString()}");

            var fs = await Client.UploadImage("http://2captcha.com/in.php", f2, TwoCaptchaKey);
            var cid = fs.Replace("OK|", "");
            Notifier.Log($"Start solving the captcha :{cid}");
            var solution = "";
            do
            {
                await Task.Delay(5000);
                var resp = await Client.GetHtml($"http://2captcha.com/res.php?key={TwoCaptchaKey}&action=get&id={cid}");
                if (resp.Equals("CAPCHA_NOT_READY"))
                {
                    continue;
                }

                solution = resp.Replace("OK|", "");
                break;
            } while (true);

            Notifier.Log($"Captcha solution : {solution}");
            return solution;
        }
        finally
        {
          if(File.Exists(f1))
              File.Delete(f1);
          if(File.Exists(f2))
              File.Delete(f2);
        }
    }
    
      public static async Task<string> SolveReCaptcha(string key,string pr)
    {
        var proxy =pr.Split(':');
        var ip = proxy[0];
        var port = proxy[1];
        var proxyUser = proxy[2];
        var proxyPass = proxy[3];
        
        var req = await Client.GetHtml($"http://2captcha.com/in.php?key={TwoCaptchaKey}&method=userrecaptcha&googlekey={key}&pageurl=https://cloud-e83ca2.managed-vps.net/spanel/login&proxy={proxyUser}:{proxyPass}@{ip}:{port}");
        var id = req.Replace("OK|", "");
        Notifier.Display($"Solving recaptcha...");
        await Task.Delay(20000);
        do
        {
            var resp = await Client.GetHtml($"http://2captcha.com/res.php?key={TwoCaptchaKey}&action=get&id={id}");
            if (resp.Equals("CAPCHA_NOT_READY"))
            {
                await Task.Delay(5000);
                continue;
            }
            var response = resp.Replace("OK|", "");
            return response;
        } while (true);
    }
}