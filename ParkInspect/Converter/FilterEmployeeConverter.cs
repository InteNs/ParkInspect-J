﻿using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Windows.Data;
using ParkInspect.ViewModel;

namespace ParkInspect.Converter
{
    public class FilterEmployeeConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var subjects = (ObservableCollection<EmployeeViewModel>)values[0];
            var query = values[1]?.ToString() ?? "";

            return subjects.Where(e => e.DismissalDate == null && (e.Name.ToLower().Contains(query.ToLower()) || e.Function.ToLower().Contains(query.ToLower()) || e.Email.ToLower().Contains(query.ToLower()) || e.Region.ToLower().Contains(query.ToLower()) || e.Id.ToString().ToLower().Contains(query.ToLower()))).ToList();
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            //Kan beter met unset value maar werkt niet met array
            throw new NotImplementedException();
        }
    }
}
