using GalaSoft.MvvmLight;
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
        private string _selectedRegion;
        private CustomerViewModel _selectedCustomer;

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


        

        public string SelectedRegion
        {
            get { return _selectedRegion; }
            set { _selectedRegion = value; RaisePropertyChanged(); }
        }

        public CustomerViewModel SelectedCustomer
        {
            get { return _selectedCustomer; }
            set
            {
                _selectedCustomer = value;
                base.RaisePropertyChanged();
            }
        }
        public List<CustomerViewModel> CustomerList { get; set; }
        

        private CommissionViewModel Commission { get; set; }

        public ICommand AddCommissionCommand { get; set; }

        private ICommissionRepository _icr;
        private RouterViewModel _router;
        private CommissionOverviewViewModel _cvm;

        public List<string> RegionList { get; set; }

        public AddCommissionViewModel(ICommissionRepository icr, RouterViewModel router, CommissionOverviewViewModel cvm)
        {
            _icr = icr;
            _router = router;
            _cvm = cvm;
            CustomerList = new List<CustomerViewModel>();
            foreach (CustomerViewModel customer in _icr.GetCustomers())
            {
                CustomerList.Add(customer);
            }
            RegionList = _icr.GetRegions().ToList();
            
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
            Commission.Region = SelectedRegion;
            int locationId = _icr.GetLocationViewModels().ToList().Count;

            if (this.ValidateInput())
            {
                _icr.CreateLocation(new LocationViewModel(locationId, ZipCode, StreetNumber, SelectedRegion));
                Commission = new CommissionViewModel(_icr.GetAll().ToList().Count, Frequency, SelectedCustomer.Id, locationId, null, DateTime.Now, null, Description, Region);
                if (_icr.Create(Commission))
                {
                    _cvm.CommissionList.Add(Commission);
                    
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
