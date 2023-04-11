using System.Text.Json;

namespace WeatherApp.Services;

public class Settings
{
    public string MainCity { get; set; }
    public List<string> FavouriteCities { get; set; } = new();
}

public class SettingsService
{
    public void Save(Settings settings, string fileName)
    {
        File.WriteAllText(fileName, JsonSerializer.Serialize(settings));
    }

    public Settings Load(string fileName)
    {
        if (File.Exists(fileName))
        {
            var fileText = File.ReadAllText(fileName);
            return JsonSerializer.Deserialize<Settings>(fileText);
        }
        else
        {
            File.CreateText(fileName);
            return new Settings();
        }
    }
}
