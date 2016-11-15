using ParkInspect.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkInspect.Repositories
{
    public interface IEmployeeRepository
    {
        IEnumerable<EmployeeViewModel> GetAll();
        bool Create(EmployeeViewModel employee);
        bool Update(EmployeeViewModel employee);
    }
}
