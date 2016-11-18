using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ParkInspect.ViewModel;
using System.Globalization;

namespace ParkInspect.Command
{
    public class SearchCustomersCommand : ICommand
    {
        private CustomersViewModel _customersViewModel;
        public event EventHandler CanExecuteChanged;

        public SearchCustomersCommand(CustomersViewModel customersViewModel)
        {
            _customersViewModel = customersViewModel;
        }

        public bool CanExecute(object parameter)
        {
            if (_customersViewModel == null || _customersViewModel.CustomerShowableList == null || _customersViewModel.CustomerCompleteList == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void Execute(object parameter)
        {
            if (_customersViewModel.Input == null || _customersViewModel.Category == null)
            {
                return;
            }
            _customersViewModel.SelectedCustomer = null;
            _customersViewModel.CustomerShowableList.Clear();
            var culture = new CultureInfo(1);
            IEnumerable<CustomerViewModel> newList = null;
            switch (_customersViewModel.Category)
            {
                case "Naam":
                    newList = _customersViewModel.CustomerCompleteList.Where(e => culture.CompareInfo.IndexOf(e.person.Name, _customersViewModel.Input, CompareOptions.IgnoreCase) >= 0);
                    break;
                case "ID":
                    int number = 0;
                    bool result = int.TryParse(_customersViewModel.Input, out number);
                    if (result)
                    {
                        newList = _customersViewModel.CustomerCompleteList.Where(e => e.Id == number);
                    }
                    break;
                case "Postcode":
                    newList = _customersViewModel.CustomerCompleteList.Where(e => culture.CompareInfo.IndexOf(e.person.Zip_Code, _customersViewModel.Input, CompareOptions.IgnoreCase) >= 0);
                    break;
                case "Telefoon":
                    newList = _customersViewModel.CustomerCompleteList.Where(e => culture.CompareInfo.IndexOf(e.person.Phone_Number, _customersViewModel.Input, CompareOptions.IgnoreCase) >= 0);
                    break;
                case "Email":
                    newList = _customersViewModel.CustomerCompleteList.Where(e => culture.CompareInfo.IndexOf(e.person.Email, _customersViewModel.Input, CompareOptions.IgnoreCase) >= 0);
                    break;
            }
            if (newList != null)
            {
                newList.ToList().ForEach(e => _customersViewModel.CustomerShowableList.Add(e));
            }
        }
    }
}
