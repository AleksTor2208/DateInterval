using System;

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
                var dateFormatter = new DateFormatter(startDate, endDate, new ValidationStatus());
                Console.WriteLine(dateFormatter.ValidateAndGetRange(startDate, endDate));
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("No parameters have been passed.");
            }
            Console.ReadLine();            
        }        
    }
}
