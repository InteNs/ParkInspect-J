using Data;
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
    public class QuestionListTest
    {
        [TestMethod]
        [TestCategory("QuestionList")]
        public void SetQuestionsTest()
        {
            //arrange
            QuestionListViewModel QuestionList = new QuestionListViewModel();
            ObservableCollection<QuestionItemViewModel> list = new ObservableCollection<QuestionItemViewModel> { new QuestionItemViewModel() { Question = new QuestionViewModel() { Id = 1, Description = "test", IsActive = true, Version = 1, QuestionType = Enumeration.QuestionType.Count} } };
            //act
            QuestionList.SetQuestions(list);
            //assert
            Assert.AreEqual(1, QuestionList.QuestionItems.Count());
           
        }

        [TestMethod]
        [TestCategory("QuestionList")]
        public void NextQuestionTest()
        {
            //arrange
            QuestionListViewModel QuestionList = new QuestionListViewModel();
            //act
            QuestionList.CurrentQuestion = new QuestionItemViewModel() { Question = new QuestionViewModel() { Id = 1, Description = "test", IsActive = true, Version = 1, QuestionType = Enumeration.QuestionType.Count } };
            QuestionList.NextQuestion();
            //assert
            Assert.AreEqual(1, QuestionList.CurrentQuestion.Question.Id);
        }

        [TestMethod]
        [TestCategory("QuestionList")]
        public void PreviousQuestionTest()
        {
            //arrange
            QuestionListViewModel QuestionList = new QuestionListViewModel();
            QuestionList.CurrentQuestion = new QuestionItemViewModel() { Question = new QuestionViewModel() { Id = 1, Description = "test", IsActive = true, Version = 1, QuestionType = Enumeration.QuestionType.Count } };
            //act
            QuestionList.PreviousQuestion();
            //assert
            Assert.AreEqual(1, QuestionList.CurrentQuestion.Question.Id);
        }

        [TestMethod]
        [TestCategory("QuestionList")]
        public void AnswerTrueTest()
        {
            //arrange
            QuestionListViewModel QuestionList = new QuestionListViewModel();
            QuestionList.CurrentQuestion = new QuestionItemViewModel() { Question = new QuestionViewModel() { Id = 1, Description = "test", IsActive = true, Version = 1, QuestionType = Enumeration.QuestionType.Count } };
            //act
            QuestionList.AnswerTrue();
            //assert
            Assert.AreEqual("Ja", QuestionList.CurrentQuestion.Answer);
        }

        [TestMethod]
        [TestCategory("QuestionList")]
        public void AnswerFalseTest()
        {
            //arrange
            QuestionListViewModel QuestionList = new QuestionListViewModel();
            QuestionList.CurrentQuestion = new QuestionItemViewModel() { Question = new QuestionViewModel() { Id = 1, Description = "test", IsActive = true, Version = 1, QuestionType = Enumeration.QuestionType.Count } };
            //act
            QuestionList.AnswerFalse();
            //assert
            Assert.AreEqual("Nee", QuestionList.CurrentQuestion.Answer);
        }

        [TestMethod]
        [TestCategory("QuestionList")]
        public void TestId()
        {
            //arrange
            QuestionListViewModel QuestionList = new QuestionListViewModel();
            //act
            QuestionList.Id = 1;
            //assert
            Assert.AreEqual(1, QuestionList.Id);

        }
        [TestMethod]
        [TestCategory("QuestionList")]
        public void TestDescription()
        {
            //arrange
            QuestionListViewModel QuestionList = new QuestionListViewModel();
            //act
            QuestionList.Description = "value";
            //assert
            Assert.AreEqual("value", QuestionList.Description);
        }

        [TestMethod]
        [TestCategory("QuestionList")]
        public void TestCurrentQuestion()
        {
            //arrange
            QuestionListViewModel QuestionList = new QuestionListViewModel();
            QuestionItemViewModel CurrentQuestion = new QuestionItemViewModel();
            //act
            QuestionList.CurrentQuestion = CurrentQuestion;
            //assert
            Assert.AreEqual(CurrentQuestion, QuestionList.CurrentQuestion);
        }

        [TestMethod]
        [TestCategory("QuestionList")]
        public void TestQuestionItems()
        {
            //arrange
            QuestionListViewModel QuestionList = new QuestionListViewModel();
            ObservableCollection<QuestionItemViewModel> QuestionItems = new ObservableCollection<QuestionItemViewModel>();
            //act
            QuestionList.QuestionItems = QuestionItems;
            //assert
            Assert.AreEqual(QuestionItems, QuestionList.QuestionItems);
        }

        [TestMethod]
        [TestCategory("QuestionList")]
        public void TestInspection()
        {
            //arrange
            QuestionListViewModel QuestionList = new QuestionListViewModel();
            InspectionViewModel Inspection = new InspectionViewModel();
            //act
            QuestionList.Inspection = Inspection;
            //assert
            Assert.AreEqual(Inspection, QuestionList.Inspection);
        }

    }
}
