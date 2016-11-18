
using Data;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using ParkInspect.Repositories;
using ParkInspect.View;

namespace ParkInspect.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            
            // Router
            SimpleIoc.Default.Register<RouterViewModel>();

            // Database Context
            SimpleIoc.Default.Register<ParkInspectEntities>();
            
            // Repositories
            SimpleIoc.Default.Register<ITestItemRepository, DummyTestItemRepository>();
            SimpleIoc.Default.Register<ManagementRapportenRepository, ManagementRapportenRepository>();

            // ViewModels
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<TestViewModel1>();
            SimpleIoc.Default.Register<TestViewModel2>();
            SimpleIoc.Default.Register<ManagementRapportenViewModel>();
        }
        //router
        public RouterViewModel Router => ServiceLocator.Current.GetInstance<RouterViewModel>();
        //viewmodels
        public MainViewModel Main => ServiceLocator.Current.GetInstance<MainViewModel>();
        public TestViewModel1 Test1 => ServiceLocator.Current.GetInstance<TestViewModel1>();
        public TestViewModel2 Test2 => ServiceLocator.Current.GetInstance<TestViewModel2>();
        public ManagementRapportenViewModel ManagementRapporten => ServiceLocator.Current.GetInstance<ManagementRapportenViewModel>();

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}