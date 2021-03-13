using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstateOfficeMvc.Controllers
{
    public class LogsController : Controller
    {
        public IActionResult Index()
        {
            var model = DisplayLog();
            return View(model);
        }

        public static List<Log> DisplayLog()
        {
            //ID; LogDate; TypeOfCRUDOperation; UserName;
            String path = "\\Files\\Log.csv";
            string testpath = Directory.GetCurrentDirectory();
            string relativePath = testpath + path;  // fullpath
            var lastLine = System.IO.File.ReadLines(relativePath).Last();

           
            List<Log> logList = new List<Log>();


            using (StreamReader reader = new StreamReader(relativePath))
            {
                string line;

                while ((line = reader.ReadLine()) != null)
                {

                    logList.Add(new Log(Convert.ToInt32(ParseTextLine(line, 0)), Convert.ToDateTime(ParseTextLine(line, 1)), ParseTextLine(line, 2), ParseTextLine(line, 2)));

                }
            }

            return logList;
        }


        public void AddToLog()
        {
            //przyjmuje obiekt klasy log i zapisuje do log.csv
        }


        static string ParseTextLine(string Line, int column)
        {
            string[] columns = Line.Split(";");
            string output = columns[column];
            return output;
        }
    }
}
