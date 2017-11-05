using System;
using System.Linq;

namespace DateRange
{
    public class ValidationStatus
    {       
        public string Message { get; set; }        

        public bool IsValid(string startDate, string endDate)
        {
            if (IsProperDateFormat(startDate, endDate))
            {
                if (IsCorrectDateOrder(startDate, endDate))
                    return true;
            }
            return false;
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

        private bool CheckDots(string date)
        {
            const int dayMonthSeparator = 2;
            const int monthYearSeparator = 5;
            return date[dayMonthSeparator] == '.' && date[monthYearSeparator] == '.';
        }
    }
}
