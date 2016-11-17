using ParkInspect.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkInspect.Repositories
{
    public interface ITestItemRepository
    {
        TestItemViewModel Get();
        IEnumerable<TestItemViewModel> GetAll();
        TestItemViewModel Create(TestItemViewModel testItem);
        TestItemViewModel Update(TestItemViewModel testItem);
        void Delete(TestItemViewModel testItem);
    }
}
