using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using ParkInspect.Service;

namespace ParkInspect.ViewModel
{
    public class ReportOverviewViewModel:ViewModelBase
    {
        private IAuthService _authService;
        public ICommand DoOpenPortal { get; set; }

        public ReportOverviewViewModel(IAuthService authService)
        {
            _authService = authService;
            DoOpenPortal = new RelayCommand(OpenPortal);
        }

        private void OpenPortal()
        {
            System.Diagnostics.Process.Start("http://parkinspect-j.azurewebsites.net/?token=" + _authService.GetLoggedInUser().EmployeeGuid);
        }
    }
}
