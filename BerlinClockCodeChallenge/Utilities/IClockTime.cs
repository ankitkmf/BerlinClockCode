using System;

namespace BerlinClockCodeChallenge
{
    interface IClockTime
    {
        Time SetInput(String time);
        String GetOutput(Time time);
    }
}
