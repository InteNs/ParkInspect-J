using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using ParkInspect.Service;
using ParkInspect.View;

namespace ParkInspect.Service
{
    public class RouterService : ViewModelBase, IRouterService
    {

        private readonly Stack<UserControl> _previousViews;

        public UserControl CurrentView { get; set; }

        public ICommand RouteCommand { get; set; }

        public ICommand RouteBackCommand { get; set; }

        private readonly IDictionary<string, Type> _views;

        public RouterService()
        {
            RouteCommand = new RelayCommand<string>(SetView);
            RouteBackCommand = new RelayCommand(SetPreviousView);
            _views = new Dictionary<string, Type>
            {
                { "employees-list", typeof(EmployeesView) },
                { "employees-add", typeof(AddEmployeeView) },
                { "employees-edit", typeof(EditEmployeeView) },
                { "management-view", typeof(ManagementView) },
                { "authentication", typeof(AuthenticationView) },
                { "questions-list", typeof(QuestionsView) },
                { "templates-list", typeof(TemplatesView) },
                { "Customers-list", typeof(CustomersView) },
                { "Customers-add", typeof(AddCustomerView) },
                { "commissions-add", typeof(AddCommission) },
                { "commissions-overview", typeof(CommissionOverview) },
                { "dashboard-manager", typeof(DashboardManagerView) }
            };
            _previousViews = new Stack<UserControl>();
        }
        public void SetView(string viewName)
        {
            if (!_views.ContainsKey(viewName))
            {
                throw new ViewNotRegisteredException();
            }

            _previousViews?.Push(CurrentView);
            this.CurrentView = (UserControl)Activator.CreateInstance(_views[viewName]);
            RaisePropertyChanged("CurrentView");
        }

        public void SetPreviousView()
        {
            if (!(_previousViews?.Count > 0)) return;
            this.CurrentView = _previousViews.Pop();
            RaisePropertyChanged("CurrentView");
        }

        private class ViewNotRegisteredException : Exception
        {
        }
    }
}
