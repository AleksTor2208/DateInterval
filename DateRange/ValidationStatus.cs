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

        public ValidationStatus(string startDate, string endDate)
        {
            this.startDate = startDate;
            this.endDate = endDate;
        }

        internal bool IsValid()
        {
            return true;
        }
    }
}
