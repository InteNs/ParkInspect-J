﻿using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ParkInspect.Repositories;
using ParkInspect.View;

namespace ParkInspect.ViewModel
{
    public class AddCommissionViewModel : ViewModelBase
    {

        private string _zipCode;
        private int _streetNumber;
        private int _frequency;
        private string _description;
        private string _region;

        public string ZipCode
        {
            get { return _zipCode; }
            set
            {
                _zipCode = value;
                RaisePropertyChanged();
            }
        }

        public int StreetNumber
        {
            get { return _streetNumber; }
            set
            {
                _streetNumber = value;
                RaisePropertyChanged();
            }
        }
        public int Frequency
        {
            get { return _frequency; }
            set { _frequency = value; RaisePropertyChanged("Frequency"); }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; RaisePropertyChanged("Description"); }
        }

        public string Region
        {
            get { return _region; }
            set { _region = value; RaisePropertyChanged("Region"); }
        }


        private string _selectedCustomer;

        public string SelectedCustomer
        {
            get { return _selectedCustomer; }
            set
            {
                _selectedCustomer = value;
                base.RaisePropertyChanged();
            }
        }
        public List<string> CustomerList { get; set; }

        private CommissionViewModel Commission { get; set; }

        public ICommand AddCommissionCommand { get; set; }

        private ICommissionRepository _icr;
        private RouterViewModel _router;
        private CommissionOverviewViewModel _cvm;

        public AddCommissionViewModel(ICommissionRepository icr, RouterViewModel router, CommissionOverviewViewModel cvm)
        {
            _icr = icr;
            _router = router;
            _cvm = cvm;
            Commission = new CommissionViewModel();
            AddCommissionCommand = new RelayCommand(AddCommission, CanAddCommission);
        }

        private bool ValidateInput()
        {
            //TODO: Check if all fields have the right content
            bool validate = false;

            //check if all fields are filled in
            if (this._selectedCustomer == null || this.Commission.Region == null ||
                this.Commission.Frequency >= 0 || this.Commission.Description == null)
            {
                return validate;
            }
            return true;
        }

        public void AddCommission()
        {
            
            if (this.ValidateInput())
            {
                if (_icr.Create(Commission))
                {
                    _cvm.EmployeesCompleteList.Add(Commission);
                    
                    _router.SetViewCommand.Execute("Customers-list");
                }
            }
            else
            {
                this.ShowValidationError();
            }
        }

        public bool CanAddCommission()
        {
            return true;
        }

        private string ShowValidationError()
        {
            //TODO: Validation error
            return "Error, de velden zijn niet juist ingevuld.";
        }
    }
}
