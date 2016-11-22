using ParkInspect.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Documents;

namespace ParkInspect.Converter
{
    public class FilterCustomerConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var subjects = (ObservableCollection<CustomerViewModel>)values[0];
            var query = values[1]?.ToString() ?? "";
            return subjects.Where(e => e.Name.Contains(query) || e.Email.Contains(query) || e.ZipCode.Contains(query) || e.StreetNumber.Contains(query) || e.PhoneNumber.Contains(query) || e.Id.ToString().Contains(query)).ToList();
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
