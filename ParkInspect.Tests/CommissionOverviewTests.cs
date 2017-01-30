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
    public class CommissionOverviewTests
    {
        [TestMethod]
        [TestCategory("CommissionOverview")]
        public void TestCommissions()
        {
            //arrange
            CommissionOverviewViewModel commOver = new CommissionOverviewViewModel();
            ObservableCollection<CommissionViewModel> Commissions = new ObservableCollection<CommissionViewModel>();
            //act
            commOver.Commissions = Commissions;
            //assert
            Assert.AreEqual(Commissions, commOver.Commissions);
        }

        [TestMethod]
        [TestCategory("CommissionOverview")]
        public void TestEmployees()
        {
            //arrange
            CommissionOverviewViewModel commOver = new CommissionOverviewViewModel();
            ObservableCollection<EmployeeViewModel> Employees = new ObservableCollection<EmployeeViewModel>();
            //act
            commOver.Employees = Employees;
            //assert
            Assert.AreEqual(Employees, commOver.Employees);
        }

        [TestMethod]
        [TestCategory("CommissionOverview")]
        public void TestSelectedCommission()
        {
            //arrange
            CommissionOverviewViewModel commOver = new CommissionOverviewViewModel();
            CommissionViewModel comm = new CommissionViewModel();
            //act
            commOver.SelectedCommission = comm;
            //assert
            Assert.AreEqual(comm, commOver.SelectedCommission);
        }
    }
}
