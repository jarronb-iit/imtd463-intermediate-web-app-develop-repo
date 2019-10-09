using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace F2C
{
    public partial class TempLog : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<string> temps = LogHelper.ReadAllTemperatures();
            TempGrid.DataSource = temps;
            TempGrid.DataBind();
        }

        public static (bool passed, float value) ValidateInput(string input)
        {
            if(float.TryParse(input, out float value))
            {
                return (true, value);
            } 
            else
            {
                return (false, value);
            }
        }
    }
}