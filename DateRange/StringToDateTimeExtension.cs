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
            var year = int.Parse(date.Substring(6));
            var month = int.Parse(date.Substring(3, 2));
            var day = int.Parse(date.Substring(0, 2));
            return new DateTime(year, month, day);
        }        
    }
}
