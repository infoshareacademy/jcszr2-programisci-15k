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
                    RealEstateList.Add(new RealEstate(Convert.ToInt32(ParseTextLine(line, 0)), Convert.ToInt32(ParseTextLine(line, 1)), System.Convert.ToDecimal(ParseTextLine(line, 2)), Convert.ToInt32(ParseTextLine(line, 3)), Convert.ToInt32(ParseTextLine(line, 4)), ParseTextLine(line, 5), ParseTextLine(line, 6), ParseTextLine(line, 7), ParseTextLine(line, 8), ParseTextLine(line, 9)));
                  
                }
            }
            return RealEstateList;
        }


        public static List<RealEstate> RealEstateChoice(Filter filter)   //List<RealEstate> 
        {
            Filter emptyFilter = new Filter();
            List<RealEstate> allRealEstateList = new List<RealEstate>();
            List<RealEstate> filteredRealEstateList = new List<RealEstate>();
            allRealEstateList = DatabaseContext.RealEstatesFilter(emptyFilter);  //gets hole list of Real Estates
                        
            foreach (var realEstate in from realEstate in allRealEstateList
                                       where ((filter.PriceLowest != null && filter.PriceHighest != null) && (realEstate.Price > filter.PriceLowest && realEstate.Price < filter.PriceHighest))
                                         &&  ((filter.AreaSmallest != null   && filter.AreaBiggest != null)  && realEstate.Area > filter.AreaSmallest && realEstate.Area < filter.AreaBiggest )
                                         &&  ((filter.RoomAmountSmallest != null && filter.RoomAmountBiggest != null) && realEstate.RoomsAmount > filter.RoomAmountSmallest && realEstate.RoomsAmount < filter.RoomAmountBiggest)
                                         &&  (!string.IsNullOrEmpty(filter.City) &&  realEstate.City == filter.City  )
                                         &&  (!string.IsNullOrEmpty(filter.OwnerSurname) &&  realEstate.OwnerSurname == filter.OwnerSurname  )
                                         &&  (!string.IsNullOrEmpty(filter.Street) &&  realEstate.Street == filter.Street )
                                         &&  (!string.IsNullOrEmpty(filter.OwnerName) && realEstate.OwnerName == filter.OwnerName )
                                         &&  filter.TypeOfRealEstate != null && realEstate.typeOfRealEstate == filter.TypeOfRealEstate

                                       select new { realEstate.Id, realEstate.typeOfRealEstate, realEstate.Price, realEstate.Area, realEstate.RoomsAmount, realEstate.OwnerName, realEstate.OwnerSurname, realEstate.City, realEstate.Street, realEstate.EstateAddress })

            {
                filteredRealEstateList.Add(new RealEstate(Convert.ToInt32(realEstate.Id), Convert.ToInt32(realEstate.typeOfRealEstate), System.Convert.ToDecimal(realEstate.Price), Convert.ToInt32(realEstate.Area), Convert.ToInt32(realEstate.RoomsAmount), realEstate.OwnerName, realEstate.OwnerSurname, realEstate.City, realEstate.Street, realEstate.EstateAddress));
                Console.WriteLine($"{realEstate.Id} {realEstate.typeOfRealEstate} {realEstate.Price} {realEstate.Area} {realEstate.RoomsAmount} {realEstate.OwnerName} {realEstate.OwnerSurname} {realEstate.City} {realEstate.Street} {realEstate.EstateAddress} ");
            }

            Console.ReadLine();
            return filteredRealEstateList;
     
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

            realEstate.CreationDate = DateTime.Today;
            realEstate.ModificationDate = DateTime.Today;
            string creationDateString;
            string modificationDateString;


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
            sb.Append(creationDateString = realEstate.CreationDate.ToShortDateString());
            sb.Append(";");
            sb.Append(modificationDateString = realEstate.ModificationDate.ToShortDateString());
            sb.Append(";");



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


        
        public static void RemoveFromDatabase(int LineToDelete)
            {
            //funkcja przyjmuje realEstate.ID
            //
            //sprawdzenie czy wpis z takim ID istnieje, jeśli tak to
            //przekazanie do frontendu potwierdzenia że wpis został usunięty
            //task 3

            String path = "..\\Files\\RealEstates.csv";
            string fullPath = DatabaseContext.bingPathToAppDir(path);
            StreamReader sr = new StreamReader(fullPath);
            string line;
            int linesDeleted = 0;
            

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
                        else
                        {
                            linesDeleted++;
                        }

                    }
                                    
                }
            }
            sr.Close();

            Console.WriteLine("Records deleted" +" : "+ linesDeleted);
            File.Copy(DatabaseContext.bingPathToAppDir("..\\Files\\Temp.csv"), fullPath,true);
            System.IO.File.WriteAllText(DatabaseContext.bingPathToAppDir("..\\Files\\Temp.csv"), string.Empty); //temp is clean

        }

                

        public static string EditRecordInDatabase(RealEstate realEstate,int id)
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

                    if (!String.IsNullOrEmpty(realEstate.OwnerName))
                    {
                        columnsToChange[4] = realEstate.OwnerName;
                    }

                    if (!String.IsNullOrEmpty(realEstate.OwnerSurname))
                    {
                        columnsToChange[5] = realEstate.OwnerSurname;
                    }

                    if (!String.IsNullOrEmpty(realEstate.City))
                    {
                        columnsToChange[6] = realEstate.City;
                    }

                    if (!String.IsNullOrEmpty(realEstate.Street))
                    {
                        columnsToChange[7] = realEstate.Street;
                    }

                    if (!String.IsNullOrEmpty(realEstate.EstateAddress))
                    {
                        columnsToChange[8] = realEstate.EstateAddress;
                    }

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
