using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;
using System.Linq;
using Data;
using ParkInspect.Repository.Interface;
using ParkInspect.ViewModel;

namespace ParkInspect.Repository.Entity
{
    public class EntityEmployeesRepository : IEmployeeRepository
    {
        private readonly ParkInspectEntities _context;
        private readonly ObservableCollection<EmployeeViewModel> _employees;
        private bool AddedThisSession = false;

        public EntityEmployeesRepository(ParkInspectEntities context)
        {
            _context = context;
            _employees = new ObservableCollection<EmployeeViewModel>();
        }

        public ObservableCollection<EmployeeViewModel> GetAll()
        {
            _employees.Clear();
            _context.Employee.Include("Person").Include("Person.Location").Include("Person.Location.Region").Include("Function").ToList()
                .ForEach(employee => _employees.Add(new EmployeeViewModel()
                {
                    Id = employee.Id,
                    StreetNumber = employee.Person.Location.StreetNumber,
                    EmploymentDate = employee.DateHired,
                    DismissalDate = employee.DateFired,
                    Region = employee.Person.Location.Region.RegionName,
                    Function = employee.Function.Name,
                    Email = employee.Person.Email,
                    Name = employee.Person.Name,
                    ZipCode = employee.Person.Location.ZipCode,
                    PhoneNumber = employee.Person.PhoneNumber
                }));
            return _employees;
        }

        public bool Add(EmployeeViewModel item)
        {
            var region = _context.Region.FirstOrDefault(r => r.RegionName == item.Region) ??
                         _context.Region.Add(new Region { Guid = Guid.NewGuid(), RegionName = item.Region });
            _context.SaveChanges();

            var location = _context.Location.FirstOrDefault(l => l.ZipCode == item.ZipCode && l.StreetNumber == item.StreetNumber) ??
                           _context.Location.Add(new Location { Region = region, ZipCode = item.ZipCode, StreetNumber = item.StreetNumber });
            _context.SaveChanges();

            var function = _context.Function.FirstOrDefault(f => f.Name == item.Function);

            var person = new Person { Location = location, Email = item.Email, Name = item.Name, PhoneNumber = item.PhoneNumber, Guid = Guid.NewGuid() };
            _context.Person.Add(person);
            _context.SaveChanges();

            var employee = new Employee { Person = person, Guid = Guid.NewGuid(), Function = function};

            _context.Employee.Add(employee);
            _context.SaveChanges();
            item.Id = employee.Id;
            _employees.Add(item);
            AddedThisSession = true;
            return true;
        }

        public bool Delete(EmployeeViewModel item)
        {
            if (AddedThisSession)
            {
                var context = ((IObjectContextAdapter)_context).ObjectContext;
                var refreshableObjects = _context.ChangeTracker.Entries().Select(c => c.Entity).ToList();
                context.Refresh(RefreshMode.StoreWins, refreshableObjects);
            }

            var employee = _context.Employee.Include("Person").Include("Person.Location").Include("Person.Location.Region").Include("Function").FirstOrDefault(e => e.Id == item.Id);
            if (employee == null) return false;
            employee.DateFired = DateTime.Now;
            _context.Entry(employee).State = EntityState.Modified;
            _context.SaveChanges();
            _employees.Remove(item);
            return true;
        }

        public bool Update(EmployeeViewModel item)
        {
            var employee = _context.Employee.Include("Person").Include("Person.Location").Include("Person.Location.Region").Include("Function").FirstOrDefault(e => e.Id == item.Id);
            if (employee == null) return false;
            employee.Person.Name = item.Name;
            employee.Person.Location.ZipCode = item.ZipCode;
            employee.Person.PhoneNumber = item.PhoneNumber;
            employee.Person.Email = item.Email;
            employee.Person.Location.StreetNumber = item.StreetNumber;
            employee.Function = _context.Function.FirstOrDefault(f => f.Name == item.Function);
            employee.Person.Location.Region = _context.Region.FirstOrDefault(r => r.RegionName == item.Region);
            _context.Entry(employee).State = EntityState.Modified;
            _context.SaveChanges();

            var index = _employees.IndexOf(item);
            _employees.RemoveAt(index);
            _employees.Insert(index, item);
            return true;
        }

        public ObservableCollection<string> GetFunctions()
        {
            var functions = new ObservableCollection<string>();
            _context.Function.ToList().ForEach(f => functions.Add(f.Name));
            return functions;
        }

        public IEnumerable<EmployeeViewModel> GetByFunction(string function) => _employees.Where(e => e.Function.Equals(function));
    }
}
