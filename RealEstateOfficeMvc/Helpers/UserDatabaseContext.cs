﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace RealEstateOfficeMvc
{
    class UserDatabaseContext
    {
        //metoda  która  pobierze  wszystkich uzytkowników
        public static List<RealEstateOfficeMvc.Models.User> ListOfUser()
        {
            String path = "\\Files\\Users.csv";
            // pobieram ID z ostatniej linijki w users.csv
            string testpath = Directory.GetCurrentDirectory();
            string relativePath = testpath + path;  // fullpath
            var lastLine = File.ReadLines(relativePath).Last();

            List<RealEstateOfficeMvc.Models.User> UserList = new List<RealEstateOfficeMvc.Models.User>();

            using (StreamReader reader = new StreamReader(relativePath))
            {
                string line;

                while ((line = reader.ReadLine()) != null)
                {
                    // ID; Login; Password; Name; Surname; EmailAddress; UserType;
                    UserList.Add(new RealEstateOfficeMvc.Models.User(Convert.ToInt32(ParseTextLine(line, 0)), ParseTextLine(line,1), ParseTextLine(line, 2), ParseTextLine(line, 3), ParseTextLine(line, 4), ParseTextLine(line, 5), Convert.ToInt32(ParseTextLine(line, 6))));

                }
            }
            return UserList;

        }
       

        //metoda do dodawania uzytkowników
        public static void AddToDatabase(RealEstateOfficeMvc.Models.User user)
        {
            String path = "\\Files\\Users.csv";
            // pobieram ID z ostatniej linijki w users.csv
            string testpath = Directory.GetCurrentDirectory();
            string relativePath = testpath + path;  // fullpath
            var lastLine = File.ReadLines(relativePath).Last();

            string[] columns = lastLine.Split(";");
            var lastId = Convert.ToInt32(columns[0]);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("");
            sb.Append(lastId + 1); //Id = lastId + 1
            sb.Append(";");
            sb.Append(user.Login); 
            sb.Append(";");
            sb.Append(codePassword(user.Password)); 
            sb.Append(";");
            sb.Append(user.Name);
            sb.Append(";");
            sb.Append(user.Surname);
            sb.Append(";");
            sb.Append(user.EmailAddress);
            sb.Append(";");
            sb.Append((int)user.TypeOfUserType);
            sb.Append(";");
            
            using (StreamWriter sw = File.AppendText(relativePath))
            {
                sw.Write(sb);
            }
        }
                
        //metoda do uswania 
       



        //metoda do edycji uzytkowników
        public static string EditUser(RealEstateOfficeMvc.Models.User user, int id)
        {
            
            String path = "..\\Files\\Users.csv";
            string fullPath = DatabaseContext.bingPathToAppDir(path);
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
                Console.WriteLine("No User record in our database with this ID !");
                Console.ReadLine();

            }
            else
            {
                string[] columnsToChange = lineToChange.Split(";");
                //ID; Login; Password; Name; Surname; EmailAddress; UserType;

                if (!String.IsNullOrEmpty(user.Login) )
                {
                    columnsToChange[1] = user.Login;
                }

                if (!String.IsNullOrEmpty(user.Password))
                {
                    columnsToChange[2] = user.Password;
                }

                if (!String.IsNullOrEmpty(user.Name))
                {
                    columnsToChange[3] = user.Name;
                }

                if (!String.IsNullOrEmpty(user.Surname))
                {
                    columnsToChange[4] = user.Surname;
                }

                if (!String.IsNullOrEmpty(user.EmailAddress))
                {
                    columnsToChange[5] = user.EmailAddress;
                }

                if ((int)user.TypeOfUserType != 0)
                {
                    int type = (int)user.TypeOfUserType;
                    columnsToChange[6] = type.ToString();
                }


                s1 = string.Join(";", columnsToChange);

            }


            return s1;

        }


        //login
        public static int Login(string login,string password)
        {

            List<RealEstateOfficeMvc.Models.User> userList = new List<RealEstateOfficeMvc.Models.User>();
            userList = UserDatabaseContext.ListOfUser();

            password = codePassword(password);
            var userToLog = (from x in userList where x.Login ==login && x.Password == password select x).SingleOrDefault<RealEstateOfficeMvc.Models.User>(); //codePassword(password)

            
            if (userToLog ==null)
            {
                return 0;
            } else
            {
                int typUser = (int)userToLog.TypeOfUserType;
                return typUser;
            }
          
        }
      

        public void OpenFile()
        {

            String path = "..\\Files\\Users.csv";
            string realativePath = UserDatabaseContext.bingPathToAppDir(path);

            using (System.IO.FileStream fs = File.OpenRead(realativePath))
            {
                byte[] b = new byte[1024];
                UTF8Encoding temp = new UTF8Encoding(true);
                while (fs.Read(b, 0, b.Length) > 0)
                {
                    Console.WriteLine(temp.GetString(b));
                }
            }
        }

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

        public static void saveLine(int idOfLineToChange, string lineToSave)
        {
            String path = "..\\Files\\Users.csv";
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
            Console.Clear();
            Console.WriteLine("Edited record have been saved.");
            System.IO.File.WriteAllText(DatabaseContext.bingPathToAppDir("..\\Files\\Temp.csv"), string.Empty); //temp is clean
            Console.ReadLine();
        }


        public static string  codePassword(string pass)
        {

            string hash;
            using (SHA256 sha256Hash = SHA256.Create())
            {
                //From String to byte array
                byte[] sourceBytes = Encoding.UTF8.GetBytes(pass);
                byte[] hashBytes = sha256Hash.ComputeHash(sourceBytes);
                hash = BitConverter.ToString(hashBytes).Replace("-", String.Empty);
            }
            return hash;
        }


    }
}
