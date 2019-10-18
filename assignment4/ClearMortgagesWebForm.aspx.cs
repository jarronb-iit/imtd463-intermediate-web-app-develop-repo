using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace assignment4
{
    public partial class ClearMortgagesWebForm : System.Web.UI.Page
    {
        LogHelper LoghHelperInstance = new LogHelper();

        protected void Page_Load(object sender, EventArgs e)
        {
            List<string> calculationsData = new List<string>();
            try
            {
                List<ICalculation> calculations = LoghHelperInstance.ReadAllEntries();
                foreach (var calculation in calculations)
                {
                    calculationsData.Add($"Monthly payment: {calculation.monthlyPayment.ToString("c")} | Principle: {calculation.principle} | Interest Rate: {calculation.rate} | Years: {calculation.years}");
                }

                CalculationsGrid.DataSource = calculationsData;
                CalculationsGrid.DataBind();
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
        protected void ClearListButton_Click(object sender, EventArgs e)
        {
            CalculationsGrid.DataSource = null;
            CalculationsGrid.DataBind();

            LoghHelperInstance.ClearEntries();
            LogHelper.DeleteErrorsFile();
        }
    }
}