using GalaSoft.MvvmLight;
using ParkInspect.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ParkInspect.ViewModel
{
    class CommissionOverviewViewModel : ViewModelBase
    {
        private ICommand BackCommand;
        private ICommand AddCommissionCommand;
        private ICommissionRepository _icr;
        private List<CommissionViewModel> _commissionList;
        private List<EmployeeViewModel> _showableEmployeeList;
        private List<EmployeeViewModel> _completeEmployeeList;
        private CommissionViewModel _selectedCommission;
        private RouterViewModel _router;

        public CommissionOverviewViewModel(ICommissionRepository _icr, RouterViewModel router)
        {
            this._icr = _icr;
            _router = router;
        }
    }
}
