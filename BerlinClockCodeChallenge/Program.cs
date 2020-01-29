using System;

namespace BerlinClockCodeChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Input time (example format 'hh:mm:ss')");
                String userTime = Console.ReadLine();
                ClockTime clockTime = new ClockTime();
                Time time = clockTime.SetInput(userTime);
                Console.WriteLine("\nOutput Time:");
                Console.WriteLine(clockTime.GetOutput(time));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }
    }
}
