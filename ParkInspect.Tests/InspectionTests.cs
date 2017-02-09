using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParkInspect.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkInspect.Tests
{
    [TestClass]
    public class InspectionTests
    {
        [TestMethod]
        [TestCategory("Inspection")]
        public void TestId()
        {
            //arrange
            InspectionViewModel ins = new InspectionViewModel();
            //act
            ins.Id = 1;
            //act
            Assert.AreEqual(1, ins.Id);
        }

        [TestMethod]
        [TestCategory("Inspection")]
        public void TestIsChecked()
        {
            //arrange
            InspectionViewModel ins = new InspectionViewModel();
            //act
            ins.IsChecked = true;
            //assert
            Assert.AreEqual(true, ins.IsChecked);
        }

        [TestMethod]
        [TestCategory("Inspection")]
        public void TestName()
        {
            //arrange
            InspectionViewModel ins = new InspectionViewModel();
            //act
            ins.Name = "value";
            //assert
            Assert.AreEqual("value", ins.Name);
        }

        [TestMethod]
        [TestCategory("Inspection")]
        public void TestCommissionVM()
        {
            //arrange
            InspectionViewModel ins = new InspectionViewModel();
            CommissionViewModel CommissionViewModel = new CommissionViewModel();
            //act
            ins.CommissionViewModel = CommissionViewModel;
            //assert
            Assert.AreEqual(CommissionViewModel, ins.CommissionViewModel);
        }

        [TestMethod]
        [TestCategory("Inspection")]
        public void TestStartTime()
        {
            //arrange
            InspectionViewModel ins = new InspectionViewModel();
            DateTime dt = new DateTime(2017, 1, 30);
            //act
            ins.StartTime = dt;
            //assert
            Assert.AreEqual(dt, ins.StartTime);
        }

        [TestMethod]
        [TestCategory("Inspection")]
        public void TestEndTime()
        {
            //arrange
            InspectionViewModel ins = new InspectionViewModel();
            DateTime dt = new DateTime(2017, 1, 30);
            //act
            ins.EndTime = dt;
            //assert
            Assert.AreEqual(dt, ins.EndTime);
        }
    }
}
