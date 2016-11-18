using Data;
using GalaSoft.MvvmLight;
using ParkInspect.DummyModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkInspect.ViewModel
{

    public class EmployeeViewModel : ViewModelBase
    {

        private Employee _employee;

        public int Id
        {
            get { return _employee.Id; }
            set
            {
                _employee.Id = value;
                base.RaisePropertyChanged("Id");
            }
        }

        public System.DateTime Employment_Date
        {
            get { return _employee.Employment_Date; }
            set
            {
                _employee.Employment_Date = value;
                base.RaisePropertyChanged("Employment_Date");
            }
        }

        public System.DateTime Dismissal_Date
        {
            get { return _employee.Dismissal_Date; }
            set
            {
                _employee.Dismissal_Date = value;
                base.RaisePropertyChanged("Dismissal_Date");
            }
        }

        public virtual Region Region
        {
            get { return _employee.Region; }
            set
            {
                _employee.Region = value;
                base.RaisePropertyChanged("Region");
            }
        }

        public virtual Function Function
        {
            get { return _employee.Function; }
            set
            {
                _employee.Function = value;
                base.RaisePropertyChanged("Function");
            }
        }

        public virtual Person Person
        {
            get { return _employee.Person; }
            set
            {
                _employee.Person = value;
                base.RaisePropertyChanged("Person");
            }
        }

        public EmployeeViewModel( Employee employee)
        {
            _employee = employee;
        }

        public EmployeeViewModel()
        {
            _employee = new Employee();
            _employee.Person = new Person();
            _employee.Region = new Region();
            _employee.Function = new Function();
        }


        //For testing
        public EmployeeViewModel(int id, string name, string region, string function)
        {
            _employee = new Employee();
            _employee.Id = id;
            _employee.Person = new Person();
            Person.Name = name;
            _employee.Region = new Region();
            Region.Name = region;
            _employee.Function = new Function();
            Function.Name = function;
        }
    }
}
