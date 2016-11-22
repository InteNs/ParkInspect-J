using ParkInspect.ViewModel;
using System.Collections.Generic;

namespace ParkInspect.Repositories
{
    public class DummyEmployeesRepository : IEmployeeRepository
    {
        public bool Create(EmployeeViewModel employee)
        {
            return true;
        }

        public IEnumerable<EmployeeViewModel> GetAll()
        {
            return new List<EmployeeViewModel>
            {
                new EmployeeViewModel { Id = 1, Name = "Pim Westervoort", Region = "Brabant", Function = "Inspecteur", Email = "pim.west@hotmail.com"},
                new EmployeeViewModel { Id = 2, Name = "Edward van Lieshout", Region = "Brabant", Function = "Inspecteur", Email = "eddie.hout@gmail.com"},
                new EmployeeViewModel { Id = 3, Name = "Mark Havekes", Region = "Utrecht", Function = "Inspecteur", Email = "mark.havekes@gmail.com"},
                new EmployeeViewModel { Id = 4, Name = "Pim Pam Pet", Region = "Limburg", Function = "Inspecteur", Email = "pimpampet@hetnet.net"},
                new EmployeeViewModel { Id = 5, Name = "Mathijs van Bree", Region = "Limburg", Function = "Directeur", Email = "mattie@msn.com"}
            };
        }

        public bool Update(EmployeeViewModel employee)
        {
            return true;
        }

        public IEnumerable<string> GetRegions()
        {
            return new List<string>
            {
                "Limburg",
                "Utrecht",
                "Brabant"
            };
        }

        public IEnumerable<string> GetFunctions()
        {
            return new List<string>
            {
                "Directeur",
                "Inspecteur",
                "Manager"
            };
        }
    }
}
