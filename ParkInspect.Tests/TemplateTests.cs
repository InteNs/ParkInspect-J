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
   public class TemplateTests
    {
        private IEnumerable<QuestionItemViewModel> questions = new List<QuestionItemViewModel>();

        [TestMethod]
        [TestCategory("Template")]
        public void TestDescription()
        {
            //arrange
            TemplateViewModel template = new TemplateViewModel(questions);
            //act
            template.Description = "value";
            //assert
            Assert.AreEqual("value", template.Description);

        }

        [TestMethod]
        [TestCategory("Template")]
        public void TestId()
        {
            //arrange
            TemplateViewModel template = new TemplateViewModel(questions);
            //act
            template.Id = 1;
            //assert
            Assert.AreEqual(1, template.Id);

        }

        [TestMethod]
        [TestCategory("Template")]
        public void TestQuestionItems()
        {
            //arrange
            TemplateViewModel template = new TemplateViewModel(questions);
            ObservableCollection<QuestionItemViewModel> QuestionItems = new ObservableCollection<QuestionItemViewModel>();
            //act
            template.QuestionItems = QuestionItems;
            //assert
            Assert.AreEqual(QuestionItems, template.QuestionItems);

        }
    }
}
