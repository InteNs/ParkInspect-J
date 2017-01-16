using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace ParkInspect.Converter
{
    public class NameToBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string input = value as string;
            if (input.Contains("Inspectie"))
            {
                int colourvalue = int.Parse(input.Split(' ')[0]) % 10;
                return new SolidColorBrush(Color.FromArgb((byte)(50 + colourvalue * 20), 0, (byte)(colourvalue * 25), 240));
            }
            switch (input)
            {
                case "Beschikbaar":
                    return System.Windows.Media.Brushes.PaleGreen;
                case "Weekend":
                    return System.Windows.Media.Brushes.Orange;
                default:
                    return System.Windows.Media.Brushes.Red;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
