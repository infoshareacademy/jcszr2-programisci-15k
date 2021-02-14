using System;

namespace RealEstateOffice
{
    class EditionMenu
    {

        public static void EditionOperationMenu()
        {
            var isEditionMenuRunning = true;

            Console.Title = "RealEstate - Edit Menu";

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
                        Console.WriteLine("2. Cenę.");
                        Console.WriteLine("3. Powierzchnię.");
                        Console.WriteLine("4. Liczbę pokoi.");
                        Console.WriteLine("5. Imię i nazwisko właściciela.");
                        Console.WriteLine("6. Miejscowość.");
                        Console.WriteLine("7. Nazwę ulicy.");
                        Console.WriteLine("8. Adres.");
                        Console.WriteLine("9. Zatwierdź zmiany.");
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
                                    AddMenu.UserSetPrice(realEstate);
                                    break;
                                case 3:
                                    AddMenu.UserSetArea(realEstate);
                                    break;
                                case 4:
                                    AddMenu.UserSetRoomsAmount(realEstate);
                                    break;
                                case 5:
                                    Console.WriteLine("Wpisz imię właściciela:");
                                    realEstate.OwnerName = FilterMenu.SetStringFromConsole();
                                    Console.WriteLine("Wpisz nazwisko właściciela:");
                                    realEstate.OwnerSurname = FilterMenu.SetStringFromConsole();
                                    break;
                                case 6:
                                    Console.WriteLine("Wpisz nazwę miejscowości:");
                                    realEstate.City = FilterMenu.SetStringFromConsole();
                                    break;
                                case 7:
                                    Console.WriteLine("Wpisz nazwę ulicy:");
                                    realEstate.Street = FilterMenu.SetStringFromConsole();
                                    break;
                                case 8:
                                    Console.WriteLine("Wpisz nr domu, mieszkania:");
                                    realEstate.EstateAddress = FilterMenu.SetStringFromConsole();
                                    break;
                                case 9:
                                    string changedLine = DatabaseContext.EditRecordInDatabase(realEstate,choice);
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
        }
    }
}