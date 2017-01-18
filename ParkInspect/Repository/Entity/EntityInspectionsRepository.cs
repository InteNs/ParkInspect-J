using ParkInspect.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkInspect.ViewModel;
using System.Collections.ObjectModel;
using Data;
using System.Data.Entity;

namespace ParkInspect.Repository.Entity
{
    class EntityInspectionsRepository : IInspectionsRepository
    {

        private readonly ParkInspectEntities _context;
        private readonly ObservableCollection<InspectionViewModel> _inspections;

        public EntityInspectionsRepository(ParkInspectEntities context)
        {
            _context = context;
            _inspections = new ObservableCollection<InspectionViewModel>();
        }


        public bool Add(InspectionViewModel item)
        {
            var commission = _context.Commission.FirstOrDefault(c => c.Id == item.cvm.Id);
            var i = new Inspection { Guid = Guid.NewGuid(), DateTimeStart = item.StartTime, Commission = commission, DateTimeEnd = null, DateCancelled=null, };

            _context.Inspection.Add(i);
            _context.SaveChanges();
            _inspections.Add(item);
            return true;
        }

        public bool Delete(InspectionViewModel item)
        {
            var inspection = _context.Question.Include("QuestionType").FirstOrDefault(i => i.Id == item.Id);
            if (inspection != null)
            {
                _context.Entry(inspection).State = EntityState.Modified;
                _context.SaveChanges();
                _inspections.Remove(item);
                return true;
            }
            else
            {
                return false;
            }
        }

        public ObservableCollection<InspectionViewModel> GetAll()
        {
            _inspections.Clear();
            if(_context.Inspection.Count() == 0)
            {
                return _inspections;
            }


            var inspections = _context.Inspection.Include("Commission").
                Include("Commission.Employee").
                Include("Commission.Customer").ToList();

            foreach (var i in inspections)
            {
                _inspections.Add(new InspectionViewModel()
                {
                    Id = i.Id,
                    Name = "Inspectie : " + i.Commission.Description,
                    StartTime = i.DateTimeStart,
                    EndTime = Convert.ToDateTime(i.DateTimeEnd),
                    cvm = new CommissionViewModel()
                    {
                        Id = i.Commission.Id,
                        Description = i.Commission.Description,
                        StreetNumber = i.Commission.Location.StreetNumber,
                        ZipCode = i.Commission.Location.ZipCode,
                        Region = i.Commission.Location.Region.RegionName,
                        DateCreated = i.Commission.DateCreated,
                        DateCompleted = i.Commission.DateCompleted,
                        //Frequency = i.Commission.Frequency,
                        //Status= i.Commission.Status   
                        Customer = new CustomerViewModel()
                        {
                            Id = i.Commission.CustomerId,
                            Name = i.Commission.Customer.Person.Name,
                            Email = i.Commission.Customer.Person.Email,
                            PhoneNumber = i.Commission.Customer.Person.PhoneNumber,
                            StreetNumber = i.Commission.Customer.Person.Location.StreetNumber,
                            ZipCode = i.Commission.Customer.Person.Location.ZipCode,
                            Region = i.Commission.Customer.Person.Location.Region.RegionName,
                        },
                        Employee = new EmployeeViewModel()
                        {
                            Id = i.Commission.EmployeeId,
                            Name = i.Commission.Employee.Person.Name,
                            Email = i.Commission.Employee.Person.Email,
                            PhoneNumber = i.Commission.Employee.Person.PhoneNumber,
                            StreetNumber = i.Commission.Employee.Person.Location.StreetNumber,
                            ZipCode = i.Commission.Employee.Person.Location.ZipCode,
                            Region = i.Commission.Employee.Person.Location.Region.RegionName,
                            Function = i.Commission.Employee.Function.Name
                        },
                    }
                });
            }
            
            return _inspections;
        }

        public bool Update(InspectionViewModel item)
        {
            var inspections = _context.Inspection.FirstOrDefault(i => i.Id == item.Id);
            inspections.DateTimeStart = item.StartTime;
            inspections.DateTimeEnd = item.EndTime;
            if (inspections == null) return false;
            _context.Entry(inspections).State = EntityState.Modified;
            _context.SaveChanges();

            var index = _inspections.IndexOf(item);
            _inspections.RemoveAt(index);
            _inspections.Insert(index, item);
            return true;
        }
    }
}
