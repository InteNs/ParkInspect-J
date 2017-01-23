using System.Collections.ObjectModel;
using ParkInspect.Repository.Interface;
using ParkInspect.ViewModel;

namespace ParkInspect.Repository.Dummy
{
    public class DummyLocationRepository : ILocationRepository
    {
        private readonly ObservableCollection<LocationViewModel> _locations;

        public DummyLocationRepository()
        {
            _locations = new ObservableCollection<LocationViewModel>
            {
                new LocationViewModel {Region = "Utrecht", StreetNumber = "32", ZipCode = "3453MC" },
                new LocationViewModel {Region = "Brabant", StreetNumber = "23", ZipCode = "9365KF" },
                new LocationViewModel {Region = "Limburg", StreetNumber = "87", ZipCode = "0274PW" }
            };
        }
        public ObservableCollection<LocationViewModel> GetAll() => _locations;

        public bool Add(LocationViewModel item)
        {
            _locations.Add(item);
            return true;
        }

        public bool Delete(LocationViewModel item) => _locations.Remove(item);

        public bool Update(LocationViewModel item)
        {
            var index = _locations.IndexOf(item);
            if (index < 0) return false;
            _locations.RemoveAt(index);
            _locations.Insert(index, item);
            return true;
        }
    }
}
