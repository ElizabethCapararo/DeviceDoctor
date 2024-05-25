using DeviceDoctorTerminalSystem.Utilities;
using System.Globalization;
using System.Windows.Data;

namespace DeviceDoctorTerminalSystem.Converters
{
    public class DescriptionConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) => 
            value is Enum enumValue ?
            (object)enumValue.Description() :
            string.Empty;

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) =>
            Binding.DoNothing;
    }
}
