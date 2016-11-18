using ParkInspect.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkInspect.Repositories
{
    class DummyCustomerRepository : ICustomerRepository
    {
        private CustomerViewModel _evm;

        public bool Create(CustomerViewModel customer)
        {
            return true;
        }

        public IEnumerable<CustomerViewModel> GetAll()
        {
            return new List<CustomerViewModel>
            {
                new CustomerViewModel(1, "Pim Westervoort", "Brabant", "Inspecteur"),
                new CustomerViewModel(2, "Edward van Lieshout", "Brabant", "Inspecteur"),
                new CustomerViewModel(3, "Mark Havekes", "Utrecht", "Inspecteur"),
                new CustomerViewModel(4, "Pim Pam Pet", "Limburg", "Inspecteur"),
                new CustomerViewModel(5, "Mathijs van Bree", "Limburg", "Directeur")
            };
        }

        public bool Update(CustomerViewModel customer)
        {
            return true;
        }
    }
}
