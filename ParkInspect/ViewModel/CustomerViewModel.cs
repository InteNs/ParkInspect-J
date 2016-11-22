using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;

namespace ParkInspect.ViewModel
{
    public class CustomerViewModel : PersonViewModel
    {
        private int id;
        private string function;

        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                RaisePropertyChanged();
            }
        }

        public string Function
        {
            get { return function; }
            set
            {
                function = value;
                RaisePropertyChanged();
            }
        }
    }
}
