using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ParkInspect.ViewModel
{
    public class AddEmployeeViewModel : ViewModelBase
    {
        private string _selectedRegion;

        public string SelectedRegion
        {
            get { return _selectedRegion; }
            set
            {
                _selectedRegion = value;
                base.RaisePropertyChanged();
            }
        }

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

        public List<string> RegionList { get; set; }

        public List<string> FunctionList { get; set; }

        private EmployeesViewModel _employeesVM;

        public EmployeeViewModel Employee;

        public ICommand AddEmployeeCommand { get; set; }

        public AddEmployeeViewModel(EmployeesViewModel employeesVM)
        {
            _employeesVM = employeesVM;
            Employee = new EmployeeViewModel();

            FunctionList = new List<string>();
            FunctionList.Add("Inspecteur");
            FunctionList.Add("Directeur");
            FunctionList.Add("Manager");

            RegionList = new List<string>();
            RegionList.Add("Limburg");
            RegionList.Add("Utrecht");
            RegionList.Add("Brabant");



            AddEmployeeCommand = new RelayCommand(AddEmployee, CanAddEmployee);
        }

        private bool CanAddEmployee()
        {
            //TODO: check if all fields are filled in
            return true;
        }

        private bool ValidateInput()
        {
            //TODO: Check if all fields have the right content
            return true;
        }

        private void AddEmployee()
        {
            if (this.ValidateInput())
            {
                //TODO: Add employee to database and add tot current load
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
