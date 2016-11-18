using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using ParkInspect.Command;
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
        public ObservableCollection<CustomerViewModel> CustomerCompleteList { get; set; }

        public ObservableCollection<CustomerViewModel> CustomerShowableList { get; set; }

        public List<string> SearchCategoryList { get; set; }

        private CustomerViewModel _selectedCustomer;
        private ICustomerRepository _repo;
        private RouterViewModel _router;
        private string _category;
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

        public ICommand SearchCustomersCommand { get; set; }

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

        public string Category
        {
            get { return _category; }
            set
            {
                _category = value;
                RaisePropertyChanged();
            }
        }

       public CustomersViewModel(ICustomerRepository repo, RouterViewModel router)
        {
            _repo = repo;
            _router = router;

            CustomerCompleteList = new ObservableCollection<CustomerViewModel>(repo.GetAll());

            CustomerShowableList = new ObservableCollection<CustomerViewModel>();

            CustomerCompleteList.ToList().ForEach(e => CustomerShowableList.Add(e));

            SearchCategoryList = new List<string>();
            SearchCategoryList.Add("Naam");
            SearchCategoryList.Add("ID");
            SearchCategoryList.Add("Postcode");
            SearchCategoryList.Add("Telefoon");
            SearchCategoryList.Add("Email");

            Category = SearchCategoryList.First();

            SearchCustomersCommand = new SearchCustomersCommand(this);
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
