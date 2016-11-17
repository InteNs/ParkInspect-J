using ParkInspect.DummyModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;

namespace ParkInspect.ViewModel
{
    public class CustomerViewModel : ViewModelBase
    {
        private Customer _customer;
        public int Id
        {
            get { return _customer.Id; }
            set
            {
                _customer.Id = value;
                RaisePropertyChanged();
            }
        }

        public Person person
        {
            get { return _customer.person; }
            set
            {
                _customer.person = value;
                RaisePropertyChanged();
            }
        }

        public CustomerViewModel()
        {
            _customer = new Customer();
        }
    }
}
