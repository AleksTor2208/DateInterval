using System;

namespace DateRange
{
    public class Program
    {
        public static void Main(string[] args)
        {            
                var argsEncoder = new ArgsEncoder();
                argsEncoder.EncodeArgs(args);
                var dateFormatter = new DateFormatter(argsEncoder.StartDate, argsEncoder.EndDate, new DateValidator());
                Console.WriteLine(dateFormatter.ValidateAndGetRange());
                Console.ReadLine();
        }        
    }
}
