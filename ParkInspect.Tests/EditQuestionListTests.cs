using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParkInspect.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using ParkInspect.Repository.Interface;
using ParkInspect.Service;

namespace ParkInspect.Tests
{
    [TestClass]
   public class EditQuestionListTests
    {

        private Mock<IQuestionListRepository> quesListMock = new Mock<IQuestionListRepository>();
        private Mock<IRouterService> rou = new Mock<IRouterService>();

        [TestMethod]
        [TestCategory("EditQuestionList")]
        public void ValidateInputTest()
        {
            //arrange
            QuestionListsviewModel qlvm = new QuestionListsviewModel(quesListMock.Object, rou.Object);
            EditQuestionListViewModel edit = new EditQuestionListViewModel(quesListMock.Object, rou.Object, qlvm);
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
            QuestionListsviewModel qlvm = new QuestionListsviewModel(quesListMock.Object, rou.Object);
            EditQuestionListViewModel edit = new EditQuestionListViewModel(quesListMock.Object, rou.Object, qlvm);
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
            QuestionListsviewModel qlvm = new QuestionListsviewModel(quesListMock.Object, rou.Object);
            EditQuestionListViewModel edit = new EditQuestionListViewModel(quesListMock.Object, rou.Object, qlvm);
            QuestionListViewModel QuestionList = new QuestionListViewModel();
            //act
            edit.QuestionList = QuestionList;
            //assert
            Assert.AreEqual(QuestionList, edit.QuestionList);
        }

   

       
    }
}
