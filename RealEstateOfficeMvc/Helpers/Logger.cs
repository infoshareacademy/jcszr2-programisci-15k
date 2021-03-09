using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace RealEstateOfficeMvc
{
    class Logger
    {
         public static List<Log> DisplayLogList()
        {
            //ID; LogDate; TypeOfCRUDOperation; UserName;
            String path = "..\\Files\\Log.csv";
            string fullPath = DatabaseContext.bingPathToAppDir(path);
            List<Log> logList = new List<Log>();
            

            using (StreamReader reader = new StreamReader(fullPath))
            {
                string line;

                while ((line = reader.ReadLine()) != null)
                {
                    
                    logList.Add(new Log(Convert.ToInt32(ParseTextLine(line, 0)), Convert.ToDateTime(ParseTextLine(line, 1)), ParseTextLine(line, 2), ParseTextLine(line, 2)));

                }
            }

            return logList;
        }


        //public static void AddLineToLog(Log log)
        //{
        //    String path = "..\\Files\\Log.csv";
        //    string relativePath = UserDatabaseContext.bingPathToAppDir(path);

        //    // pobieram ID z ostatniej linijki w users.csv
        //    var info = new FileInfo(relativePath);
        //    //var lastLine = '0';
        //    var lastId = 1;
        //    if (info.Length < 10)  // zabezp. przed pustym plikiem
        //    {
        //       lastId = 0;
        //    }
        //    else
        //    {
        //        var lastLine = File.ReadLines(relativePath).Last();
        //        string[] columns = lastLine.Split(";");
        //        lastId = Convert.ToInt32(columns[0]);
        //    }
                     
        //    //ID; LogDate; TypeOfCRUDOperation; UserName;
        //    StringBuilder sb = new StringBuilder();
        //    sb.AppendLine("");
        //    sb.Append(lastId + 1); //Id = lastId + 1
        //    sb.Append(";");
        //    sb.Append(DateTime.Now);
        //    sb.Append(";");
        //    sb.Append(log.TypeOfCRUDOperation);
        //    sb.Append(";");
        //    sb.Append(MyIdentity.GetLogin());

        //    using (StreamWriter sw = File.AppendText(relativePath))
        //    {
        //        sw.Write(sb);
        //    }

        //    Console.Clear();
           
        //}

        static string ParseTextLine(string Line, int column)
        {
            string[] columns = Line.Split(";");
            string output = columns[column];
            return output;
        }


        public static string bingPathToAppDir(string localPath)
        {
            string currentDir = Environment.CurrentDirectory;
            DirectoryInfo directory = new DirectoryInfo(
                Path.GetFullPath(Path.Combine(currentDir, @"..\..\" + localPath)));
            return directory.ToString();
        }


    }
}
