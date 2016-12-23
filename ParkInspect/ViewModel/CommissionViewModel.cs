using System;

namespace ParkInspect.ViewModel
{
    public class CommissionViewModel : LocationViewModel
    {
        private int _id;
        private int _frequency;
        private DateTime _dateCreated;
        private DateTime? _dateCompleted;
        private string _description;
        private string _customerName;
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

        public int Frequency
        {
            get { return _frequency; }
            set { _frequency = value; RaisePropertyChanged(); }
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
            set { _description = value; RaisePropertyChanged(); }
        }
        

        public string Info => "Opdracht " + Id + " - " + Customer.Name + "-" + Status;

        public string Status
        {
            get { return _status; }
            set { _status = value; RaisePropertyChanged(); }
        }
    }
}
