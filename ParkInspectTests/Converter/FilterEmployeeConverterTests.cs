using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParkInspect.Converter;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkInspect.ViewModel;

namespace ParkInspectTests.Converter
{
    [TestClass()]
    public class FilterEmployeeConverterTests
    {
        [TestMethod()]
        public void EmployeeConvertTest()
        {
            //arrange
            FilterEmployeeConverter c = new FilterEmployeeConverter();
            object[] values = new object[2];
            var collection = new ObservableCollection<EmployeeViewModel>()
            {
                new EmployeeViewModel()
                {
                    Id = 1, Name = "Werknemer 1", PhoneNumber = "0123456789", Email = "abcdefg@gmail.com", Function = "Inspecteur", StreetNumber = "Onderwijsboulevard 1", ZipCode = "1234 AB", Region = "Utrecht"
                },
                new EmployeeViewModel(){
                    Id = 2, Name = "Manager 1", PhoneNumber = "0123456789", Email = "12345@gmail.com", Function = "Manager", StreetNumber = "Onderwijsboulevard 1", ZipCode = "1234 AB", Region = "Utrecht"
                },
                new EmployeeViewModel(){
                    Id = 4, Name = "Werknemer 3", PhoneNumber = "0123456789", Email = "abfg@gmail.com", Function = "Inspecteur", StreetNumber = "AbcOnderwijsboulevard 1", ZipCode = "1234 AB", Region = "Utrecht"
                }
            };
            string query = "abc";
            values[0] = collection;
            values[1] = query;


            //act
            List<EmployeeViewModel> actual = (List<EmployeeViewModel>)c.Convert(values, null, null, null);
            var expected = new List<EmployeeViewModel>()
            {
                new EmployeeViewModel()
                {
                    Id = 1, Name = "Werknemer 1", PhoneNumber = "0123456789", Email = "abcdefg@gmail.com", Function = "Inspecteur", StreetNumber = "Onderwijsboulevard 1", ZipCode = "1234 AB", Region = "Utrecht"
}
            };
            //assert
            Assert.AreEqual(expected[0].Id, actual[0].Id);
        }
        [TestMethod()]
        public void EmployeeConvertTest_ShouldReturn_Nothing()
        {
            //arrange
            FilterEmployeeConverter c = new FilterEmployeeConverter();
            object[] values = new object[2];
            var collection = new ObservableCollection<EmployeeViewModel>()
            {
                new EmployeeViewModel()
                {
                    Id = 1, Name = "Employee", PhoneNumber = "0123456789", Email = "abcdefg@gmail.com", Function = "Inspecteur", StreetNumber = "Onderwijsboulevard 1", ZipCode = "1234 AB", Region = "Utrecht"
                },
                new EmployeeViewModel(){
                    Id = 2, Name = "test", PhoneNumber = "0123456789", Email = "12345@gmail.com", Function = "Manager", StreetNumber = "Onderwijsboulevard 1", ZipCode = "1234 AB", Region = "Noord-Brabant"
                },
                new EmployeeViewModel(){
                    Id = 3, Name = "abc", PhoneNumber = "0123456789", Email = "efg@gmail.com", Function = "Directeur", StreetNumber = "Onderwijsboulevard 1", ZipCode = "1234 AB", Region = "Limburg"
                },
                new EmployeeViewModel(){
                    Id = 4, Name = "Employee 2", PhoneNumber = "0123456789", Email = "abfg@gmail.com", Function = "Inspecteur", StreetNumber = "ABCOnderwijsboulevard 1", ZipCode = "1234 AB", Region = "Utrecht"
                }
            };
            string query = ";;;";
            values[0] = collection;
            values[1] = query;

            //act
            List<EmployeeViewModel> actual = (List<EmployeeViewModel>)c.Convert(values, null, null, null);
            //assert
            Assert.IsTrue(actual.Count == 0);
        }

    }
}