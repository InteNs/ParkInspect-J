using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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
                    Function = "Manager",
                    Email = "pim.west@hotmail.com",
                    EmploymentDate = new DateTime(2015, 03, 18),
                    DismissalDate = new DateTime(2016, 12, 12)
                },
                new EmployeeViewModel
                {
                    Id = 2,
                    Name = "Edward van Lieshout",
                    Region = "Brabant",
                    Function = "Inspecteur",
                    Email = "eddie.hout@gmail.com",
                    EmploymentDate = new DateTime(2014, 03, 18)
                },
                new EmployeeViewModel
                {
                    Id = 3,
                    Name = "Mark Havekes",
                    Region = "Utrecht",
                    Function = "Inspecteur",
                    Email = "mark.havekes@gmail.com",
                    EmploymentDate = new DateTime(2016, 06, 12)
                },
                new EmployeeViewModel
                {
                    Id = 4,
                    Name = "Pim Pam Pet",
                    Region = "Limburg",
                    Function = "Inspecteur",
                    Email = "pimpampet@hetnet.net",
                    EmploymentDate = new DateTime(2011, 01, 20)
                },
                new EmployeeViewModel
                {
                    Id = 5,
                    Name = "Mathijs van Bree",
                    Region = "Limburg",
                    Function = "Directeur",
                    Email = "mattie@msn.com",
                    EmploymentDate = new DateTime(2015, 07, 28)
                },
                new EmployeeViewModel
                {
                    Id = 301,
                    Name = "Admin",
                    Region = "Limburg",
                    Function = "Directeur",
                    Email = "mattie@msn.com",
                    EmploymentDate = new DateTime(2015, 07, 28)
                },
                new EmployeeViewModel
                {
                    Id = 302,
                    Name = "Henk",
                    Region = "Limburg",
                    Function = "Inspecteur",
                    Email = "mattie@msn.com",
                    EmploymentDate = new DateTime(2015, 07, 28)
                }
            };

        }

        public bool Add(EmployeeViewModel item)
        {
            _employees.Add(item);
            return true;
        }

        public bool Delete(EmployeeViewModel item) => _employees.Remove(item);

        public ObservableCollection<EmployeeViewModel> GetAll() => _employees;

        public bool Update(EmployeeViewModel item)
        {
            var index = _employees.IndexOf(item);
            if (index < 0) return false;
            _employees.RemoveAt(index);
            _employees.Insert(index, item);
            return true;

        }

        public ObservableCollection<string> GetFunctions() => new ObservableCollection<string> { "Manager", "Inspecteur", "Directeur" };

        public IEnumerable<EmployeeViewModel> GetByFunction(string function) => _employees.Where(e => e.Function.Equals(function));
    }
}
