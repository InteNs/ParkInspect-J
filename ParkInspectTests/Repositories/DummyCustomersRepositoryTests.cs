using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParkInspect.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkInspect.ViewModel;

namespace ParkInspectTests.Repositories
{
    [TestClass()]
    public class DummyCustomersRepositoryTests
    {
        private DummyCustomersRepository DCR = new DummyCustomersRepository();
        [TestMethod()]
        public void CreateTest()
        {
            CustomerViewModel newVM = new CustomerViewModel();
            DCR.Create(newVM);
            Assert.IsTrue(DCR.GetAll().Contains(newVM));
        }
        

        [TestMethod()]
        public void UpdateTest()
        {
            CustomerViewModel newVM = new CustomerViewModel() {Email = "test@test.com", Function = "Test", Id = 12, Name = "Test", StreetNumber = "00"};
            CustomerViewModel updatedVM = new CustomerViewModel() { Email = "test11@test.com", Function = "Test", Id = 12, Name = "Test", StreetNumber = "000" }; ;
            DCR.Create(newVM);
            DCR.Update(updatedVM);
            Assert.IsTrue(DCR.GetAll().Contains(updatedVM));
            Assert.IsFalse(DCR.GetAll().Contains(newVM));
        }
    }
}