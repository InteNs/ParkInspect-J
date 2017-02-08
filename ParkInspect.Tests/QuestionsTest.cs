using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ParkInspect.Repository.Interface;
using ParkInspect.Service;
using ParkInspect.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkInspect.Tests
{
    [TestClass]
   public class QuestionsTest
    {
        private Mock<IQuestionRepository> que = new Mock<IQuestionRepository>();
        private Mock<IRouterService> rou = new Mock<IRouterService>();

        [TestMethod]
        [TestCategory("Questions")]
        public void IsNotSelectedTest()
        {
            //arrange
            QuestionsViewModel quess = new QuestionsViewModel(que.Object, rou.Object);
            //act
            quess.IsSelected();
            //assert
            Assert.AreEqual(false, quess.IsSelected());

        }

    }
}
