using System.Collections.ObjectModel;
using ParkInspect.Repository.Interface;
using ParkInspect.Service;

namespace ParkInspect.ViewModel
{
    public class InspectionsViewModel : MainViewModel
    {
        private CommissionViewModel _selectedCommission;
        private InspectionViewModel _selectedInspection;
        private bool _isManager;
        private bool _isInspecteur;
        private IAuthService authservice;
        private ObservableCollection<CommissionViewModel> _commissionList;
        private ObservableCollection<InspectionViewModel> _inspectionList;

        public ObservableCollection<InspectionViewModel> InspectionList
        {
            get
            {
                ObservableCollection<InspectionViewModel> insp = new ObservableCollection<InspectionViewModel>();
                if (SelectedCommission == null)
                {
                    return insp;
                }
                foreach (InspectionViewModel ivm in _inspectionList)
                {
                    if(ivm.CommissionViewModel.Id == SelectedCommission.Id)
                    {
                        insp.Add(ivm);
                    }
                }
                return insp;
            }
            private set
            {
                _inspectionList = value;
                RaisePropertyChanged();
            }
        }
        public ObservableCollection<CommissionViewModel> CommissionList
        {
            get
            {
                if(authservice.CurrentFunction(authservice.GetLoggedInUser()).ToLower() == "inspecteur")
                {
                    ObservableCollection<CommissionViewModel> coms = new ObservableCollection<CommissionViewModel>();
                    foreach(CommissionViewModel cvm in _commissionList)
                    {
                        if(cvm.Employee.Id == authservice.GetLoggedInUser().EmployeeId)
                        {
                            coms.Add(cvm);
                        }
                    }
                    return coms;
                }
                return _commissionList;
            }
            private set
            {
                _commissionList = value;
                RaisePropertyChanged();
            }
        }

        public CommissionViewModel SelectedCommission
        {
            get { return _selectedCommission; }
            set { _selectedCommission = value; RaisePropertyChanged(); RaisePropertyChanged("InspectionList"); SelectedInspection = null; }
        }

        public InspectionViewModel SelectedInspection
        {
            get { return _selectedInspection; }
            set { _selectedInspection = value; RaisePropertyChanged(); RaisePropertyChanged("EnableButtons"); }
        }
        
        public bool EnableButtons
        {
            get
            {
                if(_selectedInspection == null)
                {
                    return false;
                }
                return true;
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
            IInspectionsRepository inspectionsRepository, IRouterService router, IAuthService auth) : base(router)
        {
            authservice = auth;
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
            CommissionList = commissionRepository.GetAll();
        }
    }
}
