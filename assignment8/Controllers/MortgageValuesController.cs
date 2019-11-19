using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace assignment8.Controllers
{
    public class MortgageValuesController : ApiController
    {
        // GET: api/MortgageValues
        public IEnumerable<CalculationModel> Get()
        {
            DatabaseIOHelper DatbaseHelperInstance = new DatabaseIOHelper();
            return DatbaseHelperInstance.ReadAllEntries();
        }

        // GET: api/MortgageValues/5
        public IHttpActionResult Get(int id)
        {
            DatabaseIOHelper DatbaseHelperInstance = new DatabaseIOHelper();
            var (isError, calculation) = DatbaseHelperInstance.FindById(id);

            if (!isError)
            {
                return Ok(calculation);
            }
            else
            {
                return NotFound();
            }
        }

        // POST: api/MortgageValues
        public IHttpActionResult Post([FromBody]CalculationModel calculation)
        {
            DatabaseIOHelper DatbaseHelperInstance = new DatabaseIOHelper();

            try
            {
                //double principal, double years, double rate
                calculation.monthlyPayment = MortgageHelper.useComputeMonthlyPayment(calculation.principal, calculation.years, calculation.rate);
                DatbaseHelperInstance.AddEntry(calculation);
                return Ok();

            }
            catch (Exception)
            {

                return BadRequest();
            }


        }

        // PUT: api/MortgageValues/5
        public IHttpActionResult Put([FromBody]CalculationModel calculation)
        {
            //double principal, double years, double rate
            calculation.monthlyPayment = MortgageHelper.useComputeMonthlyPayment(calculation.principal, calculation.years, calculation.rate);

            DatabaseIOHelper DatbaseHelperInstance = new DatabaseIOHelper();
            var (isError, updatedCalculation) = DatbaseHelperInstance.UpdateById(calculation.id, calculation);

            if (!isError)
            {
                return Ok<CalculationModel>(calculation);
            }
            else
            {
                return NotFound();
            }
        }

        // DELETE: api/MortgageValues/
        public IHttpActionResult Delete()
        {
            try
            {
                DatabaseIOHelper DatbaseHelperInstance = new DatabaseIOHelper();
                DatbaseHelperInstance.ClearEntries();

                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // DELETE: api/MortgageValues/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                DatabaseIOHelper DatbaseHelperInstance = new DatabaseIOHelper();
                DatbaseHelperInstance.DeleteById(id);

                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
