using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment4
{
    public class ICalculation
    {
        public ICalculation(double principal, double rate, double years, double monthlyPayment)
        {
            this.principle = principal;
            this.rate = rate;
            this.years = years;
            this.monthlyPayment = monthlyPayment;
        }

        public double principle { get; set; }
        public double years { get; set; }
        public double rate { get; set; }
        public double monthlyPayment { get; set; }

        public override string ToString()
        {
            return $"{principle};{rate};{years};{monthlyPayment}";
        }
    }
}
