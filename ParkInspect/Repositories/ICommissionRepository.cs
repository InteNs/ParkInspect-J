using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkInspect.ViewModel;

namespace ParkInspect.Repositories
{
    public interface ICommissionRepository
    {
        IEnumerable<CommissionViewModel> GetAll();
        
        bool Create(CommissionViewModel commission);
        bool Update(CommissionViewModel commission);
        void Delete(CommissionViewModel commission);

        void CreateLocation(LocationViewModel location);


        IEnumerable<string> GetRegions();
        IEnumerable<CustomerViewModel> GetCustomers();
        IEnumerable<EmployeeViewModel> GetEmployees();
        IEnumerable<LocationViewModel> GetLocationViewModels();

    }
}
