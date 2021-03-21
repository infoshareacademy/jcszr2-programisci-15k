﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using RealEstateOfficeMvc.Models;

namespace RealEstateOfficeMvc
{
    class DatabaseContext
    {
        public static List<RealEstateOfficeMvc.Models.RealEstate> RealEstatesFilter(Filter filter)
        {
            //String path = "..\\Files\\RealEstates.csv";
            //string fullPath = DatabaseContext.bingPathToAppDir(path);
            String path = "\\Files\\RealEstates.csv";
            string testpath = Directory.GetCurrentDirectory();
            string relativePath = testpath + path;  // fullpath
            List<RealEstateOfficeMvc.Models.RealEstate> RealEstateList = new List<RealEstateOfficeMvc.Models.RealEstate>();

            using (StreamReader reader = new StreamReader(relativePath))
            {
                string line;

                while ((line = reader.ReadLine()) != null)
                {
                    //RealEstateList.Add(new RealEstate(ID, TypeOfRealEstate, Price, Area, OwnerName, OwnerSurname, City, Street, EstateAddress));
                    RealEstateList.Add(new RealEstateOfficeMvc.Models.RealEstate(Convert.ToInt32(ParseTextLine(line, 0)), Convert.ToInt32(ParseTextLine(line, 1)), System.Convert.ToDecimal(ParseTextLine(line, 2)), Convert.ToInt32(ParseTextLine(line, 3)), Convert.ToInt32(ParseTextLine(line, 4)), ParseTextLine(line, 5), ParseTextLine(line, 6), ParseTextLine(line, 7), ParseTextLine(line, 8), ParseTextLine(line, 9), DateTime.Parse(ParseTextLine(line, 10)), DateTime.Parse(ParseTextLine(line, 11))));

                }
            }
            return RealEstateList;
        }
        public static RealEstate Get(int id)
        {
            String path = "\\Files\\RealEstates.csv";
            string testpath = Directory.GetCurrentDirectory();
            string relativePath = testpath + path;  // fullpath
            RealEstate realEstate = null;

            using (StreamReader reader = new StreamReader(relativePath))
            {
                string line;

                while ((line = reader.ReadLine()) != null)
                {
                    if (Convert.ToInt32(ParseTextLine(line, 0)) == id)
                    {

                        realEstate = new RealEstate(Convert.ToInt32(ParseTextLine(line, 0)), Convert.ToInt32(ParseTextLine(line, 1)), System.Convert.ToDecimal(ParseTextLine(line, 2)), Convert.ToInt32(ParseTextLine(line, 3)), Convert.ToInt32(ParseTextLine(line, 4)), ParseTextLine(line, 5), ParseTextLine(line, 6), ParseTextLine(line, 7), ParseTextLine(line, 8), ParseTextLine(line, 9), DateTime.Parse(ParseTextLine(line, 10)), DateTime.Parse(ParseTextLine(line, 11)));
                    }

                }
            }
            return realEstate;
        }

        public static List<RealEstateOfficeMvc.Models.RealEstate> RealEstateChoice(Filter filter)   //List<RealEstate> 
        {
            List<RealEstateOfficeMvc.Models.RealEstate> realEstateList;
            List<RealEstateOfficeMvc.Models.RealEstate> filteredRealEstateList = new List<RealEstateOfficeMvc.Models.RealEstate>();
            realEstateList = DatabaseContext.RealEstatesFilter(filter);  //gets hole list of Real Estates

            for (var i = 0; i < realEstateList.Count; i++)
            {
                if (filter.TypeOfRealEstate != null &&
                    realEstateList[i].typeOfRealEstate != filter.TypeOfRealEstate)
                {
                    continue;
                }

                if (filter.PriceLowest != null &&
                    (realEstateList[i].Price < filter.PriceLowest))
                {
                    continue;
                }

                if (filter.PriceHighest != null &&
                    (realEstateList[i].Price > filter.PriceHighest))
                {
                    continue;
                }

                if (filter.AreaSmallest != null &&
                    (realEstateList[i].Area < filter.AreaSmallest))
                {
                    continue;
                }

                if (filter.AreaBiggest != null &&
                    (realEstateList[i].Area > filter.AreaBiggest))
                {
                    continue;
                }

                if (filter.RoomAmountSmallest != null &&
                    (realEstateList[i].RoomsAmount < filter.RoomAmountSmallest))
                {
                    continue;
                }

                if (filter.RoomAmountBiggest != null &&
                    (realEstateList[i].RoomsAmount > filter.RoomAmountBiggest))
                {
                    continue;
                }

                if (!string.IsNullOrEmpty(filter.OwnerName) &&
                    realEstateList[i].OwnerName != filter.OwnerName)
                {
                    continue;
                }

                if (!string.IsNullOrEmpty(filter.OwnerSurname) &&
                    realEstateList[i].OwnerSurname != filter.OwnerSurname)
                {
                    continue;
                }

                if (!string.IsNullOrEmpty(filter.City) &&
                    realEstateList[i].City != filter.City)
                {
                    continue;
                }

                if (!string.IsNullOrEmpty(filter.Street) &&
                    realEstateList[i].Street != filter.Street)
                {
                    continue;
                }

                if (filter.CreationDateEarliest != null &&
                    (DateTime.Compare(realEstateList[i].CreationDate, (DateTime)filter.CreationDateEarliest) < 0))
                {
                    continue;
                }

                if (filter.CreationDateLatest != null &&
                    (DateTime.Compare(realEstateList[i].CreationDate, (DateTime)filter.CreationDateLatest) > 0))
                {
                    continue;
                }

                filteredRealEstateList.Add(realEstateList[i]);
            }
                       
            return filteredRealEstateList;

        }




