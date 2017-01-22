using ParkInspect.ViewModel;
using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Windows.Data;

namespace ParkInspect.Converter
{
    public class FilterTimeLineItemConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var subjects = (ObservableCollection<TimeLineItemViewModel>)values[0];
            var query = values[1]?.ToString() ?? "";

            return subjects.Where(t => t.Employee.DismissalDate == null && (t.Employee.Name.ToLower().Contains(query.ToLower()) || t.Employee.Function.ToLower().Contains(query.ToLower()) || t.Employee.Email.ToLower().Contains(query.ToLower()) || t.Employee.Region.ToLower().Contains(query.ToLower()) || t.Employee.Id.ToString().ToLower().Contains(query.ToLower()))).ToList();
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            //Kan beter met unset value maar werkt niet met array
            throw new NotImplementedException();
        }
    }
}