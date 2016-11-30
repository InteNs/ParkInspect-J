// <copyright file="FilterEmployeeConverterTest.cs">Copyright ©  2016</copyright>
using System;
using System.Globalization;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParkInspect.Converter;

namespace ParkInspect.Converter.Tests
{
    /// <summary>This class contains parameterized unit tests for FilterEmployeeConverter</summary>
    [PexClass(typeof(FilterEmployeeConverter))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class FilterEmployeeConverterTest
    {
        /// <summary>Test stub for ConvertBack(Object, Type[], Object, CultureInfo)</summary>
        [PexMethod]
        public object[] ConvertBackTest(
            [PexAssumeUnderTest]FilterEmployeeConverter target,
            object value,
            Type[] targetTypes,
            object parameter,
            CultureInfo culture
        )
        {
            object[] result = target.ConvertBack(value, targetTypes, parameter, culture);
            return result;
            // TODO: add assertions to method FilterEmployeeConverterTest.ConvertBackTest(FilterEmployeeConverter, Object, Type[], Object, CultureInfo)
        }

        /// <summary>Test stub for Convert(Object[], Type, Object, CultureInfo)</summary>
        [PexMethod]
        public object ConvertTest(
            [PexAssumeUnderTest]FilterEmployeeConverter target,
            object[] values,
            Type targetType,
            object parameter,
            CultureInfo culture
        )
        {
            object result = target.Convert(values, targetType, parameter, culture);
            return result;
            // TODO: add assertions to method FilterEmployeeConverterTest.ConvertTest(FilterEmployeeConverter, Object[], Type, Object, CultureInfo)
        }
    }
}
