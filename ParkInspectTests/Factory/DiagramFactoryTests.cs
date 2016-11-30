using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParkInspect.DiagramModels;
using ParkInspect.Factory;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkInspect;

namespace ParkInspectTests.Factory
{
    [TestClass()]
    public class DiagramFactoryTests
    {
        [TestMethod()]
        public void DiagramFactoryTest()
        {
            //arrange
            DiagramFactory d = new DiagramFactory();
            ObservableCollection<IDiagram> expected = new ObservableCollection<IDiagram>
            {
                new Grafiek(),
                new Kaart(),
                new Cirkeldiagram(),
                new Staafdiagram()
            };
            //act
            ObservableCollection<IDiagram> actual = new ObservableCollection<IDiagram>(d.DiagramNames);
            //assert
            foreach (IDiagram diagram in expected)
            {
                Assert.IsTrue(actual.Count() == expected.Count() );
            }
        }

        [TestMethod()]
        public void GetDiagramTest()
        {
            //arrange
            DiagramFactory d = new DiagramFactory();
            IDiagram value = d.GetDiagram("Grafiek");
            Assert.AreEqual(value.Name, new Grafiek().Name);
        }
    }
}