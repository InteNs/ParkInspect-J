using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkInspect.ViewModel;
using ParkInspect.DummyModel;

namespace ParkInspect.Repositories
{
    public class DummyCustomersRepository : ICustomerRepository
    {
        public bool Create(CustomerViewModel customer)
        {
            return true;
        }

        public IEnumerable<CustomerViewModel> GetAll()
        {
            return new List<CustomerViewModel>
            {
                new CustomerViewModel(1, "Pim Westervoort", "5624KN", "06-tooawesomeforyou", 1, "pim.westervoort@gmail.com", "Noord-Brabant", "customer")
            };
        }

        public bool Update(CustomerViewModel customer)
        {
            return true;
        }
    }
}
