using System;
using System.Xml.Schema;

namespace RealEstateOffice
{
    class FilterMenu
    {
        public static void FilterOperationMenu()
        {
            var isFilterMenuRunning = true;
            var isFilterBeingMade = false;

            Filter filter = new Filter();

            while (isFilterMenuRunning)
            {
                Console.Clear();
                Console.WriteLine("Jakie nieruchomości chcesz wyświetlić?");
                Console.WriteLine();
                Console.WriteLine("1. Wyświetl wszystkie nieruchomości. (tu nic jeszcze nie ma)");
                Console.WriteLine("2. Filtruj nieruchomości przez kategorię.");
                Console.WriteLine("3. Filtruj nieruchomości przez właściciela.");
                Console.WriteLine("4. Filtruj nieruchomości przez miejscowość.");
                Console.WriteLine("5. Filtruj nieruchomości przez nazwę ulicy.");
                Console.WriteLine("6. Filtruj nieruchomości w danym zakresie cenowym.");
                Console.WriteLine("7. Filtruj nieruchomości w danym zakresie powierzchni.");
                Console.WriteLine("8. Filtruj nieruchomości których wpisy zostały dodane w danym zakresie czasu.");
                Console.WriteLine("9. Filtruj nieruchomości których wpisy zostały zmienione w danym zakresie czasu.");
                Console.WriteLine();
                if (isFilterBeingMade)
                {
                    Console.WriteLine("Obecne filtry:");
                    Console.WriteLine("---");
                    filter.ShowActiveFilters();
                    Console.WriteLine("---");
                    Console.WriteLine("10. Wyświetl tylko nieruchomości z aktywnymi filtrami. (tu nic jeszcze nie ma)");
                    Console.WriteLine("11. Porzuć obecne filtry.");
                }
                Console.WriteLine("0. Wróć do głównego menu.");

                if (int.TryParse(Console.ReadLine(), out var choice))
                {
                    switch (choice)
                    {
                        case 1:

                            Filter emptyFilter = new Filter();
                            DatabaseContext.RealEstatesFilter(emptyFilter);                            
                            //przekazujemy pusty nowo stworzony filtr do backendu jako argument funkcji
                            //backend zwraca właściwie dobraną listę obiektów RealEstate które Display() formatuje i tu wyświetla
                            break;
                        case 2:
                            LetUserSetEnum(filter);

                            isFilterBeingMade = true;
                            break;
                        case 3:
                            Console.WriteLine("Wpisz imię właściciela:");
                            filter.OwnerName = Console.ReadLine().Trim();
                            Console.WriteLine("Wpisz nazwisko właściciela:");
                            filter.OwnerSurname = Console.ReadLine().Trim();

                            isFilterBeingMade = true;
                            break;
                        case 4:
                            Console.WriteLine("Wpisz nazwę miejscowości:");
                            filter.City = Console.ReadLine().Trim();

                            isFilterBeingMade = true;
                            break;
                        case 5:
                            Console.WriteLine("Wpisz nazwę ulicy:");
                            filter.Street = Console.ReadLine().Trim();

                            isFilterBeingMade = true;
                            break;
                        case 6:
                            LetUserSetPriceSpan(filter);

                            isFilterBeingMade = true;
                            break;
                        case 7:
                            LetUserSetAreaSpan(filter);

                            isFilterBeingMade = true;
                            break;
                        case 8:
                            LetUserSetDateSpan(filter, true);

                            isFilterBeingMade = true;
                            break;
                        case 9:
                            LetUserSetDateSpan(filter, false);

                            isFilterBeingMade = true;
                            break;
                        case 10:
                            if (isFilterBeingMade)
                            {
                                DatabaseContext.RealEstatesFilter(filter);
                                //przekazujemy istniejący filtr do backendu jako argument funkcji
                                //pola nie wypełnione przez użytkownika (null) w obiekcie filter nie mają być brane pod uwagę
                                //backend zwraca właściwie dobraną listę obiektów RealEstate które Display() formatuje i tu wyświetla
                            }
                            break;
                        case 11:
                            if (isFilterBeingMade)
                            {
                                filter.FilterReset();
                                isFilterBeingMade = false;
                            }
                            break;
                        case 0:
                            isFilterMenuRunning = false;
                            break;
                        default:
                            break;
                    }
                }
            }
        }
        private static void LetUserSetEnum(Filter filter)
        {
            var isEnumSet = false;
            
            Console.WriteLine("Wpisz numer kategorii:");
            Console.WriteLine();
            Console.WriteLine("0 - Dom,");
            Console.WriteLine("1 - Mieszkanie,");
            Console.WriteLine("2 - Działka,");
            Console.WriteLine("3 - Garaż,");
            Console.WriteLine("4 - Lokal_usługowy");

            while (isEnumSet == false)
            {
                if (int.TryParse(Console.ReadLine(), out var realEstateTypeNumber) &&
                    Enum.IsDefined(typeof(RealEstate.TypeOfRealEstate), realEstateTypeNumber))
                {
                    filter.TypeOfRealEstate = (RealEstate.TypeOfRealEstate)realEstateTypeNumber;
                    isEnumSet = true;
                }
                else
                {
                    Console.WriteLine("Wpisz jedną z podanych wartości.");
                }
            }
        }
        private static void LetUserSetPriceSpan(Filter filter)
        {
            var priceLow = 0;
            var priceHigh = 0;

            Console.WriteLine("Minimalna cena żądanej nieruchomości (w PLN):");
            while (!int.TryParse(Console.ReadLine(), out priceLow) || (priceLow < 0))
            {
                Console.WriteLine("Wpisz poprawną liczbę.");
            }
            filter.PriceLowest = priceLow;

            Console.WriteLine("Maksymalna cena żądanej nieruchomości (w PLN):");
            while (!int.TryParse(Console.ReadLine(), out priceHigh) || (priceHigh <= priceLow))
            {
                Console.WriteLine("Wpisz poprawną liczbę.");
            }
            filter.PriceHighest = priceHigh;
        }
        private static void LetUserSetAreaSpan(Filter filter)
        {
            var areaSmall = 0;
            var areaBig = 0;

            Console.WriteLine("Minimalna powierzchnia żądanej nieruchomości (w m^2):");
            while (!int.TryParse(Console.ReadLine(), out areaSmall) || (areaSmall < 0))
            {
                Console.WriteLine("Wpisz poprawną liczbę.");
            }
            filter.AreaSmallest = areaSmall;

            Console.WriteLine("Maksymalna powierzchnia żądanej nieruchomości (w m^2):");
            while (!int.TryParse(Console.ReadLine(), out areaBig) || (areaBig <= areaSmall))
            {
                Console.WriteLine("Wpisz poprawną liczbę.");
            }
            filter.AreaBiggest = areaBig;
        }
        private static void LetUserSetDateSpan(Filter filter, bool isCreation)
        {
            DateTime dateEarliest;
            DateTime dateLatest;

            Console.WriteLine("Wpisz wcześniejszą datę w formacie dd/mm/yyyy:");
            while (!DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dateEarliest))
            {
                Console.WriteLine("Wpisz poprawną datę.");
            }

            if (isCreation)
            {
                filter.CreationDateEarliest = dateEarliest;
            }
            else
            {
                filter.ModificationDateEarliest = dateEarliest;
            }
            

            Console.WriteLine("Wpisz późniejszą datę w formacie dd/mm/yyyy:");
            while (!DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dateLatest)
                   || DateTime.Compare(dateEarliest, dateLatest) > 0)
            {
                Console.WriteLine("Wpisz poprawną datę.");
            }
            
            if (isCreation)
            {
                filter.CreationDateLatest = dateLatest;
            }
            else
            {
                filter.ModificationDateLatest = dateLatest;
            }
        }
    }
}