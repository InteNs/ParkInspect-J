using ParkInspect.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkInspect.Repositories
{
    public interface ICustomerRepository
    {
        IEnumerable<CustomerViewModel> GetAll();
        bool Create(CustomerViewModel customer);
        bool Update(CustomerViewModel customer);
    }
}