        static string ParseTextLine(string Line,int column)
        {
            string[] columns = Line.Split(";");
            string output = columns[column]; 
            return output;
        }


        public static void AddToDatabase(RealEstateOfficeMvc.Models.RealEstate realEstate)
        {
            //ID; TypeOfRealEstate; Price; Area; OwnerName; OwnerSurname; City; Street; EstateAddress; CreationDate; ModificationDate;
            //ID zostaje ustalony automatycznie
            //Data stworzenia wpisu zostaje ustalona automatycznie
            //funkcja przyjmuje obiekt RealEstate

            realEstate.CreationDate = DateTime.Now;
            realEstate.ModificationDate = DateTime.Now;


            String path = "\\Files\\RealEstates.csv";
            string testpath = Directory.GetCurrentDirectory();
            string relativePath = testpath + path;  // fullpath
            var lastLine = File.ReadLines(relativePath).Last(); // z tego wyciągam  ID 

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
            sb.Append(realEstate.RoomsAmount);
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
            sb.Append(";");
            sb.Append(realEstate.CreationDate);
            sb.Append(";");
            sb.Append(realEstate.ModificationDate);
            sb.Append(";");



            using (StreamWriter sw = File.AppendText(relativePath))
            {
                sw.Write(sb);
               
            }

           // Console.Clear();
            //Console.WriteLine("Record added to database.Press any key");
            //Console.ReadLine();
            Log insertLog = new Log(0,DateTime.Now, "Insert of Real Estate: " + realEstate.typeOfRealEstate, "worker");
           // Logger.AddLineToLog(insertLog);
        }

        static int GetLastLineId(String lastLine)
        {
            string[] columns = lastLine.Split(";");
            var lastId = Convert.ToInt32(columns[0]);
            lastId = lastId + 1;
            return lastId;
        }
        
        
        

        public static string EditRecordInDatabase(RealEstateOfficeMvc.Models.RealEstate realEstate,int id)
        {

            //ID; TypeOfRealEstate; Price; Area; OwnerName; OwnerSurname; City; Street; EstateAddress; CreationDate; ModificationDate;
            //Data modyfikacji wpisu zostaje ustalona/nadpisana automatycznie
            //funkcja przyjmuje realEstate.ID
            //funkcja przyjmuje też pola RealEstate które użytkownik chce zmodyfikować
            //task 3
            String path = "..\\Files\\RealEstates.csv";
            string fullPath = DatabaseContext.bingPathToAppDir(path);
            string line;
            string lineToChange="";
            string s1 = String.Empty;

            using (StreamReader reader = new StreamReader(fullPath))
            {
               
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] columns = line.Split(";");
                        if (Convert.ToInt32(columns[0]) == id)
                        {
                          lineToChange = line; // this is  line to modify
                        }
                    }
            }


            
            if (String.IsNullOrEmpty(lineToChange) )
            {
                    Console.WriteLine("No RealEstate record in our database with this ID !");
                    Console.ReadLine();
                
            } 
            else
            {
                    string[] columnsToChange = lineToChange.Split(";");


                    if ((int)realEstate.typeOfRealEstate != 0)
                    {
                        int type = (int)realEstate.typeOfRealEstate;
                        columnsToChange[1] = type.ToString();
                    }


                    if (realEstate.Price != 0)
                    {
                        columnsToChange[2] = realEstate.Price.ToString();
                    }


                    if (realEstate.Area != 0)
                    {
                        columnsToChange[3] = realEstate.Area.ToString();
                    }

                    if (realEstate.RoomsAmount != 0)
                    {
                        columnsToChange[4] = realEstate.RoomsAmount.ToString();
                    }

                    if (!String.IsNullOrEmpty(realEstate.OwnerName))
                    {
                        columnsToChange[5] = realEstate.OwnerName;
                    }

                    if (!String.IsNullOrEmpty(realEstate.OwnerSurname))
                    {
                        columnsToChange[6] = realEstate.OwnerSurname;
                    }

                    if (!String.IsNullOrEmpty(realEstate.City))
                    {
                        columnsToChange[7] = realEstate.City;
                    }

                    if (!String.IsNullOrEmpty(realEstate.Street))
                    {
                        columnsToChange[8] = realEstate.Street;
                    }

                    if (!String.IsNullOrEmpty(realEstate.EstateAddress))
                    {
                        columnsToChange[9] = realEstate.EstateAddress;
                    }

                    
                    columnsToChange[11] = DateTime.Now.ToString();

                    s1 = string.Join(";", columnsToChange);
                
            }


            return s1;

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


        public static void  saveLine(int idOfLineToChange, string lineToSave)
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
                        if (idOfLineToChange == Convert.ToInt32(columns[0]))
                        {
                            writer.WriteLine(lineToSave);
                        }
                        else 
                        {
                            writer.WriteLine(line);
                        }
                    }

                }
            }

            sr.Close();
            File.Copy(DatabaseContext.bingPathToAppDir("..\\Files\\Temp.csv"), fullPath, true);
            Console.WriteLine("Edited record have been saved.");
            System.IO.File.WriteAllText(DatabaseContext.bingPathToAppDir("..\\Files\\Temp.csv"), string.Empty); //temp is clean
        }
    }
}
