using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using System.Diagnostics;
using WeatherApp.Domain.Models;
using WeatherApp.Services;

namespace WeatherApp.ViewModels;

public class FavouritesViewModel : ObservableObject
{
    private readonly IWeatherService _service;

    private readonly string[] _cities = { "Lviv", "Kiev", "Warszawa" };

    public ObservableCollection<CurrentWeather> FavouriteWeather { get; } = new();

    public FavouritesViewModel(IWeatherService service)
    {
        _service = service;

        Task.Run(AddCitiesWeather);
    }

    private async Task AddCitiesWeather()
    {
        await foreach (var cityWeather in GetWeathersAsync())
        {
            FavouriteWeather.Add(cityWeather);
        }
    }

    private async IAsyncEnumerable<CurrentWeather> GetWeathersAsync()
    {
        foreach (var city in _cities)
        {
            await Task.Delay(30);   
            yield return await _service.GetCurrentWeatherAsync(city);
        }
    }
}
