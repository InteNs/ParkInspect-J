using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using ParkInspect.Repositories;

namespace ParkInspect.ViewModel
{
    public class CommissionOverviewViewModel : ViewModelBase
    {

        
        private ICommissionRepository _repository;

        private RouterViewModel _router;

        private string _regionFilter;

         public ObservableCollection<CommissionViewModel> EmployeesCompleteList { get; set; }

        public ObservableCollection<CommissionViewModel> EmployeesShowableList { get; set; }

         public CommissionOverviewViewModel(ICommissionRepository repo, RouterViewModel router)
        {
            _repository = repo;
            _router = router;

            EmployeesCompleteList = new ObservableCollection<CommissionViewModel>(_repository.GetAll());

            EmployeesShowableList = new ObservableCollection<CommissionViewModel>();

    }
}
}
