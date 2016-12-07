using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using System.Windows.Input;
using ParkInspect.Repository.Interface;
using ParkInspect.Service;

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

            Customers = customerRepository.GetAll();
            Regions = regionRepository.GetAll();
            
            AddCommissionCommand = new RelayCommand(AddCommission, CanAddCommission);
        }

        private bool ValidateInput()
        {
            //TODO: Check if all fields have the right content

            //check if all fields are filled in
            if (Commission.Customer == null || Commission.Region == null ||
                Commission.Frequency <= 0 || Commission.Description == null)
            {
                return false;
            }
            return true;
        }

        private void AddCommission()
        {
            if (ValidateInput())
            {
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

        private string ShowValidationError()
        {
            //TODO: Validation error
            return "Error, de velden zijn niet juist ingevuld.";
        }
    }
}
