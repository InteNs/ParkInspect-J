using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParkInspect.Converter;
using ParkInspect.ViewModel;

namespace ParkInspectTests.Converter
{
    [TestClass()]
    public class FilterCustomerConverterTests
    {
        [TestMethod()]
        public void CustomerConvertTest()
        {
            //arrange
            FilterCustomerConverter c = new FilterCustomerConverter();
            object[] values = new object[2];
            var collection = new ObservableCollection<CustomerViewModel>()
            {
                new CustomerViewModel()
                {
                    Id = 1, Name = "Klant1", PhoneNumber = "0123456789", Email = "abcdefg@gmail.com", Function = "Klant", StreetNumber = "Onderwijsboulevard 1", ZipCode = "1234 AB"
                },
                new CustomerViewModel(){
                    Id = 2, Name = "test", PhoneNumber = "0123456789", Email = "12345@gmail.com", Function = "Klant", StreetNumber = "Onderwijsboulevard 1", ZipCode = "1234 AB"
                },
                new CustomerViewModel(){
                    Id = 4, Name = "klantje", PhoneNumber = "0123456789", Email = "abfg@gmail.com", Function = "Klant", StreetNumber = "AbcOnderwijsboulevard 1", ZipCode = "1234 AB"
                }
            };
            string query = "abc";
            values[0] = collection;
            values[1] = query;
            

            //act
            List<CustomerViewModel> actual = (List<CustomerViewModel>)c.Convert(values, null, null, null);
            var expected = new List<CustomerViewModel>()
            {
                new CustomerViewModel()
                {
                    Id = 1, Name = "Klant1", PhoneNumber = "0123456789", Email = "abcdefg@gmail.com", Function = "Klant", StreetNumber = "Onderwijsboulevard 1", ZipCode = "1234 AB"
}
            };
            //assert
            Assert.AreEqual(expected[0].Id, actual[0].Id);
        }

        [TestMethod()]
        public void CustomerConvertTest_ShouldReturn_Nothing()
        {
            //arrange
            FilterCustomerConverter c = new FilterCustomerConverter();
            object[] values = new object[2];
            var collection = new ObservableCollection<CustomerViewModel>()
            {
                new CustomerViewModel()
                {
                    Id = 1, Name = "Klant1", PhoneNumber = "0123456789", Email = "abcdefg@gmail.com", Function = "Klant", StreetNumber = "Onderwijsboulevard 1", ZipCode = "1234 AB"
                },
                new CustomerViewModel(){
                    Id = 2, Name = "", PhoneNumber = "0123456789", Email = "12345@gmail.com", Function = "Klant", StreetNumber = "Onderwijsboulevard 1", ZipCode = "1234 AB"
                },
                new CustomerViewModel(){
                    Id = 3, Name = "abc", PhoneNumber = "0123456789", Email = "efg@gmail.com", Function = "Klant", StreetNumber = "Onderwijsboulevard 1", ZipCode = "1234 AB"
                },
                new CustomerViewModel(){
                    Id = 4, Name = "klantje", PhoneNumber = "0123456789", Email = "abfg@gmail.com", Function = "Klant", StreetNumber = "ABCOnderwijsboulevard 1", ZipCode = "1234 AB"
                }
            };
            string query = ";;;";
            values[0] = collection;
            values[1] = query;

            //act
            List<CustomerViewModel> actual = (List<CustomerViewModel>)c.Convert(values, null, null, null);
            //assert
            Assert.IsTrue(actual.Count == 0);
        }
    }
}
