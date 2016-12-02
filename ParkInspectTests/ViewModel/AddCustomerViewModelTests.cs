using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParkInspect.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Markup;
using ParkInspect.Repositories;

namespace ParkInspectTests.ViewModel
{
    [TestClass()]
    public class AddCustomerViewModelTests
    {

        [TestMethod()]

        public void ValidateTest()
        {
            DummyCustomersRepository a = new DummyCustomersRepository();
            RouterViewModel b = new RouterViewModel();
            CustomersViewModel c = new CustomersViewModel(a, b);
            AddCustomerViewModel ADVM = new AddCustomerViewModel(a,b,c);
            PrivateObject privateADVM = new PrivateObject(ADVM);
            ADVM.SelectedFunction = ADVM.FunctionList.First();
            ADVM.Customer = new CustomerViewModel()
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
            DummyCustomersRepository a = new DummyCustomersRepository();
            RouterViewModel b = new RouterViewModel();
            CustomersViewModel c = new CustomersViewModel(a, b);
            AddCustomerViewModel ADVM = new AddCustomerViewModel(a, b, c);
            PrivateObject privateADVM = new PrivateObject(ADVM);
            ADVM.SelectedFunction = ADVM.FunctionList.First();
            ADVM.Customer = new CustomerViewModel()
            {
                Function = ADVM.SelectedFunction,
                Name = "Test1",
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