using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using System.Windows.Input;
using ParkInspect.Repository.Interface;
using ParkInspect.Service;
using ParkInspect.Helper;

namespace ParkInspect.ViewModel
{
    public class AddEmployeeViewModel : MainViewModel
    {
        private readonly IEmployeeRepository _employeeRepository;

        public ObservableCollection<string> RegionList { get; set; }
        public ObservableCollection<string> FunctionList { get; set; }
        public EmployeeViewModel Employee { get; set; }
        public ICommand AddEmployeeCommand { get; set; }
         
        public AddEmployeeViewModel(IEmployeeRepository employeeRepository, IRegionRepository regionRepository, IRouterService router) : base(router)
        {
            _employeeRepository = employeeRepository;
            Employee = new EmployeeViewModel();
            FunctionList = _employeeRepository.GetFunctions();
            RegionList = regionRepository.GetAll();

            AddEmployeeCommand = new RelayCommand(AddEmployee);
        }

        //constructor for unittests
        public AddEmployeeViewModel()
        {
            Employee = new EmployeeViewModel();
        }
        public bool ValidateInput()
        {
            //TODO: Check if all fields have the right content

            if (Employee.Function == null || Employee.Name == null || Employee.ZipCode == null ||
                  Employee.StreetNumber == null || Employee.PhoneNumber == null || Employee.Email == null || Employee.Region == null || Employee.Function == null)
            { return false; }
            return Employee.IsValid;
        }

        private void AddEmployee()
        {
            if (ValidateInput())
            {
                if (_employeeRepository.Add(Employee))
                {
                    RouterService.SetPreviousView();
                }
            }
            else
            {
                ShowValidationError();
            }
        }

        private void ShowValidationError() => new MetroDialogService().ShowMessage("Probleem opgetreden", "Niet alle gegevens zijn juist ingevuld.");
    }
}
