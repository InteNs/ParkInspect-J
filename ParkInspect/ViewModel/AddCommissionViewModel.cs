using System;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using System.Windows.Input;
using ParkInspect.Repository.Interface;
using ParkInspect.Service;
using ParkInspect.Helper;

namespace ParkInspect.ViewModel
{
    public class AddCommissionViewModel : MainViewModel
    {
        private readonly ICommissionRepository _commissionRepository;

        public ObservableCollection<CustomerViewModel> Customers { get; set; }
        public ObservableCollection<EmployeeViewModel> Employees { get; set; }
        public CommissionViewModel Commission { get; set; }
        public ICommand AddCommissionCommand { get; set; }
        public ObservableCollection<string> Regions { get; set; }

        public AddCommissionViewModel(ICommissionRepository commissionRepository, IEmployeeRepository employeeRepository, ICustomerRepository customerRepository, IRegionRepository regionRepository, IRouterService router) : base(router)
        {
            _commissionRepository = commissionRepository;
            Commission = new CommissionViewModel();
            Customers = customerRepository.GetAll();
            Employees = new ObservableCollection<EmployeeViewModel>();
            foreach(EmployeeViewModel evm in employeeRepository.GetAll())
            {
                if(evm.DismissalDate == null)
                {
                    Employees.Add(evm);
                }
            }
            Regions = regionRepository.GetAll();

            AddCommissionCommand = new RelayCommand(AddCommission);
        }

        //constructor for unittest
        public AddCommissionViewModel()
        {
            Commission = new CommissionViewModel();
            Employees = new ObservableCollection<EmployeeViewModel>();
        }
        

        private bool ValidateInput()
        {
            //TODO: Check if all fields have the right content
            /*   int streetNumberInt;
               int FrequencyInt;
               string pattern = "^[1-9][0-9]{3}\\s?[a-zA-Z]{2}$";
               Regex regex = new Regex(pattern);
               if (!int.TryParse(StreetNumber, out streetNumberInt) || !int.TryParse(Frequency, out FrequencyInt))
               {
                   return false;
               }

               if (!Regex.Match(Commission.ZipCode, pattern).Success)
               {
                   return false;
               }
               */
            //check if all fields are filled in

            return Commission.Customer != null && Commission.Region != null && !string.IsNullOrWhiteSpace(Commission.StreetNumber) && Commission.ZipCode != null && Commission.Description != null && Commission.IsValid && Commission.Employee != null;
        }

        public void AddCommission()
        {
            if (ValidateInput())
            {
                Commission.Status = "Nieuw";
                Commission.DateCreated = DateTime.Today;
                if (_commissionRepository != null)
                {
                    if (_commissionRepository.Add(Commission))
                    {

                        RouterService.SetPreviousView();
                    }
                }
            }
            else
            {
                ShowValidationError();
            }
        }

        private async void ShowValidationError()
        {
            //TODO: Validation error
            var dialog = new MetroDialogService();
            dialog.ShowMessage("Error", "De waarden zijn niet correct ingevuld");
        }
    }
}
