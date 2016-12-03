using System.Collections.ObjectModel;
using ParkInspect.ViewModel;

namespace ParkInspect.Repository.Interface
{
    public interface ICustomerRepository : IBaseRepository<CustomerViewModel>
    {
        ObservableCollection<string> GetFunctions();
    }
}
