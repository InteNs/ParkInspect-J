﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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
    public class EditCustomerTests
    {
        private Mock<ICustomerRepository> cusMock = new Mock<ICustomerRepository>();
        private Mock<IRouterService> rou = new Mock<IRouterService>();
        private Mock<CustomersViewModel> cussMock = new Mock<CustomersViewModel>();
        private Mock<IRegionRepository> regMock = new Mock<IRegionRepository>();

        [TestMethod]
        [TestCategory("EditCustomer")]
        public void TestRegionList()
        {
            //arrange
            EditCustomerViewModel edit = new EditCustomerViewModel(cusMock.Object, rou.Object, cussMock.Object, regMock.Object);
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
            EditCustomerViewModel edit = new EditCustomerViewModel(cusMock.Object, rou.Object, cussMock.Object, regMock.Object);
            CustomerViewModel cus = new CustomerViewModel();
             //act
            edit.Customer = cus;
            //assert
            Assert.AreEqual(cus, edit.Customer);
        }
    }
}
