using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using ParkInspect.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace ParkInspect.ViewModel
{
    public class AddEmployeeViewModel : ViewModelBase
    {
        private string _selectedRegion;

        private string _selectedFunction;

        private readonly IEmployeeRepository _repository;

        private readonly RouterViewModel _router;

        private readonly EmployeesViewModel _employeesVm;


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
            _repository = ier;
            _router = router;
            _employeesVm = evm;

            Employee = new EmployeeViewModel();

            FunctionList = _repository.GetFunctions().ToList();

            RegionList = _repository.GetRegions().ToList();

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
            Employee.Region = SelectedRegion;
            Employee.Function = SelectedFunction;
            if (this.ValidateInput())
            {
                if (_repository.Create(Employee))
                {
                    _employeesVm.Employees.Add(Employee);
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
