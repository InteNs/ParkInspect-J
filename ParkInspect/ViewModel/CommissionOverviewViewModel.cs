using GalaSoft.MvvmLight;
using ParkInspect.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ParkInspect.Repository.Interface;
using ParkInspect.Service;

namespace ParkInspect.ViewModel
{
    public class CommissionOverviewViewModel : MainViewModel
    {
        public ICommand BackCommand { get; set; }
        public ICommand AddCommissionCommand { get; set; }
        private ICommissionRepository _icr;
        private CommissionViewModel _selectedCommission;

        public CommissionOverviewViewModel(ICommissionRepository icr, IRouterService router) : base(router)
        {
            this._icr = icr;
            CommissionList = new ObservableCollection<CommissionViewModel>(icr.GetAll());
            ShowableEmployeeList = new ObservableCollection<EmployeeViewModel>();
            CompleteEmployeeList = new ObservableCollection<EmployeeViewModel>();
        }

        public ObservableCollection<CommissionViewModel> CommissionList { get; set; }

        public ObservableCollection<EmployeeViewModel> ShowableEmployeeList { get; set; }

        public ObservableCollection<EmployeeViewModel> CompleteEmployeeList { get; set; }

        public CommissionViewModel SelectedCommission
        {
            get { return _selectedCommission; }
            set { _selectedCommission = value; RaisePropertyChanged(); }
        }
    }
}
