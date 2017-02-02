using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace ParkInspect.ViewModel
{
    public class LocationViewModel : MainViewModel, INotifyDataErrorInfo
    {
        private string _zipCode;
        private string _streetNumber;
        private string _region;
        private Dictionary<string, List<string>> _errors;

        public string ZipCode
        {
            get { return _zipCode; }
            set
            {
                _zipCode = value;

                if (string.IsNullOrWhiteSpace(_zipCode))
                { AddError("ZipCode", "Postcode is verplicht"); }
                else if (!Regex.IsMatch(_zipCode, "^[1-9][0-9]{3}\\s?[a-zA-Z]{2}$"))
                {
                    AddError("ZipCode", "Postcode bevat 4 cijfers en 2 letters");
                }
                else
                { RemoveError("ZipCode"); }

                RaisePropertyChanged();
            }
        }

        public string StreetNumber
        {
            get { return _streetNumber; }
            set
            {
                _streetNumber = value;

                if (string.IsNullOrWhiteSpace(_streetNumber.ToString()))
                { AddError("StreetNumber", "Straatnummer is verplicht"); }
                else
                { RemoveError("StreetNumber"); }

                RaisePropertyChanged();
            }
        }

        public string Region
        {
            get { return _region; }
            set
            {
                _region = value;

                if (string.IsNullOrWhiteSpace(_region))
                { AddError("Region", "Regio is verplicht"); }
                else
                { RemoveError("Region"); }

                RaisePropertyChanged();
            }
        }

        public LocationViewModel()
        {
            _errors = new Dictionary<string, List<string>>();
        }

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        // get errors by property
        public IEnumerable GetErrors(string propertyName) =>  _errors.ContainsKey(propertyName) ? _errors[propertyName] : null;

        public bool HasErrors => _errors.Count > 0;

        // object is valid
        public bool IsValid => !HasErrors;

        public void AddError(string propertyName, string error)
        {
            _errors[propertyName] = new List<string> { error };
            NotifyErrorsChanged(propertyName);
        }

        public void RemoveError(string propertyName)
        {
            if (_errors.ContainsKey(propertyName))
                _errors.Remove(propertyName);
            NotifyErrorsChanged(propertyName);
        }

        public void NotifyErrorsChanged(string propertyName) => ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
    }
}
