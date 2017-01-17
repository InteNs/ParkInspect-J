using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using System.Windows.Input;
using ParkInspect.Repository.Interface;
using ParkInspect.Service;
using ParkInspect.Helper;
using System.Text.RegularExpressions;

namespace ParkInspect.ViewModel
{
    public class AddCommissionViewModel : MainViewModel
    {
        private CustomerViewModel _selectedCustomer;
        private readonly ICommissionRepository _commissionRepository;
        private string errorMessage;

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
        public string StreetNumber { get; set; }
        public string Frequency { get; set; }

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
            int streetNumberInt;
            int FrequencyInt;
            string pattern = "^[1-9][0-9]{3}\\s?[a-zA-Z]{2}$";
            Regex regex = new Regex(pattern);
      

            //check if all fields are filled in
            if (Commission.Customer == null || Commission.Region == null || Commission.ZipCode == null ||
                Commission.Description == null)
            {
                errorMessage = "Niet alle velden zijn ingevuld";
                return false;
                
            }

            if (!int.TryParse(StreetNumber, out streetNumberInt))
            {
                errorMessage = "Vul een getal in bij straatnummer";
                return false;

            }
            if (!int.TryParse(Frequency, out FrequencyInt))
            {
                errorMessage = "Vul een getal in bij frequentie";
                return false;

            }

            if (!Regex.Match(Commission.ZipCode, pattern).Success)
            {
                errorMessage = "De postcode is niet correct ingevuld";
                return false;

            }
            return true;
        }

        private void AddCommission()
        {
            if (ValidateInput())
            {
                Commission.Status = "Nieuw";
                //Commission.StreetNumber = int.Parse(StreetNumber);
                Commission.Frequency = int.Parse(Frequency);
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
            dialog.ShowMessage("Error", errorMessage);


        }
    }
}
