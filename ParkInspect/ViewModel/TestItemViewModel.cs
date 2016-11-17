using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkInspect.ViewModel
{
    public class TestItemViewModel:ViewModelBase
    {
        public string Naam { get; set; }

        public TestItemViewModel(string naam)
        {
            Naam = naam;
        }
    }
}
