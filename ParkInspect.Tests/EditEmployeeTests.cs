using GalaSoft.MvvmLight.Command;
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
   public class EditEmployeeTests
    {

        private Mock<IEmployeeRepository> empMock = new Mock<IEmployeeRepository>();
        private Mock<IRegionRepository> regMock = new Mock<IRegionRepository>();
        private Mock<IRouterService> rou = new Mock<IRouterService>();

        [TestMethod]
        [TestCategory("EditEmployee")]
        public void TestRegionlist()
        {
            //arrange
            EmployeesViewModel employees = new EmployeesViewModel(empMock.Object, rou.Object);
            EditEmployeeViewModel edit = new EditEmployeeViewModel(empMock.Object, regMock.Object, rou.Object, employees);
            ObservableCollection<string> RegionList = new ObservableCollection<string>();
            //act
            edit.RegionList = RegionList;
            //assert
            Assert.AreEqual(RegionList, edit.RegionList);
        }

        [TestMethod]
        [TestCategory("EditEmployee")]
        public void TestFunctionlist()
        {
            //arrange
            EmployeesViewModel employees = new EmployeesViewModel(empMock.Object, rou.Object);
            EditEmployeeViewModel edit = new EditEmployeeViewModel(empMock.Object, regMock.Object, rou.Object, employees);
            ObservableCollection<string> FunctionList = new ObservableCollection<string>();
            //act
            edit.FunctionList = FunctionList;
            //assert
            Assert.AreEqual(FunctionList, edit.FunctionList);
        }

        [TestMethod]
        [TestCategory("EditEmployee")]
        public void TestSelectedEmployee()
        {
            //arrange
            EmployeesViewModel employees = new EmployeesViewModel(empMock.Object, rou.Object);
            EditEmployeeViewModel edit = new EditEmployeeViewModel(empMock.Object, regMock.Object, rou.Object, employees);
            EmployeeViewModel emp = new EmployeeViewModel();
            //act
            edit.SelectedEmployee = emp;
            //assert
            Assert.AreEqual(emp, edit.SelectedEmployee);
        }

        
    }
}
