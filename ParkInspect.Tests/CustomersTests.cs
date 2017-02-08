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
    public class CustomersTests
    {
        private Mock<ICustomerRepository> cusMock = new Mock<ICustomerRepository>();
        private Mock<IRouterService> rou = new Mock<IRouterService>();

        [TestMethod]
        [TestCategory("Customers")]
        public void TestCustomers()
         {
            //arrange
            CustomersViewModel cus = new CustomersViewModel(cusMock.Object, rou.Object);
            ObservableCollection<CustomerViewModel> Customers = new ObservableCollection<CustomerViewModel>();
            //act
            cus.Customers = Customers;
            //assert
            Assert.AreEqual(Customers, cus.Customers);
        }

        [TestMethod]
        [TestCategory("Customer")]
        public void TestId()
        {
            //arrange
            CustomerViewModel cus = new CustomerViewModel();
            //act
            cus.Id = 1;
            //assert
            Assert.AreEqual(1, cus.Id);
        }

        [TestMethod]
        [TestCategory("Customers")]
        public void CanNotEditCustomerTest()
        {
            //arrange
            CustomersViewModel cuss = new CustomersViewModel(cusMock.Object, rou.Object);
            //act
            cuss.CanEditCustomer();
            //assert
            Assert.AreEqual(false, cuss.CanEditCustomer());
        }

        //[TestMethod]
        //[TestCategory("Customers")]
        //public void CanEditCustomerTest()
        //{
        //    //arrange
        //    CustomersViewModel cuss = new CustomersViewModel();
        //    CustomerViewModel cus = new CustomerViewModel();
        //    cuss.SelectedCustomer = cus;
        //    //act
        //    cuss.CanEditCustomer();
        //    //assert
        //    Assert.AreEqual(true, cuss.CanEditCustomer());
        //}

        //[TestMethod]
        //[TestCategory("Customers")]
        //public void TestSelectedCustomer()
        //{
        //    //arrange
        //    CustomersViewModel cus = new CustomersViewModel();
        //    CustomerViewModel cust = new CustomerViewModel();
        //    //act
        //    cus.SelectedCustomer = cust;
        //    //assert
        //    Assert.AreEqual(cust, cus.SelectedCustomer);
        //}
    }
}
