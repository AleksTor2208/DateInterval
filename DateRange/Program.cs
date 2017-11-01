using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateRange
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var startDate = args[0];
                var endDate = args[1];                
                Console.WriteLine(GetDateInterval(startDate, endDate));
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("No parameters have been passed.");
            }
            Console.ReadLine();
            
        }

        private static string GetDateInterval(string startDate, string endDate)
        {
            var validationStatus = new ValidationStatus(startDate, endDate);
            if (validationStatus.IsValid())
                return "IsValid";
            return null;
          
        }
    }
}
