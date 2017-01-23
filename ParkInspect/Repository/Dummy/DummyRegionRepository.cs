using System.Collections.ObjectModel;
using ParkInspect.Repository.Interface;

namespace ParkInspect.Repository.Dummy
{
    public class DummyRegionRepository : IRegionRepository
    {
        private readonly ObservableCollection<string> _regions;
        public DummyRegionRepository()
        {
            _regions = new ObservableCollection<string>
            {
                "Utrecht", "Limburg", "Brabant", "Flevoland", "Groningen", "Zeeland"
            };
        }
        public ObservableCollection<string> GetAll() =>  _regions;

        public bool Add(string item)
        {
            _regions.Add(item);
            return true;
        }

        public bool Delete(string item) =>  _regions.Remove(item);

        public bool Update(string item) =>  true;
    }
}
