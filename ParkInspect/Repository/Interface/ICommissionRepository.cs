using System.Collections.ObjectModel;
using ParkInspect.ViewModel;

namespace ParkInspect.Repository.Interface
{
    public interface ICommissionRepository : IBaseRepository<CommissionViewModel>
    {
        ObservableCollection<string> GetStatuses();
    }
}