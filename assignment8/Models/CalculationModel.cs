using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace assignment8
{
    public class CalculationModel
    {
        public CalculationModel(int id, double principal, double rate, double years, double monthlyPayment)
        {
            this.id = id;
            this.principal = principal;
            this.rate = rate;
            this.years = years;
            this.monthlyPayment = monthlyPayment;
        }

        public CalculationModel()
        {

        }
        [DisplayName("ID")]
        [Required]
        public int id { get; set; }

        [DisplayName("Principal")]
        [Required]
        [DataType(DataType.Currency)]
        public double principal { get; set; }
        [DisplayName("Years")]
        [Required]
        [Range(0, 100)]
        public double years { get; set; }
        [DisplayName("Interest Rate")]
        [Required]
        [Range(0, 10)]
        public double rate { get; set; }

        [DisplayName("Monthly Payment")]
        [DataType(DataType.Currency)]
        public double monthlyPayment { get; set; }

        public override string ToString()
        {
            return $"{principal};{rate};{years};{monthlyPayment}";
        }
    }
}
