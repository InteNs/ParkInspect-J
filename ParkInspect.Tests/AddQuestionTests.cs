using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParkInspect.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using ParkInspect.Enumeration;
using ParkInspect.Repository.Interface;
using ParkInspect.Service;

namespace ParkInspect.Tests
{
    [TestClass]
   public class AddQuestionTests
    {
        private Mock<IQuestionRepository> quesRe = new Mock<IQuestionRepository>();
        private Mock<IRouterService> rou = new Mock<IRouterService>();
        private Mock<QuestionsViewModel> quessRe = new Mock<QuestionsViewModel>();

        [TestMethod]
        [TestCategory("AddQuestion")]
        public void TestQuestion()
        {
            //arrange
            AddQuestionViewModel addQues = new AddQuestionViewModel(quesRe.Object, rou.Object, quessRe.Object);
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
            AddQuestionViewModel addQues = new AddQuestionViewModel(quesRe.Object, rou.Object, quessRe.Object);
            QuestionsViewModel ques = new QuestionsViewModel(quesRe.Object, rou.Object);
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
            AddQuestionViewModel addQues = new AddQuestionViewModel(quesRe.Object, rou.Object, quessRe.Object);
            //act
            addQues.Question.Id = 1;
            addQues.Question.Description = "test";
            addQues.Question.IsActive = true;
            addQues.Question.Version = 1;
            addQues.Question.QuestionType = QuestionType.Count;
            addQues.AddQuestion();
            //assert
            Assert.AreEqual(true, addQues.ValidateInput());
        }
    }
}
