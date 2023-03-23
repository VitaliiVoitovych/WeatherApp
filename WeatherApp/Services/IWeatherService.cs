using WeatherApp.Domain.Models;

namespace WeatherApp.Services;

public interface IWeatherService
{
    Task<Weather> GetCurrentWeatherAsync(string city);
}
