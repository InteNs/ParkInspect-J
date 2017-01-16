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
        private CustomerViewModel _selectedCustomer;
        private readonly ICommissionRepository _commissionRepository;

        public CustomerViewModel SelectedCustomer
        {
            get { return _selectedCustomer; }
            set
            {
                _selectedCustomer = value;
                base.RaisePropertyChanged();
            }
        }
        public ObservableCollection<CustomerViewModel> Customers { get; set; }
        public CommissionViewModel Commission { get; set; }
        public ICommand AddCommissionCommand { get; set; }
        public ObservableCollection<string> Regions { get; set; }

        public AddCommissionViewModel(ICommissionRepository commissionRepository, ICustomerRepository customerRepository, IRegionRepository regionRepository, IRouterService router) : base(router)
        {
            _commissionRepository = commissionRepository;
            Commission = new CommissionViewModel();
            Customers = customerRepository.GetAll();
            Regions = regionRepository.GetAll();

            AddCommissionCommand = new RelayCommand(AddCommission, CanAddCommission);
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
            if (Commission.Customer == null || Commission.Region == null || string.IsNullOrWhiteSpace(Commission.StreetNumber.ToString()) || Commission.ZipCode == null ||
                string.IsNullOrWhiteSpace(Commission.Frequency.ToString()) || Commission.Description == null || !Commission.IsValid)
            {
                return false;
            }
            return true;


        }

        private void AddCommission()
        {
            if (ValidateInput())
            {
                Commission.Status = "Nieuw";
                if (_commissionRepository.Add(Commission))
                {

                    RouterService.SetPreviousView();
                }
            }
            else
            {
                ShowValidationError();
            }
        }

        private bool CanAddCommission()
        {
            return true;
        }

        private async void ShowValidationError()
        {
            //TODO: Validation error
            var dialog = new MetroDialogService();
            dialog.ShowMessage("Error", "De waarden zijn niet correct ingevuld");


        }
    }
}
