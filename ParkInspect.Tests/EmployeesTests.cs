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
    public class EmployeesTests
    {
        [TestMethod]
        [TestCategory("Employees")]
        public void TestSelectedEmployee()
        {
            //arrange
            EmployeesViewModel emps = new EmployeesViewModel();
            EmployeeViewModel emp = new EmployeeViewModel();
            //act
            emps.SelectedEmployee = emp;
            //assert
            Assert.AreEqual(emp, emps.SelectedEmployee);

        }

        [TestMethod]
        [TestCategory("Employees")]
        public void TestEmployees()
        {
            //arrange
            EmployeesViewModel emps = new EmployeesViewModel();
            ObservableCollection<EmployeeViewModel> Employees = new ObservableCollection<EmployeeViewModel>();
            //act
            emps.Employees = Employees;
            //assert
            Assert.AreEqual(Employees, emps.Employees);

        }
    }
}
