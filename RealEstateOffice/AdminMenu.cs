using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstateOffice
{
    class AdminMenu
    {
        public static void AdminMainMenu()
        {
            //opcje zarządzania użytkownikami
            //tylko ADMIN
            //wyświetlanie wszystkich użytkowników
            //edycja użytkowników
            //dodawanie użytkowników
            //usuwanie użytkowników
            //opcja przeglądania logów systemowych
            //tylko ADMIN
            //opcja wylogowania się, powrót do StartMenu
            //wyloguj się
            //powrót do start menu

                bool menuRuns = true;

         
                while (menuRuns)
                {
                    Console.Clear();
                    Console.Title = "Menu administratora";
                    Console.WriteLine("Menu administracji użytkownikami");
                    Console.WriteLine("1. Pokaz wszystkich użytkownikow");
                    Console.WriteLine("2. Dodawanie użytkownika");
                    Console.WriteLine("3. Usuwanie użytkownika");
                    Console.WriteLine("4. Edytowanie użytkownika");
                    Console.WriteLine("5. Wyjdz");
                    int choice;
                    int.TryParse(Console.ReadLine(), out choice);
                        switch (choice)
                        {
                            case 1:
                                UsersView.ListOfUsers((UserDatabaseContext.ListOfUser()));
                                break;
                            case 2:
                                NewUserMenu.AddUser();
                                break;
                            case 3:
                                RemoveUserMenu.RemoveUser();
                                break;
                            case 4:
                                EditUserMenu.EditionOperationMenu();
                                break;
                            case 5:
                               menuRuns = false;
                               break;
                            default:
                                break;
                        }
                }   
        }
    }
}