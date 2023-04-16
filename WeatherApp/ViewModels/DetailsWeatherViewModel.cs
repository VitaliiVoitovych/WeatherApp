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
    async Task SetMainCity()
    {
        if (string.Equals(_settings.Settings.MainCity, CurrentWeather.Location.Name, StringComparison.OrdinalIgnoreCase))
        {
            await Shell.Current.DisplayAlert("", "This city is already set on the home page", "Ok");
            return;
        }
        _settings.Settings.MainCity = CurrentWeather.Location.Name;
        _settings.Save();
        await Shell.Current.DisplayAlert("", "The city is seted. Click the reload button on the home page", "Ok");
    }
}
