﻿using GalaSoft.MvvmLight;
using ParkInspect.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkInspect.ViewModel
{
    public class CommissionViewModel : ViewModelBase
    {
        private int _id;
        private int _frequency;
        private int _customerId;
        private int _locationId;
        private int? _employeeId;
        private DateTime _dateCreated;
        private DateTime? _dateCompleted;
        private string _description;
        private string _region;

        public int Id
        {
            get { return _id; }
            set { _id = value; RaisePropertyChanged("Id"); }
        }

        public int Frequency
        {
            get { return _frequency; }
            set { _frequency = value; RaisePropertyChanged("Frequency"); }
        }

        public int CustomerId
        {
            get { return _customerId; }
            set { _customerId = value; RaisePropertyChanged("CustomerId"); }
        }

        public int LocationId
        {
            get { return _locationId; }
            set { _locationId = value; RaisePropertyChanged("LocationId"); }
        }

        public int? EmployeeId
        {
            get { return _employeeId; }
            set { _employeeId = value; RaisePropertyChanged("EmployeeId"); }
        }

        public DateTime DateCreated
        {
            get { return _dateCreated; }
            set { _dateCreated = value; RaisePropertyChanged("DateCreated"); }
        }

        public DateTime? DateCompleted
        {
            get { return _dateCompleted; }
            set { _dateCompleted = value; RaisePropertyChanged("DateCompleted"); }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; RaisePropertyChanged("Description"); }
        }

        public string Region
        {
            get { return _region; }
            set { _region = value; RaisePropertyChanged("Region"); }
        }

        public CommissionViewModel(int id, int frequency, int customerId, int locationId, int? employeeId, DateTime created, DateTime? completed, string description, string region)
        {
            Id = id;
            Frequency = frequency;
            CustomerId = customerId;
            LocationId = locationId;
            EmployeeId = employeeId;
            DateCreated = created;
            DateCompleted = completed;
            Description = description;
            Region = region;
        }

        public CommissionViewModel()
        {
            
        }


        
    }
}
