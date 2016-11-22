using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using ParkInspect.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace ParkInspect.ViewModel
{
    public class EditEmployeeViewModel : ViewModelBase
    {

        private string _selectedRegion;

        private string _selectedFunction;

        private readonly IEmployeeRepository _repository;

        private readonly RouterViewModel _router;

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

        public EmployeeViewModel SelectedEmployee { get; set; }

        public ICommand EditEmployeeCommand { get; set; }

        public EditEmployeeViewModel(IEmployeeRepository ier,RouterViewModel router, EmployeesViewModel evm)
        {
            _repository = ier;
            _router = router;

            SelectedEmployee = evm.SelectedEmployee;

            FunctionList = _repository.GetFunctions().ToList();

            RegionList = _repository.GetRegions().ToList();

            EditEmployeeCommand = new RelayCommand(EditEmployee, CanEdit);
        }

        private bool CanEdit()
        {
            //TODO check content
            return true;
        }

        private void EditEmployee()
        {
            if (_repository.Update(SelectedEmployee))
            {
                _router.SetViewCommand.Execute("employees-list");
            }
        }
    }
}
