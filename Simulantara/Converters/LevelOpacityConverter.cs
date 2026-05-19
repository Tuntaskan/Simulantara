using System.Globalization;

namespace Simulantara.Converters;

public class LevelOpacityConverter : IMultiValueConverter
{
    public object Convert(
        object[] values,
        Type targetType,
        object parameter,
        CultureInfo culture)
    {
        if (values.Length < 2)
            return 0.4;

        if (values[0] == null || values[1] == null)
            return 0.4;

        int unlockLevel = System.Convert.ToInt32(values[0]);
        int userLevel = System.Convert.ToInt32(values[1]);

        return userLevel >= unlockLevel
            ? 1.0
            : 0.4;
    }

    public object[] ConvertBack(
        object value,
        Type[] targetTypes,
        object parameter,
        CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}