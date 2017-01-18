using System;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace ParkInspect.Converter
{
    public class NameToBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string input = value as string;
            if (input == null) return DependencyProperty.UnsetValue;
            if (input.Contains("Inspectie"))
            {
                int colourvalue = int.Parse(input.Split(' ')[0]) % 10;
                return new SolidColorBrush(Color.FromArgb((byte)(50 + colourvalue * 20), 0, (byte)(colourvalue * 25), 240));
            }
            switch (input)
            {
                case "Beschikbaar":
                    return Brushes.PaleGreen;
                case "Weekend":
                    return Brushes.Orange;
                default:
                    return Brushes.Red;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            //Dit geeft aan dat dit opzettelijk niet gebruikt wordt, ipv notImplemented
            return DependencyProperty.UnsetValue;
        }
    }
}
