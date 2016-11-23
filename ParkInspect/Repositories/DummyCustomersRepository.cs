using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkInspect.ViewModel;

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
                new CustomerViewModel { Id = 1, Name = "Pim Westervoort", ZipCode = "5624KN", PhoneNumber = "06-tooawesomeforyou", StreetNumber = "1", Email = "pim.westervoort@gmail.com", Function = "Klant" },
                new CustomerViewModel { Id = 2, Name = "Pim Westermoord", ZipCode = "4628JE", PhoneNumber = "06-tooawesomeforyou", StreetNumber = "1", Email = "pim.westermoord@gmail.com", Function = "Klant" },
                new CustomerViewModel { Id = 3, Name = "Pim Westerman", ZipCode = "8466UT", PhoneNumber = "06-tooawesomeforyou", StreetNumber = "1", Email = "pim.westerman@gmail.com", Function = "Klant" },
                new CustomerViewModel { Id = 4, Name = "Pim Westerpoort", ZipCode = "4878HE", PhoneNumber = "06-tooawesomeforyou", StreetNumber = "1", Email = "pim.westerpoort@gmail.com", Function = "Klant" },
                new CustomerViewModel { Id = 5, Name = "Pim Westernoord", ZipCode = "9922KK", PhoneNumber = "06-tooawesomeforyou", StreetNumber = "1", Email = "pim.westernoord@gmail.com", Function = "Klant" }
            };
        }

        public bool Update(CustomerViewModel customer)
        {
            return true;
        }
    }
}
