using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParkInspect.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkInspect.Tests
{
    [TestClass]
    public class QuestionTests
    {
        [TestMethod]
        [TestCategory("viewmodels")]
        public void QuestionCreate()
        {
            QuestionViewModel question = new QuestionViewModel();
            question.Id = 123;
            question.Version = 234;
            question.Description = "testcase";
            question.IsActive = false;
            question.QuestionType = Enumeration.QuestionType.Boolean;

            question = question.Create();
            Assert.AreEqual(question.IsActive, true);
        }

        [TestMethod]
        [TestCategory("viewmodels")]
        public void QuestionUpdate()
        {
            QuestionViewModel question = new QuestionViewModel();
            question.Id = 123;
            question.Version = 234;
            question.Description = "testcase";
            question.IsActive = false;
            question.QuestionType = Enumeration.QuestionType.Boolean;

            question = question.Update();
            Assert.AreEqual(question.Id, 0);
        }
    }
}
