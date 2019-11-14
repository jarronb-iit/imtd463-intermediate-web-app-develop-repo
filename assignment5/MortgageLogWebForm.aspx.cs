using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace assignment4
{
    public partial class MortgageLogWebForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LogHelper LoghHelperInstance = new LogHelper();
            DatabaseIOHelper DatbaseHelperInstance = new DatabaseIOHelper();
            List<string> calculationsData = new List<string>();
            try
            {
                
                List<ICalculation> calculations = DatbaseHelperInstance.ReadAllEntries();
                foreach (var calculation in calculations)
                {
                    calculationsData.Add($"Monthly payment: {calculation.monthlyPayment.ToString("c")} | Principle: {calculation.principle} | Interest Rate: {calculation.rate} | Years: {calculation.years}");
                }

                CalculationsGrid.DataSource = calculationsData;
                CalculationsGrid.DataBind();

                if (calculationsData.ToArray().Length <= 0)
                {
                    ifError.Text = "No data entered";
                    ifError.Font.Bold = true;
                    ifError.ForeColor = System.Drawing.Color.Red;
                }
            }
            catch (System.UnauthorizedAccessException ex)
            {
                ifError.Text = "Internal Error";
                ifError.Font.Bold = true;
                ifError.ForeColor = System.Drawing.Color.Red;
                Console.Write($"{ex.Message} - {ex.StackTrace}");
            }
            catch (System.IO.FileNotFoundException ex)
            {
                ifError.Text = "File was not found!";
                ifError.Font.Bold = true;
                ifError.ForeColor = System.Drawing.Color.Red;
                LogHelper.WriteErrorMessage($"{ex.Message} - {ex.StackTrace}");
            }
            catch (Exception ex)
            {
                LogHelper.WriteErrorMessage($"{ex.Message} - {ex.StackTrace}");
            }

        }
    }
}