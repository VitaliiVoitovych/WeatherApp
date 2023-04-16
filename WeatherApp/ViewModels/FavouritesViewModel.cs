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
    private readonly SettingsService _settings;

    public ObservableCollection<CurrentWeather> FavouriteWeather { get; } = new();

    public FavouritesViewModel(IWeatherService service, SettingsService settings)
    {
        _service = service;
        _settings = settings;

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
    private async Task AddFavouriteCity(Entry entry)
    {
        var cityName = entry.Text;
        if (string.IsNullOrWhiteSpace(cityName) || 
            _settings.Settings.FavouriteCities.Contains(cityName)) return;

        try
        {
            var weather = await _service.GetCurrentWeatherAsync(cityName);

            _settings.Settings.FavouriteCities.Add(cityName);
            FavouriteWeather.Add(weather);
            _settings.Save();
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Error", ex.Message, "Oh");
        }
    }

    [RelayCommand]
    private void Remove(CurrentWeather cityWeather)
    {
        _settings.Settings.FavouriteCities.Remove(cityWeather.Location.Name);
        FavouriteWeather.Remove(cityWeather);
        _settings.Save();
    }

    private async Task AddCitiesWeather()
    {
        if (_settings.Settings.FavouriteCities.Count == 0) return;
        // TODO : Fix this
        await foreach (var cityWeather in _service.GetCitiesWeatherAsync(_settings.Settings.FavouriteCities))
        {
            FavouriteWeather.Add(cityWeather);
        }
    }
}
