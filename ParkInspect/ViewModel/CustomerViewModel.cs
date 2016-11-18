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

        public Region Region
        {
            get { return _customer.Region; }
            set
            {
                _customer.Region = value;
                RaisePropertyChanged();
            }
        }

        public Function Function
        {
            get { return _customer.Function; }
            set
            {
                _customer.Function = value;
                RaisePropertyChanged();
            }
        }

        public CustomerViewModel()
        {
            _customer = new Customer();
        }
        public CustomerViewModel(int id, string name, string zipcode, string telephone, int streetnr, string email, string region, string function)
        {
            _customer = new Customer();
            _customer.Id = id;
            _customer.person = new Person();
            person.Name = name;
            person.Email = email;
            person.Phone_Number = telephone;
            person.Street_Number = streetnr;
            person.Zip_Code = zipcode;
            _customer.Region = new Region();
            Region.Name = region;
            _customer.Function = new Function();
            Function.Name = function;
        }
    }
}
