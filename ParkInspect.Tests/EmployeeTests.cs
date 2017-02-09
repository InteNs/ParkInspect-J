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
   public class EmployeeTests
    {
        [TestMethod]
        [TestCategory("Employee")]
        public void TestId()
        {
            //arrange
            EmployeeViewModel emp = new EmployeeViewModel();
            //act
            emp.Id = 1;
            //assert
            Assert.AreEqual(1, emp.Id);
        }

        [TestMethod]
        [TestCategory("Employee")]
        public void TestEmploymentDate()
        {
            //arrange
            EmployeeViewModel emp = new EmployeeViewModel();
            DateTime dt = new DateTime(2017, 1, 30);
            //act
            emp.EmploymentDate = dt;
            //assert
            Assert.AreEqual(dt, emp.EmploymentDate);
        }

        [TestMethod]
        [TestCategory("Employee")]
        public void TestDismissalDate()
        {
            //arrange
            EmployeeViewModel emp = new EmployeeViewModel();
            DateTime dt = new DateTime(2017, 1, 30);
            //act
            emp.DismissalDate = dt;
            //assert
            Assert.AreEqual(dt, emp.DismissalDate);
        }

        [TestMethod]
        [TestCategory("Employee")]
        public void TestFunction()
        {
            //arrange
            EmployeeViewModel emp = new EmployeeViewModel();
            //act
            emp.Function = "value";
            //assert
            Assert.AreEqual("value", emp.Function);
        }
    }
}
