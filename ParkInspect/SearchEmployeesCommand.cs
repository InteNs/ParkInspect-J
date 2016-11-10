using ParkInspect.ViewModel;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ParkInspect
{
    public class SearchEmployeesCommand : ICommand
    {
        private EmployeesViewModel _employeesVM;

        public event EventHandler CanExecuteChanged;

        public SearchEmployeesCommand(EmployeesViewModel employeesViewModel)
        {
            _employeesVM = employeesViewModel;
        }

        public bool CanExecute(object parameter)
        {
            if (_employeesVM == null|| _employeesVM.EmployeesShowableList == null || _employeesVM.EmployeesCompleteList == null)
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
            if(_employeesVM.Input == null || _employeesVM.Category == null)
            {
                return;
            }
            _employeesVM.SelectedEmployee = null;
            _employeesVM.EmployeesShowableList.Clear();
            var culture = new CultureInfo(1);
            IEnumerable<EmployeeViewModel> newList = null;
            switch (_employeesVM.Category)
            {
                case "Naam":
                    newList = _employeesVM.EmployeesCompleteList.Where(e => culture.CompareInfo.IndexOf(e.Name, _employeesVM.Input, CompareOptions.IgnoreCase) >= 0);
                    break;
                case "ID":
                    int number = 0;
                    bool result = int.TryParse(_employeesVM.Input, out number);
                    if (result)
                    {
                        newList = _employeesVM.EmployeesCompleteList.Where(e => e.Id == number);
                    }
                    break;
                case "Regio":
                    newList = _employeesVM.EmployeesCompleteList.Where(e => culture.CompareInfo.IndexOf(e.Region, _employeesVM.Input, CompareOptions.IgnoreCase) >= 0);
                    break;
                case "Functie":
                    newList = _employeesVM.EmployeesCompleteList.Where(e => culture.CompareInfo.IndexOf(e.Function, _employeesVM.Input, CompareOptions.IgnoreCase) >= 0);
                    break;
            }
            if (newList != null)
            {
                newList.ToList().ForEach(e => _employeesVM.EmployeesShowableList.Add(e));
            }
        }
    }
}
