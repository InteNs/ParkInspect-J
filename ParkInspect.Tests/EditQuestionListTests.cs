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

        [TestMethod]
        [TestCategory("EditQuestionList")]
        public void TestQuestion()
        {
            //arrange
            EditQuestionViewModel edit = new EditQuestionViewModel();
            QuestionViewModel Question = new QuestionViewModel();
            //act
            edit.Question = Question;
            //assert
            Assert.AreEqual(Question, edit.Question);
        }
    }
}
