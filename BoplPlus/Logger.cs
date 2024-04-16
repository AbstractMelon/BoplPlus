using System;

public static class PlusLogger
{
    public static void Log(string message)
    {
        Console.WriteLine("[BoplPlus] " + message);
    }

    public static void LogError(string errorMessage)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("[BoplPlus - ERROR] " + errorMessage);
        Console.ResetColor();
    }

    public static void LogWarning(string warningMessage)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("[BoplPlus - WARNING] " + warningMessage);
        Console.ResetColor();
    }
}