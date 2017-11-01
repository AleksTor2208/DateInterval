using System;

namespace DateRange
{
    class ValidationStatus
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
            var incorrectFormatStatus = "End date can not be less or same as first date";
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
            var incorrectFormatStatus = "Incorrect date format, proper format is: dd.MM.yyyy";
            var concatData = startDate + endDate;
            concatData = concatData.Replace(".", "");
            for (int i = 0; i < concatData.Length; i++)
            {
                if (!char.IsDigit(concatData[i]))
                {
                    Message = incorrectFormatStatus;
                    return false;
                }                    
            }
            if (!CheckDots(startDate) || !CheckDots(endDate))
            {
                Message = incorrectFormatStatus;
                return false;
            }
            return true;
        }

        private bool CheckDots(string date)
        {
            return date[2] == '.' && date[5] == '.';
        }
    }
}
