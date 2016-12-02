using System.Windows.Input;
using GalaSoft.MvvmLight;
using ParkInspect.Service;

namespace ParkInspect.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        protected IRouterService RouterService { get; set; }

        public ICommand RouteCommand { get; set; }

        public MainViewModel(IRouterService router = null)
        {
            if (router != null)
            {
                RouterService = router;
                RouteCommand = RouterService.RouteCommand;
            }
        }
    }
}