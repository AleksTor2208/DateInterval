using System;
using System.Threading;

namespace DateRange
{
    public class ArgsEncoder
    {
        public string StartDate { get; set; }
        public string EndDate { get; set; }

        public void EncodeArgs(string[] args)
        {
            try
            {
                this.StartDate = args[0];
                this.EndDate = args[1];
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Two arguments should be given.");
                Thread.Sleep(3000);
                Environment.Exit(0);
            }
        }
    }
}