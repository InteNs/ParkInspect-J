using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using System.Windows.Input;
using ParkInspect.Repository.Interface;
using ParkInspect.Service;

namespace ParkInspect.ViewModel
{
    public class EditEmployeeViewModel : MainViewModel
    {
        private readonly IEmployeeRepository _employeeRepository;

        public ObservableCollection<string> RegionList { get; set; }

        public ObservableCollection<string> FunctionList { get; set; }

        public EmployeeViewModel SelectedEmployee { get; set; }

        public ICommand EditEmployeeCommand { get; set; }

        public EditEmployeeViewModel(IEmployeeRepository employeeRepository, IRegionRepository regionRepository, IRouterService router, EmployeesViewModel evm) : base(router)
        {
            _employeeRepository = employeeRepository;
            SelectedEmployee = evm.SelectedEmployee;

            FunctionList = _employeeRepository.GetFunctions();
            RegionList = regionRepository.GetAll();

            EditEmployeeCommand = new RelayCommand(EditEmployee);
        }

        //constructor for tests
        public EditEmployeeViewModel()
        {

        }

        private void EditEmployee()
        {
            if (_employeeRepository.Update(SelectedEmployee))
            {
               RouterService.SetPreviousView();
            }
        }
    }
}
