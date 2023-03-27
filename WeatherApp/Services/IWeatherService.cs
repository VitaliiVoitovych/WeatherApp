using WeatherApp.Domain.Models;

namespace WeatherApp.Services;

public interface IWeatherService
{
    Task<CurrentWeather> GetCurrentWeatherAsync(string city);

    Task<List<Hour>> Get24HoursWeatherAsync(string city);

    Task<List<ForecastDay>> GetForecastWeather(string city);
}
