using System;
using System.Text.RegularExpressions;

namespace BerlinClockCodeChallenge
{
	public class ClockTime : IClockTime
	{		
		public Time SetInput(String userTime)
		{
			string[] timeValues = userTime.Split(new string[] { ":" }, StringSplitOptions.None);
			if (timeValues.Length ==3)
			{
				Time time = new Time();
				time.hours = Int32.Parse(timeValues[0]);
				time.minutes = Int32.Parse(timeValues[1]);
				time.seconds = Int32.Parse(timeValues[2]);
				return time;
			}
			throw new InvalidOperationException(string.Format("Invalid input.Valid format is hh:mm:ss"));
		}

		public String GetOutput(Time time)
		{
			return getSeconds(time.seconds)+"\n"+getHours(time.hours) + "\n" + getMinutes(time.minutes);
		}

		private String getHours(int hours)
		{
			return getClockState(4, (hours - (hours % 5)) / 5) + "\n" + getClockState(4, hours % 5);
		}

		private String getMinutes(int min)
		{
			return Regex.Replace(getClockState(11, (min - (min % 5)) / 5, Color.Y.ToString()), Color.Y.ToString() + Color.Y.ToString() + Color.Y.ToString(), Color.Y.ToString() + Color.Y.ToString() + Color.R.ToString()) + "\n" +
				getClockState(4, min % 5, Color.Y.ToString());
		}

		
		private String getSeconds(int seconds)
		{
			if (seconds % 2 == 0)
				return Color.Y.ToString();
			else
				return Color.O.ToString();
		}

		private String getClockState(int lamps, int onLight)
		{
			return getClockState(lamps, onLight, Color.R.ToString());
		}

		
		private String getClockState(int lamps, int onLights, String onLight)
		{
			String output = "";
			for (int i = 0; i < onLights; i++)
			{
				output += onLight;
			}
			for (int i = 0; i < (lamps - onLights); i++)
			{
				output += Color.O.ToString();
			}
			return output;
		}
	}
}
