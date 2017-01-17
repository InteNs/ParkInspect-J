using System;
using Data;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using ParkInspect.Repositories;
using ParkInspect.Repository.Dummy;
using ParkInspect.Repository.Entity;
using ParkInspect.Repository.Interface;
using ParkInspect.Service;

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
            SimpleIoc.Default.Register<ISyncService, SyncService>();

            //database context
            SimpleIoc.Default.Register<ParkInspectEntities>();

            //repositories
            SimpleIoc.Default.Register<IEmployeeRepository, DummyEmployeesRepository>();
            SimpleIoc.Default.Register<ICommissionRepository, DummyCommissionRepository>();
            SimpleIoc.Default.Register<IAuthenticationRepository, DummyAuthenticationRepository>();
            SimpleIoc.Default.Register<IRegionRepository, DummyRegionRepository>();
            SimpleIoc.Default.Register<ICustomerRepository, EntityCustomerRepository>();
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

            SimpleIoc.Default.Register<ManagementReportsViewModel>();
            SimpleIoc.Default.Register<AuthenticationViewModel>();
           
            SimpleIoc.Default.Register<QuestionsViewModel>();
            SimpleIoc.Default.Register<QuestionListsviewModel>();
            SimpleIoc.Default.Register<QuestionListItemsViewModel>();
            SimpleIoc.Default.Register<TemplatesViewModel>();
            SimpleIoc.Default.Register<InspectionsViewModel>();
            SimpleIoc.Default.Register<AddInspectionViewModel>();
            SimpleIoc.Default.Register<TimeLineViewModel>();
            SimpleIoc.Default.Register<EmployeeInspectionsViewModel>();

            SimpleIoc.Default.Register<QuestionControlMainViewModel>();
            SimpleIoc.Default.Register<AddQuestionViewModel>();
            SimpleIoc.Default.Register<EditQuestionViewModel>();

            SimpleIoc.Default.Register<SyncViewModel>();
        }
        //Services
        public IRouterService RouterService => ServiceLocator.Current.GetInstance<IRouterService>();
        public IAuthService AuthService => ServiceLocator.Current.GetInstance<IAuthService>();
        public ISyncService SyncService => ServiceLocator.Current.GetInstance<ISyncService>();
        //viewmodels

        public MainViewModel Main => ServiceLocator.Current.GetInstance<MainViewModel>();

        public EmployeesViewModel Employees => ServiceLocator.Current.GetInstance<EmployeesViewModel>();
        public AddEmployeeViewModel AddEmployee => NewInstance<AddEmployeeViewModel>(ref _addEmployeeKey);
        public EditEmployeeViewModel EditEmployee => NewInstance<EditEmployeeViewModel>(ref _editEmployeeKey);

        public CustomersViewModel Customers => ServiceLocator.Current.GetInstance<CustomersViewModel>();
        public AddCustomerViewModel AddCustomer => NewInstance<AddCustomerViewModel>(ref _addCustomerKey);
        public EditCustomerViewModel EditCustomer => NewInstance<EditCustomerViewModel>(ref _editCustomerKey);

        public ManagementReportsViewModel Management => ServiceLocator.Current.GetInstance<ManagementReportsViewModel>();
        public QuestionsViewModel Questions => ServiceLocator.Current.GetInstance<QuestionsViewModel>();
        public TemplatesViewModel Templates => ServiceLocator.Current.GetInstance<TemplatesViewModel>();
        public QuestionListsviewModel QuestionLists => ServiceLocator.Current.GetInstance<QuestionListsviewModel>();
        public QuestionListItemsViewModel QuestionList => ServiceLocator.Current.GetInstance<QuestionListItemsViewModel>();
        public AuthenticationViewModel Authentication => ServiceLocator.Current.GetInstance<AuthenticationViewModel>();
        public CommissionOverviewViewModel Commissions => ServiceLocator.Current.GetInstance<CommissionOverviewViewModel>();
        public AddCommissionViewModel AddCommission => ServiceLocator.Current.GetInstance<AddCommissionViewModel>();
        public InspectionsViewModel Inspections => ServiceLocator.Current.GetInstance<InspectionsViewModel>();
        public AddInspectionViewModel AddInspection => NewInstance<AddInspectionViewModel>(ref _addInspectionKey);
        public TimeLineViewModel TimeLine => ServiceLocator.Current.GetInstance<TimeLineViewModel>();
        public SyncViewModel Synchronisation => ServiceLocator.Current.GetInstance<SyncViewModel>();
        public EmployeeInspectionsViewModel EmployeeInspections => NewInstance<EmployeeInspectionsViewModel>(ref _addEmployeeInspectionsKey);
        public QuestionControlMainViewModel QuestionMain => ServiceLocator.Current.GetInstance<QuestionControlMainViewModel>();
        public AddQuestionViewModel AddQuestion => ServiceLocator.Current.GetInstance<AddQuestionViewModel>();
        public EditQuestionViewModel EditQuestion => ServiceLocator.Current.GetInstance<EditQuestionViewModel>();
        
        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }

        private string _addEmployeeKey = "1";
        private string _editEmployeeKey = "1";
        private string _addCustomerKey = "1";
        private string _editCustomerKey = "1";
        private string _addInspectionKey = "1";
        private string _addEmployeeInspectionsKey = "1";

        private static T NewInstance<T>(ref string key) where T : class
        {
            var vm = ServiceLocator.Current.GetInstance<T>(key);
            SimpleIoc.Default.Unregister<T>(key);
            key = Guid.NewGuid().ToString();
            return vm;
        }
    }
}
