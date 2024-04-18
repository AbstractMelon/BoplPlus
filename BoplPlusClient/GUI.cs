/*
using UnityEngine;
using System.Collections.Generic;

public class GUI : MonoBehaviour
{
    private ModLoader modLoader;

    void Start()
    {
        modLoader = FindObjectOfType<ModLoader>();
    }

    void OnGUI()
    {
        GUILayout.BeginArea(new Rect(10, 10, 200, 300));

        GUILayout.Label("Enabled Mods:");

        Dictionary<string, bool> modStatus = modLoader.GetModStatus();
        foreach (KeyValuePair<string, bool> modEntry in modStatus)
        {
            GUILayout.BeginHorizontal();
            GUILayout.Label(modEntry.Key);
            bool isEnabled = GUILayout.Toggle(modEntry.Value, "Enabled");
            if (isEnabled != modEntry.Value)
            {
                if (isEnabled)
                {
                    modLoader.EnableMod(modEntry.Key);
                }
                else
                {
                    modLoader.DisableMod(modEntry.Key);
                }
            }
            GUILayout.EndHorizontal();
        }

        GUILayout.EndArea();
    }
}
*/

