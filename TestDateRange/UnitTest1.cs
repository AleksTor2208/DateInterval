using System;
using DateRange;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestDateRange
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestProperParametersWithDiffYearsReturnProperValue()
        {
            var startDate = "01.01.2016";
            var endDate = "02.02.2017";
            var dateFormatter = new DateFormatter(startDate, endDate, new ValidationStatus());
            var expected = "01.01.2016-02.02.2017";
            Assert.AreEqual(expected, dateFormatter.ValidateAndGetRange());
        }

        [TestMethod]
        public void TestProperParametersWithSameYearsReturnProperValue()
        {
            var startDate = "01.01.2017";
            var endDate = "02.02.2017";
            var dateFormatter = new DateFormatter(startDate, endDate, new ValidationStatus());
            var expected = "01.01-02.02.2017";
            Assert.AreEqual(expected, dateFormatter.ValidateAndGetRange());
        }
    }
}
