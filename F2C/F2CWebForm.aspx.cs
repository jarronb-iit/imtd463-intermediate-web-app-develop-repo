using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace F2C
{
    enum typesOfDrinksEnum
    {
        other = 2
    }
    public partial class F2CWebForm : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) SetFocus(farText);

        }

        protected void ConvertF2C_Click(object sender, EventArgs e)
        {
            double temp = 0.0d;
            try
            {
                temp = TemperatureHelper.CalcCelsius(farText.Text);
                tempText.Text = $"{farText.Text} degrees Fahrenheit is {temp} degrees Celsius";
                LogHelper.LogTemperature(farText.Text);
                farText.Text = String.Empty;
            }
            catch (HttpException ex)
            {
                tempText.Text = $"Unable to find file!";
                LogHelper.WriteErrorMessage($"{ex.Message} - {ex.StackTrace}");
            }
            catch (Exception ex)
            {

                tempText.Text = $"{farText.Text} not valid temp";
                LogHelper.WriteErrorMessage($"{ex.Message} - {ex.StackTrace}");
            }

        }

        protected void typesOfDrinks_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (typesOfDrinks.SelectedIndex == (int) typesOfDrinksEnum.other) CheckBox1.Enabled = true;
        }
    }
}