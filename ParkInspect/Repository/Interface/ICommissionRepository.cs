using System.Collections.Generic;
using System.Collections.ObjectModel;
using ParkInspect.ViewModel;

namespace ParkInspect.Repository.Interface
{
    public interface ICommissionRepository
    {
        ObservableCollection<CommissionViewModel> GetAll();

        bool Create(CommissionViewModel commission);
        bool Update(CommissionViewModel commission);
        void Delete(CommissionViewModel commission);

        void CreateLocation(LocationViewModel location);

        ObservableCollection<string> GetStatuses();

        //        IEnumerable<string> GetRegions();
        //        IEnumerable<CustomerViewModel> GetCustomers();
        //        IEnumerable<EmployeeViewModel> GetEmployees();
        IEnumerable<LocationViewModel> GetLocationViewModels();

    }
}