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
    public class EditCustomerTests
    {
        [TestMethod]
        [TestCategory("EditCustomer")]
        public void TestRegionList()
        {
            //arrange
            EditCustomerViewModel edit = new EditCustomerViewModel();
            ObservableCollection<string> RegionList = new ObservableCollection<string>();
            //act
            edit.RegionList = RegionList;
            //assert
            Assert.AreEqual(RegionList, edit.RegionList);
        }

        [TestMethod]
        [TestCategory("EditCustomer")]
        public void TestCustomer()
        {
            //arrange
            EditCustomerViewModel edit = new EditCustomerViewModel();
            CustomerViewModel cus = new CustomerViewModel();
             //act
            edit.Customer = cus;
            //assert
            Assert.AreEqual(cus, edit.Customer);
        }
    }
}
