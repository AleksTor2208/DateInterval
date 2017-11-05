
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
            return _dateValidator.Message;
        }

        private string GetProperFormatRange()
        {
            var convStartDate = _startDate.ConvertToDateTime();
            var convEndDate = _endDate.ConvertToDateTime();
            var justDays = 2;
            var justDaysAndMonth = 5;
            if (convStartDate.Year == convEndDate.Year)
            {
                if (convStartDate.Month == convEndDate.Month)
                {
                    _startDate = _startDate.Substring(0, justDays);
                }
                else
                {
                    _startDate = _startDate.Substring(0, justDaysAndMonth);
                }
            }
            return $"{_startDate}-{_endDate}";
        }
    }
}
