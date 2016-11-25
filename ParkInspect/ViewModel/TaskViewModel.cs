using System;

namespace ParkInspect.ViewModel
{
    public class TaskViewModel : MainViewModel
    {
        private int _id;
        private string _zipCode;
        private string _streetNumber;
        private int _employeeId;
        private int _cutomerId;
        private DateTime _created;
        private DateTime _completed;
        private string _description;

        public int Id
        {
            get { return _id; }
            set
            {
                _id = value;
                RaisePropertyChanged();
            }
        }
        public string ZipCode
        {
            get { return _zipCode; }
            set
            {
                _zipCode = value;
                RaisePropertyChanged();
            }
        }
        public string StreetNumber
        {
            get { return _streetNumber; }
            set
            {
                _streetNumber = value;
                RaisePropertyChanged();
            }
        }
        public int EmployeeId
        {
            get { return _employeeId; }
            set
            {
                _employeeId = value;
                RaisePropertyChanged();
            }
        }
        public int CustomerId
        {
            get { return _cutomerId; }
            set
            {
                _cutomerId = value;
                RaisePropertyChanged();
            }
        }
        public DateTime Created
        {
            get { return _created; }
            set
            {
                _created = value;
                RaisePropertyChanged();
            }
        }
        public DateTime Completed
        {
            get { return _completed; }
            set
            {
                _completed = value;
                RaisePropertyChanged();
            }
        }
        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                RaisePropertyChanged();
            }
        }
    }
}