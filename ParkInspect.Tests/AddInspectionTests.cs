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
   public class AddInspectionTests
    {
        [TestMethod]
        [TestCategory("AddInspection")]
        public void ValidateEndLaterThanStartTest()
        {
            //arrange
            AddInspectionViewModel addInsp = new AddInspectionViewModel();
            CommissionViewModel comm = new CommissionViewModel();
            QuestionListViewModel ques = new QuestionListViewModel();
            DateTime end = new DateTime(2016, 09, 08);
            DateTime st = new DateTime(2016, 09, 09);
            addInsp.Inspection.StartTime = st;
            addInsp.Inspection.EndTime = end;
            addInsp.Inspection.CommissionViewModel = comm;
            addInsp.SelectedQuestionList = ques;
            //act
            addInsp.ValidateInput();
            //assert
            Assert.AreEqual(false, addInsp.ValidateInput());
        }

        [TestMethod]
        [TestCategory("AddInspection")]
        public void ValidateNotSelectedCommissionTest()
        {
            //arrange
            AddInspectionViewModel addInsp = new AddInspectionViewModel();
            CommissionViewModel comm = new CommissionViewModel();
            QuestionListViewModel ques = new QuestionListViewModel();
            DateTime end = new DateTime(2016, 09, 10);
            DateTime st = new DateTime(2016, 09, 09);
            addInsp.Inspection.StartTime = st;
            addInsp.Inspection.EndTime = end;
            addInsp.SelectedQuestionList = ques;
            //act
            addInsp.ValidateInput();
            //assert
            Assert.AreEqual(false, addInsp.ValidateInput());
        }

        [TestMethod]
        [TestCategory("AddInspection")]
        public void ValidateNotSelectedQuestionListTest()
        {
            //arrange
            AddInspectionViewModel addInsp = new AddInspectionViewModel();
            CommissionViewModel comm = new CommissionViewModel();
            QuestionListViewModel ques = new QuestionListViewModel();
            DateTime end = new DateTime(2016, 09, 10);
            DateTime st = new DateTime(2016, 09, 09);
            addInsp.Inspection.StartTime = st;
            addInsp.Inspection.EndTime = end;
            addInsp.Inspection.CommissionViewModel = comm;
            //act
            addInsp.ValidateInput();
            //assert
            Assert.AreEqual(false, addInsp.ValidateInput());
        }


        [TestMethod]
        [TestCategory("AddInspection")]
        public void TestInspection()
        {
            //arrange
            AddInspectionViewModel addInsp = new AddInspectionViewModel();
            InspectionViewModel ins = new InspectionViewModel();
            //act
            addInsp.Inspection = ins;
            //assert
            Assert.AreEqual(ins, addInsp.Inspection);
        }

        [TestMethod]
        [TestCategory("AddInspection")]
        public void TestCommissionList()
        {
            //arrange
            AddInspectionViewModel addInsp = new AddInspectionViewModel();
            QuestionListViewModel quesList = new QuestionListViewModel();
            //act
            addInsp.SelectedQuestionList = quesList;
            //assert
            Assert.AreEqual(quesList, addInsp.SelectedQuestionList);
        }
    }
}
