using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParkInspect.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkInspect.ViewModel;

namespace ParkInspectTests.Repositories
{
    [TestClass()]
    public class DummyTemplateRepositoryTests
    {
        DummyTemplateRepository DTR = new DummyTemplateRepository();

        [TestMethod()]
        public void FindTest()
        {
            //not implemented yet
        }

        [TestMethod()]
        public void CreateTest()
        {
            TemplateViewModel newVM = new TemplateViewModel();
            DTR.Create(newVM);
            Assert.IsTrue(DTR.All().Contains(newVM));
            }

        [TestMethod()]
        public void UpdateTest()
        {
            //cannot be implemented yet
        }
    }
}