using System;
using System.Collections.Generic;
using System.Text;
using static RealEstateOffice.User;

namespace RealEstateOffice
{
    class EditUserMenu
    {//pyta użytkownika o pola, które chce edytować, wywołuje z UserDataBaseContext metodę EditUser
        public static void EditionOperationMenu()
        {
            Console.WriteLine("Podaj numer ID wpisu który chcesz edytować:");
            int id = GetChoice(0, 10000000);

            var user = UserDatabaseContext.ListOfUser().Find(user => user.Id == id);
            Edit(user);



        }

        private static void Edit(User user)
        {
            int choice = -1;
            while (choice != 0)
            {
                Console.Clear();
                Console.WriteLine("Które pole chcesz zmienić?");
                Console.WriteLine();
                Console.WriteLine("1. Login");
                Console.WriteLine("2. Hasło");
                Console.WriteLine("3. Imie");
                Console.WriteLine("4. Nazwisko");
                Console.WriteLine("5. Typ konta");
                Console.WriteLine();
                Console.WriteLine("0. Wróć do głównego menu.");
                choice = GetChoice(0, 6);
                switch (choice)
                {
                    case 1:
                        user.Login = ReadString("login");
                        FinishEdition(user);
                        break;
                    case 2:
                        user.Password = ReadString("hasło");
                        FinishEdition(user);
                        break;

                    case 3:
                        user.Name = ReadString("imię");
                        FinishEdition(user);
                        break;
                    case 4:
                        user.Surname = ReadString("nazwisko");
                        FinishEdition(user);
                        break;
                    case 5:
                        user.TypeOfUserType = ReadTypeUser();
                        FinishEdition(user);
                        break;
                }

            }
         }

        public static void FinishEdition(User user)
        {
            string changedLine = UserDatabaseContext.EditUser(user, user.Id);
            if (!String.IsNullOrEmpty(changedLine))
            {
                UserDatabaseContext.saveLine(user.Id, changedLine);
            }
        }



        private static string ReadString(string text)
        {
            Console.Write("Wpisz " + text + ":");
            return Console.ReadLine();
        }

        private static int GetChoice(int min, int max)
        {
            int choice = 0;
            bool choiceCorrect = false;
            while (!choiceCorrect)
            {
                Console.Write("Wybór: ");
                choiceCorrect = int.TryParse(Console.ReadLine(), out choice);
                if (choiceCorrect && (choice < min || max < choice))
                {
                    choiceCorrect = false;
                }

                if (!choiceCorrect)
                {
                    Console.WriteLine("Wpisz właściwą wartość.");
                }
            }
            return choice;
        }

        private static UserType ReadTypeUser()
        {
            Console.WriteLine("Wpisz typ użytkownika:");
            Console.WriteLine("1 - Administrator");
            Console.WriteLine("2 - Pracownik Biura Nieruchomości");
            Console.WriteLine("3 - Klient");
            switch (GetChoice(1, 3))
            {
                case 1: return UserType.Administrator;
                case 2: return UserType.Klient;
                case 3: return UserType.Klient;
            }
            return UserType.Klient;//tu nigdy nie wejdzie

        }
    }



    }
    

