using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Configuration;

namespace F2C
{
    public class LogHelper
    {
        public static void LogTemperature(string data)
        {
            string pathToData = ConfigurationManager.AppSettings["PathToTempLog"];
            string filename = HttpContext.Current.Server.MapPath(pathToData);

            File.AppendAllText(filename, data + "\n");
        }

        public static List<string> ReadAllTemperatures()
        {
            string pathToData = ConfigurationManager.AppSettings["PathToTempLog"];
            string filename = HttpContext.Current.Server.MapPath(pathToData);

            List<string> tempList = new List<string>();
            tempList.AddRange(File.ReadAllLines(filename));
            return tempList;
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

        public static void DeleteTempFile()
        {
            string pathToData = ConfigurationManager.AppSettings["PathToTempLog"];
            string filename = HttpContext.Current.Server.MapPath(pathToData);

            if (File.Exists(filename))
            {
                File.Delete(filename);
            }
        }
    }
}