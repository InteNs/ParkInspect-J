using System.Collections.ObjectModel;
using ParkInspect.Repository.Interface;
using ParkInspect.Service;

namespace ParkInspect.ViewModel
{
    public class CommissionOverviewViewModel : MainViewModel
    {
        private CommissionViewModel _selectedCommission;

        public ObservableCollection<CommissionViewModel> Commissions { get; set; }
        public ObservableCollection<EmployeeViewModel> Employees { get; set; }

        public CommissionViewModel SelectedCommission
        {
            get { return _selectedCommission; }
            set { _selectedCommission = value; RaisePropertyChanged(); }
        }
        
        
        public CommissionOverviewViewModel(ICommissionRepository commissionRepository, IEmployeeRepository employeeRepository, IRouterService router) : base(router)
        {
            Commissions = commissionRepository.GetAll();
            Employees = employeeRepository.GetAll();
        }
    }
}
