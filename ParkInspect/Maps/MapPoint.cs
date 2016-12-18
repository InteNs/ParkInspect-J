using MapControl;

namespace ParkInspect.Maps
{
    public class MapPoint : MapBase
    {
        private string _name;
        private Location _location;

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                RaisePropertyChanged("Name");
            }
        }
        public Location Location
        {
            get { return _location; }
            set
            {
                _location = value;
                RaisePropertyChanged("Location");
            }
        }
    }
}