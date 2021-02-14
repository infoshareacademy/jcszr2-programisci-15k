using System;
using System.Collections.Generic;
using System.Text;


namespace RealEstateOffice
    {
        class NewUserMenu
        {
            //ID; Login; Password; Name; Surname; EmailAddress; UserType;
            //Odpytujemy uzytkownika  o  to jakie chce miec login , hasło , jego imie i nazwisko , typUzytkownika itp

            public static void AddUser()
            {
                Console.Title = "User - Add Menu";

                User user = new User();
                Console.WriteLine("Aby dodać nowego użytkownika wypełnij wszystkie pola:");
                Console.WriteLine();
                SetUserAcountEnum(user);

                

                Console.WriteLine("1. Podaj login użytkownika");
                user.Login = SetStringFromConsole();
                Console.WriteLine("2. Podaj hasło użytkownika");
                user.Password = SetStringFromConsole();
                Console.WriteLine("3. Podaj imię użytkownika");
                user.Name = SetStringFromConsole();
                Console.WriteLine("4. Podaj nazwisko użytkownika");
                user.Surname = SetStringFromConsole();
                Console.WriteLine("5. Podaj email użytkownika");
                user.EmailAddress = SetStringFromConsole();

                UserDatabaseContext.AddToDatabase(user);
            }

            private static void SetUserAcountEnum(User user)
            {
                var providedValidAccountType = false;

                Console.WriteLine("Podaj typ konta:");
                Console.WriteLine();
                Console.WriteLine("1 - Administrator,");
                Console.WriteLine("2 - Pracownik biura nieruchomści,");
                Console.WriteLine("3 - Klient");
                Console.WriteLine();

                while (!providedValidAccountType)
                {
                    if (int.TryParse(Console.ReadLine(), out var acountTypeNumber) &&
                        Enum.IsDefined(typeof(User.UserType), acountTypeNumber))
                    {
                        user.TypeOfUserType = (User.UserType)acountTypeNumber;
                        providedValidAccountType = true;
                    }

                    else
                    {
                        Console.WriteLine("Wpisz jedną z podanych wartości.");
                    }
                }
            }



            public static string SetStringFromConsole()
            {
                string input;

                while (true)
                {
                    input = Console.ReadLine().Trim();
                    if (input == String.Empty)
                    {
                        Console.WriteLine("Wpisz właściwą wartość.");
                    }
                    else
                    {
                        return input;
                    }
                }
            }

        }
    }


