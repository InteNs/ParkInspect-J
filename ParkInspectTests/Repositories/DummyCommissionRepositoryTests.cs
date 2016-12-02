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
    public class DummyCommissionRepositoryTests
    {
        DummyCommissionRepository DCR = new DummyCommissionRepository();

        [TestMethod()]
        public void CreateTest()
        {
            CommissionViewModel newVM = new CommissionViewModel(7, 0, 5, 7, null, new DateTime(2016, 11, 29, 1, 45, 0),
                null, "Test", "Brabant", "Test");
            DCR.Create(newVM);
            Assert.IsTrue(DCR.GetAll().Contains(newVM));
        }

        [TestMethod()]
        public void UpdateTest()
        {
            CommissionViewModel newVM = new CommissionViewModel(11, 0, 5, 7, null, new DateTime(2016, 11, 29, 1, 45, 0),
                null, "Test", "Brabant", "Test");
            CommissionViewModel updatedVM = new CommissionViewModel(11, 0, 5, 7, null, new DateTime(2016, 11, 29, 1, 45, 0),
                null, "Test2", "Brabant", "Test");
            DCR.Create(newVM);
            DCR.Update(updatedVM);
            Assert.IsFalse(DCR.GetAll().Contains(newVM));
            Assert.IsTrue(DCR.GetAll().Contains(updatedVM));
        }

        [TestMethod()]
        public void DeleteTest()
        {
            CommissionViewModel newVM = new CommissionViewModel(9, 2, 8, 2, null, new DateTime(2016, 11, 29, 1, 45, 0),
                null, "Test2", "Brabant", "Test");
            DCR.Create(newVM);
            DCR.Delete(newVM);
            Assert.IsFalse(DCR.GetAll().Contains(newVM));
        }

        [TestMethod()]
        public void CreateLocationTest()
        {
            LocationViewModel newVM = new LocationViewModel(5, "8643ZK", 6, "Brabant");
            DCR.CreateLocation(newVM);
            Assert.IsTrue(DCR.GetLocationViewModels().Contains(newVM));
        }

       
    }
}