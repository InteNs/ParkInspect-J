using ParkInspect.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkInspect.Repositories
{
    public class DummyTestItemRepository : ITestItemRepository
    {
        private List<TestItemViewModel> testItems;
	
        public DummyTestItemRepository()
        {              
            testItems = new  List<TestItemViewModel>();
            testItems.Add(new TestItemViewModel("Pietje"));
            testItems.Add(new TestItemViewModel("Jaap"));
            testItems.Add(new TestItemViewModel("Geert"));
            testItems.Add(new TestItemViewModel("Freek"));
            testItems.Add(new TestItemViewModel("Cobert"));
            testItems.Add(new TestItemViewModel("Chickennugget"));
        }
	
        public IEnumerable<TestItemViewModel> GetAll()
        {
            return testItems;
        }

        public TestItemViewModel Get()
        {
            throw new NotImplementedException();
        }

        public TestItemViewModel Create(TestItemViewModel testItem)
        {
            throw new NotImplementedException();
        }

        public TestItemViewModel Update(TestItemViewModel testItem)
        {
            throw new NotImplementedException();
        }

        public void Delete(TestItemViewModel testItem)
        {
            throw new NotImplementedException();
        }
    }
}
