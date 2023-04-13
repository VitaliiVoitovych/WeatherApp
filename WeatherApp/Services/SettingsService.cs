using System.Text.Json;

namespace WeatherApp.Services;

public class Settings
{
    public string MainCity { get; set; } = "London";
    public List<string> FavouriteCities { get; set; } = new();
}

public class SettingsService
{
    public Settings Settings { get; }

    private readonly string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "settings.json");

    public SettingsService()
    {
        Settings = Load();
    }

    public void Save()
    {
        File.WriteAllText(path, JsonSerializer.Serialize(Settings));
    }

    public Settings Load()
    {
        if (File.Exists(path))
        {
            var fileText = File.ReadAllText(path);
            return JsonSerializer.Deserialize<Settings>(fileText);
        }
        else
        {
            var settings = new Settings();
            File.WriteAllText(path, JsonSerializer.Serialize(settings));
            return settings;
        }
    }
}
