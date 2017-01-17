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

            var i = new Inspection { Guid = Guid.NewGuid(), DateTimeStart = item.StartTime, CommissionId = commission.Id, CommissionGuid= commission.Guid, DateTimeEnd = null, DateCancelled=null };

            _context.Inspection.Add(i);
            _inspections.Add(item);
            _context.SaveChanges();
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
            _context.Inspection.ToList()
                .ForEach(i => _inspections.Add(new InspectionViewModel
                {
                    Id = i.Id,
                    Name = i.Commission.Description, 
                    StartTime = i.DateTimeStart,
                    EndTime = Convert.ToDateTime(i.DateTimeEnd),
                    
                }));

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
