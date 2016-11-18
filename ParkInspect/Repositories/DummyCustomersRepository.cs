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
                new CustomerViewModel(1, "Pim Westervoort", "5624KN", "06-tooawesomeforyou", 1, "pim.westervoort@gmail.com", "Noord-Brabant", "Klant"),
                new CustomerViewModel(2, "Pim Westermoord", "4628JE", "06-tooawesomeforyou", 1, "pim.westermoort@gmail.com", "Noord-Holland", "Klant"),
                new CustomerViewModel(3, "Pim Westerman", "8466UT", "06-tooawesomeforyou", 1, "pim.westerman@gmail.com", "Limburg", "Klant"),
                new CustomerViewModel(4, "Pim Westerpoort", "4878HE", "06-tooawesomeforyou", 1, "pim.westerpoort@gmail.com", "Zuid-Holland", "Klant"),
                new CustomerViewModel(5, "Pim Westernoord", "9922KK", "06-tooawesomeforyou", 1, "pim.westernoord@gmail.com", "Utrecht", "Klant")
            };
        }

        public bool Update(CustomerViewModel customer)
        {
            return true;
        }
    }
}
