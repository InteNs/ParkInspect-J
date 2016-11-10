using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public ICommand ShowAddEmployeeCommand { get; set; }

        public ICommand ShowEditEmployeeCommand { get; set; }

        public ICommand SetEmployeeSuspendedCommand { get; set; }

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

        public EmployeesViewModel()
        {
            //Test data
            EmployeeViewModel e1 = new EmployeeViewModel(1,"Pim Westervoort","Brabant","Inspecteur");
            EmployeeViewModel e2 = new EmployeeViewModel(2, "Edward van Lieshout", "Brabant", "Inspecteur");
            EmployeeViewModel e3 = new EmployeeViewModel(3, "Mark Havekes", "Utrecht", "Inspecteur");
            EmployeeViewModel e4 = new EmployeeViewModel(4, "Pim Pam Pet", "Limburg", "Inspecteur");
            EmployeeViewModel e5 = new EmployeeViewModel(5, "Mathijs van Bree", "Limburg", "Directeur");

            EmployeesCompleteList = new ObservableCollection<EmployeeViewModel>();

            EmployeesCompleteList.Add(e1);
            EmployeesCompleteList.Add(e2);
            EmployeesCompleteList.Add(e3);
            EmployeesCompleteList.Add(e4);
            EmployeesCompleteList.Add(e5);

            EmployeesShowableList = new ObservableCollection<EmployeeViewModel>();

            EmployeesCompleteList.ToList().ForEach(e => EmployeesShowableList.Add(e));

            SearchCategoryList = new List<string>();
            SearchCategoryList.Add("Naam");
            SearchCategoryList.Add("ID");
            SearchCategoryList.Add("Regio");
            SearchCategoryList.Add("Functie");

            Category = SearchCategoryList.First();

            SearchEmployeesCommand = new SearchEmployeesCommand(this);
        }

        private bool EmployeeIsNotNull()
        {
            return SelectedEmployee != null;
        }
    }
}
