using ParkInspect.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data;
using System.Threading.Tasks;
using ParkInspect.ViewModel;
using System.Collections.ObjectModel;

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

            var location = _context.Location.FirstOrDefault(l => l.ZipCode == item.ZipCode && l.StreetNumber == item.StreetNumber) ??
                           _context.Location.Add(new Location { Region = region, ZipCode = item.ZipCode, StreetNumber = item.StreetNumber });

            var customer = _context.Customer.FirstOrDefault(c => c.Id == item.Customer.Id);
            var employee = _context.Employee.FirstOrDefault(e => e.Id == item.Employee.Id);
            var description = _context.Commission.FirstOrDefault(d => d.Description == item.Description);
            var dateCreated = _context.Commission.FirstOrDefault(d => d.DateCreated == item.DateCreated);
            var dateCompleted = _context.Commission.FirstOrDefault(d => d.DateCompleted == item.DateCompleted);

            var commission = new Commission { Customer = customer, Employee = employee, Guid = Guid.NewGuid() };

            _context.Commission.Add(commission);
            _commissions.Add(item);
            _context.SaveChanges();
            return true;
        }

        public bool Delete(CommissionViewModel item)
        {
            throw new NotImplementedException();
        }

        public ObservableCollection<CommissionViewModel> GetAll()
        {
            _commissions.Clear();
            _context.Commission.Include("Commission").ToList().
                ForEach(c => _commissions.Add(new CommissionViewModel
                {
                    Id = c.Id,
                    ZipCode = c.Location.ZipCode,
                    StreetNumber = c.Location.StreetNumber,
                    DateCreated = c.DateCreated,
                    DateCompleted = c.DateCompleted,
                    Description = c.Description,
                    //Employee = 
                    //Customer = 

                }));
            return _commissions;
           
        }

        public ObservableCollection<string> GetStatuses()
        {
            throw new NotImplementedException();
        }

        public bool Update(CommissionViewModel item)
        {
            throw new NotImplementedException();
        }
    }
}
