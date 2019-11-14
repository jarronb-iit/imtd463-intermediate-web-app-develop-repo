using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace assignment7.Controllers
{
    public class MortgageController : Controller
    {
        private List<double> interestRatesList = new List<double>  { .25, .50, .75, 1.00, 1.25, 1.50, 1.75, 2.00,
            2.25, 2.50, 2.75, 3.00, 3.25, 3.50, 3.75, 4.00, 4.25, 4.50, 4.75, 5.00, 5.25,
            5.50, 5.75, 6.00, 6.25, 6.50, 6.75, 7.00, 7.25, 7.50, 7.75, 8.00, 8.25, 8.50,
            8.75, 9.00, 9.25, 9.50, 9.75, 10.00};

        public MortgageController()
        {
            ViewBag.PreviousUrl = System.Web.HttpContext.Current.Request.UrlReferrer;
        }

        // GET: Mortgage
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.interestRatesList = interestRatesList;
            return View("Index");
        }

        // POST: Mortgage
        [HttpPost]
        public ActionResult Index([Bind(Include = "principal, years, rate", Exclude = "id, monthlyPayment")] CalculationModel calculation)
        {
            if (ModelState.IsValid)
            {
                string interestRage = Request.Form["rate"].ToString();

                DatabaseIOHelper DatbaseHelperInstance = new DatabaseIOHelper();

                //double principal, double years, double rate
                calculation.monthlyPayment = MortgageHelper.useComputeMonthlyPayment(calculation.principal, calculation.years, calculation.rate);
                DatbaseHelperInstance.AddEntry(calculation);
                return View("List");
            } else
            {
                ViewBag.interestRatesList = interestRatesList;
                return View("Index", calculation);
            }
        }

        // GET: Edit
        [HttpGet]
        public ActionResult Edit(int? id = null)
        {
            if (id == null)
            {
                return View("Edit");
            }

            DatabaseIOHelper DatbaseHelperInstance = new DatabaseIOHelper();
            var (isError, calculation) = DatbaseHelperInstance.FindById(id.GetValueOrDefault());
             
            return View("Edit", calculation);
        }

        // POST: Edit
        [HttpPost]
        public ActionResult Edit([Bind(Include = "id, principal, years, rate", Exclude = "monthlyPayment")] CalculationModel calculation)
        {
            if (ModelState.IsValid)
            {
                //double principal, double years, double rate
                calculation.monthlyPayment = MortgageHelper.useComputeMonthlyPayment(calculation.principal, calculation.years, calculation.rate);

                DatabaseIOHelper DatbaseHelperInstance = new DatabaseIOHelper();
                var (isError, updatedCalculation) = DatbaseHelperInstance.UpdateById(calculation.id, calculation);

                return View("List");
            }
            else
            {
                return View("Index", calculation);
            }
        }

        // GET: Edit
        [HttpGet]
        public ActionResult List([Bind(Include = "id, principal, years, rate, monthlyPayment")] CalculationModel calculation)
        {
            return View("List");
        }

        // DELETE
        public ActionResult Delete(int id)
        {
            DatabaseIOHelper DatbaseHelperInstance = new DatabaseIOHelper();
            DatbaseHelperInstance.DeleteById(id);
            return View("List");
        }

        // DELETE all
        public ActionResult DeleteAll()
        {
            DatabaseIOHelper DatbaseHelperInstance = new DatabaseIOHelper();
            DatbaseHelperInstance.ClearEntries();
            return View("List");
        }

        // GET: Edit
        [HttpGet]
        public ActionResult Details(int? id = null)
        {
            if (id == null)
            {
                return View("Edit");
            }

            DatabaseIOHelper DatbaseHelperInstance = new DatabaseIOHelper();
            var (isError, calculation) = DatbaseHelperInstance.FindById(id.GetValueOrDefault());

            return View("Details", calculation);
        }
    }
}