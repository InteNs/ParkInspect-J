using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using ParkInspect.Helper;
using ParkInspect.Repository.Interface;
using ParkInspect.Service;

namespace ParkInspect.ViewModel
{
    public class EmployeesViewModel : MainViewModel
    {
        private EmployeeViewModel _selectedEmployee;

        private readonly IEmployeeRepository _employeeRepository;
        private ObservableCollection<EmployeeViewModel> _employees;

        public EmployeeViewModel SelectedEmployee
        {
            get { return _selectedEmployee; }
            set
            {
                _selectedEmployee = value;
                RaisePropertyChanged();
            }
        }
       
        public ObservableCollection<EmployeeViewModel> Employees
        {
            get { return _employees; }
            set { _employees = value; RaisePropertyChanged(); }
        }

        public ICommand SetEmployeeDismissCommand { get; set; }

        public ICommand EditEmployeeCommand { get; set; }

        public EmployeesViewModel(IEmployeeRepository employeeRepository, IRouterService router) : base(router)
        {
            _employeeRepository = employeeRepository;

            Employees = _employeeRepository.GetAll();

            EditEmployeeCommand = new RelayCommand(() => RouterService.SetView("employees-edit"), CanEditEmployee);
            SetEmployeeDismissCommand = new RelayCommand(DismissEmployee, CanEditEmployee);
        }

        private bool CanEditEmployee()
        {
            return SelectedEmployee != null;
        }

        private async void DismissEmployee()
        {
            var dialog = new MetroDialogService();
            await dialog.ShowConfirmative("Werknemer non-actief zetten",
                "Weet u zeker dat u " + SelectedEmployee.Name + " op non-actief wilt zetten?");

            if (dialog.IsAffirmative)
            {
                _employeeRepository.Delete(SelectedEmployee);
            }
        }
    }
}
