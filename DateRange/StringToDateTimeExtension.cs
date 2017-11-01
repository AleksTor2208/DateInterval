using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateRange
{
    public static class StringToDateTimeExtension
    {
        public static DateTime ConvertToDateTime(this string date)
        {
            var yearIndex = 6;
            var monthIndex = 3;
            var dayIndex = 0;
            var monthLength = 2;
            var dayLength = 2;
            var year = int.Parse(date.Substring(yearIndex));
            var month = int.Parse(date.Substring(monthIndex, monthLength));
            var day = int.Parse(date.Substring(dayIndex, dayLength));
            return new DateTime(year, month, day);
        }        
    }
}
