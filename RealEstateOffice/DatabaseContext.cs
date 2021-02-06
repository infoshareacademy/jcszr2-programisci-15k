using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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


        public static void AddToDatabase(RealEstate realEstate)
        {
            //ID; TypeOfRealEstate; Price; Area; OwnerName; OwnerSurname; City; Street; EstateAddress; CreationDate; ModificationDate;
            //ID zostaje ustalony automatycznie
            //Data stworzenia wpisu zostaje ustalona automatycznie
            //funkcja przyjmuje obiekt RealEstate


            String path = "..\\Files\\RealEstates.csv";
            string realativePath = DatabaseContext.bingPathToAppDir(path);

            var lastLine = File.ReadLines(realativePath).Last(); // z tego wyciągam  ID 

            StringBuilder sb = new StringBuilder();

            sb.AppendLine("");
            sb.Append(GetLastLineId(lastLine)); //Id
            sb.Append(";");
            sb.Append((int)realEstate.typeOfRealEstate);  //TypeOfRealEstate
            sb.Append(";");
            sb.Append(realEstate.Price);
            sb.Append(";");
            sb.Append(realEstate.Area);
            sb.Append(";");
            sb.Append(realEstate.OwnerName);
            sb.Append(";");
            sb.Append(realEstate.OwnerSurname);
            sb.Append(";");
            sb.Append(realEstate.City);
            sb.Append(";");
            sb.Append(realEstate.Street);
            sb.Append(";");
            sb.Append(realEstate.EstateAddress);
            
                       

            using (StreamWriter sw = File.AppendText(realativePath))
            {
                sw.Write(sb);
               
            }

            Console.Clear();
            Console.WriteLine("Record added to database.Press any key");
            Console.ReadLine();
        }

        static int GetLastLineId(String lastLine)
        {
            string[] columns = lastLine.Split(";");
            var lastId = Convert.ToInt32(columns[0]);
            lastId = lastId + 1;
            return lastId;
        }

      
        
            //funkcja przyjmuje realEstate.ID
            //
            //task 3
            public static void RemoveFromDatabase(int LineToDelete)
            {
                String path = "..\\Files\\RealEstates.csv";
                string fullPath = DatabaseContext.bingPathToAppDir(path);
                StreamReader sr = new StreamReader(fullPath);
                
                string line;
            

            using (StreamReader reader = new StreamReader(fullPath))
            {
                using (StreamWriter writer = new StreamWriter(DatabaseContext.bingPathToAppDir("..\\Files\\Temp.csv")))
                {
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] columns = line.Split(";");
                        if (LineToDelete != Convert.ToInt32(columns[0]))
                        {
                          writer.WriteLine(line);
                        }
                    }
                                    
                }
            }

            sr.Close();
            File.Copy(DatabaseContext.bingPathToAppDir("..\\Files\\Temp.csv"), fullPath,true);

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
