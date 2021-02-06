using System;

namespace RealEstateOffice
{
    class RemoveMenu
    {
        public static void RemoveOperationMenu()
        {
            var isRemoveMenuRunning = true;
            Console.WriteLine("Podaj numer ID wpisu który chcesz usunąć lub wpisz '0' aby wyjść z menu:");
            while (isRemoveMenuRunning)
            {
                if (int.TryParse(Console.ReadLine(), out var choice))
                {
                    if (choice == 0)
                    {
                        isRemoveMenuRunning = false;
                    }
                    else
                    {
                        DatabaseContext.RemoveFromDatabase(choice);
                        //todo:
                        //potwierdzenie usunięcia wpisu lub informacja że nie ma wpisu z takim ID
                        isRemoveMenuRunning = false;
                    }
                }
                else
                {
                    Console.WriteLine("Wpisz właściwą wartość.");
                }
            }


            //task 8
            //Pytanie o ID, po czym backend wybiera odpowiedni wiersz i usuwa go z pliku
            //Console.WriteLine("Podaj ID nieruchomości, którą chcesz usunąć");
            //Console.ReadLine();

        }
    }
}