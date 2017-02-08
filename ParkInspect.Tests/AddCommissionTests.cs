using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ParkInspect.Repository.Interface;
using ParkInspect.Service;
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
    public class AddCommissionTests
    {
        private Mock<ICommissionRepository> com = new Mock<ICommissionRepository>();
        private Mock<IEmployeeRepository> emp = new Mock<IEmployeeRepository>();
        private Mock<ICustomerRepository> cus = new Mock<ICustomerRepository>();
        private Mock<IRegionRepository> reg = new Mock<IRegionRepository>();
        private Mock<IRouterService> rou = new Mock<IRouterService>();

        [TestMethod]
        [TestCategory("AddCommission")]
        public void TestCustomers()
        {
            //arrange
            AddCommissionViewModel addcomm = new AddCommissionViewModel(com.Object, emp.Object, cus.Object, reg.Object, rou.Object);
            ObservableCollection<CustomerViewModel> customers = new ObservableCollection<CustomerViewModel>();
            //act
            addcomm.Customers = customers;
            //assert
            Assert.AreEqual(customers, addcomm.Customers);
        }
        [TestMethod]
        [TestCategory("AddCommission")]
        public void TestEmployees()
        {
            //arrange
            AddCommissionViewModel addcomm = new AddCommissionViewModel(com.Object, emp.Object, cus.Object, reg.Object, rou.Object);
            ObservableCollection<EmployeeViewModel> employees = new ObservableCollection<EmployeeViewModel>();
            //act
            addcomm.Employees = employees;
            //assert
            Assert.AreEqual(employees, addcomm.Employees);
        }
        [TestMethod]
        [TestCategory("AddCommission")]
        public void TestCommission()
        {
            //arrange
            AddCommissionViewModel addcomm = new AddCommissionViewModel(com.Object, emp.Object, cus.Object, reg.Object, rou.Object);
            CommissionViewModel comm = new CommissionViewModel();
            //act
            addcomm.Commission = comm;
            //assert
            Assert.AreEqual(comm, addcomm.Commission);
        }

        [TestMethod]
        [TestCategory("AddCommission")]
        public void TestRegions()
        {
            //arrange
            AddCommissionViewModel addcomm = new AddCommissionViewModel(com.Object, emp.Object, cus.Object, reg.Object, rou.Object);
            ObservableCollection<string> regions = new ObservableCollection<string>();
            //act
            addcomm.Regions = regions;
            //assert
            Assert.AreEqual(regions, addcomm.Regions);
        }

        [TestMethod]
        [TestCategory("AddCommission")]
        public void AddComissionTest()
        {
            AddCommissionViewModel addcomm = new AddCommissionViewModel(com.Object, emp.Object, cus.Object, reg.Object, rou.Object);
            addcomm.Commission.Customer = new CustomerViewModel();
            addcomm.Commission.Region = "a";
            addcomm.Commission.StreetNumber = "8";
            addcomm.Commission.ZipCode = "1111aa";
            addcomm.Commission.Description = "a";
            addcomm.Commission.Employee = new EmployeeViewModel();

            addcomm.AddCommission();
            Assert.AreEqual(addcomm.Commission.Status, "Nieuw");
        }
        }
}
