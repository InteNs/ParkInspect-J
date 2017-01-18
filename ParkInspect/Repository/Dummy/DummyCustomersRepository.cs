using System.Collections.ObjectModel;
using ParkInspect.Repository.Interface;
using ParkInspect.ViewModel;

namespace ParkInspect.Repository.Dummy
{
    public class DummyCustomersRepository : ICustomerRepository
    {
        private ObservableCollection<CustomerViewModel> _customers;

        public DummyCustomersRepository() 
        {
            RefreshCustomers();
        }

        public bool Add(CustomerViewModel item)
        {
            _customers.Add(item);
            return true;
        }

        public ObservableCollection<CustomerViewModel> GetAll()
        {
            RefreshCustomers();
            return _customers;
        }

        public bool Delete(CustomerViewModel item) => _customers.Remove(item);

        public bool Update(CustomerViewModel customer) => true;

        public ObservableCollection<string> GetFunctions() => new ObservableCollection<string> { "klant" };

        private void RefreshCustomers()
        {
            if(_customers == null) _customers = new ObservableCollection<CustomerViewModel>();
            _customers.Clear();
            _customers.Add(new CustomerViewModel
            {
                Id = 1,
                Name = "Pim Westervoort",
                ZipCode = "5624KN",
                PhoneNumber = "06-tooawesomeforyou",
                StreetNumber = "1",
                Email = "pim.westervoort@gmail.com",
            });
            _customers.Add(new CustomerViewModel
            {
                Id = 2,
                Name = "Pim Westermoord",
                ZipCode = "4628JE",
                PhoneNumber = "06-tooawesomeforyou",
                StreetNumber = "1",
                Email = "pim.westermoord@gmail.com",
            });
            _customers.Add(new CustomerViewModel
            {
                Id = 3,
                Name = "Pim Westerman",
                ZipCode = "8466UT",
                PhoneNumber = "06-tooawesomeforyou",
                StreetNumber = "1",
                Email = "pim.westerman@gmail.com",
            });
            _customers.Add(new CustomerViewModel
            {
                Id = 4,
                Name = "Pim Westerpoort",
                ZipCode = "4878HE",
                PhoneNumber = "06-tooawesomeforyou",
                StreetNumber = "1",
                Email = "pim.westerpoort@gmail.com",
            });
            _customers.Add(new CustomerViewModel
            {
                Id = 5,
                Name = "Pim Westernoord",
                ZipCode = "9922KK",
                PhoneNumber = "06-tooawesomeforyou",
                StreetNumber = "1",
                Email = "pim.westernoord@gmail.com",
            });
        }
    }
}
