using System.Collections.ObjectModel;

namespace ParkInspect.ViewModel
{
    public class TimeLineItemViewModel:MainViewModel
    {
        private string _monday;
        private string _tuesday;
        private string _wednesday;
        private string _thursday;
        private string _friday;
        private string _saturday;
        private string _sunday;
        private ObservableCollection<InspectionViewModel> _inspections;

        public TimeLineItemViewModel(EmployeeViewModel evm)
        {
            Employee = evm;
            _inspections = new ObservableCollection<InspectionViewModel>();
        }

       
        public EmployeeViewModel Employee { get; set; }
        public string Monday
        {
            get { return _monday; }
            set { _monday = value; RaisePropertyChanged(); }
        }
        public string Tuesday
        {
            get { return _tuesday; }
            set { _tuesday = value; RaisePropertyChanged(); }
        }
        public string Wednesday
        {
            get { return _wednesday; }
            set { _wednesday = value; RaisePropertyChanged(); }
        }
        public string Thursday
        {
            get { return _thursday; }
            set { _thursday = value; RaisePropertyChanged(); }
        }
        public string Friday
        {
            get { return _friday; }
            set { _friday = value; RaisePropertyChanged(); }
        }
        public string Saturday
        {
            get { return _saturday; }
            set { _saturday = value; RaisePropertyChanged(); }
        }
        public string Sunday
        {
            get { return _sunday; }
            set { _sunday = value; RaisePropertyChanged(); }
        }

        public ObservableCollection<InspectionViewModel> Inspections
        {
            get { return _inspections; }
            set { _inspections = value; RaisePropertyChanged(); }
        }
    }
}
