using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstateOffice
{
    class RealEstatesView
    {

        //Metoda display do wyświetlania widoku listy nieruchomości
        public static void Display(List<RealEstate> realEstates)
        {
            //Oczekujemy listy obiektów RealEstate z backendu
            Console.Clear();
            //test formatowania tabelki:
            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------");
            foreach (var realEstate in realEstates)
            {
                Console.WriteLine($"|ID#{realEstate.Id,-3} | {realEstate.typeOfRealEstate,-10} | {realEstate.Price,10:#,##} PLN | " +
                                  $"{realEstate.Area,5} m^2 | {realEstate.OwnerName,-12} | {realEstate.OwnerSurname,-12} | " +
                                  $"{realEstate.City,-7} | {realEstate.Street,-16} | {realEstate.EstateAddress,-5} |");
                Console.WriteLine("----------------------------------------------------------------------------------------------------------------------");
            }
            Console.ReadLine();
        }
       


        enum TypeOfRealEstate
        {
            Dom,    // 0
            Mieszkanie,   // 1
            Działka,      // 2
            Garaż,      // 3
            Lokal_usługowy // 4
        }



    }
}
