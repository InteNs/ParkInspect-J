using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkInspect.ViewModel;
using Data;

namespace ParkInspect.Repositories
{
    public class EmployeesRepository : IEmployeeRepository
    {
        private ParkInspectEntities _context;

        public EmployeesRepository(ParkInspectEntities context)
        {
            _context = context;
        }

        public bool Create(EmployeeViewModel employee)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<EmployeeViewModel> GetAll()
        {
            return new List<EmployeeViewModel>
            {
                new EmployeeViewModel(1, "Pim Westervoort", "Brabant", "Inspecteur"),
                new EmployeeViewModel(2, "Edward van Lieshout", "Brabant", "Inspecteur"),
                new EmployeeViewModel(3, "Mark Havekes", "Utrecht", "Inspecteur"),
                new EmployeeViewModel(4, "Pim Pam Pet", "Limburg", "Inspecteur"),
                new EmployeeViewModel(5, "Mathijs van Bree", "Limburg", "Directeur")
            };
        }

        public bool Update(EmployeeViewModel employee)
        {
            throw new NotImplementedException();
        }
    }
}
