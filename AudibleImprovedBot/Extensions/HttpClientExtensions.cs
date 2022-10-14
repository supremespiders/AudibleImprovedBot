namespace AudibleImprovedBot.Extensions;

public static class HttpClientExtensions
{
    public static async Task DownloadFile(this HttpClient client,string url,string path)
    {
        var response = await client.GetAsync(url);
        await using var fs = new FileStream(path, FileMode.Create);
        await response.Content.CopyToAsync(fs);
    }
    public static async Task<string> UploadImage(this HttpClient client,string url, string imagePath,string k)
    {
        var bytes = await File.ReadAllBytesAsync(imagePath);
        var content = new MultipartFormDataContent();
        var key = new StringContent(k);
        content.Add(new StreamContent(new MemoryStream(bytes)), "file", "upload.jpg");
        content.Add(key, "key");
        var response = await client.PostAsync(url, content);
        var s = await response.Content.ReadAsStringAsync();
        return s;
    }

    public static async Task<string> GetHtml(this HttpClient client, string url)
    {
        var response = await client.GetAsync(url);
        return  await response.Content.ReadAsStringAsync();
    }

}