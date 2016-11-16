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
using System.Windows.Forms;
using System.Windows.Input;

namespace ParkInspect.ViewModel
{
    public class EmployeesViewModel : ViewModelBase
    {

        public ObservableCollection<EmployeeViewModel> EmployeesCompleteList { get; set; }

        public ObservableCollection<EmployeeViewModel> EmployeesShowableList { get; set; }

        public List<string> SearchCategoryList { get; set; }

        private EmployeeViewModel _selectedEmployee;

        public EmployeeViewModel SelectedEmployee
        {
            get { return _selectedEmployee; }
            set
            {
                _selectedEmployee = value;
                base.RaisePropertyChanged();
            }
        }

        public ICommand SearchEmployeesCommand { get; set; }

        public ICommand SetEmployeeDismissCommand { get; set; }

        public ICommand ShowEditEmployeeCommand { get; set; }

        private string _input;

        public string Input {
            get { return _input; }
            set
            {
                _input = value;
                base.RaisePropertyChanged();
            }
        }

        private string _category;

        public string Category
        {
            get { return _category; }
            set
            {
                _category = value;
                base.RaisePropertyChanged();
            }
        }

        private IEmployeeRepository _repo;

        public EmployeesViewModel(IEmployeeRepository repo)
        {
            _repo = repo;

            EmployeesCompleteList = new ObservableCollection<EmployeeViewModel>(_repo.GetAll());

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
            
        }

        private void DismissEmployee()
        {
            var result = MessageBox.Show("Weet u zeker dat u " + SelectedEmployee.Person.Name + " op non-actief wilt zetten?", "Werknemer op non-actief zetten", MessageBoxButtons.YesNo);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                SelectedEmployee.Dismissal_Date = DateTime.Now;
                _repo.UpdateDismiss(SelectedEmployee);
            }
        }
    }
}
