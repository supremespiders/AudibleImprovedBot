namespace AudibleImprovedBot.Extensions;

public static class Utile
{
    public static string StringBetween(this string main, string s1, string s2)
    {
        if (!main.Contains(s1) || !main.Contains(s2)) return null;
        var x1 = main.IndexOf(s1, StringComparison.Ordinal) + s1.Length;
        var x2 = main.IndexOf(s2, x1 + 1, StringComparison.Ordinal);
        return (main.Substring(x1, x2 - x1));
    }
}