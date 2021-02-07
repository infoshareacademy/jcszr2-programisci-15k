using System;

namespace RealEstateOffice
{
    class Program
    {
        static void Main(string[] args)
        {
            //pojawia się StartMenu aby można było się zalogować i dalej robić rzeczy jako użytkownik odpowiedniego typu
            //FilterMenu.FilterOperationMenu();
            //AddMenu.AddOperationMenu(); 
            //Menu.MainMenu(); 
            //DatabaseContext.RemoveFromDatabase(15);
            Filter filter = new Filter();

            filter.NoType = 1;
            filter.TypeOfRealEstate = RealEstate.TypeOfRealEstate.Działka;
            filter.PriceLowest = 100000;
            filter.PriceHighest = 900000;
            filter.NoPrice = 1;
            filter.AreaSmallest = 20;
            filter.NoArea = 1;
            filter.AreaBiggest = 60;
            filter.City = "Gdańsk";
            filter.NoCity = 1;
            filter.OwnerSurname = "Marczak";
            filter.NoSurname = 1;
            filter.OwnerName = "Kinga";
            filter.NoName = 1;
            filter.Street = "Wielkpolska";
            filter.NoStreet = 1;
            


            DatabaseContext.RealEstateChoice(filter);
        }
    }
}
