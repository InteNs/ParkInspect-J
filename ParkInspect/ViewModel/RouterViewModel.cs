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

        private Stack<UserControl> _previousViews;

        public UserControl CurrentView { get; set; }

        public ICommand SetViewCommand { get; set; }

        public ICommand SetPreviousViewCommand { get; set; }

        private IDictionary<string, Type> _views;

        public RouterViewModel()
        {
            SetViewCommand = new RelayCommand<string>(SetView);
            SetPreviousViewCommand = new RelayCommand(SetPreviousView);
            _views = new Dictionary<string, Type>
            {
                { "employees-list", typeof(EmployeesView) },
                { "employees-add", typeof(AddEmployeeView) },
                { "employees-edit", typeof(EditEmployeeView) },
                { "management-view", typeof(ManagementView) }
            };
            _previousViews = new Stack<UserControl>();
        }
        private void SetView(string viewName)
        {
            _previousViews.Push(CurrentView);
            this.CurrentView = (UserControl)Activator.CreateInstance(_views[viewName]);
            RaisePropertyChanged("CurrentView");
        }

        private void SetPreviousView()
        {
            if (!(_previousViews?.Count > 0)) return;
            this.CurrentView = _previousViews.Pop();
            RaisePropertyChanged("CurrentView");
        }
    }
}
