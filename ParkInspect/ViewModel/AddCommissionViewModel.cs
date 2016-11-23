using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ParkInspect.ViewModel
{
    public class AddCommissionViewModel : ViewModelBase
    {

        public CommissionViewModel _commissionViewModel;

        public ICommand AddCommissionCommand;

        public AddCommissionViewModel()
        {
            _commissionViewModel = new CommissionViewModel();
            AddCommissionCommand = new RelayCommand(AddCommission, CanAddCommission);
        }

        public void AddCommission()
        {

        }

        public bool CanAddCommission()
        {
            return true;
        }
    }
}
