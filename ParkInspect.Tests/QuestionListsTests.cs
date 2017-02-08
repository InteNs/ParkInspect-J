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
    public class QuestionListsTests
    {
        private Mock<IQuestionListRepository> que = new Mock<IQuestionListRepository>();
        private Mock<IRouterService> rou = new Mock<IRouterService>();

        [TestMethod]
        [TestCategory("QuestionLists")]
        public void CannotEditQuestionListTest()
        {
            //arrange
            QuestionListsviewModel ques = new QuestionListsviewModel(que.Object, rou.Object);
            //QuestionListViewModel SelectedQuestionList = new QuestionListViewModel();
            //ques.SelectedQuestionList = SelectedQuestionList;
            //act
            ques.CanEditquestionList();
            //assert
            Assert.AreEqual(false, ques.CanEditquestionList());

        }
        

        [TestMethod]
        [TestCategory("QuestionLists")]
        public void TestQuestionLists()
        {
            //arrange
            QuestionListsviewModel ques = new QuestionListsviewModel(que.Object, rou.Object);
            ObservableCollection<QuestionListViewModel> QuestionLists = new ObservableCollection<QuestionListViewModel>();
            //act
            ques.QuestionLists = QuestionLists;
            //assert
            Assert.AreEqual(QuestionLists, ques.QuestionLists);

        }


    }
}
