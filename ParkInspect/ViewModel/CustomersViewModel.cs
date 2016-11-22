using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using ParkInspect.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ParkInspect.ViewModel
{
    public class CustomersViewModel : ViewModelBase
    {
        public ObservableCollection<CustomerViewModel> Customers{ get; set; }

        private CustomerViewModel _selectedCustomer;
        private ICustomerRepository _repo;
        private RouterViewModel _router;
        private string _input;

        public CustomerViewModel SelectedCustomer
        {
            get { return _selectedCustomer; }
            set
            {
                _selectedCustomer = value;
                RaisePropertyChanged();
            }
        }
        public ICommand ShowEditCustomersCommand { get; set; }

        public string Input
        {
            get { return _input; }
            set
            {
                _input = value;
                RaisePropertyChanged();
            }
        }

       public CustomersViewModel(ICustomerRepository repo, RouterViewModel router)
        {
            _repo = repo;
            _router = router;

            Customers = new ObservableCollection<CustomerViewModel>(repo.GetAll());

            ShowEditCustomersCommand = new RelayCommand(ShowEditView, CustomerIsNotNull);
        }

        private bool CustomerIsNotNull()
        {
            return SelectedCustomer != null;
        }

        private void ShowEditView()
        {
            _router.SetViewCommand.Execute("Customers-list");
        }

    }
}
