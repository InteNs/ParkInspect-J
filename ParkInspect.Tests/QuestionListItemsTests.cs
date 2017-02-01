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
    public class QuestionListItemsTests
    {
        [TestMethod]
        [TestCategory("QuestionListItems")]
        public void CannotAddQuestionTest()
        {
            //arrange
            QuestionListItemsViewModel ques = new QuestionListItemsViewModel();
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
            QuestionListItemsViewModel ques = new QuestionListItemsViewModel();
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
            QuestionListItemsViewModel ques = new QuestionListItemsViewModel();
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
            QuestionListItemsViewModel ques = new QuestionListItemsViewModel();
            ObservableCollection<QuestionViewModel> Questions = new ObservableCollection<QuestionViewModel>();
            //act
            ques.Questions = Questions;
            //assert
            Assert.AreEqual(Questions, ques.Questions);
        }

       
    }
}
