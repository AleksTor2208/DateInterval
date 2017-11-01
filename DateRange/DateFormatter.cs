using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            if (convStartDate.Year == convEndDate.Year)
            {
                if (convStartDate.Month == convEndDate.Month)
                {
                    startDate = startDate.Substring(0, 2);
                }
                else
                {
                    startDate = startDate.Substring(0, 5);
                }
            }
            return $"{startDate}-{endDate}";
        }
    }
}
