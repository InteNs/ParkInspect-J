using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;

namespace ParkInspect.ViewModel
{
    public class EmployeeInspectionsViewModel : MainViewModel
    {
        private Dictionary<string, string> _daysOfTheWeek;
        private int _dayCounter;
        private string _selectedDay;

        public ICommand NextDayCommand { get; set; }
        public ICommand PreviousDayCommand { get; set; }
        public TimeLineItemViewModel TimeLineItem { get; private set; }

        public string SelectedDay
        {
            get { return _selectedDay; }
            set { _selectedDay = value; RaisePropertyChanged("SelectedDay"); }
        }
        
        public EmployeeInspectionsViewModel(TimeLineViewModel timeLineViewModel)
        {
            TimeLineItem = timeLineViewModel.SelectedTimeLineItem;
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
            this.NextDay();

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
                    this.SetDayString(_daysOfTheWeek.Keys.ElementAt(_dayCounter), _daysOfTheWeek.Values.ElementAt(_dayCounter));
                    break;
                }
                else
                {
                    _dayCounter = 0;
                }
            }
        }

        private void PreviousDay()
        {
            _dayCounter--;
            while (true)
            {
                if (_dayCounter >= 0)
                {
                    this.SetDayString(_daysOfTheWeek.Keys.ElementAt(_dayCounter), _daysOfTheWeek.Values.ElementAt(_dayCounter));
                    break;
                }
                else
                {
                    _dayCounter = 6;
                }
            }
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
