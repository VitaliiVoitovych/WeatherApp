using System.Globalization;

namespace WeatherApp.Converters;

public class PressureConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        var pressure = (double)value;
        return pressure * 0.7501;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
