using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ParkInspect.Repository.Interface;
using ParkInspect.Service;
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
    public class QuestionListItemsTests
    {
        private Mock<IQuestionRepository> que = new Mock<IQuestionRepository>();
        private Mock<IQuestionListRepository> qul = new Mock<IQuestionListRepository>();
        private Mock<IRouterService> rou = new Mock<IRouterService>();

        [TestMethod]
        [TestCategory("QuestionListItems")]
        public void CannotAddQuestionTest()
        {
            //arrange
            QuestionListsviewModel qvm = new QuestionListsviewModel(qul.Object, rou.Object);
            qvm.SelectedQuestionList = new QuestionListViewModel(qul.Object, rou.Object);
            QuestionListItemsViewModel ques = new QuestionListItemsViewModel(que.Object, qul.Object, rou.Object, qvm);
            //act
            ques.CanAddQuestion();
            //assert
            Assert.AreEqual(false, ques.CanAddQuestion());
        }

        [TestMethod]
        [TestCategory("QuestionListItems")]
        public void CannotDeleteQuestionTest()
        {
            //arrange
            QuestionListsviewModel qvm = new QuestionListsviewModel(qul.Object, rou.Object);
            qvm.SelectedQuestionList = new QuestionListViewModel(qul.Object, rou.Object);
            QuestionListItemsViewModel ques = new QuestionListItemsViewModel(que.Object, qul.Object, rou.Object, qvm);
            //act
            ques.CanDeleteQuestion();
            //assert
            Assert.AreEqual(false, ques.CanDeleteQuestion());
        }


        [TestMethod]
        [TestCategory("QuestionListItems")]
        public void TestQuestionItems()
        {
            //arrange
            QuestionListsviewModel qvm = new QuestionListsviewModel(qul.Object, rou.Object);
            qvm.SelectedQuestionList = new QuestionListViewModel(qul.Object, rou.Object);
            QuestionListItemsViewModel ques = new QuestionListItemsViewModel(que.Object, qul.Object, rou.Object, qvm);
            ObservableCollection<QuestionItemViewModel> QuestionItems = new ObservableCollection<QuestionItemViewModel>();
            //act
            ques.QuestionItems = QuestionItems;
            //assert
            Assert.AreEqual(QuestionItems, ques.QuestionItems);
        }


        [TestMethod]
        [TestCategory("QuestionListItems")]
        public void TestQuestions()
        {
            //arrange
            QuestionListsviewModel qvm = new QuestionListsviewModel(qul.Object, rou.Object);
            qvm.SelectedQuestionList = new QuestionListViewModel(qul.Object, rou.Object);
            QuestionListItemsViewModel ques = new QuestionListItemsViewModel(que.Object, qul.Object, rou.Object, qvm);
            ObservableCollection<QuestionViewModel> Questions = new ObservableCollection<QuestionViewModel>();
            //act
            ques.Questions = Questions;
            //assert
            Assert.AreEqual(Questions, ques.Questions);
        }

       
    }
}
