using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ParkInspect.ViewModel
{
    public class EditEmployeeViewModel : ViewModelBase
    {

        private string _selectedRegion;

        public string SelectedRegion
        {
            get { return _selectedRegion; }
            set
            {
                _selectedRegion = value;
                base.RaisePropertyChanged();
            }
        }

        private string _selectedFunction;

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

        public EditEmployeeViewModel(EmployeeViewModel employeeVM)
        {
            SelectedEmployee = employeeVM;

            FunctionList = new List<string>();
            FunctionList.Add("Inspecteur");
            FunctionList.Add("Directeur");
            FunctionList.Add("Manager");

            RegionList = new List<string>();
            RegionList.Add("Limburg");
            RegionList.Add("Utrecht");
            RegionList.Add("Brabant");
        }
    }
}
