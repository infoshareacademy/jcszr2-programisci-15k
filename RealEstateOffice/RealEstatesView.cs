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
            Console.WriteLine("Zwiększ szerokość okna aby było czytelnie.");
            //test formatowania tabelki:
            Console.WriteLine("--------------------------------------------------------------------------------------------------------------------------------------------------------------------");
            foreach (var realEstate in realEstates)
            {
                Console.WriteLine($"|ID#{realEstate.Id,-3} | {realEstate.typeOfRealEstate,-10} | {realEstate.Price,10:#,##} PLN | {realEstate.Area,5} m^2 | " +
                                  $"{realEstate.Area,5} m^2 | {realEstate.RoomsAmount,3} | {realEstate.OwnerName,-12} | {realEstate.OwnerSurname,-12} | " +
                                  $"{realEstate.City,-10} | {realEstate.Street,-16} | {realEstate.EstateAddress,-5} | " +
                                  $"{realEstate.CreationDate} | {realEstate.ModificationDate}|" );
                Console.WriteLine("--------------------------------------------------------------------------------------------------------------------------------------------------------------------");
            }
            Console.ReadLine();
        }



    }
}
