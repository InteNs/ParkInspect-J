using System;
using ParkInspect.Converter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows.Media;
using System.Collections.ObjectModel;
using ParkInspect.ViewModel;
using System.Collections.Generic;

namespace ParkInspect.Tests
{
    [TestClass]
    public class ConverterTests
    {
        [TestMethod]
        [TestCategory("Converters")]
        public void DateTimeToTimeString()
        {
            DatetimeToTimestringConverter converter = new DatetimeToTimestringConverter();
            string result = (string)converter.Convert(new DateTime(2016, 5, 12, 15, 43, 56), null, null, null);
            Assert.AreEqual(result, "15:43");
        }

        [TestMethod]
        [TestCategory("Converters")]
        public void NameToBrushAvailable()
        {
            NameToBrushConverter converter = new NameToBrushConverter();
            SolidColorBrush brush = (SolidColorBrush)converter.Convert("Beschikbaar", null, null, null);
            Assert.AreEqual(brush, Brushes.PaleGreen);
        }

        [TestMethod]
        [TestCategory("Converters")]
        public void NameToBrushWeekend()
        {
            NameToBrushConverter converter = new NameToBrushConverter();
            SolidColorBrush brush = (SolidColorBrush)converter.Convert("Weekend", null, null, null);
            Assert.AreEqual(brush, Brushes.Orange);
        }

        [TestMethod]
        [TestCategory("Converters")]
        public void NameToBrushInspection()
        {
            NameToBrushConverter converter = new NameToBrushConverter();
            SolidColorBrush brush = (SolidColorBrush)converter.Convert("7 Inspecties", null, null, null);
            Assert.AreEqual(brush.Color, new SolidColorBrush(Color.FromArgb(190, 0, 175, 240)).Color);
        }

        [TestMethod]
        [TestCategory("Converters")]
        public void FilterCustomer()
        {
            FilterCustomerConverter converter = new FilterCustomerConverter();
            ObservableCollection<CustomerViewModel> input = new ObservableCollection<CustomerViewModel> { new CustomerViewModel { Name = "Edward", Email="test", Function="test", Id=1, PhoneNumber="1", Region="test", StreetNumber="1", ZipCode="test"  }, new CustomerViewModel { Name = "Mathijs", Email = "test", Function = "test", Id = 1, PhoneNumber = "1", Region = "test", StreetNumber = "1", ZipCode = "test" }, new CustomerViewModel { Name = "Nurleyanti", Email = "test", Function = "test", Id = 1, PhoneNumber = "1", Region = "test", StreetNumber = "1", ZipCode = "test" } };
            List<CustomerViewModel> output = (List<CustomerViewModel>)converter.Convert(new object[] { input, "edw" }, null, null, null);
            Assert.IsTrue(output.Count == 1 && output[0].Name.Equals("Edward"));
        }

        [TestMethod]
        [TestCategory("Converters")]
        public void FilterEmployee()
        {
            FilterEmployeeConverter converter = new FilterEmployeeConverter();
            ObservableCollection<EmployeeViewModel> input = new ObservableCollection<EmployeeViewModel>() { new EmployeeViewModel() { Name = "Edward", Email = "test", Function = "test", Id = 1, PhoneNumber = "1", Region = "test", StreetNumber = "1", ZipCode = "test" }, new EmployeeViewModel() { Name = "Mathijs", Email = "test", Function = "test", Id = 1, PhoneNumber = "1", Region = "test", StreetNumber = "1", ZipCode = "test"}, new EmployeeViewModel() { Name = "Nurleyanti", Email = "test", Function = "test", Id = 1, PhoneNumber = "1", Region = "test", StreetNumber = "1", ZipCode = "test" } };
            List<EmployeeViewModel> output = (List<EmployeeViewModel>)converter.Convert(new object[] { input, "edw" }, null, null, null);
            Assert.IsTrue(output.Count == 1 && output[0].Name.Equals("Edward"));
        }

        [TestMethod]
        [TestCategory("Converters")]
        public void FilterTimeLineItem()
        {
            FilterTimeLineItemConverter converter = new FilterTimeLineItemConverter();
            ObservableCollection<TimeLineItemViewModel> input = new ObservableCollection<TimeLineItemViewModel> { new TimeLineItemViewModel(new EmployeeViewModel()) { Employee = new EmployeeViewModel { Name = "Edward", Email = "test", Function = "test", Id = 1, PhoneNumber = "1", Region = "test", StreetNumber = "1", ZipCode = "test" } }, new TimeLineItemViewModel(new EmployeeViewModel()) { Employee = new EmployeeViewModel { Name = "Mathijs", Email = "test", Function = "test", Id = 1, PhoneNumber = "1", Region = "test", StreetNumber = "1", ZipCode = "test" } }, new TimeLineItemViewModel(new EmployeeViewModel()) { Employee = new EmployeeViewModel { Name = "Nurleyanti", Email = "test", Function = "test", Id = 1, PhoneNumber = "1", Region = "test", StreetNumber = "1", ZipCode = "test" } } };
            List<TimeLineItemViewModel> output = (List<TimeLineItemViewModel>)converter.Convert(new object[] { input, "edw" }, null, null, null);
            Assert.IsTrue(output.Count == 1 && output[0].Employee.Name.Equals("Edward"));
        }
    }
}
