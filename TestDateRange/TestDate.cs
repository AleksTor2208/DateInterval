using DateRange;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestDateRange
{
    [TestClass]
    public class TestDate
    {


        //[TestMethod]
        //public void TestReturnsCorrectValueWhenProperParamsWithDiffYearSent()
        //{
        //    var year = randomYear();
        //    const string startDate = getRandomDateWithYear(year); //"01.01.2016";
        //    const string endDate = getRandomDateWithYear(year); //"02.02.2017";
        //    var dateFormatter = new DateFormatter(startDate, endDate, new DateValidator());
        //    const string expected = "01.01.2016-02.02.2017";
        //    Assert.AreEqual(expected, dateFormatter.ValidateAndGetRange());
        //}

        [TestMethod]
        public void TestReturnsCorrectValueWhenProperParamsWithSameYearSent()
        {
            const string startDate = "01.01.2017";
            const string endDate = "02.02.2017";
            var dateFormatter = new DateFormatter(startDate, endDate, new DateValidator());
            const string expected = "01.01-02.02.2017";
            Assert.AreEqual(expected, dateFormatter.ValidateAndGetRange());
        }

        [TestMethod]
        public void TestReturnsCorrectValueWhenProperParamsWithSameYearAndMonthSent()
        {
            const string startDate = "01.02.2017";
            const string endDate = "02.02.2017";
            var dateFormatter = new DateFormatter(startDate, endDate, new DateValidator());
            const string expected = "01-02.02.2017";
            Assert.AreEqual(expected, dateFormatter.ValidateAndGetRange());
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
        public void TestProperErrorMessageIsSentIfParamsIncludeNegativeNumber()
        {
            const string startDate = "0-1.02.2017";
            const string endDate = "02.05.2017";
            var dateFormatter = new DateFormatter(startDate, endDate, new DateValidator());
            string expected = $"{startDate}, {endDate} is not a valid date representation";
            Assert.AreEqual(expected, dateFormatter.ValidateAndGetRange());
        }

        [TestMethod]
        public void TestProperValueIsReturnedWhenSpecificFormatWithSpacesIsPassed()
        {
            const string startDate = "02 SEP 2017";
            const string endDate = "03 SEP 2017";
            var dateFormatter = new DateFormatter(startDate, endDate, new DateValidator());
            string expected = "02-03 SEP 2017";
            Assert.AreEqual(expected, dateFormatter.ValidateAndGetRange());
        }

        

        [TestMethod]
        public void TestProperErrorMessageSentIfParameterDataHasIncorrectOrder()
        {
            const string startDate = "2016.09.10";
            const string endDate = "2015.08.12";
            var dateFormatter = new DateFormatter(startDate, endDate, new DateValidator());
            string expected = "Inapropriate yyyy.MM.dd format. Try dd.MM.yyy";
            Assert.AreEqual(expected, dateFormatter.ValidateAndGetRange());
        }

        [TestMethod]
        public void TestProperErrorMessageSentIfBigIntegerIsSentAsParameter()
        {
            const string startDate = "118494549584938485783475838375993485748938574839485438904593485940" +
                                     "34985490395489403945849037898789878987898789878799589430498590394859749384857389";
            const string endDate = "15438904593485940349854903954894039458490349589430498590394859035843" +
                                   "42343488909890989098907968987898789878987879958943049859039485974938485738809890";
            var dateFormatter = new DateFormatter(startDate, endDate, new DateValidator());
            string expected = $"{startDate}, {endDate} is not a valid date representation";
            Assert.AreEqual(expected, dateFormatter.ValidateAndGetRange());
        }

        [TestMethod]
        public void TestProperErrorMessageSentIfParameterDataIsNull()
        {
            const string startDate = null;
            const string endDate = null;
            var dateFormatter = new DateFormatter(startDate, endDate, new DateValidator());
            string expected = $"{startDate}, {endDate} is not a valid date representation";
            Assert.AreEqual(expected, dateFormatter.ValidateAndGetRange());
        }
    }       
}
