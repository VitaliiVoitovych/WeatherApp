using System.Globalization;

namespace WeatherApp.Converters;

public class WindDirectionConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return value switch
        {
            "N" => 0,
            "NNE" => 25,
            "NE" => 45,
            "ENE" => 62,
            "E" => 90,
            "ESE" => 115,
            "SE" => 135,
            "SSE" => 155,
            "S" => 180,
            "SSW" => 205,
            "SW" => 225,
            "WSW" => 245,
            "W" => 270,
            "WNW" => 295,
            "NW" => 317,
            "NNW" => 335,
            _ => 0,
        };
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
