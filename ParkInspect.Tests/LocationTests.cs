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
   public class LocationTests
    {

        [TestMethod]
        [TestCategory("viewmodels")]
        public void AddErrorTest()
        {
            //arrange
            LocationViewModel locations = new LocationViewModel();
            
            string propertyName = "test";
            string error = "error";
            
            //act
            locations.AddError(propertyName, error);
            //assert
            Assert.AreEqual(true, locations.HasErrors);
        }

        [TestMethod]
        [TestCategory("viewmodels")]
        public void RemoveErrorTest()
        {
            //arrange
            LocationViewModel locations = new LocationViewModel();
            string propertyName = "test";
            //act
            locations.RemoveError(propertyName);
            //assert
            Assert.AreEqual(false, locations.HasErrors);
        }
    }
}
