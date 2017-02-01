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
   public class EditQuestionListTests
    {
        [TestMethod]
        [TestCategory("EditQuestionList")]
        public void ValidateInputTest()
        {
            //arrange
            EditQuestionListViewModel edit = new EditQuestionListViewModel();
            QuestionListViewModel QuestionList = new QuestionListViewModel();
            edit.QuestionList = QuestionList;
            edit.QuestionList.Description = "test";
            //act
            edit.ValidateInput();
            //assert
            Assert.AreEqual(true, edit.ValidateInput());
        }

        [TestMethod]
        [TestCategory("EditQuestionList")]
        public void ValidateNoInputTest()
        {
            //arrange
            EditQuestionListViewModel edit = new EditQuestionListViewModel();
            QuestionListViewModel QuestionList = new QuestionListViewModel();
            edit.QuestionList = QuestionList;
            //act
            edit.ValidateInput();
            //assert
            Assert.AreEqual(false, edit.ValidateInput());
        }

        [TestMethod]
        [TestCategory("EditQuestionList")]
        public void TestQuestionList()
        {
            //arrange
            EditQuestionListViewModel edit = new EditQuestionListViewModel();
            QuestionListViewModel QuestionList = new QuestionListViewModel();
            //act
            edit.QuestionList = QuestionList;
            //assert
            Assert.AreEqual(QuestionList, edit.QuestionList);
        }

   

       
    }
}
