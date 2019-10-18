using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Configuration;

namespace assignment4
{
    public class LogHelper : IIOHelper
    {
        public void AddEntry(ICalculation calculation)
        {
            string pathToData = ConfigurationManager.AppSettings["PathToCalculationsLog"];
            string filename = HttpContext.Current.Server.MapPath(pathToData);
            string msg = calculation.ToString();
            File.AppendAllText(filename, msg + "\n");
        }

        public List<ICalculation> ReadAllEntries()
        {
            int principalField = 0, rateField = 1, yearsField = 2, monthlyPayment = 3;
            string pathToData = ConfigurationManager.AppSettings["PathToCalculationsLog"];
            string filename = HttpContext.Current.Server.MapPath(pathToData);

            List<ICalculation> calculationsList = new List<ICalculation>();

            foreach (var line in File.ReadAllLines(filename))
            {
                string[] items = line.Split(';');

               
                calculationsList.Add(
                    new ICalculation(Double.Parse(items[principalField]), 
                    Double.Parse(items[rateField]), Double.Parse(items[yearsField]), Double.Parse(items[monthlyPayment]
                    )));
            }


            return calculationsList;
        }

        public void ClearEntries()
        {
            string pathToData = ConfigurationManager.AppSettings["PathToCalculationsLog"];
            string filename = HttpContext.Current.Server.MapPath(pathToData);

            if (File.Exists(filename))
            {
                File.Delete(filename);
            }
        }
        public static void WriteLogMessage(string msg)
        {
            string pathToData = ConfigurationManager.AppSettings["PathToErrorLog"];
            string filename = HttpContext.Current.Server.MapPath(pathToData);

            File.AppendAllText(filename, $"App Message: {msg}\n");
            

        }

        public static void WriteErrorMessage(string msg)
        {
            string pathToData = ConfigurationManager.AppSettings["PathToErrorLog"];
            string filename = HttpContext.Current.Server.MapPath(pathToData);

            File.AppendAllText(filename, $"App Error: {msg}\n");

        }

        public static void DeleteErrorsFile()
        {
            string pathToData = ConfigurationManager.AppSettings["PathToErrorLog"];
            string filename = HttpContext.Current.Server.MapPath(pathToData);

            if (File.Exists(filename))
            {
                File.Delete(filename);
            }
        }
    }
}