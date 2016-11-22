using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using ParkInspect.Repositories;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using MahApps.Metro.Controls.Dialogs;
using MaterialDesignThemes.Wpf;
using MessageBox = System.Windows.Forms.MessageBox;

namespace ParkInspect.ViewModel
{
    public class EmployeesViewModel : ViewModelBase
    {
        private EmployeeViewModel _selectedEmployee;

        private string _input;

        private readonly IEmployeeRepository _repository;

        private readonly RouterViewModel _router;

        public EmployeeViewModel SelectedEmployee
        {
            get { return _selectedEmployee; }
            set
            {
                _selectedEmployee = value;
                RaisePropertyChanged();
            }
        }

        public string Input
        {
            get { return _input; }
            set
            {
                _input = value;
                RaisePropertyChanged();
            }
        }

        public ObservableCollection<EmployeeViewModel> Employees { get; set; }

        public ICommand SetEmployeeDismissCommand { get; set; }

        public ICommand ShowEditEmployeeCommand { get; set; }

        public EmployeesViewModel(IEmployeeRepository repo, RouterViewModel router)
        {
            _repository = repo;
            _router = router;

            Employees = new ObservableCollection<EmployeeViewModel>(_repository.GetAll());

            ShowEditEmployeeCommand = new RelayCommand(ShowEditView, EmployeeIsNotNull);
            SetEmployeeDismissCommand = new RelayCommand(DismissEmployee, EmployeeIsNotNull);
    }

        private bool EmployeeIsNotNull()
        {
            return SelectedEmployee != null;
        }

        private void ShowEditView()
        {
            _router.SetViewCommand.Execute("employees-edit");
        }

        private void DismissEmployee()
        {
            var result = MessageBox.Show("Weet u zeker dat u " + SelectedEmployee.Name + " op non-actief wilt zetten?", "Werknemer op non-actief zetten", MessageBoxButtons.YesNo);

            if (result != DialogResult.Yes) return;

            SelectedEmployee.DismissalDate = DateTime.Now;

            if (!_repository.Update(SelectedEmployee)) return;

            Employees.Remove(SelectedEmployee);
        }
    }
}
