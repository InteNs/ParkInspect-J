using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using ParkInspect.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using ParkInspect.Service;

namespace ParkInspect.ViewModel
{
    public class AddCustomerViewModel : MainViewModel
    {

        private string _selectedFunction;

        public string SelectedFunction
        {
            get { return _selectedFunction; }
            set
            {
                _selectedFunction = value;
                base.RaisePropertyChanged();
            }
        }

        public List<string> FunctionList { get; set; }

        public CustomerViewModel Customer { get; set; }

        public ICommand AddCustomerCommand { get; set; }


        private ICustomerRepository _ier;

        private CustomersViewModel _cvm;

        public AddCustomerViewModel(ICustomerRepository ier, IRouterService router, CustomersViewModel cvm) : base(router)
        {
            _ier = ier;
            _cvm = cvm;

            Customer = new CustomerViewModel();

            FunctionList = new List<string> {"Klant"};

            AddCustomerCommand = new RelayCommand(AddCustomer, CanAddCustomer);
        }



        private bool CanAddCustomer()
        {
            //TODO: check if all fields are filled in
            return true;
        }

        private bool ValidateInput()
        {
            //TODO: Check if all fields have the right content
            bool validate = false;

            //check if all fields are filled in
            if (_selectedFunction == null || Customer.Name == null || Customer.ZipCode == null ||
                Customer.StreetNumber == null || Customer.PhoneNumber == null || Customer.Email == null)
            {
                return validate;
            }

            //Name can not contain a number
            if (this.Customer.Name.Any(c => char.IsDigit(c)))
            { 
                return validate;
            }


            return true;
        }

        private void AddCustomer()
        {
            //Customer.Region.Name = SelectedRegion;
            //Customer.Function.Name = SelectedFunction;
            if (this.ValidateInput())
            {
                if (_ier.Create(Customer))
                {
                    _cvm.Customers.Add(Customer);
                    RouterService.SetPreviousView();
                }
            }
            else
            {
                MessageBox.Show(ShowValidationError());
            }
        }

        private string ShowValidationError()
        {
            //TODO: Validation error
            return "Error, de velden zijn niet juist ingevuld.";
        }

    }
}
