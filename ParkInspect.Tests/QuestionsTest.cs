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
   public class QuestionsTest
    {
        [TestMethod]
        [TestCategory("Questions")]
        public void IsNotSelectedTest()
        {
            //arrange
            QuestionsViewModel quess = new QuestionsViewModel();
            //act
            quess.IsSelected();
            //assert
            Assert.AreEqual(false, quess.IsSelected());

        }

    }
}
