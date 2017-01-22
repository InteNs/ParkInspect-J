using ParkInspect.Repository.Interface;
using System;
using System.Linq;
using ParkInspect.ViewModel;
using System.Collections.ObjectModel;
using Data;
using System.Data.Entity;

namespace ParkInspect.Repository.Entity
{
    public class EntityInspectionsRepository : IInspectionsRepository
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
            if (!_context.Commission.Any())
            {
                return false;
            }
            var commission = _context.Commission.FirstOrDefault(c => c.Id == item.CommissionViewModel.Id);
            var inspection = new Inspection { Guid = Guid.NewGuid(), CommissionId = commission.Id, CommissionGuid = commission.Guid, DateTimeStart = item.StartTime, Commission = commission, DateTimeEnd = null, DateCancelled = null };

            _context.Inspection.Add(inspection);
            _context.SaveChanges();
            item.Id = inspection.Id;
            _inspections.Add(item);
            return true;
        }

        public bool Delete(InspectionViewModel item)
        {
            var inspection = _context.Question.Include("QuestionType").FirstOrDefault(i => i.Id == item.Id);
            if (inspection == null) return false;
            _context.Entry(inspection).State = EntityState.Modified;
            _context.SaveChanges();
            _inspections.Remove(item);
            return true;
        }

        public ObservableCollection<InspectionViewModel> GetAll()
        {
            _inspections.Clear();
            if (!_context.Inspection.Any())
            {
                return _inspections;
            }


            var inspections = _context.Inspection.Include("Commission").
                Include("Commission.Employee").
                Include("Commission.Customer").ToList();

            //Best veel nesting, maar ik weet niet zo hoe dit het beste opgelost kan worden

            foreach (var i in inspections)
            {
                _inspections.Add(new InspectionViewModel
                {
                    Id = i.Id,
                    Name = "Inspectie : " + i.Commission.Description,
                    StartTime = i.DateTimeStart,

                    EndTime = Convert.ToDateTime(i.DateTimeEnd),
                    CommissionViewModel = new CommissionViewModel
                    {
                        Id = i.Commission.Id,
                        Description = i.Commission.Description,
                        StreetNumber = i.Commission.Location.StreetNumber,
                        ZipCode = i.Commission.Location.ZipCode,
                        Region = i.Commission.Location.Region.RegionName,
                        DateCreated = i.Commission.DateCreated,
                        DateCompleted = i.Commission.DateCompleted,
                        //Waarom in comments? Kan dit weg?
                        //Frequency = i.Commission.Frequency,
                        //Status= i.Commission.Status   
                        Customer = new CustomerViewModel
                        {
                            Id = i.Commission.CustomerId,
                            Name = i.Commission.Customer.Person.Name,
                            Email = i.Commission.Customer.Person.Email,
                            PhoneNumber = i.Commission.Customer.Person.PhoneNumber,
                            StreetNumber = i.Commission.Customer.Person.Location.StreetNumber,
                            ZipCode = i.Commission.Customer.Person.Location.ZipCode,
                            Region = i.Commission.Customer.Person.Location.Region.RegionName,
                        },
                        Employee = new EmployeeViewModel
                        {
                            Id = i.Commission.EmployeeId,
                            Name = i.Commission.Employee.Person.Name,
                            Email = i.Commission.Employee.Person.Email,
                            PhoneNumber = i.Commission.Employee.Person.PhoneNumber,
                            StreetNumber = i.Commission.Employee.Person.Location.StreetNumber,
                            ZipCode = i.Commission.Employee.Person.Location.ZipCode,
                            Region = i.Commission.Employee.Person.Location.Region.RegionName,
                            Function = i.Commission.Employee.Function.Name
                        } // end employee,
                    } // end commisionviewmodel
                }); // end add
            } //end foreach

            return _inspections;
        }

        public bool Update(InspectionViewModel item)
        {
            var inspections = _context.Inspection.FirstOrDefault(i => i.Id == item.Id);
            if (inspections == null) return false;
            inspections.DateTimeStart = item.StartTime;
            inspections.DateTimeEnd = item.EndTime;

            _context.Entry(inspections).State = EntityState.Modified;
            _context.SaveChanges();

            var index = _inspections.IndexOf(item);
            _inspections.RemoveAt(index);
            _inspections.Insert(index, item);
            return true;
        }
    }
}
