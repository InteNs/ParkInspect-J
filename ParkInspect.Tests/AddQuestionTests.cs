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
   public class AddQuestionTests
    {
        [TestMethod]
        [TestCategory("AddQuestion")]
        public void TestQuestion()
        {
            //arrange
            AddQuestionViewModel addQues = new AddQuestionViewModel();
            QuestionViewModel ques = new QuestionViewModel();
            //act
            addQues.Question = ques;
            //assert
            Assert.AreEqual(ques, addQues.Question);
        }

        [TestMethod]
        [TestCategory("AddQuestion")]
        public void TestQuestions()
        {
            //arrange
            AddQuestionViewModel addQues = new AddQuestionViewModel();
            QuestionsViewModel ques = new QuestionsViewModel();
            //act
            addQues.Questions = ques;
            //assert
            Assert.AreEqual(ques, addQues.Questions);
        }

        [TestMethod]
        [TestCategory("AddQuestion")]
        public void AddQuestions()
        {
            //arrange
            AddQuestionViewModel addQues = new AddQuestionViewModel();
            //act
            addQues.AddQuestion();
            //assert
            Assert.AreEqual(addQues.Question.Id, 1);
        }
    }
}
