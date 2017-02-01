using System;
using Data;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using ParkInspect.Repository.Dummy;
using ParkInspect.Repository.Entity;
using ParkInspect.Repository.Interface;
using ParkInspect.Service;

namespace ParkInspect.ViewModel
{

    public class ViewModelLocator
    {
        private string _addEmployeeKey = "1";
        private string _addEmployeeInspectionsKey = "1";
        private string _editEmployeeKey = "1";
        private string _addCustomerKey = "1";
        private string _editCustomerKey = "1";
        private string _addInspectionKey = "1";
        private string _addQuestionKey = "1";
        private string _editQuestionKey = "1";
        private string _editQuestionListKey = "1";
        private string _questionListItemsKey = "1";

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
            SimpleIoc.Default.Register<ICommissionRepository, EntityCommissionRepository>();
            SimpleIoc.Default.Register<IRegionRepository, EntityRegionRepository>();
            SimpleIoc.Default.Register<IEmployeeRepository, EntityEmployeesRepository>();
            SimpleIoc.Default.Register<IAuthenticationRepository, EntityAuthenticationRepository>();
            SimpleIoc.Default.Register<ICustomerRepository, EntityCustomerRepository>();
            SimpleIoc.Default.Register<ITemplateRepository, DummyTemplateRepository>();
            SimpleIoc.Default.Register<IQuestionRepository, EntityQuestionRepository>();
            SimpleIoc.Default.Register<IQuestionListRepository, EntityQuestionListRepository>();
            SimpleIoc.Default.Register<IInspectionsRepository, EntityInspectionsRepository>();

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
            SimpleIoc.Default.Register<EditQuestionListViewModel>();
            
            SimpleIoc.Default.Register<SyncViewModel>();
            SimpleIoc.Default.Register<ReportOverviewViewModel>();
        }
        //Services
        public IAuthService AuthService => ServiceLocator.Current.GetInstance<IAuthService>();
        public IRouterService RouterService => ServiceLocator.Current.GetInstance<IRouterService>();
        public ISyncService SyncService => ServiceLocator.Current.GetInstance<ISyncService>();

        //viewmodels (Alphabetisch op naam)
        public AddCustomerViewModel AddCustomer => NewInstance<AddCustomerViewModel>(ref _addCustomerKey);
        public AddCommissionViewModel AddCommission => ServiceLocator.Current.GetInstance<AddCommissionViewModel>();
        public AddEmployeeViewModel AddEmployee => NewInstance<AddEmployeeViewModel>(ref _addEmployeeKey);
        public AddInspectionViewModel AddInspection => NewInstance<AddInspectionViewModel>(ref _addInspectionKey);
        public AddQuestionViewModel AddQuestion => NewInstance<AddQuestionViewModel>(ref _addQuestionKey);
        public AuthenticationViewModel Authentication => ServiceLocator.Current.GetInstance<AuthenticationViewModel>();
        public CommissionOverviewViewModel Commissions => ServiceLocator.Current.GetInstance<CommissionOverviewViewModel>();
        public CustomersViewModel Customers => ServiceLocator.Current.GetInstance<CustomersViewModel>();
        public EditCustomerViewModel EditCustomer => NewInstance<EditCustomerViewModel>(ref _editCustomerKey);
        public EditEmployeeViewModel EditEmployee => NewInstance<EditEmployeeViewModel>(ref _editEmployeeKey);
        public EditQuestionViewModel EditQuestion => NewInstance<EditQuestionViewModel>(ref _editQuestionKey);
        public EditQuestionListViewModel EditQuestionList => NewInstance<EditQuestionListViewModel>(ref _editQuestionListKey);
        public EmployeeInspectionsViewModel EmployeeInspections => NewInstance<EmployeeInspectionsViewModel>(ref _addEmployeeInspectionsKey);
        public EmployeesViewModel Employees => ServiceLocator.Current.GetInstance<EmployeesViewModel>();
        public InspectionsViewModel Inspections => ServiceLocator.Current.GetInstance<InspectionsViewModel>();
        public MainViewModel Main => ServiceLocator.Current.GetInstance<MainViewModel>();
        public ManagementReportsViewModel Management => ServiceLocator.Current.GetInstance<ManagementReportsViewModel>();
        public ReportOverviewViewModel Portal => ServiceLocator.Current.GetInstance<ReportOverviewViewModel>();
        public QuestionListItemsViewModel QuestionList => NewInstance<QuestionListItemsViewModel>(ref _questionListItemsKey);
        public QuestionListsviewModel QuestionLists => ServiceLocator.Current.GetInstance<QuestionListsviewModel>();
        public QuestionControlMainViewModel QuestionMain => ServiceLocator.Current.GetInstance<QuestionControlMainViewModel>();
        public QuestionsViewModel Questions => ServiceLocator.Current.GetInstance<QuestionsViewModel>();
        public SyncViewModel Synchronisation => ServiceLocator.Current.GetInstance<SyncViewModel>();
        public TemplatesViewModel Templates => ServiceLocator.Current.GetInstance<TemplatesViewModel>();
        public TimeLineViewModel TimeLine => ServiceLocator.Current.GetInstance<TimeLineViewModel>();
        
        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }

        private static T NewInstance<T>(ref string key) where T : class
        {
            var vm = ServiceLocator.Current.GetInstance<T>(key);
            SimpleIoc.Default.Unregister<T>(key);
            key = Guid.NewGuid().ToString();
            return vm;
        }
    }
}
