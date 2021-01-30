using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace RealEstateOffice
{
    class DatabaseContext
    {
        public static List<RealEstate> RealEstatesFilter(Filter filter)
        {
            String path = "..\\Files\\RealEstates.csv";
            string fullPath =  DatabaseContext.bingPathToAppDir(path); 
            List<RealEstate> RealEstateList = new List<RealEstate>();

            using (StreamReader reader = new StreamReader(fullPath))
            {
                string line;
                long count = 0;
                while ((line = reader.ReadLine()) != null)
                {
                    //RealEstateList.Add(new RealEstate(ID, TypeOfRealEstate, Price, Area, OwnerName, OwnerSurname, City, Street, EstateAddress));
                    RealEstateList.Add(new RealEstate(Convert.ToInt32(ParseTextLine(line, 0)), Convert.ToInt32(ParseTextLine(line, 1)), System.Convert.ToDecimal(ParseTextLine(line, 2)), Convert.ToInt32(ParseTextLine(line, 3)), ParseTextLine(line, 4), ParseTextLine(line, 5), ParseTextLine(line, 6), ParseTextLine(line, 7), ParseTextLine(line, 8)));

                    
                }
            }
                      

            return RealEstateList;


        }


        static string ParseTextLine(string Line,int column)
        {
            string[] columns = Line.Split(";");
            string output = columns[column]; 
            return output;
        }


        void AddToDatabase(RealEstate realEstate)
        {
            //ID zostaje ustalony automatycznie
            //Data stworzenia wpisu zostaje ustalona automatycznie
            //funkcja przyjmuje obiekt RealEstate
            //task 3
        }

        void RemoveFromDatabase()
        {
            //funkcja przyjmuje realEstate.ID
            //
            //task 3
        }

        void EditRecordInDatabase()
        {
            //Data modyfikacji wpisu zostaje ustalona/nadpisana automatycznie
            //funkcja przyjmuje realEstate.ID
            //funkcja przyjmuje też pola RealEstate które użytkownik chce zmodyfikować
            //task 3
        }


        public void OpenFile()
        {

           String path = "..\\Files\\RealEstates.csv";
            string realativePath = DatabaseContext.bingPathToAppDir(path);
            
           using (System.IO.FileStream fs = File.OpenRead(realativePath))  
           {  
            byte[] b = new byte[1024];
             UTF8Encoding temp = new UTF8Encoding(true);  
            while (fs.Read(b,0,b.Length) > 0)  
            {  
                Console.WriteLine(temp.GetString(b));  
            }  
           }  
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
