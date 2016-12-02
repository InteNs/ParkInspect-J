using System.Collections.Generic;
using System.Collections.ObjectModel;
using ParkInspect.Repository.Interface;
using ParkInspect.ViewModel;

namespace ParkInspect.Repository.Dummy
{
    public class DummyEmployeesRepository : IEmployeeRepository
    {
        private readonly ObservableCollection<EmployeeViewModel> _employees;

        public DummyEmployeesRepository()
        {
            _employees = new ObservableCollection<EmployeeViewModel>
            {
                new EmployeeViewModel
                {
                    Id = 1,
                    Name = "Pim Westervoort",
                    Region = "Brabant",
                    Function = "Inspecteur",
                    Email = "pim.west@hotmail.com"
                },
                new EmployeeViewModel
                {
                    Id = 2,
                    Name = "Edward van Lieshout",
                    Region = "Brabant",
                    Function = "Inspecteur",
                    Email = "eddie.hout@gmail.com"
                },
                new EmployeeViewModel
                {
                    Id = 3,
                    Name = "Mark Havekes",
                    Region = "Utrecht",
                    Function = "Inspecteur",
                    Email = "mark.havekes@gmail.com"
                },
                new EmployeeViewModel
                {
                    Id = 4,
                    Name = "Pim Pam Pet",
                    Region = "Limburg",
                    Function = "Inspecteur",
                    Email = "pimpampet@hetnet.net"
                },
                new EmployeeViewModel
                {
                    Id = 5,
                    Name = "Mathijs van Bree",
                    Region = "Limburg",
                    Function = "Directeur",
                    Email = "mattie@msn.com"
                }
            };

        }

        public bool Add(EmployeeViewModel item)
        {
            _employees.Add(item);
            return true;
        }

        public bool Delete(EmployeeViewModel item)
        {
            return _employees.Remove(item);
        }

        public ObservableCollection<EmployeeViewModel> GetAll()
        {
            return _employees;
        }

        public bool Update(EmployeeViewModel item)
        {
            var index = _employees.IndexOf(item);
            if (index < 0) return false;
            _employees.RemoveAt(index);
            _employees.Insert(index, item);
            return true;

        }

        public ObservableCollection<string> GetFunctions()
        {
            return new ObservableCollection<string>
            {
                "Manager", "Inspecteur", "Directeur"
            };
        }
    }
}
