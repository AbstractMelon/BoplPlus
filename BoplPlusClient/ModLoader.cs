/*
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using BepInEx;
using UnityEngine;

public class ModLoader : MonoBehaviour
{
    private Dictionary<string, bool> modStatus; // Dictionary to track mod status (enabled/disabled)

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

        modStatus = new Dictionary<string, bool>();

        // Load mods from all mod directories
        LoadModsFromDirectory("mods/BepInEx/plugins");
        LoadModsFromDirectory("mods/BoplPlus/mods");
        LoadUserMods();
    }

    void LoadModsFromDirectory(string directoryPath)
    {
        if (Directory.Exists(directoryPath))
        {
            string[] modFiles = Directory.GetFiles(directoryPath, "*.dll");
            foreach (string modFile in modFiles)
            {
                try
                {
                    Assembly assembly = Assembly.LoadFile(Path.GetFullPath(modFile));
                    Type modType = assembly.GetTypes().FirstOrDefault(t => typeof(BaseUnityPlugin).IsAssignableFrom(t));
                    if (modType != null)
                    {
                        // Instantiate the mod and add it to the game
                        MonoBehaviour modInstance = gameObject.AddComponent(modType) as MonoBehaviour;
                        modInstance.enabled = false; // Disable the mod by default
                        modStatus.Add(Path.GetFileNameWithoutExtension(modFile), false);
                    }
                }
                catch (Exception e)
                {
                    Logger.Log($"Failed to load mod from file {modFile}: {e.Message}");
                }
            }
        }
    }

    void LoadUserMods()
    {
        LoadModsFromDirectory("mods/user_mods");
    }

    public void EnableMod(string modName)
    {
        if (modStatus.ContainsKey(modName))
        {
            modStatus[modName] = true;
            MonoBehaviour modInstance = gameObject.GetComponent(modName) as MonoBehaviour;
            if (modInstance != null)
            {
                modInstance.enabled = true;
            }
        }
    }

    public void DisableMod(string modName)
    {
        if (modStatus.ContainsKey(modName))
        {
            modStatus[modName] = false;
            MonoBehaviour modInstance = gameObject.GetComponent(modName) as MonoBehaviour;
            if (modInstance != null)
            {
                modInstance.enabled = false;
            }
        }
    }

    public Dictionary<string, bool> GetModStatus()
    {
        return modStatus;
    }
}
*/