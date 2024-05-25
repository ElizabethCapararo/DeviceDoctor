using DeviceDoctorTerminalSystem.Enumerations;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Data;

namespace DeviceDoctorTerminalSystem.Converters
{
    public class TypographyConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value == null || value is not string stringValue)
            {
                return string.Empty;
            }

            if(parameter == null || parameter is not TypographyFormat format)
            {
                return stringValue;
            }

            return format switch
            {
                TypographyFormat.Uppercase => stringValue.ToUpper(),
                _ => stringValue
            };
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) =>
            Binding.DoNothing;
    }
}
