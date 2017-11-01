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
            if (args.Length == 0)
                Console.WriteLine("No arguments were passed");
            Console.Read();
            var startDate = args[0];
            var endDate = args[1];
            GetDateInterval(startDate, endDate);
        }

        private static void GetDateInterval(string startDate, string endDate)
        {
            throw new NotImplementedException();
        }
    }
}
