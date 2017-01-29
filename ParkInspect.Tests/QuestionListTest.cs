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
        [TestCategory("viewmodels")]
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
    }
}
