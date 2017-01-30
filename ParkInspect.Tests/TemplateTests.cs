﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParkInspect.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkInspect.Tests
{
    [TestClass]
   public class TemplateTests
    {
        [TestMethod]
        [TestCategory("Template")]
        public void TestDescription()
        {
            //arrange
            TemplateViewModel template = new TemplateViewModel();
            //act
            template.Description = "value";
            //assert
            Assert.AreEqual("value", template.Description);

        }

        [TestMethod]
        [TestCategory("Template")]
        public void TestId()
        {
            //arrange
            TemplateViewModel template = new TemplateViewModel();
            //act
            template.Id = 1;
            //assert
            Assert.AreEqual(1, template.Id);

        }
    }
}
