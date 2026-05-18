using System.Globalization;

namespace Simulantara.Converters;

public class ExpToProgressConverter : IValueConverter
{
    public object Convert(object value, Type targetType,
        object parameter, CultureInfo culture)
    {
        if (value is int exp)
        {
            return exp / 100.0;
        }

        return 0;
    }

    public object ConvertBack(object value, Type targetType,
        object parameter, CultureInfo culture)
    {
        return null;
    }
}