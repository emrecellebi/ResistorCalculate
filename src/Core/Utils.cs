using System;

public class Utils
{
	public static double ResiztorCalc(int a, int b)
	{
		return a * Math.Pow(10, b);
	}
	
	public static string GetSembol(double ohm)
	{
		if(ohm >= 1000000000)
        {
            double gOhm = ohm / 1000000000.0;
            return $"{gOhm}GΩ";
        }
		else if(ohm >= 1000000)
		{
			double mohm = ohm / 1000000.0;
			return $"{mohm}MΩ";
		}
		else if(ohm >= 1000)
		{
			double kohm = ohm / 1000.0;
			return $"{kohm}KΩ";
		}
		else
		{
			return $"{ohm}Ω";
		}
	}
}