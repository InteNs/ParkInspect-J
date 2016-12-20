using System.Collections.ObjectModel;
using System.Windows.Input;
using ParkInspect.Repository.Interface;
using ParkInspect.Service;

namespace ParkInspect.ViewModel
{
    public class CommissionOverviewViewModel : MainViewModel
    {

        private CommissionViewModel _selectedCommission;
        private readonly ICommissionRepository _commissionRepository;
        private readonly IEmployeeRepository _employeeRepository;

        public ObservableCollection<CommissionViewModel> Commissions { get; set; }
        public ObservableCollection<EmployeeViewModel> Employees { get; set; }

        public CommissionViewModel SelectedCommission
        {
            get { return _selectedCommission; }
            set { _selectedCommission = value; RaisePropertyChanged(); }
        }
        public ICommand AddCommissionCommand { get; set; }
        
        public CommissionOverviewViewModel(ICommissionRepository commissionRepository, IEmployeeRepository employeeRepository, IRouterService router) : base(router)
        {
            _commissionRepository = commissionRepository;
            _employeeRepository = employeeRepository;

            Commissions = _commissionRepository.GetAll();
            Employees = _employeeRepository.GetAll();
        }
    }
}
