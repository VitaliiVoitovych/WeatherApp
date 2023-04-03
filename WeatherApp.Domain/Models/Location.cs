using System.Text.Json.Serialization;
using WeatherApp.Domain.Converters;

namespace WeatherApp.Domain.Models;

public class Location
{
    public required string Name { get; set; }

    public required string Region { get; set; }

    public required string Country { get; set; }

    public required string LocalTime { get; set; }
}
