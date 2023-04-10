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

    private readonly string[] _cities = { "Lviv", "Kiev", "Warszawa", "Volia Baranetska", "Sao Sebastiao Da Feira" };

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

    private async Task AddCitiesWeather()
    {
        await foreach (var cityWeather in _service.GetCitiesWeatherAsync(_cities))
        {
            FavouriteWeather.Add(cityWeather);
        }
    }
}
