using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkInspect.Repositories
{
    public interface ICommissionRepository
    {
        Commission Get();
        List<Commission> GetAll();
        Commission Create(Commission commission);
        Commission Update(Commission commission);
        void Delete(Commission commission);
    }
}
