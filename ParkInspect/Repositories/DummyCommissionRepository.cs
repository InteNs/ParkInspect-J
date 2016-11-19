using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkInspect.ViewModel;

namespace ParkInspect.Repositories
{
    public class DummyCommissionRepository : ICommissionRepository
    {

        private List<CommissionViewModel> commissions;

        public DummyCommissionRepository()
        {
            commissions = new List<CommissionViewModel>();
            commissions.Add(new CommissionViewModel(1, 1, 1, 1, 1, new DateTime(2016, 11, 17, 19, 57, 0), new DateTime(2016, 11, 19, 20, 13, 0), "Test Description 1", "Utrecht"));
            commissions.Add(new CommissionViewModel(2, 1, 2, 2, 2, new DateTime(2016, 10, 5, 19, 57, 0), null, "Test Description 2", "Utrecht"));
            commissions.Add(new CommissionViewModel(3, 2, 3, 1, null, new DateTime(2016, 11, 17, 19, 57, 0), null, "Test Description 3", "Utrecht"));
        }

        public IEnumerable GetAll()
        {
            return commissions;
        }



        IEnumerable<CommissionViewModel> ICommissionRepository.GetAll()
        {
            throw new NotImplementedException();
        }

        public bool Create(CommissionViewModel commission)
        {
            return true;
        }

        public bool Update(CommissionViewModel commission)
        {
            return true;
        }

        public void Delete(CommissionViewModel commission)
        {
            throw new NotImplementedException();
        }
    }
}
