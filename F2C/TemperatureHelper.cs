using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace F2C
{
    public class TemperatureHelper
    {
        public static string CalcFahrenheit(string str)
        {
            return str;
        }

        public static double CalcCelsius(string str)
        {
            double temp = Double.Parse(str);
            temp = temp - 7;
            return temp;
        }
    }
}