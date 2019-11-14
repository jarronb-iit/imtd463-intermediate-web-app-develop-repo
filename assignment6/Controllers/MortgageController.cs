using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace assignment7.Controllers
{
    public class MortgageController : Controller
    {
        // GET: Mortgage
        [HttpGet]
        public ActionResult Index()
        {
            return View("Index");
        }

        // POST: Mortgage
        [HttpPost]
        public ActionResult Index(CalculationModel calculation)
        {
            if (ModelState.IsValid)
            {
                //double principle, double years, double rate
                calculation.monthlyPayment = MortgageHelper.useComputeMonthlyPayment(calculation.principle, calculation.years, calculation.rate);
                return View("PaymentDetails", calculation);
            } else
            {
                return View("Index", calculation);
            }
        }

        // GET: Edit
        [HttpGet]
        public ActionResult Edit()
        {
            return View("Edit");
        }

        // POST: Edit
        [HttpPost]
        public ActionResult Edit(CalculationModel calculation)
        {
            if (ModelState.IsValid)
            {
                //double principle, double years, double rate
                calculation.monthlyPayment = MortgageHelper.useComputeMonthlyPayment(calculation.principle, calculation.years, calculation.rate);
                return View("PaymentDetails", calculation);
            }
            else
            {
                return View("Index", calculation);
            }
        }
    }
}