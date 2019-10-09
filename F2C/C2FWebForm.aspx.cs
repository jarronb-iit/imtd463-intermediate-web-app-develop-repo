using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace F2C
{
    public partial class C2FWebForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) SetFocus(celText);
        }

        protected void ConvertC2F_Click(object sender, EventArgs e)
        {
            double temp = 0.0d;
            try
            {
                temp = TemperatureHelper.CalcCelsius(celText.Text);
                tempText.Text = $"{celText.Text} degrees Celsisu is {temp} degrees Farhenheit";
                celText.Text = String.Empty;
            }
            catch (Exception ex)
            {

                tempText.Text = $"{celText.Text} not valid temp";

            }

        }
    }
}