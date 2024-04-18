using System;
using System.IO;
using System.Runtime.InteropServices;

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

class Program
{
    [DllImport("kernel32.dll")]
    private static extern bool AllocConsole();

    [DllImport("kernel32.dll")]
    private static extern bool FreeConsole();

    static void Main(string[] args)
    {
        // Allocate a new console window
        AllocConsole();

        // Redirect console output to a log file
        // Loader.RedirectConsoleOutput();

        // Initialize the mod loader
        Loader.Initialize();

        // Wait for user input to keep the console window open
        Console.WriteLine("Press any key to exit...");

        // Close the console window when done
        FreeConsole();
    }
}