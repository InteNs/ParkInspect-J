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
        private List<DateTime> week;
        private ICommissionRepository _icr;
        private IEmployeeRepository _ier;
        private TimeLineItemViewModel _selectedTimeLineItem;
        public TimeLineViewModel(IRouterService router, ICommissionRepository icr, IEmployeeRepository ier) : base(router)
        {
            _icr = icr;
            _ier = ier;
            week = new List<DateTime>();
            DateTime dateCounter = DateTime.Now;
            while (dateCounter.DayOfWeek != DayOfWeek.Monday)
            {
                week.Add(dateCounter);
                dateCounter = dateCounter.AddDays(-1);
            }
            week.Add(dateCounter);
            dateCounter = DateTime.Now.AddDays(1);
            while (dateCounter.DayOfWeek != DayOfWeek.Sunday)
            {
                week.Add(dateCounter);
                dateCounter = dateCounter.AddDays(1);
            }
            week.Add(dateCounter);
            week.Sort();
            Monday = week[0].ToShortDateString();
            Tuesday = week[1].ToShortDateString();
            Wednesday = week[2].ToShortDateString();
            Thursday = week[3].ToShortDateString();
            Friday = week[4].ToShortDateString();
            Saturday = week[5].ToShortDateString();
            Sunday = week[6].ToShortDateString();

            TimeLineItems = new ObservableCollection<TimeLineItemViewModel>();
            UpdateTimeLineItems();

            NextWeekCommand = new RelayCommand(NextWeek);
            PreviousWeekCommand = new RelayCommand(PreviousWeek);
        }

        public TimeLineItemViewModel SelectedTimeLineItem
        {
            get { return _selectedTimeLineItem;}
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

        public void UpdateTimeLineItems()
        {
            TimeLineItems.Clear();
            foreach (EmployeeViewModel evm in _ier.GetAll().Where(e => e.Function == "inspecteur"))
            {
                TimeLineItemViewModel tlivm = new TimeLineItemViewModel(evm);
                foreach(DateTime day in week)
                {
                    string status = "Beschikbaar";
                    foreach(CommissionViewModel cvm in _icr.GetAll())
                    {
                        if(cvm.Employee.Equals(evm) && cvm.DateCreated < day && cvm.DateCompleted > day)
                        {
                            status = "Opdracht " + cvm.Id;
                        }
                    }
                    if (day.DayOfWeek.Equals(DayOfWeek.Saturday) || day.DayOfWeek.Equals(DayOfWeek.Sunday))
                    {
                        status = "Weekend";
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
            for(int i = 0; i<7; i++)
            {
                week[i] = week[i].AddDays(7);
            }
            Monday = week[0].ToShortDateString();
            Tuesday = week[1].ToShortDateString();
            Wednesday = week[2].ToShortDateString();
            Thursday = week[3].ToShortDateString();
            Friday = week[4].ToShortDateString();
            Saturday = week[5].ToShortDateString();
            Sunday = week[6].ToShortDateString();
            UpdateTimeLineItems();
            RaisePropertyChanged("");
        }

        public void PreviousWeek()
        {
            for (int i = 0; i < 7; i++)
            {
                week[i] = week[i].AddDays(-7);
            }
            Monday = week[0].ToShortDateString();
            Tuesday = week[1].ToShortDateString();
            Wednesday = week[2].ToShortDateString();
            Thursday = week[3].ToShortDateString();
            Friday = week[4].ToShortDateString();
            Saturday = week[5].ToShortDateString();
            Sunday = week[6].ToShortDateString();
            UpdateTimeLineItems();
            RaisePropertyChanged("");
        }
    }
}
