using Microsoft.VisualStudio.TestTools.UnitTesting;
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
        [TestMethod]
        [TestCategory("EmployeeInspections")]
        public void TestInspections()
        {
            //arrange
            EmployeeInspectionsViewModel empIns = new EmployeeInspectionsViewModel();
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
            EmployeeInspectionsViewModel empIns = new EmployeeInspectionsViewModel();

            //act
            empIns.SelectedDay = "value";
            //assert
            Assert.AreEqual("value", empIns.SelectedDay);

        }
    }
}
