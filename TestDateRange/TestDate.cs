using DateRange;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestDateRange
{
    [TestClass]
    public class TestDate
    {
        [TestMethod]
        public void TestReturnsCorrectValueWhenProperParamsWithDiffYearSent()
        {
            //given
            const string startDate = "01.01.2016";
            const string endDate = "02.02.2017";
            var dateFormatter = new DateFormatter(startDate, endDate, new DateValidator());
            const string expected = "01.01.2016-02.02.2017";
            //when
            var actual = dateFormatter.ValidateAndGetRange();
            //then
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestReturnsCorrectValueWhenProperParamsWithSameYearSent()
        {
            //given
            const string startDate = "01.01.2017";
            const string endDate = "02.02.2017";
            var dateFormatter = new DateFormatter(startDate, endDate, new DateValidator());
            const string expected = "01.01-02.02.2017";
            //when
            var actual = dateFormatter.ValidateAndGetRange();
            //then
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestReturnsCorrectValueWhenProperParamsWithSameYearAndMonthSent()
        {
            //given
            const string startDate = "01.02.2017";
            const string endDate = "02.02.2017";
            var dateFormatter = new DateFormatter(startDate, endDate, new DateValidator());
            const string expected = "01-02.02.2017";
            //when
            var actual = dateFormatter.ValidateAndGetRange();
            //then
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestReturnsErrorMessageWhenEndDateIsLessThenStartDate()
        {
            //given
            const string startDate = "02.02.2017";
            const string endDate = "01.02.2017";
            var dateFormatter = new DateFormatter(startDate, endDate, new DateValidator());
            const string expected = "End date can not be less then first date";
            //when
            var actual = dateFormatter.ValidateAndGetRange();
            //then
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestReturnsProperValueWithSameDateParameters()
        {
            //given
            const string startDate = "02.02.2017";
            const string endDate = "02.02.2017";
            var dateFormatter = new DateFormatter(startDate, endDate, new DateValidator());
            const string expected = "02.02.2017";
            //when
            var actual = dateFormatter.ValidateAndGetRange();
            //then
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestProperErrorMessageIsSentIfParamsIncludeNegativeNumber()
        {
            //given
            const string startDate = "0-1.02.2017";
            const string endDate = "02.05.2017";
            var dateFormatter = new DateFormatter(startDate, endDate, new DateValidator());
            string expected = $"{startDate}, {endDate} is not a valid date representation";
            //when
            var actual = dateFormatter.ValidateAndGetRange();
            //then
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestProperValueIsReturnedWhenSpecificFormatWithSpacesIsPassed()
        {
            //given
            const string startDate = "02 SEP 2017";
            const string endDate = "03 SEP 2017";
            var dateFormatter = new DateFormatter(startDate, endDate, new DateValidator());
            string expected = "02-03 SEP 2017";
            //when
            var actual = dateFormatter.ValidateAndGetRange();
            //then
            Assert.AreEqual(expected, actual);
        }        

        [TestMethod]
        public void TestProperErrorMessageSentIfParameterDataHasIncorrectOrder()
        {
            //given
            const string startDate = "2016.09.10";
            const string endDate = "2015.08.12";
            var dateFormatter = new DateFormatter(startDate, endDate, new DateValidator());
            string expected = "Inapropriate yyyy.MM.dd format. Try dd.MM.yyy";
            //when
            var actual = dateFormatter.ValidateAndGetRange();
            //then
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestProperErrorMessageSentIfInapropriateCommandsSentAsParameter()
        {
            //given
            const string startDate = "rm -rf *";
            const string endDate = "rm -rf.";
            var dateFormatter = new DateFormatter(startDate, endDate, new DateValidator());
            string expected = $"{startDate}, {endDate} is not a valid date representation";
            //when
            var actual = dateFormatter.ValidateAndGetRange();
            //then
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestProperErrorMessageSentIfParameterDataIsNull()
        {
            //given
            const string startDate = null;
            const string endDate = null;
            var dateFormatter = new DateFormatter(startDate, endDate, new DateValidator());
            string expected = $"{startDate}, {endDate} is not a valid date representation";
            //when
            var actual = dateFormatter.ValidateAndGetRange();
            //then
            Assert.AreEqual(expected, actual);
        }
    }       
}
