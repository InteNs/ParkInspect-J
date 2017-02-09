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
    public class AddEmployeeTests
    {
        private Mock<IEmployeeRepository> emp = new Mock<IEmployeeRepository>();
        private Mock<IRegionRepository> reg = new Mock<IRegionRepository>();
        private Mock<IRouterService> rou = new Mock<IRouterService>();

        [TestMethod]
        [TestCategory("AddEmployee")]
        public void TestRegionList()
        {
            //arrange
            AddEmployeeViewModel addemp = new AddEmployeeViewModel(emp.Object, reg.Object, rou.Object);
            ObservableCollection<string> regions = new ObservableCollection<string>();
            //act
            addemp.RegionList = regions;
            //assert
            Assert.AreEqual(regions, addemp.RegionList);
        }

        [TestMethod]
        [TestCategory("AddEmployee")]
        public void TestFunctionList()
        {
            //arrange
            AddEmployeeViewModel addemp = new AddEmployeeViewModel(emp.Object, reg.Object, rou.Object);
            ObservableCollection<string> functions = new ObservableCollection<string>();
            //act
            addemp.FunctionList = functions;
            //assert
            Assert.AreEqual(functions, addemp.FunctionList);
        }

        [TestMethod]
        [TestCategory("AddEmployee")]
        public void TestEmployee()
        {
            //arrange
            AddEmployeeViewModel addemp = new AddEmployeeViewModel(emp.Object, reg.Object, rou.Object);
            EmployeeViewModel empl = new EmployeeViewModel();
            //act
            addemp.Employee = empl;
            //assert
            Assert.AreEqual(empl, addemp.Employee);
        }

        [TestMethod]
        [TestCategory("AddEmployee")]
        public void AddEmployee()
        {
            AddEmployeeViewModel addemp = new AddEmployeeViewModel(emp.Object, reg.Object, rou.Object);
            addemp.Employee.Function = "a";
            addemp.Employee.Name = "a";
            addemp.Employee.ZipCode = "5231we";
            addemp.Employee.StreetNumber = "8";
            addemp.Employee.PhoneNumber = "0612345678";
            addemp.Employee.Email = "test@test.nl";
            addemp.Employee.Region = "a";

            Assert.AreEqual(addemp.ValidateInput(), true);
        }
    }
}
