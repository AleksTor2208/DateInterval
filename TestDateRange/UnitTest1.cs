using System;
using DateRange;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestDateRange
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestProperParametersWithDiffYearsPassedReturnProperValue()
        {
            var startDate = "01.01.2001";
            var endDate = "02.02.2002";
            var dateFormatter = new DateFormatter(startDate, endDate, new ValidationStatus());
            var expected = "01.01.2001-02.02.2002";
            Assert.AreEqual(expected, dateFormatter.ValidateAndGetRange());
        }
    }
}
