using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParkInspect.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using ParkInspect.View;

namespace ParkInspectTests.ViewModel
{
    [TestClass()]
    public class RouterViewModelTests
    {
        [TestMethod()]
        public void SetPreviousTest()
        {
            RouterViewModel a = new RouterViewModel();
            PrivateObject RVM = new PrivateObject(a);
            RVM.Invoke("SetView", "dashboard-manager");
            UserControl temp = a.CurrentView;
            RVM.Invoke("SetView", "dashboard-manager");
            RVM.Invoke("SetPreviousView");

            Assert.IsTrue(a.CurrentView == temp);
        }
        [TestMethod()]
        public void SetPreviousTest_No_Previous()
        {
            RouterViewModel a = new RouterViewModel();
            PrivateObject RVM = new PrivateObject(a);
            UserControl temp = a.CurrentView;
            RVM.Invoke("SetPreviousView");

            Assert.IsTrue(a.CurrentView == temp);
        }
    }
}