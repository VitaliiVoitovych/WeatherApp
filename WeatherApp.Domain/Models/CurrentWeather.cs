using System.Text.Json.Serialization;

namespace WeatherApp.Domain.Models;

public class CurrentWeather
{
    public required Location Location { get; set; }

    public required Current Current { get; set; }

}

public class Current
{
    [JsonPropertyName("temp_c")]
    public double Temp { get; set; }

    [JsonPropertyName("feelslike_c")]
    public double Feelslike { get; set; }

    [JsonPropertyName("wind_kph")]
    public double Wind { get; set; }

    [JsonPropertyName("wind_dir")]
    public required string WindDirection { get; set; }

    [JsonPropertyName("wind_degree")]
    public double WindDegree { get; set; }

    [JsonPropertyName("precip_mm")]
    public double Precipitation { get; set; }

    [JsonPropertyName("pressure_mb")]
    public double Pressure { get; set; }

    [JsonPropertyName("is_day")]
    public int IsDay { get; set; }
    public int Humidity { get; set; }

    public int Cloud { get; set; }

    public required Condition Condition { get; set; }
}

public class Condition
{
    public required string Text { get; set; }
    [JsonPropertyName("code")]
    public int IconCode { get; set; }
}