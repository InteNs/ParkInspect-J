using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParkInspect.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkInspect.Repositories;

namespace ParkInspectTests.ViewModel
{
    [TestClass()]
    public class AddCommissionViewModelTests
    {
        [TestMethod()]

        public void ValidateTest()
        {
            DummyCommissionRepository a = new DummyCommissionRepository();
            RouterViewModel b = new RouterViewModel();
            CommissionOverviewViewModel c = new CommissionOverviewViewModel(a);
            AddCommissionViewModel ADVM = new AddCommissionViewModel(a, b, c);
            ADVM.SelectedCustomer = new CustomerViewModel();
            ADVM.Description = "test";
            ADVM.Frequency = 4;
            ADVM.SelectedRegion = "test";
            PrivateObject privateADVM = new PrivateObject(ADVM);
            Object result = privateADVM.Invoke("ValidateInput");
            Assert.IsTrue((bool)result);
        }

        [TestMethod()]
        public void ValidateTest_With_Invalid_Input()
        {
            DummyCommissionRepository a = new DummyCommissionRepository();
            RouterViewModel b = new RouterViewModel();
            CommissionOverviewViewModel c = new CommissionOverviewViewModel(a);
            AddCommissionViewModel ADVM = new AddCommissionViewModel(a, b, c);
            ADVM.SelectedCustomer = new CustomerViewModel();
            ADVM.Frequency = 4;
            ADVM.SelectedRegion = "test";
            PrivateObject privateADVM = new PrivateObject(ADVM);
            Object result = privateADVM.Invoke("ValidateInput");
            Assert.IsFalse((bool)result);
        }
    }
}