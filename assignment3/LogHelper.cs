using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Configuration;

namespace MortgageCalculator
{
    public class LogHelper
    {
        public static void LogCalculations(string data)
        {
            string pathToData = ConfigurationManager.AppSettings["PathToCalculationsLog"];
            string filename = HttpContext.Current.Server.MapPath(pathToData);

            File.AppendAllText(filename, data + "\n");
        }

        public static List<string> ReadAllCalculations()
        {
            string pathToData = ConfigurationManager.AppSettings["PathToCalculationsLog"];
            string filename = HttpContext.Current.Server.MapPath(pathToData);

            List<string> calculationsList = new List<string>();
            calculationsList.AddRange(File.ReadAllLines(filename));
            return calculationsList;
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

        public static void DeleteCalculationsFile()
        {
            string pathToData = ConfigurationManager.AppSettings["PathToCalculationsLog"];
            string filename = HttpContext.Current.Server.MapPath(pathToData);

            if (File.Exists(filename))
            {
                File.Delete(filename);
            }
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