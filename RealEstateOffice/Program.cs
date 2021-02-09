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
            //NewUserMenu.AddUser();

            //test metody  Login
            //int test =UserDatabaseContext.Login("m.ruszczyk", "haslo");
            //Console.WriteLine(test);
            //Console.ReadLine();
            //Menu.MainMenu(); 
            LoginMenu.LoginUser();
            //DatabaseContext.RemoveFromDatabase(15);
            
        }
    }
}
