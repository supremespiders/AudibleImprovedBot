using Microsoft.Playwright;

namespace AudibleImprovedBot.Services;

public static class GlobalUtility
{
    private static readonly SemaphoreSlim SemaphoreSlim= new SemaphoreSlim(1, 1);
    private static DateTime LastSessionSavedAt;

    public static async Task SaveSession(this IPage p)
    {
        await SemaphoreSlim.WaitAsync();
        try
        {
            if ((DateTime.Now - LastSessionSavedAt).TotalSeconds < 60) return;
            Notifier.Log("Session saved");
            await p.Context.StorageStateAsync(new()
            {
                Path = "state.json"
            });
            LastSessionSavedAt=DateTime.Now;
        }
        finally
        {
            SemaphoreSlim.Release();
        }
    }
}