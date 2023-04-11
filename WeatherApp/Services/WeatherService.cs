using System.Net.Http.Json;
using WeatherApp.Domain.Models;

namespace WeatherApp.Services;

public class WeatherService : IWeatherService
{
    private readonly HttpClient _httpClient;
    private readonly string apiKey = "98ed774aaea5475bbbd175303232202";
    public WeatherService()
    {
#if WINDOWS
        _httpClient = new HttpClient();
#elif ANDROID
        _httpClient = new HttpClient(new Xamarin.Android.Net.AndroidMessageHandler());
#endif
    }
    public async Task<CurrentWeather> GetCurrentWeatherAsync(string cityName)
    {
        return await _httpClient.GetFromJsonAsync<CurrentWeather>($"https://api.weatherapi.com/v1/current.json?key={apiKey}&q={cityName}");
    }

    public async IAsyncEnumerable<Hour> Get24HoursWeatherAsync(string cityName)
    {
        var hours = (await _httpClient.GetFromJsonAsync<ForecastWeather>($"https://api.weatherapi.com/v1/forecast.json?key={apiKey}&q={cityName}&days=2"))
            .Forecast
            .ForecastDays
            .SelectMany(f => f.Hours)
            .Where(f => f.Time >= DateTime.Now && f.Time < DateTime.Now.AddHours(24));
        foreach (var hour in hours)
        {
            yield return hour;
        }
    }

    public async IAsyncEnumerable<ForecastDay> GetForecastWeather(string cityName)
    {
        var days = (await _httpClient.GetFromJsonAsync<ForecastWeather>($"https://api.weatherapi.com/v1/forecast.json?key={apiKey}&q={cityName}&days=3"))
            .Forecast
            .ForecastDays;
        foreach (var day in days)
        {
            yield return day;
        }
    }

    public async IAsyncEnumerable<CurrentWeather> GetCitiesWeatherAsync(IEnumerable<string> cityNames)
    {
        foreach (var cityName in cityNames)
        {
            yield return await GetCurrentWeatherAsync(cityName);
        }
    }
}
