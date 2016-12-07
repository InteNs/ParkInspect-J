using System.Collections.ObjectModel;
using ParkInspect.Repository.Interface;
using ParkInspect.Service;

namespace ParkInspect.ViewModel
{
    public class InspectionsViewModel : MainViewModel
    {
        private CommissionViewModel _selectedCommission;

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

        public InspectionsViewModel(ICommissionRepository commissionRepository,
            IInspectionsRepository inspectionsRepository, IRouterService router) : base(router)
        {
            InspectionList = inspectionsRepository.GetAll();
            CommissionList = new ObservableCollection<CommissionViewModel>(commissionRepository.GetAll());
        }
    }
}
