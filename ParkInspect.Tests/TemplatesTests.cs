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
    public class TemplatesTests
    {
        [TestMethod]
        [TestCategory("Templates")]
        public void TestTemplates()
        {
            //arrange
            TemplatesViewModel temp = new TemplatesViewModel();
            ObservableCollection<TemplateViewModel> Templates = new ObservableCollection<TemplateViewModel>();
            //act
            temp.Templates = Templates;
            //assert
            Assert.AreEqual(Templates, temp.Templates);
        }
    }
}
