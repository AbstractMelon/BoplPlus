using System;
using System.IO;
using System.Xml.Linq;

public class Config
{
    private static readonly string configFilePath = "config.xml";

    // Define your configuration properties here
    public static string ModDirectory { get; private set; }
    public static bool EnableLogging { get; private set; }

    static Config()
    {
        LoadConfig();
    }

    private static void LoadConfig()
    {
        try
        {
            if (File.Exists(configFilePath))
            {
                XDocument doc = XDocument.Load(configFilePath);

                // Parse configuration settings from XML
                ModDirectory = doc.Root.Element("ModDirectory").Value;
                EnableLogging = bool.Parse(doc.Root.Element("EnableLogging").Value);
            }
            else
            {
                // Default configuration settings
                ModDirectory = "Mods";
                EnableLogging = true;

                // Create a new config file with default settings
                CreateDefaultConfig();
            }
        }
        catch (Exception ex)
        {
            // Log any errors while loading config
            Logger.Log("Failed to load config: " + ex.Message);
        }
    }

    private static void CreateDefaultConfig()
    {
        try
        {
            XDocument doc = new XDocument(
                new XElement("Config",
                    new XElement("ModDirectory", "Mods"),
                    new XElement("EnableLogging", "true")
                )
            );

            doc.Save(configFilePath);
        }
        catch (Exception ex)
        {
            Logger.Log("Failed to create default config file: " + ex.Message);
        }
    }
}
