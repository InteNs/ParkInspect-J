using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using ParkInspect.Repository.Interface;
using ParkInspect.Service;

namespace ParkInspect.ViewModel
{
    public class CustomersViewModel : MainViewModel
    {
        private CustomerViewModel _selectedCustomer;
        public ObservableCollection<CustomerViewModel> Customers { get; set; }

        public CustomerViewModel SelectedCustomer
        {
            get { return _selectedCustomer; }
            set
            {
                _selectedCustomer = value;
                EditCustomerCommand.RaiseCanExecuteChanged();
                RaisePropertyChanged();
            }
        }
        public RelayCommand EditCustomerCommand { get; set; }

        public CustomersViewModel(ICustomerRepository repo, IRouterService router) : base(router)
        {
            Customers = repo.GetAll();
            EditCustomerCommand = new RelayCommand(() => RouterService.SetView("customers-edit"), CanEditCustomer);
        }

        private bool CanEditCustomer() => SelectedCustomer != null;
    }
}
