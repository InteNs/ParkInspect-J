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
        private int v1;
        private string v2;
        private string v3;
        private string v4;

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

        public CustomerViewModel(int v1, string v2, string v3, string v4)
        {
            this.v1 = v1;
            this.v2 = v2;
            this.v3 = v3;
            this.v4 = v4;
        }
    }
}
