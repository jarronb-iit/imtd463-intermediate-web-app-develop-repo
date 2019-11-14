using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace assignment4
{
    enum typesOfMortgageLoanDurationsEnum
    {
        fiftheenYears = 15,
        thirtyYears = 30,
        other = -1
    }
    public partial class CalculateMortgageWebForm : System.Web.UI.Page
    {
        LogHelper LoghHelperInstance = new LogHelper();
        DatabaseIOHelper DatbaseHelperInstance = new DatabaseIOHelper();

        public static List<string> errorsList = new List<string>();

        double[] interestRatesArray = new double[] { .25, .50, .75, 1.00, 1.25, 1.50, 1.75, 2.00,
            2.25, 2.50, 2.75, 3.00, 3.25, 3.50, 3.75, 4.00, 4.25, 4.50, 4.75, 5.00, 5.25,
            5.50, 5.75, 6.00, 6.25, 6.50, 6.75, 7.00, 7.25, 7.50, 7.75, 8.00, 8.25, 8.50,
            8.75, 9.00, 9.25, 9.50, 9.75, 10.00};

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                otherLoanDurationInput.Enabled = false;
                typesOfLoanDurationsRBList.SelectedIndex = 0;
                SetFocus(principleInput);
                interestRateDropDownList.DataSource = interestRatesArray;
                interestRateDropDownList.DataBind();
            }
        }

        protected void Calculate_Mortgage(object sender, EventArgs e)
        {
            double principle = 0.0d;
            bool principlePassed = false;
            string principleErrorMessage = String.Empty;
            double interestRate = 0.0d;
            bool interestRatePassed = false;
            string interestRateErrorMessage = String.Empty;
            double years = 0;
            bool yearsPassed = false;
            string yearsErrorMessage = String.Empty;
            double monthlyPayment = 0;

            try
            {
                // reset errors onClick
                ErrorsGridView.DataSource = null;
                ErrorsGridView.DataBind();
                errorsList.Clear();
                string temp = interestRateDropDownList.SelectedValue;

                (principlePassed, principle, principleErrorMessage) = MortgageHelper.validateInput(principleInput.Text, "Principle entry was invalid");
                (interestRatePassed, interestRate, interestRateErrorMessage) = MortgageHelper.validateInput(interestRateDropDownList.SelectedValue, "Principle entry was invalid");
                (yearsPassed, years, yearsErrorMessage) = MortgageHelper.validateInput(typesOfLoanDurationsRBList.SelectedValue, "Years was not selected");
                if (otherLoanDurationInput.Enabled)
                {
                 (yearsPassed, years, yearsErrorMessage) = MortgageHelper.validateInput(otherLoanDurationInput.Text, "Years was not selected");
                }

                if (!principlePassed)
                {
                    errorsList.Add(principleErrorMessage);
                    LogHelper.WriteErrorMessage(principleErrorMessage);
                }
                if (!interestRatePassed)
                {
                    errorsList.Add(interestRateErrorMessage);
                    LogHelper.WriteErrorMessage(interestRateErrorMessage);
                }
                if (!yearsPassed)
                {
                    errorsList.Add(yearsErrorMessage);
                    LogHelper.WriteErrorMessage(yearsErrorMessage);
                }

                if (errorsList.Count > 0)
                {
                    ErrorsGridView.DataSource = errorsList.ToArray();
                    ErrorsGridView.DataBind();
                    ErrorsGridView.Font.Bold = true;
                    ErrorsGridView.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    monthlyPayment = MortgageHelper.useComputeMonthlyPayment(principle, years, interestRate);
                    var calulation = new ICalculation(principle, interestRate, years, monthlyPayment);
                    resultText.Text = $"Monthly payment is {monthlyPayment.ToString("c")}";
                    DatbaseHelperInstance.AddEntry(calulation);

                    // Reset
                    principleInput.Text = String.Empty;
                    interestRateDropDownList.SelectedIndex = 0;
                    typesOfLoanDurationsRBList.ClearSelection();
                }
            }
            catch (System.UnauthorizedAccessException ex)
            {
                resultText.Text = "Internal Error";
                resultText.Font.Bold = true;
                resultText.ForeColor = System.Drawing.Color.Red;
                Console.Write($"{ex.Message} - {ex.StackTrace}");
            }
            catch (HttpException ex)
            {
                principleInput.Text = $"Unable to find file!";
                LogHelper.WriteErrorMessage($"{ex.Message} - {ex.StackTrace}");
            }
            catch (Exception ex)
            {

                resultText.Text = $"Fix errors";
                resultText.ForeColor = System.Drawing.Color.Red;
                LogHelper.WriteErrorMessage($"{ex.Message} - {ex.StackTrace}");
            }

        }

        protected void typesOfLoanDurations_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (int.Parse(typesOfLoanDurationsRBList.SelectedValue) == (int)typesOfMortgageLoanDurationsEnum.other)
            {
                otherLoanDurationInput.Enabled = true;
            }
            else
            {
                otherLoanDurationInput.Enabled = false;
                otherLoanDurationInput.Text = String.Empty;
            }
        }

        protected void Unnamed_Tick(object sender, EventArgs e)
        {
            TimerofDay.Text = DateTime.Now.ToLocalTime().ToString();
        }
    }
}