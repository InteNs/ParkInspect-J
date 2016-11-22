using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using ParkInspect.Repositories;
using System;
using System.Collections.Generic;
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

        private IEmployeeRepository _repository;

        private RouterViewModel _router;

        private string _category;

        public EmployeeViewModel SelectedEmployee
        {
            get { return _selectedEmployee; }
            set
            {
                _selectedEmployee = value;
                base.RaisePropertyChanged();
            }
        }

        public string Input
        {
            get { return _input; }
            set
            {
                _input = value;
                base.RaisePropertyChanged();
            }
        }

        public string Category
        {
            get { return _category; }
            set
            {
                _category = value;
                base.RaisePropertyChanged();
            }
        }

        public ObservableCollection<EmployeeViewModel> EmployeesCompleteList { get; set; }

        public ObservableCollection<EmployeeViewModel> EmployeesShowableList { get; set; }

        public List<string> SearchCategoryList { get; set; }

        public ICommand SearchEmployeesCommand { get; set; }

        public ICommand SetEmployeeDismissCommand { get; set; }

        public ICommand ShowEditEmployeeCommand { get; set; }

        public EmployeesViewModel(IEmployeeRepository repo, RouterViewModel router)
        {
            _repository = repo;
            _router = router;

            EmployeesCompleteList = new ObservableCollection<EmployeeViewModel>(_repository.GetAll());

            EmployeesShowableList = new ObservableCollection<EmployeeViewModel>();

            EmployeesCompleteList.ToList().ForEach(e => EmployeesShowableList.Add(e));

            SearchCategoryList = new List<string>();
            SearchCategoryList.Add("Naam");
            SearchCategoryList.Add("ID");
            SearchCategoryList.Add("Regio");
            SearchCategoryList.Add("Functie");

            Category = SearchCategoryList.First();

            SearchEmployeesCommand = new SearchEmployeesCommand(this);
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

            var result = MessageBox.Show("Weet u zeker dat u " + SelectedEmployee.Person.Name + " op non-actief wilt zetten?", "Werknemer op non-actief zetten", MessageBoxButtons.YesNo);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                SelectedEmployee.Dismissal_Date = DateTime.Now;
                if (_repository.Update(SelectedEmployee))
                {
                    EmployeesCompleteList.Remove(SelectedEmployee);
                    EmployeesShowableList.Remove(SelectedEmployee);
                }
            }
        }
    }
}
