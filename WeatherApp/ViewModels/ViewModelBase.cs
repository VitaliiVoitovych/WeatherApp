using CommunityToolkit.Mvvm.ComponentModel;
using WeatherApp.Services;

namespace WeatherApp.ViewModels;

public class ViewModelBase : ObservableObject
{
    public Settings Settings { get; set; } = new();

    public SettingsService SettingsService { get; set; } = new();
}
