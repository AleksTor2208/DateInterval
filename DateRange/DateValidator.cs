using System;
using System.Linq;

namespace DateRange
{
    public class DateValidator : IDateValidator
    {       
        public string Message { get; set; }        

        public bool IsValid(string startDate, string endDate)
        {
            return IsNotNull(startDate, endDate) && IsProperDateFormat(startDate, endDate) && IsCorrectDateOrder(startDate, endDate);
        }

        private bool IsNotNull(string startDate, string endDate)
        {
            const string incorrectFormatStatus = "Arguments can't be 'null'";
            Message = incorrectFormatStatus;
            return startDate != null && endDate != null;
            
        }

        private bool IsCorrectDateOrder(string startDate, string endDate)
        {
            const string incorrectFormatStatus = "End date can not be less or same as first date";
            var compareResult = DateTime.Compare(startDate.ConvertToDateTime(), endDate.ConvertToDateTime());
            if (compareResult >= 0)
            {
                Message = incorrectFormatStatus;
                return false;
            }
            return true;
        }        

        private bool IsProperDateFormat(string startDate, string endDate)
        {
            const string incorrectFormatStatus = "Incorrect date format, proper format is: dd.MM.yyyy";
            var concatData = startDate + endDate;
            concatData = concatData.Replace(".", "");
            if (concatData.Any(t => !char.IsDigit(t)))
            {
                Message = incorrectFormatStatus;
                return false;
            }
            if (CheckDots(startDate) && CheckDots(endDate)) return true;
            Message = incorrectFormatStatus;
            return false;
        }

        private static bool CheckDots(string date)
        {
            const int dayMonthSeparator = 2;
            const int monthYearSeparator = 5;
            return date[dayMonthSeparator] == '.' && date[monthYearSeparator] == '.';
        }
    }
}
