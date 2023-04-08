using WeatherApp.Domain.Models;

namespace WeatherApp.Services;

public interface IWeatherService
{
    Task<CurrentWeather> GetCurrentWeatherAsync(string cityName);

    IAsyncEnumerable<Hour> Get24HoursWeatherAsync(string cityName);

    IAsyncEnumerable<ForecastDay> GetForecastWeather(string cityName);

    IAsyncEnumerable<CurrentWeather> GetCitiesWeatherAsync(IEnumerable<string> citiNames);
}
