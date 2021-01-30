using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace RealEstateOffice
{
    class DatabaseContext
    {
        public static void RealEstatesFilter(Filter filter)
        {
            
            //metoda przyjmuje obiekt klasy Filter z filtrami z frontendu
            //output to będzie lista wpisów (lista obiektów RealEstate)
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
