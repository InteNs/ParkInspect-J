using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParkInspect.Repositories;
using ParkInspect.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkInspectTests.ViewModel
{
    [TestClass()]
    public class AddEmployeeViewModelTests
    {
        [TestMethod()]

        public void ValidateTest()
        {
            DummyEmployeesRepository a = new DummyEmployeesRepository();
            RouterViewModel b = new RouterViewModel();
            EmployeesViewModel c = new EmployeesViewModel(a, b);
            AddEmployeeViewModel ADVM = new AddEmployeeViewModel(a, b, c);
            PrivateObject privateADVM = new PrivateObject(ADVM);
            ADVM.SelectedFunction = ADVM.FunctionList.First();
            ADVM.Employee = new EmployeeViewModel()
            {
                Function = ADVM.SelectedFunction,
                Email = "test",
                StreetNumber = "9",
                PhoneNumber = "0",
                ZipCode = "5432AE"
            };
            Object result = privateADVM.Invoke("ValidateInput");
            Assert.IsFalse((bool)result);
        }

        [TestMethod()]
        public void ValidateTest_Name_With_Number()
        {
            DummyEmployeesRepository a = new DummyEmployeesRepository();
            RouterViewModel b = new RouterViewModel();
            EmployeesViewModel c = new EmployeesViewModel(a, b);
            AddEmployeeViewModel ADVM = new AddEmployeeViewModel(a, b, c);
            PrivateObject privateADVM = new PrivateObject(ADVM);
            ADVM.SelectedFunction = ADVM.FunctionList.First();
            ADVM.Employee = new EmployeeViewModel()
            {
                Function = ADVM.SelectedFunction,
                Name = "Test2",
                Email = "test",
                StreetNumber = "9",
                PhoneNumber = "0",
                ZipCode = "5432AE"
            };
            Object result = privateADVM.Invoke("ValidateInput");
            Assert.IsFalse((bool)result);
        }
    }
}