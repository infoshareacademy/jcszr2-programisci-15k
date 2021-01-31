using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstateOffice
{
    public class Menu
    {
        public void MainMenu()
        {
            //Zależnie od typu zalogowanego użytkownika zmienia się ilość opcji

            //Tutaj ma być console.writeline z wyjaśnieniem jakie użytkownik ma opcje i jak je aktywować

            //Ze wszystkich menu powinno dać się wyjść przyciskiem (np ESC) przed sfinalizowaniem anulując zmiany

            //task 4
            //FilterOperationMenu()
            //wyświetlenie listy nieruchomości (wszystkich albo wg filtrów uzyskanych przez zadane pytania do użytkownika)
            //jedyna opcja dla klienta, pracownik biura nieruchomości

            //AddOperationMenu()
            //dodawanie nieruchomośći (pytania o wszystkie pola nieruchomości)
            //tylko pracownik biura nieruchomości

            //RemoveOperationMenu()
            //usuwanie nieruchomości (wystarczy podać ID nieruchomości)
            //tylko pracownik biura nieruchomości

            //EditionOperationMenu()
            //edycja nieruchomości (wystarczy podać ID nieruchomości a potem seria pytań o to które pola edytować)
            //tylko pracownik biura nieruchomości



            //wyloguj się
            //powrót do start menu
            Console.WriteLine("Podaj numer operacji, którą chcesz wykonać");
            Console.WriteLine("1. Filtrowanie listy nieruchomości");
            Console.WriteLine("2. Dodawanie nowej nieruchomości");
            Console.WriteLine("3. Usuwanie nieruchomości z listy");
            Console.WriteLine("4. Edytowanie listy nieruchomości");
            Console.WriteLine("5. Wyloguj się");
            Console.ReadLine();
            int choice;
            int.TryParse(Console.ReadLine(), out choice);
            switch (choice)
            {
                case 1:
                    FilterMenu.FilterOperationMenu();
                    break;
                case 2:
                    AddMenu.AddOperationMenu();
                    break;
                case 3:
                    RemoveMenu.RemoveOperationMenu();
                    break;
                case 4:
                    EditionMenu.EditionOperationMenu();
                    
                    break;
                case 5:
                    StartMenu.BeginStartMenu();
                    break;
                default:
                    break;
            }





        }
    }
}
