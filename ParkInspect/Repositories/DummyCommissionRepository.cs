using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkInspect.Repositories
{
    public class DummyCommissionRepository : ICommissionRepository
    {
        private List<Commission> commissions;
        public DummyCommissionRepository()
        {
            commissions = new List<Commission>();
            commissions.Add(new Commission { Id = 1, Frequency = 0, CustomerId = 1 });
            commissions.Add(new Commission { Id = 2, Frequency = 0, CustomerId = 2 });
            commissions.Add(new Commission { Id = 3, Frequency = 2, CustomerId = 3 });
        }

        public Commission Get()
        {
            throw new NotImplementedException();
        }

        List<Commission> ICommissionRepository.GetAll()
        {
            throw new NotImplementedException();
        }

        public Commission Create(Commission commission)
        {
            throw new NotImplementedException();
        }

        public Commission Update(Commission commission)
        {
            throw new NotImplementedException();
        }

        public void Delete(Commission commission)
        {
            throw new NotImplementedException();
        }

        public IEnumerable GetAll()
        {
            return commissions;
        }


    }
}
