using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Domain.Models;

namespace WeatherApp.Converters;

public class WeatherIconConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        // TODO: Rewrite
        if (value is Current current)
        {
            var isDay = current.IsDay;
            return isDay == 1 ? $"day{current.Condition.IconCode}.png" : $"night{current.Condition.IconCode}.png";
        }
        else if (value is Hour hour)
        {
            var isDay = hour.IsDay;
            return isDay == 1 ? $"day{hour.Condition.IconCode}.png" : $"night{hour.Condition.IconCode}.png";
        }
        return $"day1000.png";
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
