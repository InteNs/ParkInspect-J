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
   public class AddCustomerTests
    {
        [TestMethod]
        [TestCategory("AddCustomer")]
        public void TestRegionList()
        {
            //arrange
            AddCustomerViewModel addcus = new AddCustomerViewModel();
            ObservableCollection<string> regions = new ObservableCollection<string>();
            //act
            addcus.RegionList = regions;
            //assert
            Assert.AreEqual(regions, addcus.RegionList);
        }

        [TestMethod]
        [TestCategory("AddCustomer")]
        public void TestCommission()
        {
            //arrange
            AddCustomerViewModel addcus = new AddCustomerViewModel();
            CustomerViewModel cust = new CustomerViewModel();
            //act
            addcus.Customer = cust;
            //assert
            Assert.AreEqual(cust, addcus.Customer);
        }
    }
}
