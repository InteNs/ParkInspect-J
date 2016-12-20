using System.Collections.ObjectModel;
using ParkInspect.Repository.Interface;
using ParkInspect.Service;

namespace ParkInspect.ViewModel
{
    public class InspectionsViewModel : MainViewModel
    {
        private CommissionViewModel _selectedCommission;
        private bool _isManager;
        private bool _isInspecteur;

        public ObservableCollection<InspectionViewModel> InspectionList { get; private set; }
        public ObservableCollection<CommissionViewModel> CommissionList { get; private set; }

        public CommissionViewModel SelectedCommission
        {
            get { return _selectedCommission; }
            set
            {
                _selectedCommission = value;
                base.RaisePropertyChanged();
            }
        }

        public bool IsManager
        {
            get { return _isManager; }
            set { _isManager = value; RaisePropertyChanged(); }
        }

        public bool IsInspecteur
        {
            get { return _isInspecteur; }
            set { _isInspecteur = value; RaisePropertyChanged(); }
        }

        public InspectionsViewModel(ICommissionRepository commissionRepository,
            IInspectionsRepository inspectionsRepository, IRouterService router) : base(router)
        {
            switch (RouterService.CurrentDashboard)
            {
                case "dashboard-inspecteur":
                    IsInspecteur = true;
                    IsManager = false;
                    break;
                case "dashboard-manager":
                    IsInspecteur = false;
                    IsManager = true;
                    break;
                default:
                    IsInspecteur = false;
                    IsManager = false;
                    break;
            }
            
            InspectionList = inspectionsRepository.GetAll();
            CommissionList = new ObservableCollection<CommissionViewModel>(commissionRepository.GetAll());
        }
    }
}
