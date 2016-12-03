using System;
using Data;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using ParkInspect.Repositories;
using ParkInspect.Repository;
using ParkInspect.Repository.Dummy;
using ParkInspect.Repository.Interface;
using ParkInspect.Service;
using ParkInspect.View;

namespace ParkInspect.ViewModel
{

    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            //services
            SimpleIoc.Default.Register<IRouterService, RouterService>();
            SimpleIoc.Default.Register<IAuthService, AuthService>();
            
            //database context
            SimpleIoc.Default.Register<ParkInspectEntities>();

            //repositories
            SimpleIoc.Default.Register<IEmployeeRepository, DummyEmployeesRepository>();
            SimpleIoc.Default.Register<ICommissionRepository, DummyCommissionRepository>();
            SimpleIoc.Default.Register<IManagementRapportenRepository, DummyManagementRapportenRepository>();
            SimpleIoc.Default.Register<IAuthenticationRepository, DummyAuthenticationRepository>();
            SimpleIoc.Default.Register<IRegionRepository, DummyRegionRepository>();
            SimpleIoc.Default.Register<ITaskRepository, DummyTaskRepository>();
            SimpleIoc.Default.Register<ICustomerRepository, DummyCustomersRepository>();
            SimpleIoc.Default.Register<ITemplateRepository, DummyTemplateRepository>();
            SimpleIoc.Default.Register<IQuestionRepository, DummyQuestionRepository>();
            SimpleIoc.Default.Register<IQuestionListRepository, DummyQuestionListRepository>();
            SimpleIoc.Default.Register<IInspectionsRepository, DummyInspectionsRepository>();

            //viewmodels
            SimpleIoc.Default.Register<MainViewModel>();

            SimpleIoc.Default.Register<EmployeesViewModel>();
            SimpleIoc.Default.Register<AddEmployeeViewModel>();
            SimpleIoc.Default.Register<EditEmployeeViewModel>();

            SimpleIoc.Default.Register<CustomersViewModel>();
            SimpleIoc.Default.Register<AddCustomerViewModel>();
            SimpleIoc.Default.Register<EditCustomerViewModel>();

            SimpleIoc.Default.Register<AddCommissionViewModel>();
            SimpleIoc.Default.Register<CommissionOverviewViewModel>();
        
            SimpleIoc.Default.Register<AddCommissionViewModel>();
            SimpleIoc.Default.Register<CommissionOverviewViewModel>();

            SimpleIoc.Default.Register<ManagementRapportenViewModel>();
            SimpleIoc.Default.Register<AuthenticationViewModel>();
           
            SimpleIoc.Default.Register<QuestionsViewModel>();
            SimpleIoc.Default.Register<QuestionListsviewModel>();
            SimpleIoc.Default.Register<TemplatesViewModel>();
            SimpleIoc.Default.Register<InspectionsViewModel>();
            SimpleIoc.Default.Register<TimeLineViewModel>();
        }
        //Services
        public IRouterService RouterService => ServiceLocator.Current.GetInstance<IRouterService>();
        public IAuthService AuthService => ServiceLocator.Current.GetInstance<IAuthService>();
        //viewmodels

        public MainViewModel Main => ServiceLocator.Current.GetInstance<MainViewModel>();

        public EmployeesViewModel Employees => ServiceLocator.Current.GetInstance<EmployeesViewModel>();
        public AddEmployeeViewModel AddEmployee => NewInstance<AddEmployeeViewModel>(ref _addEmployeeKey);
        public EditEmployeeViewModel EditEmployee => NewInstance<EditEmployeeViewModel>(ref _editEmployeeKey);

        public CustomersViewModel Customers => ServiceLocator.Current.GetInstance<CustomersViewModel>();
        public AddCustomerViewModel AddCustomer => NewInstance<AddCustomerViewModel>(ref _addCustomerKey);
        public EditCustomerViewModel EditCustomer => NewInstance<EditCustomerViewModel>(ref _editCustomerKey);

        public ManagementRapportenViewModel Management => ServiceLocator.Current.GetInstance<ManagementRapportenViewModel>();
        public QuestionsViewModel Questions => ServiceLocator.Current.GetInstance<QuestionsViewModel>();
        public TemplatesViewModel Templates => ServiceLocator.Current.GetInstance<TemplatesViewModel>();
        public QuestionListsviewModel QuestionLists => ServiceLocator.Current.GetInstance<QuestionListsviewModel>();
        public AuthenticationViewModel Authentication => ServiceLocator.Current.GetInstance<AuthenticationViewModel>();
        public CommissionOverviewViewModel Commissions => ServiceLocator.Current.GetInstance<CommissionOverviewViewModel>();
        public AddCommissionViewModel AddCommission => ServiceLocator.Current.GetInstance<AddCommissionViewModel>();
        public InspectionsViewModel Inspections => ServiceLocator.Current.GetInstance<InspectionsViewModel>();
        public AddInspectionViewModel AddInspection => new AddInspectionViewModel();
        public TimeLineViewModel TimeLine => ServiceLocator.Current.GetInstance<TimeLineViewModel>();

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }

        private string _addEmployeeKey = "1";
        private string _editEmployeeKey = "1";
        private string _addCustomerKey = "1";
        private string _editCustomerKey = "1";

        private static T NewInstance<T>(ref string key) where T : class
        {
            var vm = ServiceLocator.Current.GetInstance<T>(key);
            SimpleIoc.Default.Unregister<T>(key);
            key = Guid.NewGuid().ToString();
            return vm;
        }
    }
}
