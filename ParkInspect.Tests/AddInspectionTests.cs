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
