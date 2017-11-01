using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateRange
{
    class ValidationStatus
    {
        private string startDate;
        private string endDate;
        public string StatusMessage { get; set; }

        public ValidationStatus(string startDate, string endDate)
        {
            this.startDate = startDate;
            this.endDate = endDate;
        }

        internal bool IsValid()
        {
            if (IsProperDateFormat())
            {
                if (IsCorrectDateOrder())
                    return true;
            }
            return false;
        }

        private bool IsCorrectDateOrder()
        {
            var incorrectFormatStatus = "End date can not be less or same as first date";
            var compareResult = DateTime.Compare(startDate.ConvertToDateTime(), endDate.ConvertToDateTime());
            if (compareResult >= 0)
            {
                StatusMessage = incorrectFormatStatus;
                return false;
            }
            return true;
        }        

        private bool IsProperDateFormat()
        {
            var incorrectFormatStatus = "Incorrect date format, proper format is: dd.MM.yyyy";
            var concatData = startDate + endDate;
            concatData = concatData.Replace(".", "");
            for (int i = 0; i < concatData.Length; i++)
            {
                if (!char.IsDigit(concatData[i]))
                {
                    StatusMessage = incorrectFormatStatus;
                    return false;
                }                    
            }
            if (!CheckDots(startDate) || !CheckDots(endDate))
            {
                StatusMessage = incorrectFormatStatus;
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
