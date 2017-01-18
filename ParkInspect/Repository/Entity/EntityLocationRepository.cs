using ParkInspect.Repository.Interface;
using System;
using System.Linq;
using ParkInspect.ViewModel;
using System.Collections.ObjectModel;
using Data;

namespace ParkInspect.Repository.Entity
{
   public class EntityLocationRepository : ILocationRepository
    {
        private readonly ParkInspectEntities _context;
        private readonly ObservableCollection<LocationViewModel> _locations;
        public EntityLocationRepository(ParkInspectEntities context)
        {
            _context = context;
            _locations = new ObservableCollection<LocationViewModel>();
        }

        public bool Add(LocationViewModel item)
        {
            // TODO deze function implementeren of weggooien
            throw new NotImplementedException();
        }

        public bool Delete(LocationViewModel item)
        {
            // TODO deze function implementeren of weggooien
            throw new NotImplementedException();
        }

        public ObservableCollection<LocationViewModel> GetAll()
        {
            _locations.Clear();
            _context.Location.Include("Location.Region").ToList().ForEach(l => _locations.Add(new LocationViewModel
            {
                Region = l.Region.RegionName,
                StreetNumber = l.StreetNumber,
                ZipCode = l.ZipCode
            }));
            return _locations;
        }

        public bool Update(LocationViewModel item)
        {
            // TODO deze function implementeren of weggooien
            throw new NotImplementedException();
        }
    }
}
