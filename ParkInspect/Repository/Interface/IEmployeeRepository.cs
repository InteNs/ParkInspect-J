using System.Collections.ObjectModel;
using ParkInspect.ViewModel;

namespace ParkInspect.Repository.Interface
{
    public interface IEmployeeRepository : IBaseRepository<EmployeeViewModel>
    {
        ObservableCollection<string> GetFunctions();
    }
}
