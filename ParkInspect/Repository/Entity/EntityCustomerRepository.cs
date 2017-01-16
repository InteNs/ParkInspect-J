﻿using System;
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
            _customers.Add(item);
            _context.SaveChanges();
            return true;
        }

        public bool Delete(CustomerViewModel item)
        {
            var customer = _context.Customer.Attach(new Customer {Id = item.Id});
            if (customer == null) return false;
            _context.Customer.Remove(customer);
            _context.SaveChanges();
            _customers.Remove(item);
            return true;
        }

        public bool Update(CustomerViewModel item)
        {
            var customer = _context.Customer.Attach(new Customer { Id = item.Id });
            var person = _context.Person.Attach(new Person {Email = item.Email, Name = item.Name});
            if (customer == null || person == null) return false;
            _context.Location.AddOrUpdate(new Location {StreetNumber = item.StreetNumber, ZipCode = item.ZipCode});
            _context.Entry(customer).State = EntityState.Modified;
            _context.Entry(person).State = EntityState.Modified;
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