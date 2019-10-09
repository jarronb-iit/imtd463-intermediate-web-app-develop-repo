using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MortgageCalculator
{
    public partial class MortgageLogWebForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                List<string> calculations = LogHelper.ReadAllCalculations();
                CalculationsGrid.DataSource = calculations;
                CalculationsGrid.DataBind();
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