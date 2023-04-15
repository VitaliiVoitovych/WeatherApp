using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WeatherApp.Domain.Models;
using WeatherApp.Services;

namespace WeatherApp.ViewModels;

[QueryProperty("CurrentWeather", "CurrentWeather")]
public partial class DetailsWeatherViewModel : ObservableObject
{
    [ObservableProperty]
    CurrentWeather currentWeather;

    private readonly SettingsService _settings;
    public DetailsWeatherViewModel(SettingsService settings)
    {
        _settings = settings;
    }

    [RelayCommand]
    async Task GoToBack()
    {
        await Shell.Current.GoToAsync("..");
    }

    [RelayCommand]
    void SetMainCity()
    {
        _settings.Settings.MainCity = CurrentWeather.Location.Name;
        _settings.Save();
    }
}
