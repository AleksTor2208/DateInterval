using System;

namespace DateRange
{
    public class DateFormatter
    {
        private string _startDate;
        private string _endDate;
        private readonly IDateValidator _dateValidator;

        public DateFormatter(string startDate, string endDate, IDateValidator dateValidator)
        {
            this._startDate = startDate;
            this._endDate = endDate;
            this._dateValidator = dateValidator;
        }

        public string ValidateAndGetRange()
        {            
            if (_dateValidator.IsValid(_startDate, _endDate))
                return GetProperFormatRange();
            return _dateValidator.ErrorMessage;
        }

        private string GetProperFormatRange()
        {
            var convStartDate = DateTime.Parse(_startDate);
            var convEndDate = DateTime.Parse(_endDate);                                 
                if (convStartDate.Year == convEndDate.Year)                
                    return FormatDateWithSameYear(convStartDate, convEndDate);                             
            return $"{_startDate}-{_endDate}";                     
        }

        private string FormatDateWithSameYear(DateTime convStartDate, DateTime convEndDate)
        {
            if (convStartDate.Month != convEndDate.Month)
            {
                const int DaysMonthIndex = 5;
                _startDate = _startDate.Substring(0, DaysMonthIndex);
                return $"{_startDate}-{_endDate}";
            }
            return FormatDateWithSameMonth(convStartDate, convEndDate);
        }

        private string FormatDateWithSameMonth(DateTime convStartDate, DateTime convEndDate)
        {
            if (convStartDate.Day != convEndDate.Day)
            {
                const int daysIndex = 2;
                _startDate = _startDate.Substring(0, daysIndex);
                return $"{_startDate}-{_endDate}";                
            }
            return convStartDate.ToShortDateString();              
        }
    }
}
