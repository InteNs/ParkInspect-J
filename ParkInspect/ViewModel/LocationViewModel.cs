namespace ParkInspect.ViewModel
{
    public class LocationViewModel : MainViewModel
    {
        private string _zipCode;
        private string _streetNumber;
        private string _region;

        public string ZipCode
        {
            get { return _zipCode; }
            set { _zipCode = value; RaisePropertyChanged(); }
        }

        public string StreetNumber
        {
            get { return _streetNumber; }
            set { _streetNumber = value; RaisePropertyChanged(); }
        }

        public string Region
        {
            get { return _region; }
            set { _region = value; RaisePropertyChanged(); }
        }
    }
}
