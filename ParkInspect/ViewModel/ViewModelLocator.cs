using Data;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using ParkInspect.Repositories;
using ParkInspect.Service;
using ParkInspect.View;

namespace ParkInspect.ViewModel
{

    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            //services
            SimpleIoc.Default.Register<IRouterService, RouterService>();
            SimpleIoc.Default.Register<IAuthService, AuthService>();
            //authe
            //database context
            SimpleIoc.Default.Register<ParkInspectEntities>();
            //repositories
            SimpleIoc.Default.Register<IEmployeeRepository, DummyEmployeesRepository>();
            SimpleIoc.Default.Register<ICommissionRepository, DummyCommissionRepository>();
            SimpleIoc.Default.Register<IManagementRapportenRepository, ManagementRapportenRepository>();
            SimpleIoc.Default.Register<IAuthenticationRepository, DummyAuthenticationRepository>();
            SimpleIoc.Default.Register<ITaskRepository, DummyTaskRepository>();
            SimpleIoc.Default.Register<ICustomerRepository, DummyCustomersRepository>();
            SimpleIoc.Default.Register<ITemplateRepository, DummyTemplateRepository>();
            SimpleIoc.Default.Register<IQuestionRepository, DummyQuestionRepository>();
            SimpleIoc.Default.Register<IQuestionListRepository, DummyQuestionListRepository>();
            SimpleIoc.Default.Register<IInspectionsRepository, DummyInspectionsRepository>();

            //viewmodels
            SimpleIoc.Default.Register<AddCommissionViewModel>();
            SimpleIoc.Default.Register<CommissionOverviewViewModel>();
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<AddCommissionViewModel>();
            SimpleIoc.Default.Register<CommissionOverviewViewModel>();
            SimpleIoc.Default.Register<EmployeesViewModel>();
            SimpleIoc.Default.Register<ManagementRapportenViewModel>();
            SimpleIoc.Default.Register<AuthenticationViewModel>();
            SimpleIoc.Default.Register<CustomersViewModel>();
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
        public ManagementRapportenViewModel Management => ServiceLocator.Current.GetInstance<ManagementRapportenViewModel>();
   	    public EmployeesViewModel Employees => ServiceLocator.Current.GetInstance<EmployeesViewModel>();
        public QuestionsViewModel Questions => ServiceLocator.Current.GetInstance<QuestionsViewModel>();
        public TemplatesViewModel Templates => ServiceLocator.Current.GetInstance<TemplatesViewModel>();
        public QuestionListsviewModel QuestionLists => ServiceLocator.Current.GetInstance<QuestionListsviewModel>();
        public EditEmployeeViewModel EditEmployee => new EditEmployeeViewModel(ServiceLocator.Current.GetInstance<IEmployeeRepository>(), RouterService, Employees);
        public AddEmployeeViewModel AddEmployee => new AddEmployeeViewModel(ServiceLocator.Current.GetInstance<IEmployeeRepository>(), RouterService, Employees);
        public AuthenticationViewModel Authentication => ServiceLocator.Current.GetInstance<AuthenticationViewModel>();
        public CustomersViewModel Customers => ServiceLocator.Current.GetInstance<CustomersViewModel>();
        public AddCustomerViewModel AddCustomer => new AddCustomerViewModel(ServiceLocator.Current.GetInstance<ICustomerRepository>(), RouterService, Customers);
        public CommissionOverviewViewModel Commissions => ServiceLocator.Current.GetInstance<CommissionOverviewViewModel>();
        public AddCommissionViewModel AddCommission => new AddCommissionViewModel(ServiceLocator.Current.GetInstance<ICommissionRepository>(), RouterService, Commissions);
        public InspectionsViewModel Inspections => ServiceLocator.Current.GetInstance<InspectionsViewModel>();
        public AddInspectionViewModel AddInspection => new AddInspectionViewModel();
        public TimeLineViewModel TimeLine => ServiceLocator.Current.GetInstance<TimeLineViewModel>();
        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}
