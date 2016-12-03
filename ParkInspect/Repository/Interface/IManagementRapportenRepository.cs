using System.Collections.Generic;
using ParkInspect.ViewModel;

namespace ParkInspect.Repositories
{
    public interface IManagementRapportenRepository
    {
        ManagementRapportenViewModel Get();
        List<ManagementRapportenViewModel> GetAll();
        ManagementRapportenViewModel Create(ManagementRapportenViewModel vm);
        ManagementRapportenViewModel Update(ManagementRapportenViewModel vm);
        void Delete(ManagementRapportenViewModel vm);
    }
}