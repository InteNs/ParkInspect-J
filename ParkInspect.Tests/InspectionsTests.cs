using Microsoft.Practices.ServiceLocation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParkInspect.Repository.Interface;
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
    public class InspectionsTests
    {
        [TestMethod]
        [TestCategory("Inspections")]
        public void TestSelectedCommission()
        {
            //arrange
            InspectionsViewModel inspections = new InspectionsViewModel();
            CommissionViewModel SelectedCommission = new CommissionViewModel();
            //act
            inspections.SelectedCommission = SelectedCommission;
            //assert
            Assert.AreEqual(SelectedCommission, inspections.SelectedCommission);
        }

        [TestMethod]
        [TestCategory("Inspections")]
        public void TestSelectedInspection()
        {
            //arrange
            InspectionsViewModel inspections = new InspectionsViewModel();
            InspectionViewModel SelectedInspection = new InspectionViewModel();
            //act
            inspections.SelectedInspection = SelectedInspection;
            //assert
            Assert.AreEqual(SelectedInspection, inspections.SelectedInspection);
        }

        [TestMethod]
        [TestCategory("Inspections")]
        public void TestIsManager()
        {
            //arrange
            InspectionsViewModel inspections = new InspectionsViewModel();
            //act
            inspections.IsManager = true;
            //assert
            Assert.AreEqual(true, inspections.IsManager);
        }

        [TestMethod]
        [TestCategory("Inspections")]
        public void TestIsInspector()
        {
            //arrange
            InspectionsViewModel inspections = new InspectionsViewModel();
            //act
            inspections.IsInspecteur = true;
            //assert
            Assert.AreEqual(true, inspections.IsInspecteur);
        }

    }
}
