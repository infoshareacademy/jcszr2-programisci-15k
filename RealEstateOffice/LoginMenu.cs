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
            Console.WriteLine("Podaj hasło");
            string password = Console.ReadLine();
            Console.Clear();
            int output = UserDatabaseContext.Login(login, password);

            if (output == 1)
            {
                Menu.MainMenu();
            }
            else
            {
                Console.WriteLine("Podałeś błędny login lub hasło");
            }


        }
    }
}