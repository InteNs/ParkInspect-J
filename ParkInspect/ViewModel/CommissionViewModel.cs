using GalaSoft.MvvmLight;
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

        private Commission _commission;


        public int Id
        {
            get { return _commission.Id; }
            set { _commission.Id = value; RaisePropertyChanged("Id"); }
        }

        public int Frequency
        {
            get { return _commission.Frequency; }
            set { _commission.Frequency = value; RaisePropertyChanged("Frequency"); }
        }

        public int CustomerId
        {
            get { return _commission.CustomerId; }
            set { _commission.CustomerId = value; RaisePropertyChanged("CustomerId"); }
        }

        public CommissionViewModel(int id, int frequency)
        {
            Id = id;
            Frequency = frequency;
        }
        public CommissionViewModel()
        {
            _commission = new Commission();
        }

        public CommissionViewModel(Commission commission)
        {
            commission = new Commission();
        }
    }
}
