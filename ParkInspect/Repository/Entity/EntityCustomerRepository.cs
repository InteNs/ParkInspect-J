using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using Data;
using ParkInspect.Repository.Interface;
using ParkInspect.ViewModel;

namespace ParkInspect.Repository.Entity
{
    class EntityCustomerRepository : ICustomerRepository
    {
        private readonly ParkInspectEntities _context;
        private readonly ObservableCollection<CustomerViewModel> _customers;

        public EntityCustomerRepository(ParkInspectEntities context)
        {
            _context = context;
            _customers = new ObservableCollection<CustomerViewModel>();
        }

        public ObservableCollection<CustomerViewModel> GetAll()
        {
            _customers.Clear();
            _context.Customer.Include("Person").Include("Person.Location").ToList()
                .ForEach(c => _customers.Add(new CustomerViewModel
                {
                    Email = c.Person.Email,
                    Name = c.Person.Name,
                    Id = c.Id,
                    PhoneNumber = c.Person.PhoneNumber,
                    StreetNumber = c.Person.Location.StreetNumber,
                    Region = c.Person.Location.Region.RegionName,
                    ZipCode = c.Person.Location.ZipCode
                }));

            return _customers;
        }

        public bool Add(CustomerViewModel item)
        {
            

            var region = _context.Region.FirstOrDefault(r => r.RegionName == item.Region) ??
                         _context.Region.Add(new Region {Guid = Guid.NewGuid(), RegionName = item.Region});

            var location = _context.Location.FirstOrDefault(l => l.ZipCode == item.ZipCode && l.StreetNumber ==item.StreetNumber) ??
                           _context.Location.Add(new Location {Region = region, ZipCode = item.ZipCode, StreetNumber = item.StreetNumber });

            var person = new Person { Location = location, Email = item.Email, Name = item.Name, PhoneNumber = item.PhoneNumber, Guid = Guid.NewGuid() };
            _context.Person.Add(person);

            var c = new Customer {Person = person, Guid = Guid.NewGuid()};

            _context.Customer.Add(c);
            _context.SaveChanges();
            var id = _context.Customer.Include("Person").Include("Person.Location").FirstOrDefault(cs => cs.Person.Name == item.Name && cs.Person.Location.StreetNumber == item.StreetNumber && cs.Person.Location.ZipCode == item.ZipCode).Id;
            item.Id = id;
            _customers.Add(item);
            return true;
        }

        public bool Delete(CustomerViewModel item)
        {
            throw new NotImplementedException();
        }

        public bool Update(CustomerViewModel item)
        {
            var customer = _context.Customer.Include("Person").Include("Person.Location").FirstOrDefault(c => c.Id == item.Id);
            if (customer == null) return false;
            customer.Person.Name = item.Name;
            customer.Person.Location.ZipCode = item.ZipCode;
            customer.Person.PhoneNumber = item.PhoneNumber;
            customer.Person.Email = item.Email;
            customer.Person.Location.StreetNumber = item.StreetNumber;
            customer.Person.Location.Region = _context.Region.FirstOrDefault(r => r.RegionName == item.Region);
            _context.Entry(customer).State = EntityState.Modified;
            _context.SaveChanges();

            var index = _customers.IndexOf(item);
            _customers.RemoveAt(index);
            _customers.Insert(index, item);
            return true;
        }

        public ObservableCollection<string> GetFunctions()
        {
            return new ObservableCollection<string>(new List<string> {"klant"});
        }
    }
}