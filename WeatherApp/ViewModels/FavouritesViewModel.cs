using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using WeatherApp.Domain.Models;
using WeatherApp.Pages;
using WeatherApp.Services;

namespace WeatherApp.ViewModels;

public partial class FavouritesViewModel : ObservableObject
{
    private readonly IWeatherService _service;

    Settings setting = new();
    SettingsService settingsService = new();

    public ObservableCollection<CurrentWeather> FavouriteWeather { get; } = new();

    public FavouritesViewModel(IWeatherService service)
    {
        _service = service;
        
        Task.Run(AddCitiesWeather);
    }

    [RelayCommand]
    async Task GoToDetailsWeather(CurrentWeather currentWeather)
    {
        if (currentWeather is null) return;

        await Shell.Current.GoToAsync($"{nameof(DetailsWeatherPage)}?id={currentWeather.Location.Name}", true,
            new Dictionary<string, object>
            {
                {"CurrentWeather", currentWeather}
            });
    }

    [RelayCommand]
    async Task AddFavouriteCity(Entry entry)
    {
        var cityName = entry.Text;
        if (string.IsNullOrWhiteSpace(cityName) || setting.FavouriteCities.Contains(cityName)) return;

        setting.FavouriteCities.Add(cityName);
        var weather = await _service.GetCurrentWeatherAsync(cityName);
        FavouriteWeather.Add(weather);
    }

    private async Task AddCitiesWeather()
    {
        if (setting.FavouriteCities.Count == 0) return;
        // TODO : Fix this
        await foreach (var cityWeather in _service.GetCitiesWeatherAsync(setting.FavouriteCities))
        {
            FavouriteWeather.Add(cityWeather);
        }
    }
}
