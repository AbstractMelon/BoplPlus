using HarmonyLib;
using System;
using System.IO;

public class ModLoader
{
    public static void Initialize()
    {
        // Initialize Doorstop
        InitializeDoorstop();

        // Initialize HarmonyX
        Harmony harmony = new Harmony("com.BoplPlus.BoplPlus");
        harmony.PatchAll();

        // Load mods
        LoadMods();
    }

    private static void InitializeDoorstop()
    {
        // Path to the Doorstop DLL
        string doorstopPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "winhttp.dll");

        // Check if Doorstop DLL exists
        if (!File.Exists(doorstopPath))
        {
            Logger.Log("winhttp.dll not found.");
            return;
        }

        // Load Doorstop
        try
        {
            // Load Doorstop DLL
            System.Reflection.Assembly.LoadFrom(doorstopPath);

            // Get the Doorstop entry point method
            var doorstopType = Type.GetType("Doorstop.EntryPoint, Doorstop", throwOnError: true);
            var initMethod = doorstopType.GetMethod("Initialize", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public);

            // Call Doorstop's Initialize method
            initMethod.Invoke(null, null);
        }
        catch (Exception ex)
        {
            Logger.Log("Failed to initialize Doorstop: " + ex.Message);
        }
    }

    private static void LoadMods()
    {
        string modsDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Mods");
        if (!Directory.Exists(modsDirectory))
        {
            Logger.Log("Mods directory not found.");
            return;
        }

        string[] modFiles = Directory.GetFiles(modsDirectory, "*.dll");
        foreach (string modFile in modFiles)
        {
            // Load each mod assembly using Doorstop
            LoadMod(modFile);
        }
    }

    private static void LoadMod(string modFile)
    {
        try
        {
            // Load the mod assembly
            System.Reflection.Assembly.LoadFrom(modFile);
            Logger.Log($"Loaded mod: {Path.GetFileName(modFile)}");
        }
        catch (Exception ex)
        {
            Logger.Log($"Failed to load mod {Path.GetFileName(modFile)}: {ex.Message}");
        }
    }
}

public static class Logger
{
    public static void Log(string message)
    {
        Console.WriteLine("[ModLoader] " + message);
    }
}
