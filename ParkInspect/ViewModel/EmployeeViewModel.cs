using System;

namespace ParkInspect.ViewModel
{

    public class EmployeeViewModel : PersonViewModel
    {
        private int _id;
        private DateTime _employmentDate;
        private DateTime? _dismissalDate;
        private string _region;
        private string _function;

        public int Id
        {
            get { return _id; }
            set
            {
                _id = value;
                RaisePropertyChanged();
            }
        }

        public DateTime EmploymentDate
        {
            get { return _employmentDate; }
            set
            {
                _employmentDate = value;
                RaisePropertyChanged();
            }
        }

        public DateTime? DismissalDate
        {
            get { return _dismissalDate; }
            set
            {
                _dismissalDate = value;
                RaisePropertyChanged();
            }
        }

        public string Region
        {
            get { return _region; }
            set
            {
                _region = value;
                RaisePropertyChanged();
            }
        }

        public string Function
        {
            get { return _function; }
            set
            {
                _function = value;
                RaisePropertyChanged();
            }
        }
    }
}
