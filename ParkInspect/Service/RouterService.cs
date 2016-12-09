using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using ParkInspect.View;

namespace ParkInspect.Service
{
    public class RouterService : ViewModelBase, IRouterService
    {

        private readonly Stack<UserControl> _previousViews;
        private readonly IDictionary<string, Type> _views;
        private UserControl _currentView;

        public UserControl CurrentView
        {
            get { return _currentView; }
            set { _currentView = value; RaisePropertyChanged(); }
        }

        public ICommand RouteCommand { get; set; }

        public ICommand RouteBackCommand { get; set; }

        public RouterService()
        {
            RouteCommand = new RelayCommand<string>(SetView);
            RouteBackCommand = new RelayCommand(SetPreviousView);
            _views = new Dictionary<string, Type>
            {
                { "employees-list", typeof(EmployeesView) },
                { "dashboard-inspecteur", typeof(MainMenuInspecteurView) },
                { "employees-add", typeof(AddEmployeeView) },
                { "employees-edit", typeof(EditEmployeeView) },
                { "management-view", typeof(ManagementView) },
                { "authentication", typeof(AuthView) },
                { "questions-list", typeof(QuestionsView) },
                { "templates-list", typeof(TemplatesView) },
                { "customers-list", typeof(CustomersView) },
                { "customers-add", typeof(AddCustomerView) },
                { "customers-edit", typeof(EditCustomerView) },
                { "commissions-add", typeof(AddCommission) },
                { "commissions-overview", typeof(CommissionOverview) },
                { "dashboard-manager", typeof(DashboardManagerView) },
                { "inspections-list", typeof(InspectionsView) },
                { "inspections-add" , typeof(AddInspectionView)},
                { "timeline", typeof(TimeLineView) }
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
            CurrentView = (UserControl)Activator.CreateInstance(_views[viewName]);
        }

        public void SetPreviousView()
        {
            if (!(_previousViews?.Count > 0)) return;
            CurrentView = _previousViews.Pop();
        }

        public void ClearPreviousStack()
        {
            _previousViews.Clear();
        }

        private class ViewNotRegisteredException : Exception
        {
        }
    }
}
