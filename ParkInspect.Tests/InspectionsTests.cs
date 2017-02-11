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
        private Mock<IEmployeeRepository> emp = new Mock<IEmployeeRepository>();
        private Mock<IRouterService> rou = new Mock<IRouterService>();
        private Mock<IAuthService> aut = new Mock<IAuthService>();

        [TestMethod]
        [TestCategory("Inspections")]
        public void TestSelectedCommission()
        {
            //arrange
            QuestionListsviewModel qvm = new QuestionListsviewModel(iql.Object, rou.Object);
            TimeLineViewModel time = new TimeLineViewModel(rou.Object, ins.Object, emp.Object, aut.Object);
            InspectionsViewModel inspections = new InspectionsViewModel(com.Object, ins.Object, iql.Object, rou.Object, aut.Object, qvm, time);
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
            QuestionListsviewModel qvm = new QuestionListsviewModel(iql.Object, rou.Object);
            TimeLineViewModel time = new TimeLineViewModel(rou.Object, ins.Object, emp.Object, aut.Object);
            InspectionsViewModel inspections = new InspectionsViewModel(com.Object, ins.Object, iql.Object, rou.Object, aut.Object, qvm, time);
            InspectionViewModel selectedInspection = new InspectionViewModel();
            //act
            inspections.SelectedInspection = selectedInspection;
            //assert
            Assert.AreEqual(selectedInspection, inspections.SelectedInspection);
        }

        [TestMethod]
        [TestCategory("Inspections")]
        public void TestIsManager()
        {
            //arrange
            QuestionListsviewModel qvm = new QuestionListsviewModel(iql.Object, rou.Object);
            TimeLineViewModel time = new TimeLineViewModel(rou.Object, ins.Object, emp.Object, aut.Object);
            InspectionsViewModel inspections = new InspectionsViewModel(com.Object, ins.Object, iql.Object, rou.Object, aut.Object, qvm, time);
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
            QuestionListsviewModel qvm = new QuestionListsviewModel(iql.Object, rou.Object);
            TimeLineViewModel time = new TimeLineViewModel(rou.Object, ins.Object, emp.Object, aut.Object);
            InspectionsViewModel inspections = new InspectionsViewModel(com.Object, ins.Object, iql.Object, rou.Object, aut.Object, qvm, time);
            //act
            inspections.IsInspecteur = true;
            //assert
            Assert.AreEqual(true, inspections.IsInspecteur);
        }

    }
}
