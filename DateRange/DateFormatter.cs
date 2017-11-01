
namespace DateRange
{
    class DateFormatter
    {
        private string startDate;
        private string endDate;
        private ValidationStatus validationStatus;

        public DateFormatter(string startDate, string endDate, ValidationStatus validationStatus)
        {
            this.startDate = startDate;
            this.endDate = endDate;
            this.validationStatus = validationStatus;
        }

        public string ValidateAndGetRange(string startDate, string endDate)
        {            
            if (validationStatus.IsValid(startDate, endDate))
                return GetProperFormatRange(startDate, endDate);
            return validationStatus.Message;
        }

        private string GetProperFormatRange(string startDate, string endDate)
        {
            var convStartDate = startDate.ConvertToDateTime();
            var convEndDate = endDate.ConvertToDateTime();
            var justDays = 2;
            var justDaysAndMonth = 5;
            if (convStartDate.Year == convEndDate.Year)
            {
                if (convStartDate.Month == convEndDate.Month)
                {
                    startDate = startDate.Substring(0, justDays);
                }
                else
                {
                    startDate = startDate.Substring(0, justDaysAndMonth);
                }
            }
            return $"{startDate}-{endDate}";
        }
    }
}
