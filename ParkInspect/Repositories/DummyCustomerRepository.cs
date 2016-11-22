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

        public bool Create(CustomerViewModel customer)
        {
            return true;
        }

        public IEnumerable<CustomerViewModel> GetAll()
        {
            return new List<CustomerViewModel>
            {
                new CustomerViewModel(1, "Pim Westervoort", "1234AB", "5497" , 61, "e@mail.com", "Klant"),
                new CustomerViewModel(2, "Edward van Lieshout", "1234AB", "5497", 61, "e@mail.com", "Klant"),
                new CustomerViewModel(3, "Mark Havekes", "1234AB", "5497" , 61, "e@mail.com", "Klant"),
                new CustomerViewModel(4, "Pim Pam Pet","1234AB", "5497" , 61, "e@mail.com", "Klant"),
                new CustomerViewModel(5, "Mathijs van Bree", "1234AB", "5497" , 61, "e@mail.com", "Klant")
            };
        }

        public bool Update(CustomerViewModel customer)
        {
            return true;
        }
    }
}
