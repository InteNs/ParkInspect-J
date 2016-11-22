
using Data;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using ParkInspect.Repositories;
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
            //router
            SimpleIoc.Default.Register<RouterViewModel>();
            //database context
            SimpleIoc.Default.Register<ParkInspectEntities>();
            //repositories
            SimpleIoc.Default.Register<IEmployeeRepository, DummyEmployeesRepository>();
            SimpleIoc.Default.Register<ICommissionRepository, DummyCommissionRepository>();
            SimpleIoc.Default.Register<IManagementRapportenRepository, ManagementRapportenRepository>();
            SimpleIoc.Default.Register<IAuthenticationRepository, DummyAuthenticationRepository>();

            //viewmodels
            SimpleIoc.Default.Register<AddCommissionViewModel>();
            SimpleIoc.Default.Register<CommissionOverviewViewModel>();
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<EmployeesViewModel>();
            SimpleIoc.Default.Register<ManagementRapportenViewModel>();
            SimpleIoc.Default.Register<AuthenticationViewModel>();
        }
        //router
        public RouterViewModel Router => ServiceLocator.Current.GetInstance<RouterViewModel>();
        //viewmodels
        public MainViewModel Main => ServiceLocator.Current.GetInstance<MainViewModel>();
        public ManagementRapportenViewModel Management => ServiceLocator.Current.GetInstance<ManagementRapportenViewModel>();
   	    public EmployeesViewModel Employees => ServiceLocator.Current.GetInstance<EmployeesViewModel>(); 


        public EditEmployeeViewModel EditEmployee => new EditEmployeeViewModel(ServiceLocator.Current.GetInstance<IEmployeeRepository>(), Router, Employees);
        public AddEmployeeViewModel AddEmployee => new AddEmployeeViewModel(ServiceLocator.Current.GetInstance<IEmployeeRepository>(), Router, Employees);
        public AuthenticationViewModel Authentication => ServiceLocator.Current.GetInstance<AuthenticationViewModel>();
        public CommissionOverviewViewModel Commissions => ServiceLocator.Current.GetInstance<CommissionOverviewViewModel>();
        public AddCommissionViewModel AddCommission => new AddCommissionViewModel(ServiceLocator.Current.GetInstance<ICommissionRepository>(), Router, Commissions);

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}
