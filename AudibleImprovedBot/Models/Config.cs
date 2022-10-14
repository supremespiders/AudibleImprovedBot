namespace AudibleImprovedBot.Models;

public class Config
{
    public string InputFile { get; set; }
    public string TwoCaptchaKey { get; set; }
    public bool DoRunAt { get; set; }
    public DateTime RunAt { get; set; }
    public bool DoLimitRedeem { get; set; }
    public int LimitRedeem { get; set; }
    public int Delay { get; set; }
    public int Stars { get; set; }
    public int HoursBetweenFiles { get; set; }
}