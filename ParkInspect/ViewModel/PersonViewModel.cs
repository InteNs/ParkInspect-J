using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkInspect.ViewModel
{
    public abstract class PersonViewModel : MainViewModel, INotifyDataErrorInfo
    {
        private string _name;
        private string _zipCode;
        private string _streetNumber;
        private string _phoneNumber;
        private string _region;
        private string _email;

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                if (string.IsNullOrWhiteSpace(_name))
                { AddError("Name", "Naam is verplicht"); }
                else if (_name.Any(char.IsDigit))
                { AddError("Name", "Naam mag geen cijfers bevatten"); }
                else
                { RemoveError("Name"); }
                
                RaisePropertyChanged();
            }
        }

        public string ZipCode
        {
            get { return _zipCode; }
            set
            {
                _zipCode = value;

                if (string.IsNullOrWhiteSpace(_zipCode))
                { AddError("ZipCode", "Postcode is verplicht"); }
                else
                { RemoveError("ZipCode"); }

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
                { AddError("Region", "Postcode is verplicht"); }
                else
                { RemoveError("Region"); }

                RaisePropertyChanged();
            }
        }

        public string StreetNumber
        {
            get { return _streetNumber; }
            set
            {
                _streetNumber = value;

                if (string.IsNullOrWhiteSpace(_streetNumber))
                { AddError("StreetNumber", "Straatnummer is verplicht"); }
                else
                { RemoveError("StreetNumber"); }

                RaisePropertyChanged();
            }
        }

        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set
            {
                _phoneNumber = value;

                if (string.IsNullOrWhiteSpace(_phoneNumber))
                { AddError("PhoneNumber", "Telefoonnummer is verplicht"); }
                else if (_phoneNumber.Any(char.IsLetter))
                { AddError("Telefoonnummer", "Telefoonnummer kan geen letters bevatten"); }
                else
                { RemoveError("PhoneNumber"); }


                RaisePropertyChanged();
            }
        }

        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;

                if (string.IsNullOrWhiteSpace(_email))
                { AddError("Email", "Email is verplicht"); }
                else if(!_email.Contains("@"))
                {
                    AddError("Email", "Dit is geen geldige email");
                }
                else
                { RemoveError("Email"); }


                RaisePropertyChanged();
            }
        }
        //validation
        private Dictionary<string, List<string>> _errors = new Dictionary<string, List<string>>();


        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        // get errors by property
        public IEnumerable GetErrors(string propertyName)
        {
            if (_errors.ContainsKey(propertyName))
                return _errors[propertyName];
            return null;
        }

        public bool HasErrors => _errors.Count > 0;

        // object is valid
        public bool IsValid => !HasErrors;

        public void AddError(string propertyName, string error)
        {
            // Add error to list
            _errors[propertyName] = new List<string>() { error };
            NotifyErrorsChanged(propertyName);
        }

        public void RemoveError(string propertyName)
        {
            // remove error
            if (_errors.ContainsKey(propertyName))
                _errors.Remove(propertyName);
            NotifyErrorsChanged(propertyName);
        }

        public void NotifyErrorsChanged(string propertyName)
        {
            // Notify
            if (ErrorsChanged != null)
                ErrorsChanged(this, new DataErrorsChangedEventArgs(propertyName));
        }
    }
}
