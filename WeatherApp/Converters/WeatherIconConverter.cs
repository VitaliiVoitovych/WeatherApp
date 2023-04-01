using System.Globalization;
using WeatherApp.Domain.Models;

namespace WeatherApp.Converters;

public class WeatherIconConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is Weather weather)
        {
            return weather.IsDay == 1 ? $"day{weather.Condition.IconCode}.png" : $"night{weather.Condition.IconCode}.png";
        }
        return "day1000.png";
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
