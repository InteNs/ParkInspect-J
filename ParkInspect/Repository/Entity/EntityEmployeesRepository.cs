using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using ParkInspect.Repository.Interface;
using ParkInspect.ViewModel;

namespace ParkInspect.Repository.Entity
{
    public class EntityEmployeesRepository : IEmployeeRepository
    {
        private readonly ParkInspectEntities _context;
        private readonly ObservableCollection<EmployeeViewModel> _employees;

        public EntityEmployeesRepository(ParkInspectEntities context)
        {
            _context = context;
            _employees = new ObservableCollection<EmployeeViewModel>();
        }

        public ObservableCollection<EmployeeViewModel> GetAll()
        {
            _employees.Clear();
            _context.Employee.Include("Person").Include("Person.Location").Include("Person.Location.Region").Include("Function").ToList()
                .ForEach(e => _employees.Add(new EmployeeViewModel()
                {
                    Id = e.Id,
                    StreetNumber = e.Person.Location.StreetNumber,
                    EmploymentDate = e.DateHired,
                    DismissalDate = e.DateFired,
                    Region = e.Person.Location.Region.RegionName,
                    Function = e.Function.Name,
                    Email = e.Person.Email,
                    Name = e.Person.Name,
                    ZipCode = e.Person.Location.ZipCode,
                    PhoneNumber = e.Person.PhoneNumber
                }));
            //TODO:remove comments
            /*if (_employees.Count > 0)
            {
                return _employees;
            }*/

            _employees.Add(new EmployeeViewModel()
            {
                Id = 1,
                StreetNumber = "1",
                EmploymentDate = DateTime.Now,
                DismissalDate = null,
                Region = "Limboland",
                Function = "manager",
                Email = "admin@parkinspect.nl",
                Name = "admin",
                ZipCode = "121212",
                PhoneNumber = "0900090909"
            });

            return _employees;
        }

        public bool Add(EmployeeViewModel item)
        {
            var region = _context.Region.FirstOrDefault(r => r.RegionName == item.Region) ??
                         _context.Region.Add(new Region { Guid = Guid.NewGuid(), RegionName = item.Region });

            var location = _context.Location.FirstOrDefault(l => l.ZipCode == item.ZipCode && l.StreetNumber == item.StreetNumber) ??
                           _context.Location.Add(new Location { Region = region, ZipCode = item.ZipCode, StreetNumber = item.StreetNumber });

            var function = _context.Function.FirstOrDefault(f => f.Name == item.Function);

            var person = new Person { Location = location, Email = item.Email, Name = item.Name, PhoneNumber = item.PhoneNumber, Guid = Guid.NewGuid() };
            _context.Person.Add(person);

            var e = new Employee() { Person = person, Guid = Guid.NewGuid(), Function = function};

            _context.Employee.Add(e);
            _context.SaveChanges();

            var id = _context.Employee.Include("Person").Include("Person.Location").FirstOrDefault(em => em.Person.Name == item.Name&&em.Person.Location.StreetNumber == item.StreetNumber&&em.Person.Location.ZipCode == item.ZipCode).Id;
            item.Id = id;
            _employees.Add(item);
            return true;
        }

        public bool Delete(EmployeeViewModel item)
        {
            var employee = _context.Employee.Include("Person").Include("Person.Location").Include("Person.Location.Region").Include("Function").FirstOrDefault(e => e.Id == item.Id);
            employee.DateFired = DateTime.Now;
            if (employee == null) return false;
            _context.Entry(employee).State = EntityState.Modified;
            _context.SaveChanges();
            _employees.Remove(item);
            return true;
        }

        public bool Update(EmployeeViewModel item)
        {
            var employee = _context.Employee.Include("Person").Include("Person.Location").Include("Person.Location.Region").Include("Function").FirstOrDefault(e => e.Id == item.Id);
            employee.Person.Name = item.Name;
            employee.Person.Location.ZipCode = item.ZipCode;
            employee.Person.PhoneNumber = item.PhoneNumber;
            employee.Person.Email = item.Email;
            employee.Person.Location.StreetNumber = item.StreetNumber;
            employee.Function = _context.Function.FirstOrDefault(f => f.Name == item.Function);
            employee.Person.Location.Region = _context.Region.FirstOrDefault(r => r.RegionName == item.Region);
            if (employee == null) return false;
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

        public IEnumerable<EmployeeViewModel> GetByFunction(string function)
        {
            return _employees.Where(e => e.Function.Equals(function));
        }
    }
}
