using ParkInspect.Repositories;

namespace ParkInspect.ViewModel
{
    public class ManagementRapportenViewModel : MainViewModel
    {
        private IManagementRapportenRepository Repository { get; set; }

        public ManagementRapportenViewModel(IManagementRapportenRepository repo)
        {
            Repository = repo;
        }


    }
}
