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
    public class EditQuestionTests
    {

        [TestMethod]
        [TestCategory("EditQuestion")]
        public void ValidateInputTest()
        {
            //arrange
            EditQuestionViewModel edit = new EditQuestionViewModel();
            QuestionViewModel Question = new QuestionViewModel();
            edit.Question = Question;
            edit.Question.Description = "test";
            //act
            edit.ValidateInput();
            //assert
            Assert.AreEqual(true, edit.ValidateInput());
        }

        [TestMethod]
        [TestCategory("EditQuestion")]
        public void ValidateNoInputTest()
        {
            //arrange
            EditQuestionViewModel edit = new EditQuestionViewModel();
            QuestionViewModel Question = new QuestionViewModel();
            edit.Question = Question;
            //act
            edit.ValidateInput();
            //assert
            Assert.AreEqual(false, edit.ValidateInput());
        }

        [TestMethod]
        [TestCategory("EditQuestion")]
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
