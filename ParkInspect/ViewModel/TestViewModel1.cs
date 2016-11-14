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
    public class TestViewModel1 : MainViewModel
    {
        private ITestItemRepository _itir;
        public TestViewModel1(ITestItemRepository itir)
        {
            _itir = itir;
            ItemCollection = new ObservableCollection<TestItemViewModel>(itir.GetAll());
        }

        public ObservableCollection<TestItemViewModel> ItemCollection { get; set; }

    }
}
