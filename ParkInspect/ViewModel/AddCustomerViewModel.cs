using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using System.Windows.Input;
using ParkInspect.Repository.Interface;
using ParkInspect.Service;
using ParkInspect.Helper;

namespace ParkInspect.ViewModel
{
    public class AddCustomerViewModel : MainViewModel
    {
        private readonly ICustomerRepository _customerRepository;

        public ObservableCollection<string> RegionList { get; set; }
        public CustomerViewModel Customer { get; set; }
        public ICommand AddCustomerCommand { get; set; }
        
        public AddCustomerViewModel(ICustomerRepository customerRepository, IRegionRepository regionRepository, IRouterService router) : base(router)
        {
            _customerRepository = customerRepository;
            Customer = new CustomerViewModel();
            RegionList = regionRepository.GetAll();
            AddCustomerCommand = new RelayCommand(AddCustomer);
        }

        private bool ValidateInput() => Customer.Name != null && Customer.ZipCode != null && Customer.StreetNumber != null && Customer.PhoneNumber != null && Customer.Email != null && Customer.IsValid;

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

        private void ShowValidationError() => new MetroDialogService().ShowMessage("Probleem opgetreden", "Niet alle gegevens zijn juist ingevuld.");
    }
}
