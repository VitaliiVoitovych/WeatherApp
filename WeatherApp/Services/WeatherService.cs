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
    public async Task<Weather> GetCurrentWeatherAsync(string city)
    {
        return await _httpClient.GetFromJsonAsync<Weather>($"https://api.weatherapi.com/v1/current.json?key={apiKey}&q={city}");
    }
}
