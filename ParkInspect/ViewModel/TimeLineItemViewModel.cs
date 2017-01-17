using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkInspect.ViewModel
{
    public class TimeLineItemViewModel:MainViewModel
    {
        private string monday;
        private string tuesday;
        private string wednesday;
        private string thursday;
        private string friday;
        private string saturday;
        private string sunday;
        private ObservableCollection<InspectionViewModel> inspections;

        public TimeLineItemViewModel(EmployeeViewModel evm)
        {
            Employee = evm;
            inspections = new ObservableCollection<InspectionViewModel>();
        }

        public EmployeeViewModel Employee { get; set; }
        public string Monday
        {
            get { return monday; }
            set { monday = value; RaisePropertyChanged(); }
        }
        public string Tuesday
        {
            get { return tuesday; }
            set { tuesday = value; RaisePropertyChanged(); }
        }
        public string Wednesday
        {
            get { return wednesday; }
            set { wednesday = value; RaisePropertyChanged(); }
        }
        public string Thursday
        {
            get { return thursday; }
            set { thursday = value; RaisePropertyChanged(); }
        }
        public string Friday
        {
            get { return friday; }
            set { friday = value; RaisePropertyChanged(); }
        }
        public string Saturday
        {
            get { return saturday; }
            set { saturday = value; RaisePropertyChanged(); }
        }
        public string Sunday
        {
            get { return sunday; }
            set { sunday = value; RaisePropertyChanged(); }
        }

        public ObservableCollection<InspectionViewModel> Inspections
        {
            get { return inspections; }
            set { inspections = value; RaisePropertyChanged(); }
        }
    }
}
