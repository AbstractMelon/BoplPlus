using System;
using System.IO;

public static class Logger
{
    private static readonly string LogFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "console.log");

    public static void Log(string message)
    {
        // Log to console
        Console.WriteLine("[BoplPlus] " + message);

        // Log to file
        LogToFile(message);
    }

    private static void LogToFile(string message)
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(LogFilePath, true))
            {
                writer.WriteLine("[BoplPlus] " + message);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("[Logger] Failed to log to file: " + ex.Message);
        }
    }
}
