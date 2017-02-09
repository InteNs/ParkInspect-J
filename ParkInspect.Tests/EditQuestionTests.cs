using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ParkInspect.Repository.Interface;
using ParkInspect.Service;
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
        private Mock<IQuestionRepository> que = new Mock<IQuestionRepository>();
        private Mock<IRouterService> rou = new Mock<IRouterService>();

        [TestMethod]
        [TestCategory("EditQuestion")]
        public void ValidateInputTest()
        {
            //arrange
            QuestionsViewModel questions = new QuestionsViewModel(que.Object, rou.Object);
            EditQuestionViewModel edit = new EditQuestionViewModel(que.Object, rou.Object, questions);
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
            QuestionsViewModel questions = new QuestionsViewModel(que.Object, rou.Object);
            EditQuestionViewModel edit = new EditQuestionViewModel(que.Object, rou.Object, questions);
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
            QuestionsViewModel questions = new QuestionsViewModel(que.Object, rou.Object);
            EditQuestionViewModel edit = new EditQuestionViewModel(que.Object, rou.Object, questions);
            QuestionViewModel Question = new QuestionViewModel();
            //act
            edit.Question = Question;
            //assert
            Assert.AreEqual(Question, edit.Question);
        }
    }
}
