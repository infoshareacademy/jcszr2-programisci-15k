using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace RealEstateOffice
{
    class UserDatabaseContext
    {
        //metoda  która  pobierze  wszystkich uzytkowników
        //ListOfUsers();

        //public static void ListOfUsers(List<User> user)
        //{

        //}
       
        public static void AddToDatabase(User user)
        {
            String path = "..\\Files\\Users.csv";
            string relativePath = UserDatabaseContext.bingPathToAppDir(path);

            // pobieram ID z ostatniej linijki w users.csv
            var lastLine = File.ReadLines(relativePath).Last();
            string[] columns = lastLine.Split(";");
            var lastId = Convert.ToInt32(columns[0]);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("");
            sb.Append(lastId + 1); //Id = lastId + 1
            sb.Append(";");
            sb.Append(user.Login);
            sb.Append(";");
            sb.Append(user.Password);
            sb.Append(";");
            sb.Append(user.Name);
            sb.Append(";");
            sb.Append(user.Surname);
            sb.Append(";");
            sb.Append(user.EmailAddress);
            sb.Append(";");
            sb.Append(user.TypeOfUserType.ToString());
            sb.Append(";");


            using (StreamWriter sw = File.AppendText(relativePath))
            {
                sw.Write(sb);
            }

            Console.Clear();
            Console.WriteLine("Record added to database. Press any key.");
            Console.ReadLine();

        }

        //metoda do dodawania uzytkowników
        //AddUser()
        //metoda do uswania 
        //RemoveUser();
        //metoda do edycji uzytkowników
        //EditUser();
        //login
        //Login();

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


        public static string bingPathToAppDir(string localPath)
        {
            string currentDir = Environment.CurrentDirectory;
            DirectoryInfo directory = new DirectoryInfo(
                Path.GetFullPath(Path.Combine(currentDir, @"..\..\" + localPath)));
            return directory.ToString();
        }


    }
}
