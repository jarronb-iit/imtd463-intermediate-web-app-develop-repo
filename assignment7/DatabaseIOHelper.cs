using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace assignment7
{
    public class DatabaseIOHelper : IIOHelper
    {
        public void AddEntry(CalculationModel calculation)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = ConfigurationManager.ConnectionStrings["PaymentInfo"].ConnectionString;
                    conn.Open();

                    string sqlCommandString = $"INSERT INTO PaymentInfo (Principal, InterestRate, Years, MonthlyPayment) VALUES (@Principal, @InterestRate, @Years, @MonthlyPayment)";
                    
                    // use the connection here
                    using (SqlCommand sqlCommand = new SqlCommand(sqlCommandString, conn))
                    {
                        sqlCommand.Parameters.AddWithValue("@Principal", calculation.principal);
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

                    string sqlCommandString = "DELETE FROM dbo.PaymentInfo";

                    // use the connection here
                    using (SqlCommand sqlCommand = new SqlCommand(sqlCommandString, conn))
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

        public List<CalculationModel> ReadAllEntries()
        {
            List<CalculationModel> calculationsList = new List<CalculationModel>();

            try
            {
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = ConfigurationManager.ConnectionStrings["PaymentInfo"].ConnectionString;
                    conn.Open();

                    string sqlCommandString = $"SELECT * FROM PaymentInfo";

                    // use the connection here
                    using (SqlCommand sqlCommand = new SqlCommand(sqlCommandString, conn))
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

                                CalculationModel calculation = new CalculationModel(id, principal, rate, years, monthlyPayment);

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
        public (bool isError, CalculationModel calculation) FindById(int id)
        {
            CalculationModel calculation = null;
            try
            {
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = ConfigurationManager.ConnectionStrings["PaymentInfo"].ConnectionString;
                    conn.Open();

                    string sqlCommandString = $"SELECT * FROM PaymentInfo WHERE Id=@Id";

                    // use the connection here

                    using (SqlCommand sqlCommand = new SqlCommand(sqlCommandString, conn))
                    {
                        sqlCommand.Parameters.AddWithValue("@Id", id);
                        
                        using (var reader = sqlCommand.ExecuteReader())
                        {
                            // while there is another record present
                            while (reader.Read())
                            {
                                double principal = Double.Parse(reader["Principal"].ToString());
                                double rate = Double.Parse(reader["InterestRate"].ToString());
                                double years = Double.Parse(reader["Years"].ToString());
                                double monthlyPayment = Double.Parse(reader["MonthlyPayment"].ToString());
                                calculation = new CalculationModel(id, principal, rate, years, monthlyPayment);
                            }
                        }

                    }
                }
                return (false, calculation);
            }
            catch (Exception ex)
            {
                LogHelper.WriteErrorMessage($"{ex.Message} - {ex.StackTrace}");
                return (true, calculation);
            }
        }

        public (bool isError, CalculationModel calculation) UpdateById(int id, CalculationModel calculation)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = ConfigurationManager.ConnectionStrings["PaymentInfo"].ConnectionString;
                    conn.Open();

                    string sqlCommandString = $"UPDATE dbo.PaymentInfo SET Principal = @Principal, InterestRate = @InterestRate, Years = @Years, MonthlyPayment = @MonthlyPayment WHERE Id = @Id";

                    // use the connection here
                    using (SqlCommand sqlCommand = new SqlCommand(sqlCommandString, conn))
                    {
                        sqlCommand.Parameters.AddWithValue("@Principal", calculation.principal);
                        sqlCommand.Parameters.AddWithValue("@InterestRate", calculation.rate);
                        sqlCommand.Parameters.AddWithValue("@Years", calculation.years);
                        sqlCommand.Parameters.AddWithValue("@MonthlyPayment", calculation.monthlyPayment);
                        sqlCommand.Parameters.AddWithValue("@Id", id);

                        using (var reader = sqlCommand.ExecuteReader())
                        {
                            // while there is another record present
                            while (reader.Read())
                            {
                                double principal = Double.Parse(reader["Principal"].ToString());
                                double rate = Double.Parse(reader["InterestRate"].ToString());
                                double years = Double.Parse(reader["Years"].ToString());
                                double monthlyPayment = Double.Parse(reader["MonthlyPayment"].ToString());
                                calculation = new CalculationModel(id, principal, rate, years, monthlyPayment);
                            }
                        }

                    }
                }
                return (false, calculation);
            }
            catch (Exception ex)
            {
                LogHelper.WriteErrorMessage($"{ex.Message} - {ex.StackTrace}");
                return (true, calculation);
            }
        }

        public void DeleteById(int id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = ConfigurationManager.ConnectionStrings["PaymentInfo"].ConnectionString;
                    conn.Open();

                    string sqlCommandString = $"DELETE FROM dbo.PaymentInfo WHERE Id = @Id";


                    // use the connection here

                    using (SqlCommand sqlCommand = new SqlCommand(sqlCommandString, conn))
                    {
                        sqlCommand.Parameters.AddWithValue("@Id", id);

                        int result = sqlCommand.ExecuteNonQuery();

                        if (result <= 0)
                        {
                            throw new Exception("Unable to delete data to database");
                        }
                    }
                }
                //return (false, calculation);
            }
            catch (Exception ex)
            {
                LogHelper.WriteErrorMessage($"{ex.Message} - {ex.StackTrace}");
                //return (true, calculation);
            }
        }

    } // End of class
} // End of namespace