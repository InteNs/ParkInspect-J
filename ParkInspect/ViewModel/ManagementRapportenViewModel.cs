using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkInspect.Repositories;

namespace ParkInspect.ViewModel
{
    public class ManagementRapportenViewModel : MainViewModel
    {
        private ManagementRapportenRepository _repository { get; set; }

        public ManagementRapportenViewModel(ManagementRapportenRepository repository)
        {
            _repository = repository;
        }


    }
}
