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
        private bool _isLoggedIn;
        private string _currentDashboard;

        public bool IsLoggedIn
        {
            get { return _isLoggedIn; }
            set { _isLoggedIn = value; RaisePropertyChanged("IsLoggedIn"); }
        }

        public UserControl CurrentView
        {
            get { return _currentView; }
            set { _currentView = value; RaisePropertyChanged(); }
        }

        public string CurrentDashboard
        {
            get { return _currentDashboard; }
            set { _currentDashboard = value; RaisePropertyChanged("CurrentDashboard"); }
        }

        public ICommand RouteCommand { get; set; }

        public ICommand RouteBackCommand { get; set; }

        public RouterService()
        {
            IsLoggedIn = false;
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
                { "questionnaire-start", typeof(AnswerQuestionView) },
                { "inspections-list", typeof(InspectionsView) },
                { "inspections-add" , typeof(AddInspectionView)},
                { "timeline", typeof(TimeLineView) },
                { "question-main", typeof(QuestionControlMainView) },
                { "question-lists", typeof(QuestionListsView) },
                { "question-add", typeof(AddQuestionView) },
                { "question-list", typeof(QuestionListView) },
                { "question-edit", typeof(EditQuestionView) },
                { "questionList-edit", typeof(EditQuestionListView) }
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

            IsLoggedIn = CurrentView.GetType() != typeof(AuthView);
        }

        public void SetPreviousView()
        {
            if (!(_previousViews?.Count > 0)) return;
            CurrentView = _previousViews.Pop();
        }

        public void ClearPreviousStack() => _previousViews.Clear();

        private class ViewNotRegisteredException : Exception
        {
        }
    }
}
