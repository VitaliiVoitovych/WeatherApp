using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WeatherApp.Domain.Models;

namespace WeatherApp.ViewModels;

[QueryProperty("CurrentWeather", "CurrentWeather")]
public partial class DetailsWeatherViewModel : ObservableObject
{
    [ObservableProperty]
    CurrentWeather currentWeather;
    public DetailsWeatherViewModel()
    {
        
    }

    [RelayCommand]
    async Task GoToBack()
    {
        await Shell.Current.GoToAsync("..");
    }
}
