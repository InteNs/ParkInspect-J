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
        [TestCategory("Location")]
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
        [TestCategory("Location")]
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

        [TestMethod]
        [TestCategory("Location")]
        public void TestZipCode()
        {
            //arrange
            LocationViewModel locations = new LocationViewModel();
            //act
            locations.ZipCode = "5224xw";
            //assert
            Assert.AreEqual("5224xw", locations.ZipCode);
        }

        [TestMethod]
        [TestCategory("Location")]
        public void TestStreetNumber()
        {
            //arrange
            LocationViewModel locations = new LocationViewModel();
            //act
            locations.StreetNumber = "8";
            //assert
            Assert.AreEqual("8", locations.StreetNumber);
        }

        [TestMethod]
        [TestCategory("Location")]
        public void TestRegion()
        {
            //arrange
            LocationViewModel locations = new LocationViewModel();
            //act
            locations.Region = "value";
            //assert
            Assert.AreEqual("value", locations.Region);
        }
    }
}
