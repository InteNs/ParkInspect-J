using System.Collections.Generic;
using ParkInspect.ViewModel;

namespace ParkInspect.Repository.Interface
{
    public interface ICommissionRepository
    {
        IEnumerable<CommissionViewModel> GetAll();

        bool Create(CommissionViewModel commission);
        bool Update(CommissionViewModel commission);
        void Delete(CommissionViewModel commission);

        void CreateLocation(LocationViewModel location);


        IEnumerable<string> GetRegions();
        IEnumerable<CustomerViewModel> GetCustomers();
        IEnumerable<LocationViewModel> GetLocationViewModels();

    }
}