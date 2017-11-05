using System;

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
            }
        }
    }
}