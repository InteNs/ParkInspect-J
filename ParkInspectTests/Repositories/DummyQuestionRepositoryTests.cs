using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParkInspect.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkInspect.ViewModel;

namespace ParkInspectTests.Repositories
{
    [TestClass()]
    public class DummyQuestionRepositoryTests
    {
        DummyQuestionRepository DQR = new DummyQuestionRepository();

        [TestMethod()]
        public void FindTest()
        {
            QuestionViewModel newVM = new QuestionViewModel() {Id = 30};
            DQR.Create(newVM);
            Assert.IsTrue(DQR.Find(30) == newVM);
        }

        [TestMethod()]
        public void CreateTest()
        {
            QuestionViewModel newVM = new QuestionViewModel();
            DQR.Create(newVM);
            Assert.IsTrue(DQR.GetAll().Contains(newVM));

        }

        [TestMethod()]
        public void UpdateTest()
        {
            QuestionViewModel newVM = new QuestionViewModel() {Description = "test", Id = 11};
            QuestionViewModel updatedVM = new QuestionViewModel() {Description = "test1", Id = 11};
            DQR.Create(newVM);
            DQR.Update(updatedVM);
            Assert.IsFalse(DQR.GetAll().Contains(newVM));
            Assert.IsTrue(DQR.GetAll().Contains(updatedVM));
        }
    }
}