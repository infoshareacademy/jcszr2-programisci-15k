using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstateOffice
{
    class StartMenu
    {
       public static void BeginStartMenu()
        {

            

            bool ProgramRuns = true;

            //pierwszy ekran
            //1 - opcja zalogowania się
            //pyta się o login i hasło a potem weryfikuje z bazą użytkowników w backendzie
            while (ProgramRuns)
            {
                Console.Clear();
                Console.Title = "Start Menu";
                Console.WriteLine("Menu startowe");

                Console.WriteLine("1. Zaloguj się");
                Console.WriteLine("2. Zarejestruj się");
                Console.WriteLine("3. Wyjdź z aplikacji");


                if (int.TryParse(Console.ReadLine(), out var choice))
                {
                    switch (choice)
                    {
                        case 1:
                            Console.Clear();
                            LoginMenu.LoginUser();
                            break;
                        case 2:
                            Console.Clear();
                            NewUserMenu.AddUser();
                            break;
                        case 3:
                            //ProgramRuns = false;
                            break;
                    }
                }
            }

            //jeśli ktoś loguje się jako admin, to zostaje przekierowany do AdminMenu

            //2 - opcja stworzenia nowego profilu użytkownika
            //dodaje nowego użytkownika i dodaje nowy wpis w bazie użytkowników w backendzie
            //NewUserMenu.AddUser();

            //3 - opcja wyłączenia aplikacji
            //wtedy ProgramRuns = false;
        }
    }
}
