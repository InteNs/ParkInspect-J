using Microsoft.Practices.ServiceLocation;
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
    public class InspectionsTests
    {
        private Mock<ICommissionRepository> com = new Mock<ICommissionRepository>();
        private Mock<IInspectionsRepository> ins = new Mock<IInspectionsRepository>();
        private Mock<IQuestionListRepository> iql = new Mock<IQuestionListRepository>();
        private Mock<IRouterService> rou = new Mock<IRouterService>();
        private Mock<IAuthService> aut = new Mock<IAuthService>();

        [TestMethod]
        [TestCategory("Inspections")]
        public void TestSelectedCommission()
        {
            //arrange
            InspectionsViewModel inspections = new InspectionsViewModel(com.Object, ins.Object, iql.Object, rou.Object, aut.Object);
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
            InspectionsViewModel inspections = new InspectionsViewModel(com.Object, ins.Object, iql.Object, rou.Object, aut.Object);
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
            InspectionsViewModel inspections = new InspectionsViewModel(com.Object, ins.Object, iql.Object, rou.Object, aut.Object);
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
            InspectionsViewModel inspections = new InspectionsViewModel(com.Object, ins.Object, iql.Object, rou.Object, aut.Object);
            //act
            inspections.IsInspecteur = true;
            //assert
            Assert.AreEqual(true, inspections.IsInspecteur);
        }

    }
}
