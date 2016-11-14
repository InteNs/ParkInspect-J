using ParkInspect.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;

namespace ParkInspect.Repositories
{
    public class DummyTestItemRepository : ITestItemRepository
    {
        private ParkInspectEntities _context;
	
        public DummyTestItemRepository(ParkInspectEntities context)
        {
            _context = context;
        }
	
        public IEnumerable<TestItemViewModel> GetAll()
        {
            return new List<TestItemViewModel>
            {
                new TestItemViewModel("test1")
            };
            //return _context.employees.all.tolist; as viewmodels
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
