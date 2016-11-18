
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
            SimpleIoc.Default.Register<ITestItemRepository, DummyTestItemRepository>();
            SimpleIoc.Default.Register<IEmployeeRepository, DummyEmployeesRepository>();
            //SimpleIoc.Default.Register<ICustomerRepository, DummyEmployeesRepository>();

            //viewmodels
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<TestViewModel1>();
            SimpleIoc.Default.Register<TestViewModel2>();
            SimpleIoc.Default.Register<EmployeesViewModel>();
            SimpleIoc.Default.Register<CustomersViewModel>();
        }
        //router
        public RouterViewModel Router => ServiceLocator.Current.GetInstance<RouterViewModel>();
        //viewmodels
        public MainViewModel Main => ServiceLocator.Current.GetInstance<MainViewModel>();
        public TestViewModel1 Test1 => ServiceLocator.Current.GetInstance<TestViewModel1>();
        public TestViewModel2 Test2 => ServiceLocator.Current.GetInstance<TestViewModel2>();
   	    public EmployeesViewModel Employees => ServiceLocator.Current.GetInstance<EmployeesViewModel>();
        public CustomersViewModel Customers => ServiceLocator.Current.GetInstance<CustomersViewModel>();


        public EditEmployeeViewModel EditEmployee => new EditEmployeeViewModel(ServiceLocator.Current.GetInstance<IEmployeeRepository>(), Router, Employees);
        public AddEmployeeViewModel AddEmployee => new AddEmployeeViewModel(ServiceLocator.Current.GetInstance<IEmployeeRepository>(), Router, Employees);

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}
