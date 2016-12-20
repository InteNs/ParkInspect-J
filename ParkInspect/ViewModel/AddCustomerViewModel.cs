using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using ParkInspect.Repository.Interface;
using ParkInspect.Service;
using System.ComponentModel;
using System;
using System.Collections;
using System.Collections.Generic;

namespace ParkInspect.ViewModel
{
    public class AddCustomerViewModel : MainViewModel, INotifyDataErrorInfo
    {
        private readonly ICustomerRepository _customerRepository;

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        public ObservableCollection<string> FunctionList { get; set; }
        public CustomerViewModel Customer { get; set; }
        public ICommand AddCustomerCommand { get; set; }
        Dictionary<string, List<string>> propErrors;
        public bool HasErrors
        {
            get
            {
                    var propErrorsCount = propErrors.Values.FirstOrDefault(r => r.Count > 0);
                    if (propErrorsCount != null)
                        return true;
                    else
                        return false;
            }
        }

        public AddCustomerViewModel(ICustomerRepository customerRepository, IRouterService router, CustomersViewModel cvm) : base(router)
        {
            _customerRepository = customerRepository;
            Customer = new CustomerViewModel();
            FunctionList = customerRepository.GetFunctions();
            propErrors = new Dictionary<string, List<string>>();
            AddCustomerCommand = new RelayCommand(AddCustomer, CanAddCustomer);
        }

        private bool CanAddCustomer()
        {
            //TODO: check if all fields are filled in
            return true;
        }

        private bool ValidateInput()
        {
            //check if all fields are filled in
            if (Customer.Function == null || Customer.Name == null || Customer.ZipCode == null ||
                Customer.StreetNumber == null || Customer.PhoneNumber == null || Customer.Email == null)
            {
                return false;
            }

            //Name can not contain a number
            return !Customer.Name.Any(char.IsDigit);
        }

        private void AddCustomer()
        {
            if (ValidateInput())
            {
                if (_customerRepository.Add(Customer))
                {
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

        public IEnumerable GetErrors(string propertyName)
        {
            List<string> errors = new List<string>();
            if (propertyName != null)
            {
                propErrors.TryGetValue(propertyName, out errors);
                return errors;
            }
            else
                return null;
        }
    }
}
