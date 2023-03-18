using WeatherApp.Domain.Models;
using System.Net.Http.Json;

namespace WeatherApp.Domain.Services;

public class WeatherService : IWeatherService
{
    private readonly HttpClient _httpClient;
    private readonly string apiKey = "98ed774aaea5475bbbd175303232202";

    public WeatherService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    public async Task<Weather?> GetWeatherASync(string city)
    {
        return await _httpClient.GetFromJsonAsync<Weather>($"http://api.weatherapi.com/v1/current.json?key={apiKey}&q={city}\"");
    }
}
