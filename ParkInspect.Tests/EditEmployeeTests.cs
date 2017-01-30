using GalaSoft.MvvmLight.Command;
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
   public class EditEmployeeTests
    {
        [TestMethod]
        [TestCategory("EditEmployee")]
        public void TestRegionlist()
        {
            //arrange
            EditEmployeeViewModel edit = new EditEmployeeViewModel();
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
            EditEmployeeViewModel edit = new EditEmployeeViewModel();
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
            EditEmployeeViewModel edit = new EditEmployeeViewModel();
            EmployeeViewModel emp = new EmployeeViewModel();
            //act
            edit.SelectedEmployee = emp;
            //assert
            Assert.AreEqual(emp, edit.SelectedEmployee);
        }

        
    }
}
