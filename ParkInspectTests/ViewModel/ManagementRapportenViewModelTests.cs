using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParkInspect.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkInspect.DiagramModels;
using ParkInspect.Repositories;

namespace ParkInspectTests.ViewModel
{
    [TestClass()]
    public class ManagementRapportenViewModelTests
    {
        ManagementRapportenViewModel MRVM = new ManagementRapportenViewModel(new ManagementRapportenRepository());
        
        [TestMethod()]
        public void SetVisibilitiesTest()
        {
            MRVM.SelectedDiagram = new Cirkeldiagram();
            MRVM.SelectedOption = "Verdeling van de functies van de werknemers";
            Assert.IsTrue(MRVM.Locatie == true);
            
        }

        [TestMethod()]
        public void SetVisibilities_Should_Set_False()
        {
            MRVM.SelectedDiagram = new Cirkeldiagram();
            MRVM.SelectedOption = "Verdeling van de functies van de werknemers";
            MRVM.SelectedOption = "Verdeling van de status van de opdrachten";
            Assert.IsFalse(MRVM.Locatie);
        }
    }
}