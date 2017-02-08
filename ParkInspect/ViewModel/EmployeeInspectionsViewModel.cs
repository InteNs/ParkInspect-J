using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using System.Collections.ObjectModel;

namespace ParkInspect.ViewModel
{
    public class EmployeeInspectionsViewModel : MainViewModel
    {
        private Dictionary<string, string> _daysOfTheWeek;
        private int _dayCounter;
        private string _selectedDay;

        public ICommand NextDayCommand { get; set; }
        public ICommand PreviousDayCommand { get; set; }
        public TimeLineItemViewModel TimeLineItem { get; }
        public ObservableCollection<InspectionViewModel> Inspections { get; set; }

        public string SelectedDay
        {
            get { return _selectedDay; }
            set { _selectedDay = value; RaisePropertyChanged("SelectedDay"); }
        }
        
        public EmployeeInspectionsViewModel(TimeLineViewModel timeLineViewModel)
        {
            TimeLineItem = timeLineViewModel.SelectedTimeLineItem;
            Inspections = new ObservableCollection<InspectionViewModel>();
            _daysOfTheWeek = new Dictionary<string, string>()
            {
                {"Maandag",timeLineViewModel.Monday },
                {"Dinsdag",timeLineViewModel.Tuesday },
                {"Woensdag",timeLineViewModel.Wednesday },
                {"Donderdag",timeLineViewModel.Thursday },
                {"Vrijdag",timeLineViewModel.Friday },
                {"Zaterdag",timeLineViewModel.Saturday },
                {"Zondag",timeLineViewModel.Sunday }
            };
            _dayCounter = 6;
            NextDay();

            NextDayCommand = new RelayCommand(NextDay);
            PreviousDayCommand = new RelayCommand(PreviousDay);
        }

       
        private void NextDay()
        {
            _dayCounter++;
            while (true)
            {
                if (_dayCounter < 7)
                {
                    SetDayString(_daysOfTheWeek.Keys.ElementAt(_dayCounter), _daysOfTheWeek.Values.ElementAt(_dayCounter));
                    DateTime today = new DateTime(int.Parse(_daysOfTheWeek.Values.ElementAt(_dayCounter).Split('-')[2]), int.Parse(_daysOfTheWeek.Values.ElementAt(_dayCounter).Split('-')[1]), int.Parse(_daysOfTheWeek.Values.ElementAt(_dayCounter).Split('-')[0]));
                    Inspections = new ObservableCollection<InspectionViewModel>(TimeLineItem.Inspections.Where(i => i.StartTime.DayOfWeek.Equals(today.DayOfWeek)));
                    break;
                }
                _dayCounter = 0;
            }
            RaisePropertyChanged("");
        }

        private void PreviousDay()
        {
            _dayCounter--;
            while (true)
            {
                if (_dayCounter >= 0)
                {
                    SetDayString(_daysOfTheWeek.Keys.ElementAt(_dayCounter), _daysOfTheWeek.Values.ElementAt(_dayCounter));
                    DateTime today = new DateTime(int.Parse(_daysOfTheWeek.Values.ElementAt(_dayCounter).Split('-')[2]), int.Parse(_daysOfTheWeek.Values.ElementAt(_dayCounter).Split('-')[1]), int.Parse(_daysOfTheWeek.Values.ElementAt(_dayCounter).Split('-')[0]));
                    Inspections = new ObservableCollection<InspectionViewModel>(TimeLineItem.Inspections.Where(i => i.StartTime.DayOfWeek.Equals(today.DayOfWeek)));
                    break;
                }
                _dayCounter = 6;
            }
            RaisePropertyChanged("");
        }

        private void SetDayString(string day, string date)
        {
            if (day != null&&date != null)
            {
                SelectedDay = day + " - " + date;
            }
        }
    }
}
