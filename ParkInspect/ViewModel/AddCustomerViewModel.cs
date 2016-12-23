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
    public class AddCustomerViewModel : MainViewModel
    {
        private readonly ICustomerRepository _customerRepository;
        

        public ObservableCollection<string> FunctionList { get; set; }
        public CustomerViewModel Customer { get; set; }
        public ICommand AddCustomerCommand { get; set; }
        

        public AddCustomerViewModel(ICustomerRepository customerRepository, IRouterService router, CustomersViewModel cvm) : base(router)
        {
            _customerRepository = customerRepository;
            Customer = new CustomerViewModel();
            FunctionList = customerRepository.GetFunctions();
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
            // return !Customer.Name.Any(char.IsDigit);
            return true;
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

       
    }
}
