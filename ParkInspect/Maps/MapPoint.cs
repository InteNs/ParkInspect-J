using MapControl;

namespace ParkInspect.Maps
{
    public class MapPoint : MapBase
    {
        private string _description;
        private Location _location;

        public string Description
        {
            get { return _description; }
            set { _description = value; RaisePropertyChanged("Name"); }
        }
        public Location Location
        {
            get { return _location; }
            set { _location = value; RaisePropertyChanged("Location"); }
        }
    }
}