using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Documents;
using ParkInspect.ViewModel;

namespace ParkInspect.Converter
{
    public class FilterEmployeeConverter : IMultiValueConverter
    {

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var subjects = (ObservableCollection<EmployeeViewModel>) values[0];
            var query = values[1]?.ToString() ?? "";
            
            return subjects.Where(e => e.DismissalDate == null && (e.Name.Contains(query) || e.Function.Contains(query) || e.Email.Contains(query) || e.Region.Contains(query) || e.Id.ToString().Contains(query))).ToList();
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
