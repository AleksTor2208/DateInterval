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

        [TestMethod]
        public void TestProperParametersWithSameYearAndMonthReturnProperValue()
        {
            var startDate = "01.02.2017";
            var endDate = "02.02.2017";
            var dateFormatter = new DateFormatter(startDate, endDate, new ValidationStatus());
            var expected = "01-02.02.2017";
            Assert.AreEqual(expected, dateFormatter.ValidateAndGetRange());
        }

        [TestMethod]
        public void TestErrorMessageIsSentIfEndDateIsLessThenStartDate()
        {
            var startDate = "02.02.2017";
            var endDate = "01.02.2017";
            var dateFormatter = new DateFormatter(startDate, endDate, new ValidationStatus());
            var expected = "End date can not be less or same as first date";
            Assert.AreEqual(expected, dateFormatter.ValidateAndGetRange());
        }

        [TestMethod]
        public void TestErrorMessageIsSentIfEndDateIsSameAsStartDate()
        {
            var startDate = "02.02.2017";
            var endDate = "02.02.2017";
            var dateFormatter = new DateFormatter(startDate, endDate, new ValidationStatus());
            var expected = "End date can not be less or same as first date";
            Assert.AreEqual(expected, dateFormatter.ValidateAndGetRange());
        }

        [TestMethod]
        public void TestProperErrorMessageSentIfParametersHaveIncorrectFormat()
        {
            var startDate = "02 Sep 2017";
            var endDate = "02 Nov 2017";
            var dateFormatter = new DateFormatter(startDate, endDate, new ValidationStatus());
            var expected = "Incorrect date format, proper format is: dd.MM.yyyy";
            Assert.AreEqual(expected, dateFormatter.ValidateAndGetRange());
        }

        [TestMethod]
        public void TestProperErrorMessageSentIfBigIntegerIsSentAsParameter()
        {
            var startDate = "118494549584938485783475838375993485748938574839485438904593485940" +
                "34985490395489403945849037898789878987898789878799589430498590394859749384857389";
            var endDate = "15438904593485940349854903954894039458490349589430498590394859035843" +
                "42343488909890989098907968987898789878987879958943049859039485974938485738809890";
            var dateFormatter = new DateFormatter(startDate, endDate, new ValidationStatus());
            var expected = "Incorrect date format, proper format is: dd.MM.yyyy";
            Assert.AreEqual(expected, dateFormatter.ValidateAndGetRange());
        }
    }
}
