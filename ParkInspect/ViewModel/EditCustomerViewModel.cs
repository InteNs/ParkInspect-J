using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using ParkInspect.Repository.Interface;
using ParkInspect.Service;

namespace ParkInspect.ViewModel
{
    public class EditCustomerViewModel : MainViewModel
    {
        public ObservableCollection<string> FunctionList { get; set; }

        public CustomerViewModel Customer { get; set; }

        public ICommand EditCustomerCommand { get; set; }

        private readonly ICustomerRepository _customerRepository;

        public EditCustomerViewModel(ICustomerRepository customerRepository, IRouterService router, CustomersViewModel cvm) : base(router)
        {
            _customerRepository = customerRepository;
            Customer = cvm.SelectedCustomer;
            FunctionList = _customerRepository.GetFunctions();

            EditCustomerCommand = new RelayCommand(EditCustomer, CanEditCustomer);
        }

        private bool ValidateInput()
        {
            //check if all fields are filled in
            if (Customer.Function == null || Customer.Name == null || Customer.ZipCode == null ||
                Customer.StreetNumber == null || Customer.PhoneNumber == null || Customer.Email == null)
            {
                return false;
            }

            //Name can not contain a number
            return !this.Customer.Name.Any(char.IsDigit);
        }

        private bool CanEditCustomer()
        {
            //TODO check content
            return true;
        }

        private void EditCustomer()
        {
            if (this.ValidateInput())
            {
                if (_customerRepository.Update(Customer))
                {
                    RouterService.SetPreviousView();
                }
            }
            else
            {
                MessageBox.Show(ShowValidationError());
            }
        }

        private string ShowValidationError()
        {
            //TODO: Validation error
            return "Error, de velden zijn niet juist ingevuld.";
        }
    }
}
