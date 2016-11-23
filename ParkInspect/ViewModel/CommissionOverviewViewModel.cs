using GalaSoft.MvvmLight;
using ParkInspect.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ParkInspect.ViewModel
{
    public class CommissionOverviewViewModel : ViewModelBase
    {
        public ICommand BackCommand { get; set; }
        public ICommand AddCommissionCommand { get; set; }
        private ICommissionRepository _icr;
        private CommissionViewModel _selectedCommission;
        private RouterViewModel _router;

        public CommissionOverviewViewModel(ICommissionRepository _icr, RouterViewModel router)
        {
            this._icr = _icr;
            _router = router;
        }

        public ObservableCollection<CommissionViewModel> CommissionList { get; set; }

        public ObservableCollection<EmployeeViewModel> ShowableEmployeeList { get; set; }

        public ObservableCollection<EmployeeViewModel> CompleteEmployeeList { get; set; }

        public CommissionViewModel SelectedCommission
        {
            get { return _selectedCommission; }
            set { _selectedCommission = value; RaisePropertyChanged("SelectedCommission"); }
        }
    }
}
