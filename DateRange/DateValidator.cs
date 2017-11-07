using System;
using System.Linq;

namespace DateRange
{
    public class DateValidator : IDateValidator
    {       
        public string ErrorMessage { get; set; }
        public string ErrorDetails { get; set; }

        public bool IsValid(string startDate, string endDate)
        {
            return IsConvertable(startDate, endDate)
                && !HasUSCultureDateFormat(startDate)
                && !HasUSCultureDateFormat(endDate)
                && IsCorrectDateOrder(startDate, endDate);
                
        }

        private bool HasUSCultureDateFormat(string date)
        {
            ErrorDetails = "Inapropriate yyyy.MM.dd format. Try dd.MM.yyy";
            char[] separators = new char[] { '.', '/', ',', '_', '-'};            
            const int yearMonthSeparatorIndex = 4;
            const int monthDaysSeparatorIndex = 7;
            var hasBadFormat = separators.Contains(date[yearMonthSeparatorIndex])
                && separators.Contains(date[monthDaysSeparatorIndex]);
            if (!hasBadFormat) return false;
            ErrorMessage = ErrorDetails;
            return true;                 
        }

        private bool IsConvertable(string startDate, string endDate)
        {
            ErrorDetails = $"{startDate}, {endDate} is not a valid date representation";
            var hasConverted = DateTime.TryParse(startDate, out DateTime date)
                && DateTime.TryParse(endDate, out date);
            if (hasConverted) return true;
            ErrorMessage = ErrorDetails;
            return false;            
        }

        private bool IsCorrectDateOrder(string startDate, string endDate)
        {
            ErrorDetails = "End date can not be less then first date";
            var convStartDate = DateTime.Parse(startDate);
            var convEtartDate = DateTime.Parse(endDate);
            var compareResult = DateTime.Compare(convStartDate, convEtartDate);
            if (compareResult < 0) return true;
            ErrorMessage = ErrorDetails;
            return false;                   
        }          
    }
}
