using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParkInspect.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using ParkInspect.Repository.Interface;
using ParkInspect.Service;

namespace ParkInspect.Tests
{
    [TestClass]
   public class AddInspectionTests
    {
        private Mock<IInspectionsRepository> insRe = new Mock<IInspectionsRepository>();
        private Mock<ICommissionRepository> comRe = new Mock<ICommissionRepository>();
        private Mock<IQuestionListRepository> quesRe = new Mock<IQuestionListRepository>();
        private Mock<IAuthService> auth = new Mock<IAuthService>();
        private Mock<IRouterService> rou = new Mock<IRouterService>();
        private IEnumerable<QuestionItemViewModel> questions = new ObservableCollection<QuestionItemViewModel>();
        private List<QuestionItemViewModel> temp = new List<QuestionItemViewModel>();

        [TestMethod]
        [TestCategory("AddInspection")]
        public void ValidateEndLaterThanStartTest()
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

            AddInspectionViewModel addInsp = new AddInspectionViewModel(insRe.Object, comRe.Object, quesRe.Object, auth.Object, rou.Object);
            CommissionViewModel comm = new CommissionViewModel();
            QuestionListViewModel ques = new QuestionListViewModel(questions, quesRe.Object, rou.Object);
            DateTime end = new DateTime(2016, 09, 08);
            DateTime st = new DateTime(2016, 09, 09);
            addInsp.Inspection.StartTime = st;
            addInsp.Inspection.EndTime = end;
            addInsp.Inspection.CommissionViewModel = comm;
            addInsp.SelectedQuestionList = ques;
            //act
            addInsp.ValidateInput();
            //assert
            Assert.AreEqual(false, addInsp.ValidateInput());
        }

        [TestMethod]
        [TestCategory("AddInspection")]
        public void ValidateNotSelectedCommissionTest()
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

            AddInspectionViewModel addInsp = new AddInspectionViewModel(insRe.Object, comRe.Object, quesRe.Object, auth.Object, rou.Object);
            CommissionViewModel comm = new CommissionViewModel();
            QuestionListViewModel ques = new QuestionListViewModel(questions, quesRe.Object, rou.Object);
            DateTime end = new DateTime(2016, 09, 10);
            DateTime st = new DateTime(2016, 09, 09);
            addInsp.Inspection.StartTime = st;
            addInsp.Inspection.EndTime = end;
            addInsp.SelectedQuestionList = ques;
            //act
            addInsp.ValidateInput();
            //assert
            Assert.AreEqual(false, addInsp.ValidateInput());
        }

        [TestMethod]
        [TestCategory("AddInspection")]
        public void ValidateNotSelectedQuestionListTest()
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

            AddInspectionViewModel addInsp = new AddInspectionViewModel(insRe.Object, comRe.Object, quesRe.Object, auth.Object, rou.Object);
            CommissionViewModel comm = new CommissionViewModel();
            QuestionListViewModel ques = new QuestionListViewModel(questions, quesRe.Object, rou.Object);
            DateTime end = new DateTime(2016, 09, 10);
            DateTime st = new DateTime(2016, 09, 09);
            addInsp.Inspection.StartTime = st;
            addInsp.Inspection.EndTime = end;
            addInsp.Inspection.CommissionViewModel = comm;
            //act
            addInsp.ValidateInput();
            //assert
            Assert.AreEqual(false, addInsp.ValidateInput());
        }


        [TestMethod]
        [TestCategory("AddInspection")]
        public void TestInspection()
        {
            //arrange
            AddInspectionViewModel addInsp = new AddInspectionViewModel(insRe.Object, comRe.Object, quesRe.Object, auth.Object, rou.Object);
            InspectionViewModel ins = new InspectionViewModel();
            //act
            addInsp.Inspection = ins;
            //assert
            Assert.AreEqual(ins, addInsp.Inspection);
        }

        [TestMethod]
        [TestCategory("AddInspection")]
        public void TestCommissionList()
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

            AddInspectionViewModel addInsp = new AddInspectionViewModel(insRe.Object, comRe.Object, quesRe.Object, auth.Object, rou.Object);
            QuestionListViewModel ques = new QuestionListViewModel(questions, quesRe.Object, rou.Object);
            //act
            addInsp.SelectedQuestionList = ques;
            //assert
            Assert.AreEqual(ques, addInsp.SelectedQuestionList);
        }
    }
}
