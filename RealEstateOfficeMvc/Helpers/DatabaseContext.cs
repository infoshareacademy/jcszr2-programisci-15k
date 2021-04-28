using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using RealEstateOfficeMvc.Models;

namespace RealEstateOfficeMvc
{
    class DatabaseContext
    {
        public static List<Domain.RealEstate> RealEstatesFilter(Filter filter)
        {
           
            List<Domain.RealEstate> RealEstateList = new List<Domain.RealEstate>();

            using(var context = new RealEstateOfficeContext())
            {
                RealEstateList = context.RealEstates.ToList();
            }


            return RealEstateList;
        }


        public static Domain.RealEstate Get(int id)
        {

            using (var context = new RealEstateOfficeContext())
            {
                var realEstate = context.RealEstates.Single(x => x.Id == id);
                return realEstate;
            }
         
        }

        public static List<Domain.RealEstate> RealEstateChoice(Filter filter)   //List<RealEstate> 
        {
            List<Domain.RealEstate> realEstateList;
            List<Domain.RealEstate> filteredRealEstateList = new List<Domain.RealEstate>();
            realEstateList = RealEstatesFilter(filter);  //gets hole list of Real Estates

            for (var i = 0; i < realEstateList.Count; i++)
            {
                if (filter.TypeOfRealEstate != null &&
                    realEstateList[i].Typeofrealestate != (int)filter.TypeOfRealEstate)
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
                    (realEstateList[i].Roomamount < filter.RoomAmountSmallest))
                {
                    continue;
                }

                if (filter.RoomAmountBiggest != null &&
                    (realEstateList[i].Roomamount > filter.RoomAmountBiggest))
                {
                    continue;
                }

                if (!string.IsNullOrEmpty(filter.OwnerName) &&
                    realEstateList[i].Ownername != filter.OwnerName)
                {
                    continue;
                }

                if (!string.IsNullOrEmpty(filter.OwnerSurname) &&
                    realEstateList[i].Ownersurname != filter.OwnerSurname)
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
                    (DateTime.Compare(realEstateList[i].Creationdate, (DateTime)filter.CreationDateEarliest) < 0))
                {
                    continue;
                }

                if (filter.CreationDateLatest != null &&
                    (DateTime.Compare(realEstateList[i].Creationdate, (DateTime)filter.CreationDateLatest) > 0))
                {
                    continue;
                }

                filteredRealEstateList.Add(realEstateList[i]);
            }

            return filteredRealEstateList;

        }




        static string ParseTextLine(string Line, int column)
        {
            string[] columns = Line.Split(";");
            string output = columns[column];
            return output;
        }


        static int GetLastLineId(String lastLine)
        {
            string[] columns = lastLine.Split(";");
            var lastId = Convert.ToInt32(columns[0]);
            lastId = lastId + 1;
            return lastId;
        }




        public static void EditRecordInDatabase(RealEstate realEstate, int id)
        {

            //ID; TypeOfRealEstate; Price; Area; OwnerName; OwnerSurname; City; Street; EstateAddress; CreationDate; ModificationDate;
            //Data modyfikacji wpisu zostaje ustalona/nadpisana automatycznie
            //funkcja przyjmuje realEstate.ID
            //funkcja przyjmuje też pola RealEstate które użytkownik chce zmodyfikować
            //task 3

            string fullPath = Directory.GetCurrentDirectory() + "\\Files\\RealEstates.csv";
            string line;
            string lineToChange = "";
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



            if (String.IsNullOrEmpty(lineToChange))
            {
                Console.WriteLine("No RealEstate record in our database with this ID !");

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

            SaveLine(id, s1);
        }

      
        public void OpenFile()
        {

            String path = "..\\Files\\RealEstates.csv";
            string realativePath = bingPathToAppDir(path);

            using (FileStream fs = File.OpenRead(realativePath))
            {
                byte[] b = new byte[1024];
                UTF8Encoding temp = new UTF8Encoding(true);
                while (fs.Read(b, 0, b.Length) > 0)
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


        public static void SaveLine(int idOfLineToChange, string lineToSave)
        {
            string originalPath = Directory.GetCurrentDirectory() + "\\Files\\RealEstates.csv";
            string tempPath = Directory.GetCurrentDirectory() + "\\Files\\Temp.csv";
            StreamReader sr = new StreamReader(originalPath);


            using (StreamReader reader = new StreamReader(originalPath))
            {
                using (StreamWriter writer = new StreamWriter(tempPath))
                {
                    string line;
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
            File.Move(tempPath, originalPath, true);
        }
    }
}
