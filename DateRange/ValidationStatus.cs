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
            return IsProperDateFormat() &&
                IsCorrectDateOrder();
        }

        private bool IsCorrectDateOrder()
        {
            var firstDateYear = int.Parse(startDate.Substring(-4));
            var secondDateYear = int.Parse(endDate.Substring(-4));
            if (secondDateYear < firstDateYear)
            {
                StatusMessage = "End date can not be less then first date";
                return false;
            }
            return true;
        }

        private bool IsProperDateFormat()
        {
            var concatData = startDate + endDate;
            concatData = concatData.Replace(".", "");
            for (int i = 0; i < concatData.Length; i++)
            {
                if (!char.IsDigit(concatData[i]) || concatData[i] < 0)
                {
                    StatusMessage = "Passing dates should be positive numbers";
                    return false;
                }                    
            }
            if (!CheckDots(startDate) || !CheckDots(endDate))
            {
                StatusMessage = "Passing dates should be positive numbers";
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
