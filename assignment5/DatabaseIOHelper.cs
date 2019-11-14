using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace assignment4
{
    public class DatabaseIOHelper : IIOHelper
    {
        public void AddEntry(ICalculation calculation)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = ConfigurationManager.ConnectionStrings["PaymentInfo"].ConnectionString;
                    conn.Open();

                    string sqlInsertCommand = $"INSERT INTO PaymentInfo (Principal, InterestRate, Years, MonthlyPayment) VALUES (@Principal, @InterestRate, @Years, @MonthlyPayment)";
                    // use the connection here

                    using (SqlCommand sqlCommand = new SqlCommand(sqlInsertCommand, conn))
                    {
                        sqlCommand.Parameters.AddWithValue("@Principal", calculation.principle);
                        sqlCommand.Parameters.AddWithValue("@InterestRate", calculation.rate);
                        sqlCommand.Parameters.AddWithValue("@Years", calculation.years);
                        sqlCommand.Parameters.AddWithValue("@MonthlyPayment", calculation.monthlyPayment);

                        int result = sqlCommand.ExecuteNonQuery();

                        if (result <= 0)
                        {
                            throw new Exception("Unable to add data to database");
                        }

                    }
                }
            }
            catch (Exception ex)
            {

                LogHelper.WriteErrorMessage($"{ex.Message} - {ex.StackTrace}");
            }
        }

        public void ClearEntries()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = ConfigurationManager.ConnectionStrings["PaymentInfo"].ConnectionString;
                    conn.Open();

                    string sqlDeleteCommand = "DELETE FROM dbo.PaymentInfo";
                    // use the connection here

                    using (SqlCommand sqlCommand = new SqlCommand(sqlDeleteCommand, conn))
                    {
                        int result = sqlCommand.ExecuteNonQuery();

                        if (result <= 0)
                        {
                            throw new Exception("Unable to clear to database");
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteErrorMessage($"{ex.Message} - {ex.StackTrace}");
            }
        }

        public List<ICalculation> ReadAllEntries()
        {
            List<ICalculation> calculationsList = new List<ICalculation>();

            try
            {
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = ConfigurationManager.ConnectionStrings["PaymentInfo"].ConnectionString;
                    conn.Open();

                    string sqlInsertCommand = $"SELECT * FROM PaymentInfo";
                    // use the connection here

                    using (SqlCommand sqlCommand = new SqlCommand(sqlInsertCommand, conn))
                    {
                                            
                        using (var reader = sqlCommand.ExecuteReader())
                        {
                            // while there is another record present
                            while (reader.Read())
                            {
                                int id = int.Parse(reader["Id"].ToString());
                                double principal = Double.Parse(reader["Principal"].ToString());
                                double rate = Double.Parse(reader["InterestRate"].ToString());
                                double years = Double.Parse(reader["Years"].ToString());
                                double monthlyPayment = Double.Parse(reader["MonthlyPayment"].ToString());

                                ICalculation calculation = new ICalculation(principal, rate, years, monthlyPayment);

                                calculationsList.Add(calculation);
                            }
                        }

                    }
                }
                return calculationsList;
            }
            catch (Exception ex)
            {
                LogHelper.WriteErrorMessage($"{ex.Message} - {ex.StackTrace}");
                return calculationsList;
            }
        }
    }
}