using System;

namespace RealEstateOffice
{
    class EditionMenu
    {

        public static void EditionOperationMenu()
        {
            var isEditionMenuRunning = true;

            Console.WriteLine("Podaj numer ID wpisu który chcesz edytować:");
            while (isEditionMenuRunning)
            {
                if (int.TryParse(Console.ReadLine(), out var choice))
                {
                    //todo:
                    //tutaj przekazywane jest ID do backendu który zwraca pojedynczy obiekt RealEstate o właściwym ID
                    //jeśli nie ma wpisu o takim ID ma być zwracana o tym informacja
                    //jeśli obiekt został zwrócony jest on tutaj wyświetlany
                    //tu zwrócony z backendu opbiekt RealEstate może być zmieniany, ale roboczo jest tu tworzony nowy obiekt realestate
                    var realEstate = new RealEstate();
                    while (isEditionMenuRunning)
                    {
                        Console.Clear();
                        Console.WriteLine("Które pole chcesz zmienić?");
                        Console.WriteLine();
                        Console.WriteLine("1. Kategorię nieruchomości.");
                        Console.WriteLine("2. Imię i nazwisko właściciela.");
                        Console.WriteLine("3. Miejscowość.");
                        Console.WriteLine("4. Nazwę ulicy.");
                        Console.WriteLine("5. Adres.");
                        Console.WriteLine("6. Cenę.");
                        Console.WriteLine("7. Powierzchnię.");
                        Console.WriteLine("8. Zatwierdź zmiany.");
                        Console.WriteLine();
                        Console.WriteLine("0. Wróć do głównego menu.");

                        //tu powinien się wyświetlać bieżący stan obiektu realestate
                        if (int.TryParse(Console.ReadLine(), out var editchoice))
                        {
                            switch (editchoice)
                            {
                                case 1:
                                    AddMenu.UserSetEnum(realEstate);
                                    break;
                                case 2:
                                    Console.WriteLine("Wpisz imię właściciela:");
                                    realEstate.OwnerName = FilterMenu.SetStringFromConsole();
                                    Console.WriteLine("Wpisz nazwisko właściciela:");
                                    realEstate.OwnerSurname = FilterMenu.SetStringFromConsole();
                                    break;
                                case 3:
                                    Console.WriteLine("Wpisz nazwę miejscowości:");
                                    realEstate.City = FilterMenu.SetStringFromConsole();
                                    break;
                                case 4:
                                    Console.WriteLine("Wpisz nazwę ulicy:");
                                    realEstate.Street = FilterMenu.SetStringFromConsole();
                                    break;
                                case 5:
                                    Console.WriteLine("Wpisz nr domu, mieszkania:");
                                    realEstate.EstateAddress = FilterMenu.SetStringFromConsole();
                                    break;
                                case 6:
                                    AddMenu.UserSetPrice(realEstate);
                                    break;
                                case 7:
                                    AddMenu.UserSetArea(realEstate);
                                    break;
                                case 8:
                                    //todo:
                                    //tu obiekt realestate jest przekazywany do backendu który nadpisuje wpis w bazie danych
                                    //jakieś potwierdzenie pomyślnego wprowadzenia zmian powinno się wyświetlić

                                    string changedLine = DatabaseContext.EditRecordInDatabase(realEstate,choice);  ///realEstate.Id  nie jest zczytane
                                    if (!String.IsNullOrEmpty(changedLine))
                                    { 
                                        DatabaseContext.saveLine(choice, changedLine);
                                    }
                                    
                                   
                                    isEditionMenuRunning = false;
                                    break;
                                case 0:
                                    isEditionMenuRunning = false;
                                    break;
                                default:
                                    break;

                            }
                        }
                        else
                        {
                            Console.WriteLine("Wpisz właściwą wartość.");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Wpisz właściwą wartość.");
                }
            }


            //task 7
            //Pytanie do użytkownika jaki wpis chce edytować (pytanie o ID)
            //Pytanie do użytkownika jakie pola chce edytować, po czym pobrać te wartości
            //Przekazać te pola i ID do odpowiedniej metody z backendu

            //Console.WriteLine("Podaj ID nieruchomości, którą chcesz edytować");
            //Console.ReadLine();
        }
    }
}