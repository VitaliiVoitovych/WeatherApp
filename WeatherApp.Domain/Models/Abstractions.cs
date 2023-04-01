using System.Text.Json.Serialization;

namespace WeatherApp.Domain.Models;

public abstract class Weather
{
    [JsonPropertyName("temp_c")]
    public double Temp { get; set; }

    [JsonPropertyName("is_day")]
    public int IsDay { get; set; }

    public required Condition Condition { get; set; }
}
