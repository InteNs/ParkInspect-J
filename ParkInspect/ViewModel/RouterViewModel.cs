using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using ParkInspect.View;

namespace ParkInspect.ViewModel
{
    public class RouterViewModel : ViewModelBase
    {
        public UserControl CurrentView { get; set; }

        public ICommand SetViewCommand { get; set; }

        private IDictionary<string, Type> _views;

        public RouterViewModel()
        {
            SetViewCommand = new RelayCommand<string>(SetView);
            _views = new Dictionary<string, Type>
            {
                { "employees-list", typeof(EmployeesView) },
                { "employees-add", typeof(AddEmployeeView) },
                { "employees-edit", typeof(EditEmployeeView) },
                { "Management-view", typeof(ManagementView) }
            };

        }
        private void SetView(string viewName)
        {
            this.CurrentView = (UserControl)Activator.CreateInstance(_views[viewName]);
            RaisePropertyChanged("CurrentView");
        }
    }
}
