using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParkInspect.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using ParkInspect.Repository.Interface;
using ParkInspect.Service;

namespace ParkInspect.Tests
{
    [TestClass]
   public class AddCustomerTests
    {
        private Mock<ICustomerRepository> cus = new Mock<ICustomerRepository>();
        private Mock<IRegionRepository> reg = new Mock<IRegionRepository>();
        private Mock<IRouterService> rou = new Mock<IRouterService>();

        [TestMethod]
        [TestCategory("AddCustomer")]
        public void ValidateEmptyFieldTest()
        {
            //arrange
            AddCustomerViewModel addcus = new AddCustomerViewModel(cus.Object, reg.Object, rou.Object);
            addcus.Customer.Name = null;
            //act
            addcus.ValidateInput();
            //assert
            Assert.AreEqual(false, addcus.ValidateInput());
        }

        [TestMethod]
        [TestCategory("AddCustomer")]
        public void ValidateInputTest()
        {
            //arrange
            AddCustomerViewModel addcus = new AddCustomerViewModel(cus.Object, reg.Object, rou.Object);
            addcus.Customer.Name = "test";
            addcus.Customer.ZipCode = "5231xe";
            addcus.Customer.StreetNumber = "8";
            addcus.Customer.PhoneNumber = "0612121212";
            addcus.Customer.Email = "test@test.nl";
            //act
            addcus.ValidateInput();
            //assert
            Assert.AreEqual(true, addcus.ValidateInput());
        }

        [TestMethod]
        [TestCategory("AddCustomer")]
        public void ValidateInputWrongZipTest()
        {
            //arrange
            AddCustomerViewModel addcus = new AddCustomerViewModel(cus.Object, reg.Object, rou.Object);
            addcus.Customer.Name = "test";
            addcus.Customer.ZipCode = "5231x";
            addcus.Customer.StreetNumber = "8";
            addcus.Customer.PhoneNumber = "0612121212";
            addcus.Customer.Email = "test@test.nl";
            //act
            addcus.ValidateInput();
            //assert
            Assert.AreEqual(false, addcus.ValidateInput());
        }

        [TestMethod]
        [TestCategory("AddCustomer")]
        public void TestRegionList()
        {
            //arrange
            AddCustomerViewModel addcus = new AddCustomerViewModel(cus.Object, reg.Object, rou.Object);
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
            AddCustomerViewModel addcus = new AddCustomerViewModel(cus.Object, reg.Object, rou.Object);
            CustomerViewModel cust = new CustomerViewModel();
            //act
            addcus.Customer = cust;
            //assert
            Assert.AreEqual(cust, addcus.Customer);
        }
    }
}
