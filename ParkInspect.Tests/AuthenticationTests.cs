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
    public class AuthenticationTests
    {
        [TestMethod]
        [TestCategory("Authentication")]
        public void TestUsername()
        {
            //arrange
            AuthenticationViewModel auth = new AuthenticationViewModel();
            //act
            auth.Username = "value";
            //assert
            Assert.AreEqual("value", auth.Username);
        }

        [TestMethod]
        [TestCategory("Authentication")]
        public void TestFunction()
        {
            //arrange
            AuthenticationViewModel auth = new AuthenticationViewModel();
            //act
            auth.Function = "value";
            //assert
            Assert.AreEqual("value", auth.Function);
        }

        [TestMethod]
        [TestCategory("Authentication")]
        public void TestEmployeeId()
        {
            //arrange
            AuthenticationViewModel auth = new AuthenticationViewModel();
            //act
            auth.EmployeeId = 1;
            //assert
            Assert.AreEqual(1, auth.EmployeeId);
        }
    }
}
