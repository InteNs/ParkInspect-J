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
    public class AddEmployeeViewModel : ViewModelBase
    {
        private string _selectedRegion;

        private string _selectedFunction;

        private IEmployeeRepository _ier;

        private RouterViewModel _router;

        private EmployeesViewModel _evm;


        public string SelectedRegion
        {
            get { return _selectedRegion; }
            set
            {
                _selectedRegion = value;
                base.RaisePropertyChanged();
            }
        }

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

        public EmployeeViewModel Employee { get; set; }

        public ICommand AddEmployeeCommand { get; set; }

        public AddEmployeeViewModel(IEmployeeRepository ier,RouterViewModel router,EmployeesViewModel evm)
        {
            _ier = ier;
            _router = router;
            _evm = evm;

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
            Employee.Region.Name = SelectedRegion;
            Employee.Function.Name = SelectedFunction;
            if (this.ValidateInput())
            {
                if (_ier.Create(Employee))
                {
                    _evm.EmployeesCompleteList.Add(Employee);
                    _evm.EmployeesShowableList.Add(Employee);
                    _router.SetViewCommand.Execute("employees-list");
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
