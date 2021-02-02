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
        //metoda do uswania 
        //RemoveUser();
        //metoda do edycji uzytkowników
        //EditUser();

        //metoda do dodawania uzytkowników
        public static void AddUser(User user)
        {
            //ID; Login; Password; Name; Surname; EmailAddress; UserType;
            String path = "..\\Files\\Users.csv";
            string realativePath = DatabaseContext.bingPathToAppDir(path);

            var lastLine = File.ReadLines(realativePath).Last(); // z tego wyciągam  ID 
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("");
            sb.Append(lastLine); //Id
            sb.Append(";");
            sb.Append(user.Login);
            sb.Append(";");
            sb.Append(user.Password);
            sb.Append(";");
            sb.Append(user.Name);
            sb.Append(";");
            sb.Append(user.Surname);
            sb.Append(";");
            sb.Append((int)user.UserType);
     
            using (StreamWriter sw = File.AppendText(realativePath))
            {
                sw.Write(sb);

            }

            Console.Clear();
            Console.WriteLine("User record added to database.Press any key");
            Console.ReadLine();

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
