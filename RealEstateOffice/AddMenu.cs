using System;

namespace RealEstateOffice
{
    class AddMenu
    {
        public static void AddOperationMenu()
        {
            Console.Title = "RealEstate - Add Menu";

            RealEstate realEstate = new RealEstate();

            Console.WriteLine("Aby dodać nowy wpis do bazy danych, wypełnij wszystkie pola.");
            Console.WriteLine();

            UserSetEnum(realEstate);
            UserSetPrice(realEstate);
            UserSetArea(realEstate);
            UserSetRoomsAmount(realEstate);
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
        }




        public static void UserSetEnum(RealEstate realEstate)
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

        public static void UserSetPrice(RealEstate realEstate)
        {
            var price = 0.0m;

            Console.WriteLine("Wpisz cenę dodawanej nieruchomości (w PLN):");
            while (!decimal.TryParse(Console.ReadLine(), out price) || (price < 0))
            {
                Console.WriteLine("Wpisz poprawną liczbę.");
            }

            realEstate.Price = price;
        }

        public static void UserSetArea(RealEstate realEstate)
        {
            var area = 0;

            Console.WriteLine("Wpisz powierzchnię dodawanej nieruchomości (w m^2):");
            while (!int.TryParse(Console.ReadLine(), out area) || (area < 0))
            {
                Console.WriteLine("Wpisz poprawną liczbę.");
            }
            realEstate.Area = area;
        }

        public static void UserSetRoomsAmount(RealEstate realEstate)
        {
            if (realEstate.typeOfRealEstate == RealEstate.TypeOfRealEstate.Dom ||
                realEstate.typeOfRealEstate == RealEstate.TypeOfRealEstate.Mieszkanie)
            {
                int roomsAmount;
                Console.WriteLine("Wpisz liczbę pokoi:");
                while (!int.TryParse(Console.ReadLine(), out roomsAmount) && roomsAmount < 0)
                {
                    Console.WriteLine("Wpisz właściwą liczbę.");
                }
                realEstate.RoomsAmount = roomsAmount;
            }
            else
            {
                realEstate.RoomsAmount = 0;
            }
        }
    }
}