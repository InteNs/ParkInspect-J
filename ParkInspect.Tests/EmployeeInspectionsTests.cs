using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ParkInspect.Repository.Interface;
using ParkInspect.Service;
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
   public class EmployeeInspectionsTests
    {
        private Mock<IRouterService> rou = new Mock<IRouterService>();
        private Mock<IInspectionsRepository> iin = new Mock<IInspectionsRepository>();
        private Mock<IEmployeeRepository> emp = new Mock<IEmployeeRepository>();
        private Mock<IAuthService> aut = new Mock<IAuthService>();

        [TestMethod]
        [TestCategory("EmployeeInspections")]
        public void TestInspections()
        {
            //arrange
            TimeLineViewModel time = new TimeLineViewModel(rou.Object, iin.Object, emp.Object, aut.Object);
            EmployeeInspectionsViewModel empIns = new EmployeeInspectionsViewModel(time);
            ObservableCollection<InspectionViewModel> Inspections = new ObservableCollection<InspectionViewModel>();
            //act
            empIns.Inspections = Inspections;
            //assert
            Assert.AreEqual(Inspections, empIns.Inspections);

        }

        [TestMethod]
        [TestCategory("EmployeeInspections")]
        public void TestSelectedDay()
        {
            //arrange
            TimeLineViewModel time = new TimeLineViewModel(rou.Object, iin.Object, emp.Object, aut.Object);
            EmployeeInspectionsViewModel empIns = new EmployeeInspectionsViewModel(time);

            //act
            empIns.SelectedDay = "value";
            //assert
            Assert.AreEqual("value", empIns.SelectedDay);

        }
    }
}
