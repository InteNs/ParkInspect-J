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
        [TestCategory("Question")]
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

        [TestMethod]
        [TestCategory("Question")]
        public void TestId()
        {
            //arrange
            QuestionViewModel ques = new QuestionViewModel();
            //act
            ques.Id = 1;
            //assert
            Assert.AreEqual(1, ques.Id);

        }

        [TestMethod]
        [TestCategory("Question")]
        public void TestDescription()
        {
            //arrange
            QuestionViewModel ques = new QuestionViewModel();
            //act
            ques.Description = "value";
            //assert
            Assert.AreEqual("value", ques.Description);

        }

        [TestMethod]
        [TestCategory("Question")]
        public void TestVersion()
        {
            //arrange
            QuestionViewModel ques = new QuestionViewModel();
            //act
            ques.Version = 1;
            //assert
            Assert.AreEqual(1, ques.Version);

        }

        [TestMethod]
        [TestCategory("Question")]
        public void TestIsActive()
        {
            //arrange
            QuestionViewModel ques = new QuestionViewModel();
            //act
            ques.IsActive = true;
            //assert
            Assert.AreEqual(true, ques.IsActive);

        }


    }
}
