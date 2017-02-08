using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ParkInspect.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkInspect.Tests
{
    [TestClass]
   public class TimeLineItemTests
    {
        private Mock<EmployeeViewModel> emp = new Mock<EmployeeViewModel>();

        [TestMethod]
        [TestCategory("TimeLineItem")]
        public void TestEmployee()
        {
            //arrange
            TimeLineItemViewModel tl = new TimeLineItemViewModel(emp.Object);
            EmployeeViewModel Employee = new EmployeeViewModel();
            //act
            tl.Employee = Employee;
            //assert
            Assert.AreEqual(Employee, tl.Employee);
        }

        [TestMethod]
        [TestCategory("TimeLineItem")]
        public void TestInspections()
        {
            //arrange
            TimeLineItemViewModel tl = new TimeLineItemViewModel(emp.Object);
            ObservableCollection<InspectionViewModel> Inspections = new ObservableCollection<InspectionViewModel>();
            //act
            tl.Inspections = Inspections;
            //assert
            Assert.AreEqual(Inspections, tl.Inspections);
        }
    }
}
