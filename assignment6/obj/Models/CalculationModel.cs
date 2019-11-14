using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace assignment7
{
    [Bind(Include = "principle, years, rate", Exclude = "monthlyPayment")]
    public class CalculationModel
    {
        public CalculationModel(double principal, double rate, double years, double monthlyPayment)
        {
            this.principle = principal;
            this.rate = rate;
            this.years = years;
            this.monthlyPayment = monthlyPayment;
        }

        public CalculationModel()
        {
         
        }

        [DisplayName("Principle")]
        [Required]
        public double principle { get; set; }
        [DisplayName("Years")]
        [Required]
        [Range(0, 100)]
        public double years { get; set; }
        [DisplayName("Interest Rate")]
        [Required]
        [Range(0, 10)]
        public double rate { get; set; }
        [DataType(DataType.Currency)]
        public double monthlyPayment { get; set; }

        public override string ToString()
        {
            return $"{principle};{rate};{years};{monthlyPayment}";
        }
    }
}
