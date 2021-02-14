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

            switch (output)
            {
                case 1:
                    AdminMenu.AdminMainMenu();
                    break;
                case 2:
                    Menu.MainMenu();
                    break;
                case 3:
                    FilterMenu.FilterOperationMenu();
                    break;
                default:
                    Console.WriteLine("Podałeś błędny login lub hasło");
                    break;
            }


        }
    }
}