using GalaSoft.MvvmLight.Command;
using ParkInspect.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using ParkInspect.Repository.Interface;

namespace ParkInspect.ViewModel
{
    public class TimeLineViewModel : MainViewModel
    {
        private List<DateTime> _week;
        private IInspectionsRepository _inspectionsRepository;
        private IEmployeeRepository _employeeRepository;
        private TimeLineItemViewModel _selectedTimeLineItem;
        private IAuthService _authservice;

        public TimeLineItemViewModel SelectedTimeLineItem
        {
            get { return _selectedTimeLineItem; }
            set { _selectedTimeLineItem = value; RaisePropertyChanged("SelectedTimeLineItem"); }
        }
        public ICommand NextWeekCommand { get; set; }
        public ICommand PreviousWeekCommand { get; set; }
        public ObservableCollection<TimeLineItemViewModel> TimeLineItems { get; set; }
        public string Monday { get; set; }
        public string Tuesday { get; set; }
        public string Wednesday { get; set; }
        public string Thursday { get; set; }
        public string Friday { get; set; }
        public string Saturday { get; set; }
        public string Sunday { get; set; }

        public TimeLineViewModel(IRouterService router, IInspectionsRepository inspectionsRepository, IEmployeeRepository employeeRepository, IAuthService auth) : base(router)
        {
            _authservice = auth;
            _inspectionsRepository = inspectionsRepository;
            _employeeRepository = employeeRepository;
            _week = new List<DateTime>();
            DateTime dateCounter = DateTime.Now;
            while (dateCounter.DayOfWeek != DayOfWeek.Monday)
            {
                _week.Add(dateCounter);
                dateCounter = dateCounter.AddDays(-1);
            }
            _week.Add(dateCounter);
            if (DateTime.Now.DayOfWeek != DayOfWeek.Sunday)
            {
                dateCounter = DateTime.Now.AddDays(1);
                while (dateCounter.DayOfWeek != DayOfWeek.Sunday)
                {
                    _week.Add(dateCounter);
                    dateCounter = dateCounter.AddDays(1);
                }
                _week.Add(dateCounter);
            }
            _week.Sort();
            Monday = _week[0].ToShortDateString();
            Tuesday = _week[1].ToShortDateString();
            Wednesday = _week[2].ToShortDateString();
            Thursday = _week[3].ToShortDateString();
            Friday = _week[4].ToShortDateString();
            Saturday = _week[5].ToShortDateString();
            Sunday = _week[6].ToShortDateString();

            TimeLineItems = new ObservableCollection<TimeLineItemViewModel>();
            UpdateTimeLineItems();

            NextWeekCommand = new RelayCommand(NextWeek);
            PreviousWeekCommand = new RelayCommand(PreviousWeek);
        }


        public void UpdateTimeLineItems()
        {
            TimeLineItems.Clear();
            ObservableCollection<InspectionViewModel> inspectionslist = _inspectionsRepository.GetAll();
            IEnumerable<EmployeeViewModel> employeelist = _employeeRepository.GetAll().Where(e => e.Function.ToLower() == "inspecteur");
            if (_authservice.CurrentFunction(_authservice.GetLoggedInUser()).ToLower() == "inspecteur")
            {
                employeelist = employeelist.Where(e => e.Id == _authservice.GetLoggedInUser().EmployeeId);
            }
            foreach (EmployeeViewModel evm in employeelist)
            {
                TimeLineItemViewModel tlivm = new TimeLineItemViewModel(evm);
                foreach (DateTime day in _week)
                {
                    string status = "Beschikbaar";
                    int inspectionsAmount = 0;

                    foreach (InspectionViewModel ivm in inspectionslist)
                    {
                        if (ivm.CommissionViewModel.Employee.Id == evm.Id && ivm.StartTime.DayOfYear == day.DayOfYear && ivm.StartTime.Year == day.Year&&ivm.DateCancelled != null)
                        {
                            tlivm.Inspections.Add(ivm);
                            inspectionsAmount++;
                        }
                    }
                    if (day.DayOfWeek.Equals(DayOfWeek.Saturday) || day.DayOfWeek.Equals(DayOfWeek.Sunday))
                    {
                        status = "Weekend";
                    }
                    if (inspectionsAmount == 1)
                    {
                        status = "1 Inspectie";
                    }
                    if (inspectionsAmount > 1)
                    {
                        status = inspectionsAmount + " Inspecties";
                    }
                    switch (day.DayOfWeek)
                    {
                        case DayOfWeek.Monday:
                            tlivm.Monday = status;
                            break;
                        case DayOfWeek.Tuesday:
                            tlivm.Tuesday = status;
                            break;
                        case DayOfWeek.Wednesday:
                            tlivm.Wednesday = status;
                            break;
                        case DayOfWeek.Thursday:
                            tlivm.Thursday = status;
                            break;
                        case DayOfWeek.Friday:
                            tlivm.Friday = status;
                            break;
                        case DayOfWeek.Saturday:
                            tlivm.Saturday = status;
                            break;
                        case DayOfWeek.Sunday:
                            tlivm.Sunday = status;
                            break;
                    }
                }
                TimeLineItems.Add(tlivm);
            }
        }

        public void NextWeek()
        {
            for (int i = 0; i < 7; i++)
            {
                _week[i] = _week[i].AddDays(7);
            }
            Monday = _week[0].ToShortDateString();
            Tuesday = _week[1].ToShortDateString();
            Wednesday = _week[2].ToShortDateString();
            Thursday = _week[3].ToShortDateString();
            Friday = _week[4].ToShortDateString();
            Saturday = _week[5].ToShortDateString();
            Sunday = _week[6].ToShortDateString();
            UpdateTimeLineItems();
            RaisePropertyChanged("");
        }

        public void PreviousWeek()
        {
            for (int i = 0; i < 7; i++)
            {
                _week[i] = _week[i].AddDays(-7);
            }
            Monday = _week[0].ToShortDateString();
            Tuesday = _week[1].ToShortDateString();
            Wednesday = _week[2].ToShortDateString();
            Thursday = _week[3].ToShortDateString();
            Friday = _week[4].ToShortDateString();
            Saturday = _week[5].ToShortDateString();
            Sunday = _week[6].ToShortDateString();
            UpdateTimeLineItems();
            RaisePropertyChanged("");
        }
    }
}
