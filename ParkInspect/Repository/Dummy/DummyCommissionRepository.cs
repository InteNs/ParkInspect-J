using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkInspect.ViewModel;

namespace ParkInspect.Repositories
{
    public class DummyCommissionRepository : ICommissionRepository
    {

        private List<CommissionViewModel> commissions;
        private List<LocationViewModel> locations;
        private List<CustomerViewModel> customers;

        public DummyCommissionRepository()
        {
            locations = new List<LocationViewModel>();
            customers = new List<CustomerViewModel>
            {
                new CustomerViewModel { Id = 1, Name = "Pim Westervoort", ZipCode = "5624KN", PhoneNumber = "06-tooawesomeforyou", StreetNumber = "1", Email = "pim.westervoort@gmail.com", Function = "Klant" },
                new CustomerViewModel { Id = 2, Name = "Pim Westermoord", ZipCode = "4628JE", PhoneNumber = "06-tooawesomeforyou", StreetNumber = "1", Email = "pim.westermoord@gmail.com", Function = "Klant" },
                new CustomerViewModel { Id = 3, Name = "Pim Westerman", ZipCode = "8466UT", PhoneNumber = "06-tooawesomeforyou", StreetNumber = "1", Email = "pim.westerman@gmail.com", Function = "Klant" },
                new CustomerViewModel { Id = 4, Name = "Pim Westerpoort", ZipCode = "4878HE", PhoneNumber = "06-tooawesomeforyou", StreetNumber = "1", Email = "pim.westerpoort@gmail.com", Function = "Klant" },
                new CustomerViewModel { Id = 5, Name = "Pim Westernoord", ZipCode = "9922KK", PhoneNumber = "06-tooawesomeforyou", StreetNumber = "1", Email = "pim.westernoord@gmail.com", Function = "Klant" }
            };

            commissions = new List<CommissionViewModel>();
            commissions.Add(new CommissionViewModel(1, 1, 1, 1, 1, new DateTime(2016, 11, 17, 19, 57, 0), new DateTime(2016, 11, 19, 20, 13, 0), "Test Description 1", "Limburg", "Pim Westervoort", "Nieuw"));
            commissions.Add(new CommissionViewModel(2, 1, 2, 2, 2, new DateTime(2016, 10, 5, 19, 57, 0), null, "Test Description 2", "Utrecht", "Pim Westermoord", "Bezig"));
            commissions.Add(new CommissionViewModel(3, 2, 3, 1, null, new DateTime(2016, 11, 17, 19, 57, 0), null, "Test Description 3", "Brabant", "Pim Westerman", "Klaar"));
        }

        public IEnumerable<CustomerViewModel> GetCustomers()
        {
            return customers;
        }
        public IEnumerable<CommissionViewModel> GetAll()
        {
            return commissions;
        }
        

        public bool Create(CommissionViewModel commission)
        {
            commissions.Add(commission);
            return true;
        }

        public bool Update(CommissionViewModel commission)
        {
            return true;
        }

        public void Delete(CommissionViewModel commission)
        {
            throw new NotImplementedException();
        }

        

        public void CreateLocation(LocationViewModel location)
        {
            locations.Add(location);
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

        public IEnumerable<LocationViewModel> GetLocationViewModels()
        {
            return locations;
        }
    }
}
