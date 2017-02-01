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
    public class AddEmployeeTests
    {
        [TestMethod]
        [TestCategory("AddEmployee")]
        public void TestRegionList()
        {
            //arrange
            AddEmployeeViewModel addemp = new AddEmployeeViewModel();
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
            AddEmployeeViewModel addemp = new AddEmployeeViewModel();
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
            AddEmployeeViewModel addemp = new AddEmployeeViewModel();
            EmployeeViewModel emp = new EmployeeViewModel();
            //act
            addemp.Employee = emp;
            //assert
            Assert.AreEqual(emp, addemp.Employee);
        }

        [TestMethod]
        [TestCategory("AddEmployee")]
        public void AddEmployee()
        {
            AddEmployeeViewModel addemp = new AddEmployeeViewModel();
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
