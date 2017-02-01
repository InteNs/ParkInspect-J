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
    public class AddCommissionTests
    {
        [TestMethod]
        [TestCategory("AddCommission")]
        public void TestCustomers()
        {
            //arrange
            AddCommissionViewModel addcomm = new AddCommissionViewModel();
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
            AddCommissionViewModel addcomm = new AddCommissionViewModel();
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
            AddCommissionViewModel addcomm = new AddCommissionViewModel();
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
            AddCommissionViewModel addcomm = new AddCommissionViewModel();
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
            AddCommissionViewModel addcomm = new AddCommissionViewModel();
            addcomm.AddCommission();
            Assert.AreEqual(addcomm.Commission.Status, "Nieuw");
        }
        }
}
