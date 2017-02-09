using Data;
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
    public class QuestionListTest
    {
        private IEnumerable<QuestionItemViewModel> questions = new ObservableCollection<QuestionItemViewModel>();
        private Mock<IQuestionListRepository> que = new Mock<IQuestionListRepository>();
        private Mock<IRouterService> rou = new Mock<IRouterService>();
        private List<QuestionItemViewModel> temp = new List<QuestionItemViewModel>();

        [TestMethod]
        [TestCategory("QuestionList")]
        public void SetQuestionsTest()
        {
            //arrange
            QuestionItemViewModel question1 = new QuestionItemViewModel();
            QuestionItemViewModel question2 = new QuestionItemViewModel();
            QuestionItemViewModel question3 = new QuestionItemViewModel();
            QuestionItemViewModel question4 = new QuestionItemViewModel();
            QuestionItemViewModel question5 = new QuestionItemViewModel();

            question1.Question = new QuestionViewModel();
            question2.Question = new QuestionViewModel();
            question3.Question = new QuestionViewModel();
            question4.Question = new QuestionViewModel();
            question5.Question = new QuestionViewModel();

            temp.Add(question1);
            temp.Add(question2);
            temp.Add(question3);
            temp.Add(question4);
            temp.Add(question5);

            questions = temp.AsEnumerable();
            
            QuestionListViewModel QuestionList = new QuestionListViewModel(questions, que.Object, rou.Object);
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
            QuestionItemViewModel question1 = new QuestionItemViewModel();
            QuestionItemViewModel question2 = new QuestionItemViewModel();
            QuestionItemViewModel question3 = new QuestionItemViewModel();
            QuestionItemViewModel question4 = new QuestionItemViewModel();
            QuestionItemViewModel question5 = new QuestionItemViewModel();

            question1.Question = new QuestionViewModel() { Id = 1, Description = "test1", IsActive = true, Version = 1, QuestionType = Enumeration.QuestionType.Count };
            question2.Question = new QuestionViewModel() { Id = 2, Description = "test2", IsActive = true, Version = 1, QuestionType = Enumeration.QuestionType.Count };
            question3.Question = new QuestionViewModel() { Id = 3, Description = "test3", IsActive = true, Version = 1, QuestionType = Enumeration.QuestionType.Count };
            question4.Question = new QuestionViewModel() { Id = 4, Description = "test4", IsActive = true, Version = 1, QuestionType = Enumeration.QuestionType.Count };
            question5.Question = new QuestionViewModel() { Id = 5, Description = "test5", IsActive = true, Version = 1, QuestionType = Enumeration.QuestionType.Count };

            temp.Add(question1);
            temp.Add(question2);
            temp.Add(question3);
            temp.Add(question4);
            temp.Add(question5);

            questions = temp.AsEnumerable();
            QuestionListViewModel QuestionList = new QuestionListViewModel(questions, que.Object, rou.Object);
            //act
            QuestionList.NextQuestion();
            //assert
            Assert.AreEqual(2, QuestionList.CurrentQuestion.Question.Id);
        }

        [TestMethod]
        [TestCategory("QuestionList")]
        public void PreviousQuestionTest()
        {
            //arrange
            QuestionItemViewModel question1 = new QuestionItemViewModel();
            QuestionItemViewModel question2 = new QuestionItemViewModel();
            QuestionItemViewModel question3 = new QuestionItemViewModel();
            QuestionItemViewModel question4 = new QuestionItemViewModel();
            QuestionItemViewModel question5 = new QuestionItemViewModel();

            question1.Question = new QuestionViewModel() { Id = 1, Description = "test1", IsActive = true, Version = 1, QuestionType = Enumeration.QuestionType.Count };
            question2.Question = new QuestionViewModel() { Id = 2, Description = "test2", IsActive = true, Version = 1, QuestionType = Enumeration.QuestionType.Count };
            question3.Question = new QuestionViewModel() { Id = 3, Description = "test3", IsActive = true, Version = 1, QuestionType = Enumeration.QuestionType.Count };
            question4.Question = new QuestionViewModel() { Id = 4, Description = "test4", IsActive = true, Version = 1, QuestionType = Enumeration.QuestionType.Count };
            question5.Question = new QuestionViewModel() { Id = 5, Description = "test5", IsActive = true, Version = 1, QuestionType = Enumeration.QuestionType.Count };

            temp.Add(question1);
            temp.Add(question2);
            temp.Add(question3);
            temp.Add(question4);
            temp.Add(question5);

            questions = temp.AsEnumerable();
            QuestionListViewModel QuestionList = new QuestionListViewModel(questions, que.Object, rou.Object);
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
            QuestionItemViewModel question1 = new QuestionItemViewModel();
            QuestionItemViewModel question2 = new QuestionItemViewModel();
            QuestionItemViewModel question3 = new QuestionItemViewModel();
            QuestionItemViewModel question4 = new QuestionItemViewModel();
            QuestionItemViewModel question5 = new QuestionItemViewModel();

            question1.Question = new QuestionViewModel() { Id = 1, Description = "test1", IsActive = true, Version = 1, QuestionType = Enumeration.QuestionType.Count };
            question2.Question = new QuestionViewModel() { Id = 2, Description = "test2", IsActive = true, Version = 1, QuestionType = Enumeration.QuestionType.Count };
            question3.Question = new QuestionViewModel() { Id = 3, Description = "test3", IsActive = true, Version = 1, QuestionType = Enumeration.QuestionType.Count };
            question4.Question = new QuestionViewModel() { Id = 4, Description = "test4", IsActive = true, Version = 1, QuestionType = Enumeration.QuestionType.Count };
            question5.Question = new QuestionViewModel() { Id = 5, Description = "test5", IsActive = true, Version = 1, QuestionType = Enumeration.QuestionType.Count };

            temp.Add(question1);
            temp.Add(question2);
            temp.Add(question3);
            temp.Add(question4);
            temp.Add(question5);

            questions = temp.AsEnumerable();
            QuestionListViewModel QuestionList = new QuestionListViewModel(questions, que.Object, rou.Object);
            //act
            QuestionList.AnswerTrue();
            QuestionList.PreviousQuestion();
            //assert
            Assert.AreEqual("Ja", QuestionList.CurrentQuestion.Answer);
        }

        [TestMethod]
        [TestCategory("QuestionList")]
        public void AnswerFalseTest()
        {
            //arrange
            QuestionItemViewModel question1 = new QuestionItemViewModel();
            QuestionItemViewModel question2 = new QuestionItemViewModel();
            QuestionItemViewModel question3 = new QuestionItemViewModel();
            QuestionItemViewModel question4 = new QuestionItemViewModel();
            QuestionItemViewModel question5 = new QuestionItemViewModel();

            question1.Question = new QuestionViewModel() { Id = 1, Description = "test1", IsActive = true, Version = 1, QuestionType = Enumeration.QuestionType.Count };
            question2.Question = new QuestionViewModel() { Id = 2, Description = "test2", IsActive = true, Version = 1, QuestionType = Enumeration.QuestionType.Count };
            question3.Question = new QuestionViewModel() { Id = 3, Description = "test3", IsActive = true, Version = 1, QuestionType = Enumeration.QuestionType.Count };
            question4.Question = new QuestionViewModel() { Id = 4, Description = "test4", IsActive = true, Version = 1, QuestionType = Enumeration.QuestionType.Count };
            question5.Question = new QuestionViewModel() { Id = 5, Description = "test5", IsActive = true, Version = 1, QuestionType = Enumeration.QuestionType.Count };

            temp.Add(question1);
            temp.Add(question2);
            temp.Add(question3);
            temp.Add(question4);
            temp.Add(question5);

            questions = temp.AsEnumerable();
            QuestionListViewModel QuestionList = new QuestionListViewModel(questions, que.Object, rou.Object);
            //act
            QuestionList.AnswerFalse();
            QuestionList.PreviousQuestion();
            //assert
            Assert.AreEqual("Nee", QuestionList.CurrentQuestion.Answer);
        }

        [TestMethod]
        [TestCategory("QuestionList")]
        public void TestId()
        {
            //arrange
            QuestionItemViewModel question1 = new QuestionItemViewModel();
            QuestionItemViewModel question2 = new QuestionItemViewModel();
            QuestionItemViewModel question3 = new QuestionItemViewModel();
            QuestionItemViewModel question4 = new QuestionItemViewModel();
            QuestionItemViewModel question5 = new QuestionItemViewModel();

            question1.Question = new QuestionViewModel() { Id = 1, Description = "test1", IsActive = true, Version = 1, QuestionType = Enumeration.QuestionType.Count };
            question2.Question = new QuestionViewModel() { Id = 2, Description = "test2", IsActive = true, Version = 1, QuestionType = Enumeration.QuestionType.Count };
            question3.Question = new QuestionViewModel() { Id = 3, Description = "test3", IsActive = true, Version = 1, QuestionType = Enumeration.QuestionType.Count };
            question4.Question = new QuestionViewModel() { Id = 4, Description = "test4", IsActive = true, Version = 1, QuestionType = Enumeration.QuestionType.Count };
            question5.Question = new QuestionViewModel() { Id = 5, Description = "test5", IsActive = true, Version = 1, QuestionType = Enumeration.QuestionType.Count };

            temp.Add(question1);
            temp.Add(question2);
            temp.Add(question3);
            temp.Add(question4);
            temp.Add(question5);

            questions = temp.AsEnumerable();
            QuestionListViewModel QuestionList = new QuestionListViewModel(questions, que.Object, rou.Object);
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
            QuestionItemViewModel question1 = new QuestionItemViewModel();
            QuestionItemViewModel question2 = new QuestionItemViewModel();
            QuestionItemViewModel question3 = new QuestionItemViewModel();
            QuestionItemViewModel question4 = new QuestionItemViewModel();
            QuestionItemViewModel question5 = new QuestionItemViewModel();

            question1.Question = new QuestionViewModel() { Id = 1, Description = "test1", IsActive = true, Version = 1, QuestionType = Enumeration.QuestionType.Count };
            question2.Question = new QuestionViewModel() { Id = 2, Description = "test2", IsActive = true, Version = 1, QuestionType = Enumeration.QuestionType.Count };
            question3.Question = new QuestionViewModel() { Id = 3, Description = "test3", IsActive = true, Version = 1, QuestionType = Enumeration.QuestionType.Count };
            question4.Question = new QuestionViewModel() { Id = 4, Description = "test4", IsActive = true, Version = 1, QuestionType = Enumeration.QuestionType.Count };
            question5.Question = new QuestionViewModel() { Id = 5, Description = "test5", IsActive = true, Version = 1, QuestionType = Enumeration.QuestionType.Count };

            temp.Add(question1);
            temp.Add(question2);
            temp.Add(question3);
            temp.Add(question4);
            temp.Add(question5);

            questions = temp.AsEnumerable();
            QuestionListViewModel QuestionList = new QuestionListViewModel(questions, que.Object, rou.Object);
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
            QuestionItemViewModel question1 = new QuestionItemViewModel();
            QuestionItemViewModel question2 = new QuestionItemViewModel();
            QuestionItemViewModel question3 = new QuestionItemViewModel();
            QuestionItemViewModel question4 = new QuestionItemViewModel();
            QuestionItemViewModel question5 = new QuestionItemViewModel();

            question1.Question = new QuestionViewModel() { Id = 1, Description = "test1", IsActive = true, Version = 1, QuestionType = Enumeration.QuestionType.Count };
            question2.Question = new QuestionViewModel() { Id = 2, Description = "test2", IsActive = true, Version = 1, QuestionType = Enumeration.QuestionType.Count };
            question3.Question = new QuestionViewModel() { Id = 3, Description = "test3", IsActive = true, Version = 1, QuestionType = Enumeration.QuestionType.Count };
            question4.Question = new QuestionViewModel() { Id = 4, Description = "test4", IsActive = true, Version = 1, QuestionType = Enumeration.QuestionType.Count };
            question5.Question = new QuestionViewModel() { Id = 5, Description = "test5", IsActive = true, Version = 1, QuestionType = Enumeration.QuestionType.Count };

            temp.Add(question1);
            temp.Add(question2);
            temp.Add(question3);
            temp.Add(question4);
            temp.Add(question5);

            questions = temp.AsEnumerable();
            QuestionListViewModel QuestionList = new QuestionListViewModel(questions, que.Object, rou.Object);
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
            QuestionItemViewModel question1 = new QuestionItemViewModel();
            QuestionItemViewModel question2 = new QuestionItemViewModel();
            QuestionItemViewModel question3 = new QuestionItemViewModel();
            QuestionItemViewModel question4 = new QuestionItemViewModel();
            QuestionItemViewModel question5 = new QuestionItemViewModel();

            question1.Question = new QuestionViewModel() { Id = 1, Description = "test1", IsActive = true, Version = 1, QuestionType = Enumeration.QuestionType.Count };
            question2.Question = new QuestionViewModel() { Id = 2, Description = "test2", IsActive = true, Version = 1, QuestionType = Enumeration.QuestionType.Count };
            question3.Question = new QuestionViewModel() { Id = 3, Description = "test3", IsActive = true, Version = 1, QuestionType = Enumeration.QuestionType.Count };
            question4.Question = new QuestionViewModel() { Id = 4, Description = "test4", IsActive = true, Version = 1, QuestionType = Enumeration.QuestionType.Count };
            question5.Question = new QuestionViewModel() { Id = 5, Description = "test5", IsActive = true, Version = 1, QuestionType = Enumeration.QuestionType.Count };

            temp.Add(question1);
            temp.Add(question2);
            temp.Add(question3);
            temp.Add(question4);
            temp.Add(question5);

            questions = temp.AsEnumerable();
            QuestionListViewModel QuestionList = new QuestionListViewModel(questions, que.Object, rou.Object);
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
            QuestionItemViewModel question1 = new QuestionItemViewModel();
            QuestionItemViewModel question2 = new QuestionItemViewModel();
            QuestionItemViewModel question3 = new QuestionItemViewModel();
            QuestionItemViewModel question4 = new QuestionItemViewModel();
            QuestionItemViewModel question5 = new QuestionItemViewModel();

            question1.Question = new QuestionViewModel() { Id = 1, Description = "test1", IsActive = true, Version = 1, QuestionType = Enumeration.QuestionType.Count };
            question2.Question = new QuestionViewModel() { Id = 2, Description = "test2", IsActive = true, Version = 1, QuestionType = Enumeration.QuestionType.Count };
            question3.Question = new QuestionViewModel() { Id = 3, Description = "test3", IsActive = true, Version = 1, QuestionType = Enumeration.QuestionType.Count };
            question4.Question = new QuestionViewModel() { Id = 4, Description = "test4", IsActive = true, Version = 1, QuestionType = Enumeration.QuestionType.Count };
            question5.Question = new QuestionViewModel() { Id = 5, Description = "test5", IsActive = true, Version = 1, QuestionType = Enumeration.QuestionType.Count };

            temp.Add(question1);
            temp.Add(question2);
            temp.Add(question3);
            temp.Add(question4);
            temp.Add(question5);

            questions = temp.AsEnumerable();
            QuestionListViewModel QuestionList = new QuestionListViewModel(questions, que.Object, rou.Object);
            InspectionViewModel Inspection = new InspectionViewModel();
            //act
            QuestionList.Inspection = Inspection;
            //assert
            Assert.AreEqual(Inspection, QuestionList.Inspection);
        }

    }
}
