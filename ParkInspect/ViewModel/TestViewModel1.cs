using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ParkInspect.ViewModel
{
    public class TestViewModel1 : ViewModelBase
    {

        public ICommand ToggleScreenCommand { get; set; }
        private MainViewModel mvm;
        public TestViewModel1(MainViewModel mvm)
        {
            this.mvm = mvm;
            ToggleScreenCommand = new RelayCommand(ToggleScreen);
        }

        public void ToggleScreen()
        {
            mvm.ToggleScreen();
        }

    }
}
