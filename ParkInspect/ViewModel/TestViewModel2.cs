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
    public class TestViewModel2 : ViewModelBase
    {

        public MainViewModel mvm { get; set; }
        public TestViewModel2(MainViewModel mvm)
        {
            this.mvm = mvm;
        }

    }
}
