using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;

namespace ParkInspect.ViewModel
{
    public class LocationViewModel : ViewModelBase
    {
        private int _id;
        private string _zipCode;
        private int _streetNumber;
        private string _region;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public string ZipCode
        {
            get { return _zipCode; }
            set { _zipCode = value; }
        }

        public int StreetNumber
        {
            get { return _streetNumber; }
            set { _streetNumber = value; }
        }

        public string Region
        {
            get { return _region; }
            set { _region = value; }
        }

        public LocationViewModel(int id, string zipCode, int streetNumber, string region)
        {
            _id = id;
            _zipCode = zipCode;
            _streetNumber = streetNumber;
            _region = region;
        }
    }
}
