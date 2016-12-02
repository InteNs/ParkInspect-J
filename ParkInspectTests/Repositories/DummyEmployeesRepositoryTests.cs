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
    public class DummyEmployeesRepositoryTests
    {
        private DummyEmployeesRepository DER = new DummyEmployeesRepository();

        [TestMethod()]
        public void CreateTest()
        {
            EmployeeViewModel newVM = new EmployeeViewModel();
            DER.Create(newVM);
            Assert.IsTrue(DER.GetAll().Contains(newVM));
        }
        

        [TestMethod()]
        public void UpdateTest()
        {
            EmployeeViewModel newVM = new EmployeeViewModel() { Email = "test@test.com", Function = "Test", Id = 12, Name = "Test", StreetNumber = "00" };
            EmployeeViewModel updatedVM = new EmployeeViewModel() { Email = "test11@test.com", Function = "Test", Id = 12, Name = "Test", StreetNumber = "000" }; ;
            DER.Create(newVM);
            DER.Update(updatedVM);
            Assert.IsTrue(DER.GetAll().Contains(updatedVM));
            Assert.IsFalse(DER.GetAll().Contains(newVM));
        }
        
    }
}