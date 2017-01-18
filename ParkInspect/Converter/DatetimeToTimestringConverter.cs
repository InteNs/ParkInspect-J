using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace ParkInspect.Converter
{
    public class DatetimeToTimestringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            DateTime datetime = (DateTime)value;
            return datetime.ToShortTimeString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //Dit geeft aan dat dit opzettelijk niet gebruikt wordt, ipv notImplemented
            return DependencyProperty.UnsetValue;
        }
    }
}
