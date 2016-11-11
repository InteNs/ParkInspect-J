using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using ParkInspect.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ParkInspect.ViewModel
{
    public class TestViewModel1 : ViewModelBase
    {
        public MainViewModel mvm { get; set; }
        private ITestItemRepository itir;
        public TestViewModel1(MainViewModel mvm, ITestItemRepository itir)
        {
            this.mvm = mvm;
            this.itir = itir;
            ItemCollection = new ObservableCollection<TestItemViewModel>(itir.GetAll());
        }

        public ObservableCollection<TestItemViewModel> ItemCollection { get; set; }

    }
}
