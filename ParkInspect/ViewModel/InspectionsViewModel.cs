using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using ParkInspect.Repositories;
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

        public InspectionsViewModel(ICommissionRepository commissionRepository,IRouterService router):base(router)
        {
            InspectionList = new ObservableCollection<InspectionViewModel>
            {
                new InspectionViewModel("Inspectie 1"),
                new InspectionViewModel("Inspectie 2"),
                new InspectionViewModel("Inspectie 3"),
                new InspectionViewModel("Inspectie 4"),
                new InspectionViewModel("Inspectie 5")
            };
            CommissionList = new ObservableCollection<CommissionViewModel>(commissionRepository.GetAll());
        }
    }
}
