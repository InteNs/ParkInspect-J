using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using ParkInspect.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ParkInspect.ViewModel
{
    public class AddCustomerViewModel : ViewModelBase
    {
        
            private string _selectedFunction;

            public string SelectedFunction
            {
                get { return _selectedFunction; }
                set
                {
                    _selectedFunction = value;
                    base.RaisePropertyChanged();
                }
            }
        
            public List<string> FunctionList { get; set; }

            public CustomerViewModel Customer { get; set; }

            public ICommand AddCustomerCommand { get; set; }

            private ICustomerRepository _ier;
            private RouterViewModel _router;

            private CustomersViewModel _cvm;

            public AddCustomerViewModel(ICustomerRepository ier, RouterViewModel router, CustomersViewModel cvm)
            {
                _ier = ier;
                _router = router;
                _cvm = cvm;

                Customer = new CustomerViewModel();

                FunctionList = new List<string>();
                FunctionList.Add("Klant");

                AddCustomerCommand = new RelayCommand(AddCustomer, CanAddCustomer);
            }

            private bool CanAddCustomer()
            {
                //TODO: check if all fields are filled in
                return true;
            }

            private bool ValidateInput()
            {
                //TODO: Check if all fields have the right content
                return true;
            }

            private void AddCustomer()
            {
                //Customer.Region.Name = SelectedRegion;
                //Customer.Function.Name = SelectedFunction;
                if (this.ValidateInput())
                {
                    if (_ier.Create(Customer))
                    {
                        _cvm.CustomerCompleteList.Add(Customer);
                        _cvm.CustomerShowableList.Add(Customer);
                        _router.SetViewCommand.Execute("Customers-list");
                    }
                }
                else
                {
                    this.ShowValidationError();
                }
            }

            private void ShowValidationError()
            {
                //TODO: Validation error
            }
        }
}
