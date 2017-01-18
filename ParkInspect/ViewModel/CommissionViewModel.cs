using System;

namespace ParkInspect.ViewModel
{
    public class CommissionViewModel : LocationViewModel
    {
        private int _id;
        private DateTime _dateCreated;
        private DateTime? _dateCompleted;
        private string _description;
        private string _status;
        private CustomerViewModel _customer;
        private EmployeeViewModel _employee;

        public CustomerViewModel Customer
        {
            get { return _customer; }
            set { _customer = value; RaisePropertyChanged(); }
        }

        public int Id
        {
            get { return _id; }
            set { _id = value; RaisePropertyChanged(); }
        }

        public EmployeeViewModel Employee
        {
            get { return _employee; }
            set { _employee = value; RaisePropertyChanged(); }
        }

        public DateTime DateCreated
        {
            get { return _dateCreated; }
            set { _dateCreated = value; RaisePropertyChanged(); }
        }

        public DateTime? DateCompleted
        {
            get { return _dateCompleted; }
            set { _dateCompleted = value; RaisePropertyChanged(); }
        }

        public string Description
        {
            get { return _description; }
            set {
                _description = value;
                if (string.IsNullOrWhiteSpace(_description))
                {
                    AddError("Description", "Beschrijving is verplicht");
                }
                else
                {
                    RemoveError("Description");
                }
            }
        }
        

        public string Info => "Opdracht " + Id + " - " + Customer.Name + "-" + Status;

        public string Status
        {
            get { return _status; }
            set { _status = value; RaisePropertyChanged(); }
        }
    }
}
