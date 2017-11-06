using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateRange
{
    public interface IDateValidator
    {
        string ErrorMessage { get; set; }
        bool IsValid(string startDate, string endDate);
       
    }
}
