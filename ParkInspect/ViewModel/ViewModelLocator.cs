
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
            //router
            SimpleIoc.Default.Register<RouterViewModel>();
            //database context
            SimpleIoc.Default.Register<ParkInspectEntities>();
            //repositories
            SimpleIoc.Default.Register<ITestItemRepository, DummyTestItemRepository>();

            //viewmodels
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<TestViewModel1>();
            SimpleIoc.Default.Register<TestViewModel2>();
        }
        //router
        public RouterViewModel Router => ServiceLocator.Current.GetInstance<RouterViewModel>();
        //viewmodels
        public MainViewModel Main => ServiceLocator.Current.GetInstance<MainViewModel>();
        public TestViewModel1 Test1 => ServiceLocator.Current.GetInstance<TestViewModel1>();
        public TestViewModel2 Test2 => ServiceLocator.Current.GetInstance<TestViewModel2>();
    

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}