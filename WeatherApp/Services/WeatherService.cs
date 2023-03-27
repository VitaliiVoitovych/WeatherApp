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
    public async Task<CurrentWeather> GetCurrentWeatherAsync(string city)
    {
        return await _httpClient.GetFromJsonAsync<CurrentWeather>($"https://api.weatherapi.com/v1/current.json?key={apiKey}&q={city}");
    }

    public async Task<List<Hour>> Get24HoursWeatherAsync(string city)
    {
        return (await _httpClient.GetFromJsonAsync<ForecastWeather>($"https://api.weatherapi.com/v1/forecast.json?key={apiKey}&q={city}&days=2")).Forecast.ForecastDays.SelectMany(f => f.Hours).Where(f => f.Time >= DateTime.Now && f.Time < DateTime.Now.AddHours(24)).ToList();
    }

    public async Task<List<ForecastDay>> GetForecastWeather(string city)
    {
        return (await _httpClient.GetFromJsonAsync<ForecastWeather>($"https://api.weatherapi.com/v1/forecast.json?key={apiKey}&q={city}&days=3")).Forecast.ForecastDays;
    }
}
