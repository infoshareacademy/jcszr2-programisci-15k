using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstateOffice
{
    class StartMenu
    {
       public static void BeginStartMenu()
        {
            //pierwszy ekran
            //1 - opcja zalogowania się
            //pyta się o login i hasło a potem weryfikuje z bazą użytkowników w backendzie

            //jeśli ktoś loguje się jako admin, to zostaje przekierowany do AdminMenu

            //2 - opcja stworzenia nowego profilu użytkownika
            //dodaje nowego użytkownika i dodaje nowy wpis w bazie użytkowników w backendzie
            NewUserMenu.AddUser();
        }
    }
}
