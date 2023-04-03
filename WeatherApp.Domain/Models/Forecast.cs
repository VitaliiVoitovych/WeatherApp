using System.Text.Json.Serialization;
using WeatherApp.Domain.Converters;

namespace WeatherApp.Domain.Models;

public class ForecastWeather
{
    public required Forecast Forecast { get; set; }
}

public class Forecast
{
    [JsonPropertyName("forecastday")]
    public required List<ForecastDay> ForecastDays { get; set; }
}

public class ForecastDay
{
    public required string Date { get; set; }

    public required Day Day { get; set; }

    [JsonPropertyName("hour")]
    public required List<Hour> Hours { get; set; }
}

public class Day
{
    public required Condition Condition { get; set; }

    [JsonPropertyName("maxtemp_c")]
    public double MaxTemp { get; set; }

    [JsonPropertyName("mintemp_c")]
    public double MinTemp { get; set; }

    [JsonPropertyName("maxwind_kph")]
    public double MaxWind { get; set; }

    [JsonPropertyName("daily_chance_of_rain")]
    public double ChanceOfRain { get; set; }

}

public class Hour : Weather
{
    [JsonConverter(typeof(JsonDateTimeConverter))]
    public DateTime Time { get; set; }
}
