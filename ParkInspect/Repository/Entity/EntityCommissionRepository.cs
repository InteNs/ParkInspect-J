using ParkInspect.Repository.Interface;
using System;
using System.Linq;
using Data;
using ParkInspect.ViewModel;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace ParkInspect.Repository.Entity
{
    public class EntityCommissionRepository : ICommissionRepository
    {
        private readonly ParkInspectEntities _context;
        private readonly ObservableCollection<CommissionViewModel> _commissions;

        public EntityCommissionRepository(ParkInspectEntities context)
        {
            _context = context;
            _commissions = new ObservableCollection<CommissionViewModel>();
        }

        public bool Add(CommissionViewModel item)
        {
            var region = _context.Region.FirstOrDefault(r => r.RegionName == item.Region) ??
                         _context.Region.Add(new Region { Guid = Guid.NewGuid(), RegionName = item.Region });
            _context.SaveChanges();
            var location = _context.Location.FirstOrDefault(l => l.ZipCode == item.ZipCode && l.StreetNumber == item.StreetNumber) ??
                           _context.Location.Add(new Location { Region = region, ZipCode = item.ZipCode, StreetNumber = item.StreetNumber, Guid = Guid.NewGuid()});
            _context.SaveChanges();
            var customer = _context.Customer.FirstOrDefault(c => c.Id == item.Customer.Id);
            var employee = _context.Employee.FirstOrDefault(e => e.Id == item.Employee.Id);

            var commission = new Commission { Description = item.Description, Customer = customer, Employee = employee, Location = location, DateCreated = item.DateCreated, DateCompleted = item.DateCompleted, Guid = Guid.NewGuid() };

            _context.Commission.Add(commission);
            _context.SaveChanges();
            item.Id = commission.Id;
            _commissions.Add(item);
            return true;
        }

        public bool Delete(CommissionViewModel item)
        {
            var commission = _context.Commission.Attach(new Commission { Id = item.Id });
            if (commission == null) return false;
            _context.Commission.Remove(commission);
            _context.SaveChanges();
            _commissions.Remove(item);
            return true;
        }

        public ObservableCollection<CommissionViewModel> GetAll()
        {
            _commissions.Clear();
            
            var commission = _context.Commission.Include("Location").Include("Location.Region").Include("Employee").Include("Customer").Include("Customer.Person").Include("Customer.Person.Location").Include("Employee.Person").Include("Employee.Person.Location").ToList();

            foreach (var c in commission)
            {
                _commissions.Add(new CommissionViewModel()
                {
                    Id = c.Id,
                    ZipCode = c.Location.ZipCode,
                    StreetNumber = c.Location.StreetNumber,
                    DateCreated = c.DateCreated,
                    DateCompleted = c.DateCompleted,
                    Description = c.Description,
                    Status = c.Status,
                    Region = c.Location.Region.RegionName,
                    Customer = new CustomerViewModel
                    {
                        Email = c.Customer.Person.Email,
                        Name = c.Customer.Person.Name,
                        Id = c.Customer.Id,
                        PhoneNumber = c.Customer.Person.PhoneNumber,
                        StreetNumber = c.Customer.Person.Location.StreetNumber,
                        ZipCode = c.Customer.Person.Location.ZipCode
                    },
                    Employee = new EmployeeViewModel()
                    {
                        Email = c.Employee.Person.Email,
                        Name = c.Employee.Person.Name,
                        Id = c.Employee.Id,
                        PhoneNumber = c.Employee.Person.PhoneNumber,
                        StreetNumber = c.Employee.Person.Location.StreetNumber,
                        ZipCode = c.Employee.Person.Location.ZipCode
                    }
                });
            }
            return _commissions;           
        }

        public ObservableCollection<string> GetStatuses() => new ObservableCollection<string> { "Nieuw", "Ingedeeld", "Bezig", "Klaar" };

        public bool Update(CommissionViewModel item)
        {
            //var commission = _context.Commission.Attach(new Commission { Id = item.Id });
            //var person = _context.Person.Attach(new Person { Email = item.Email, Name = item.Name });
            var commission = _context.Commission.Include("Location").Include("Location.Region").Include("Employee").Include("Customer").FirstOrDefault(c => c.Id == item.Id);
            if (commission == null) return false;
            commission.Id = item.Id;
            commission.Description = item.Description;
            commission.DateCompleted = item.DateCompleted;
            commission.CustomerId = item.Customer.Id;
            commission.EmployeeId = item.Employee.Id;
            commission.Location.Region.RegionName = item.Region;

            
            _context.Location.AddOrUpdate(new Location { StreetNumber = item.StreetNumber, ZipCode = item.ZipCode });
            _context.Entry(commission).State = EntityState.Modified;
            _context.SaveChanges();

            var index = _commissions.IndexOf(item);
            _commissions.RemoveAt(index);
            _commissions.Insert(index, item);
            return true;
        }
    }
}
