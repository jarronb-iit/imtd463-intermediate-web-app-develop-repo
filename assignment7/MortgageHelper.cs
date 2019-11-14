using System;
using System.Collections.Generic;

namespace assignment7
{
    public class MortgageHelper
    {
        public static List<String> errorMessages = new List<string>();

        public static (bool passed, double value, string message) validateInput(string num, string errorMessage="")
        {
            if (Double.TryParse(num, out double value))
            {
                return (true, value, errorMessage);
            }
            else
            {
                return (false, value, errorMessage);
            }
        }

        private static double ComputeMonthlyPayment(double principal, double years, double rate)
        {
            double monthly = 0;
            double top = principal * rate / 1200.00;
            double bottom = 1 - Math.Pow(1.0 + rate / 1200.0, -12.0 * years);
            // http://www.bankrate.com/calculators/mortgages/loan-calculator.aspx
            monthly = top / bottom;
            //Console.WriteLine();
            //Console.WriteLine("With a principl of ${0}, duration of {1} years and a interest rate of {2}% the monthly loan payment amount is {3:$0.00}", principal, years, rate, monthly);
            return monthly;
        }
        
        public static double useComputeMonthlyPayment(double principal, double years, double rate)
        {
            return ComputeMonthlyPayment(principal, years, rate);
        }

        public static double CalcCelsius(string str)
        {
            double temp = Double.Parse(str);
            temp = temp - 7;
            return temp;
        }
    }
}