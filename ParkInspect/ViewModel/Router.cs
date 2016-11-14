using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;

namespace ParkInspect.ViewModel
{
    public class Router : ViewModelBase
    {
        public ICommand ToggleScreenCommand { get; set; }
        public Router()
        {
            ToggleScreenCommand = new RelayCommand<ViewModelBase>(ToggleScreen);
        }

        public ViewModelBase CurrentView { get; set; }

        public void ToggleScreen(ViewModelBase vmb)
        {
            CurrentView = vmb;
            RaisePropertyChanged("CurrentView");
        }
    }
}
