using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Http;
using RealEstateOfficeMvc.Helpers;

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

        
        //metoda do edycji uzytkowników
       

        //login
        public static int Login(string login,string password,int usertypeorid)
        {

            List<RealEstateOfficeMvc.Models.User> userList = new List<RealEstateOfficeMvc.Models.User>();
            userList = UserDatabaseContext.ListOfUser();

            password = codePassword(password);
            var userToLog = (from x in userList where x.Login ==login && x.Password == password select x).SingleOrDefault<RealEstateOfficeMvc.Models.User>(); //codePassword(password)
            int userid = userToLog.Id;
            int output = 0;

            switch (usertypeorid)
            {
                case 1:
                    if (userToLog == null)
                    {
                        output = 0;
                    }
                    else
                    {
                        int typUser = (int)userToLog.TypeOfUserType;
                        output = typUser;
                    };
                    break;
                    
                case 2:
                    output = userid;
                    break;
                default:
                    
                 break;
            }

            return output;

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
            String path = "\\Files\\Users.csv";
            string testpath = Directory.GetCurrentDirectory();
            string fullPath = testpath + path;  // fullpath

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
            System.IO.File.WriteAllText(DatabaseContext.bingPathToAppDir("..\\Files\\Temp.csv"), string.Empty); //temp is clean
            
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
