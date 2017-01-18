﻿using GalaSoft.MvvmLight.Command;
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
using ParkInspect.Helper;

namespace ParkInspect.ViewModel
{
    public class AddCustomerViewModel : MainViewModel
    {
        private readonly ICustomerRepository _customerRepository;
        

        public ObservableCollection<string> RegionList { get; set; }
        public CustomerViewModel Customer { get; set; }
        public ICommand AddCustomerCommand { get; set; }
        

        public AddCustomerViewModel(ICustomerRepository customerRepository, IRegionRepository regionRepository, IRouterService router, CustomersViewModel cvm) : base(router)
        {
            _customerRepository = customerRepository;
            Customer = new CustomerViewModel();
            RegionList = regionRepository.GetAll();
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
            if (Customer.Name == null || Customer.ZipCode == null ||
                Customer.StreetNumber == null || Customer.PhoneNumber == null || Customer.Email == null || !Customer.IsValid)
            {
                return false;
            }
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
                ShowValidationError();
            }
        }

        private void ShowValidationError()
        {
            //TODO: Validation error
            var dialog = new MetroDialogService();
            dialog.ShowMessage("Probleem opgetreden",
                            "Niet alle gegevens zijn juist ingevuld.");
        }

       
    }
}
