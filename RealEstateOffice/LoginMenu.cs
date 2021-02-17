using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstateOffice
{
    class LoginMenu
    {//pyta o login i hasło i przekazuje do metody Login w UserDatabaseContext - sprawdza czy jest login i hasło 
        public static void LoginUser()
        {
            Console.Title = "Login Menu!";
            Console.WriteLine("Podaj login");

            string login = Console.ReadLine();
            //Console.WriteLine("Podaj hasło");
            //string password = Console.ReadLine();
            string password = asteriskPass();
            Console.Clear();
            int output = UserDatabaseContext.Login(login, password);
            

            switch (output)
            {
                case 1:
                    var userSession = new UserSession(output, login);
                    AdminMenu.AdminMainMenu(userSession);
                    break;
                case 2:
                    var userSession2 = new UserSession(output, login);
                    Menu.MainMenu(userSession2);
                    break;
                case 3:
                    var userSession3 = new UserSession(output, login);
                    FilterMenu.FilterOperationMenu(userSession3);
                    break;
                default:
                    Console.WriteLine("Podałeś błędny login lub hasło");
                    break;
            }


        }

        public static string asteriskPass()
        {

            ConsoleKeyInfo key;
            Console.Write("Podaj hasło: ");
            StringBuilder sb = new StringBuilder();
            do
            {
                key = Console.ReadKey(true);
                sb.Append(key.KeyChar);
                Console.Write("*");

            } while (key.Key != ConsoleKey.Enter);
            Console.WriteLine();

            string pass= sb.ToString().Remove(sb.Length - 1, 1);

            return pass;

        }




    }
}