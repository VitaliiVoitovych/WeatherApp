using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using System.Runtime;
using WeatherApp.Domain.Models;

namespace WeatherApp.Services;

public partial class CurrentWeatherService : ObservableObject
{
    private readonly IWeatherService _service;

    private readonly SettingsService _settings;


    CurrentWeather currentWeather;
    public CurrentWeather CurrentWeather
    {
        get => currentWeather;
        set
        {
            currentWeather = value;
            OnPropertyChanged();
        }
    }

    public ObservableCollection<Hour> Hours { get; } = new();

    public ObservableCollection<ForecastDay> Days { get; } = new();

    public CurrentWeatherService(IWeatherService service, SettingsService settings)
    {
        _service = service;
        _settings = settings;

        Task.Run(GetWeatherAndForecastAsync);
    }

    public async Task RefreshWeather()
    {
        await GetWeatherAndForecastAsync();
    }

    private async Task GetWeatherAndForecastAsync()
    {
        await GetWeatherAsync();
        await Get24HoursAsync();
        await GetDailyForecastAsync();
    }

    private async Task GetWeatherAsync()
    {
        CurrentWeather = await _service.GetCurrentWeatherAsync(_settings.Settings.MainCity);
    }

    private async Task Get24HoursAsync()
    {
        var hours = _service.Get24HoursWeatherAsync(_settings.Settings.MainCity);

        Hours.Clear();
        await foreach (var hour in hours)
        {
            Hours.Add(hour);
        }
    }

    private async Task GetDailyForecastAsync()
    {
        var days = _service.GetForecastWeather(_settings.Settings.MainCity);

        Days.Clear();
        await foreach (var day in days)
        {
            Days.Add(day);
        }
    }
}
