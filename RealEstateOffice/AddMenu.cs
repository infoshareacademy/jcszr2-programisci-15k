using System;

namespace RealEstateOffice
{
    class AddMenu
    {
        public static void AddOperationMenu()
        {
            RealEstate realEstate = new RealEstate();

            Console.WriteLine("Aby dodać nowy wpis do bazy danych, wypełnij wszystkie pola.");
            Console.WriteLine();

            UserSetEnum(realEstate);
            UserSetPriceAndArea(realEstate);
            Console.WriteLine("Wpisz imię właściciela:");
            realEstate.OwnerName = FilterMenu.SetStringFromConsole();
            Console.WriteLine("Wpisz nazwisko właściciela:");
            realEstate.OwnerSurname = FilterMenu.SetStringFromConsole();
            Console.WriteLine("Wpisz nazwę miejscowości:");
            realEstate.City = FilterMenu.SetStringFromConsole();
            Console.WriteLine("Wpisz nazwę ulicy:");
            realEstate.Street = FilterMenu.SetStringFromConsole();
            Console.WriteLine("Wpisz nr domu, mieszkania:");
            realEstate.EstateAddress = FilterMenu.SetStringFromConsole();

            DatabaseContext.AddToDatabase(realEstate);
           
            //jakieś potwierdzenie trzeba napisać, np zwrócić z backendu ID wpisu
            //koniec funkcji
            //task 6



            //Pytania o pola po kolei (TypeOfRealEstate; Price; Area; OwnerName; OwnerSurname; City; Street; EstateAddress;)
            //Console.WriteLine("Podaj typ nieruchomości");
            //Console.ReadLine();
            //Console.WriteLine("Podaj cenę nieruchomości");
            //Console.ReadLine();
            //Console.WriteLine("Podaj powierzchnię nieruchomości");
            //Console.ReadLine();
            //Console.WriteLine("Podaj imię właściciela nieruchomości");
            //Console.ReadLine();
            //Console.WriteLine("Podaj nazwisko właściciela nieruchomości");
            //Console.ReadLine();
            //Console.WriteLine("Podaj miasto");
            //Console.ReadLine();
            //Console.WriteLine("Podaj ulicę");
            //Console.ReadLine();
            //Console.WriteLine("Podaj numer posesji");
            //Console.ReadLine();

            //wszystkie te właściwości zapisujemy do klasy RealEstate
        }




        private static void UserSetEnum(RealEstate realEstate)
        {
            var isEnumSet = false;

            Console.WriteLine("Podaj typ nieruchomości:");
            Console.WriteLine();
            Console.WriteLine("0 - Dom,");
            Console.WriteLine("1 - Mieszkanie,");
            Console.WriteLine("2 - Działka,");
            Console.WriteLine("3 - Garaż,");
            Console.WriteLine("4 - Lokal_usługowy");
            Console.WriteLine();

            while (!isEnumSet)
            {
                if (int.TryParse(Console.ReadLine(), out var realEstateTypeNumber) &&
                    Enum.IsDefined(typeof(RealEstate.TypeOfRealEstate), realEstateTypeNumber))
                {
                    realEstate.typeOfRealEstate = (RealEstate.TypeOfRealEstate)realEstateTypeNumber;
                    isEnumSet = true;
                }
                else
                {
                    Console.WriteLine("Wpisz jedną z podanych wartości.");
                }
            }
        }
        private static void UserSetPriceAndArea(RealEstate realEstate)
        {
            var price = 0.0m;
            var area = 0;
            
            Console.WriteLine("Wpisz cenę dodawanej nieruchomości (w PLN):");
            while (!decimal.TryParse(Console.ReadLine(), out price) || (price < 0))
            {
                Console.WriteLine("Wpisz poprawną liczbę.");
            }
            realEstate.Price = price;

            Console.WriteLine("Wpisz powierzchnię dodawanej nieruchomości (w m^2):");
            while (!int.TryParse(Console.ReadLine(), out area) || (area < 0))
            {
                Console.WriteLine("Wpisz poprawną liczbę.");
            }
            realEstate.Area = area;
        }
    }
}