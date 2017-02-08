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
   public class QuestionItemTests
    {
        private Mock<IQuestionListRepository> que = new Mock<IQuestionListRepository>();
        private Mock<IRouterService> rou = new Mock<IRouterService>();

        [TestMethod]
        [TestCategory("QuestionItem")]
        public void TestQuestion()
        {
            //arrange
            QuestionItemViewModel ques = new QuestionItemViewModel();
            QuestionViewModel Question = new QuestionViewModel();
            //act
            ques.Question = Question;
            //assert
            Assert.AreEqual(Question, ques.Question);
        }

        [TestMethod]
        [TestCategory("QuestionItem")]
        public void TestQuestionList()
        {
            //arrange
            QuestionItemViewModel ques = new QuestionItemViewModel();
            QuestionListViewModel QuestionList = new QuestionListViewModel(que.Object, rou.Object);
            //act
            ques.QuestionList = QuestionList;
            //assert
            Assert.AreEqual(QuestionList, ques.QuestionList);
        }

        [TestMethod]
        [TestCategory("QuestionItem")]
        public void TestAnswer()
        {
            //arrange
            QuestionItemViewModel ques = new QuestionItemViewModel();
            //act
            ques.Answer = "value";
            //assert
            Assert.AreEqual("value", ques.Answer);
        }
    }
}
