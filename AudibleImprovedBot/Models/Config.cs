namespace AudibleImprovedBot.Models;

public class Config
{
    public string InputFolder { get; set; }
    public string TwoCaptchaKey { get; set; }
    public bool DoRunAt { get; set; }
    public DateTime RunAt { get; set; }
    public bool DoLimitRedeem { get; set; }
    public int TargetSuccessPerFile { get; set; }
    public int Delay { get; set; }
    public int Stars { get; set; }
    public int HoursBetweenFiles { get; set; }
    public int MaxThreads { get; set; }

    public bool DoLoop { get; set; }
    public bool DoLoopFiles { get; set; }
    public bool SkipFailedEntries { get; set; }
    public bool Test { get; set; }
    public bool StopListen { get; set; }
    public int ListenDuration { get; set; }
}