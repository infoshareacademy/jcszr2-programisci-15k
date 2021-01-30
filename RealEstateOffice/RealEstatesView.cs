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
            foreach (var realEstate in realEstates)
            {
                Console.WriteLine("RealEstate: {0},{1},{2},{3},{4},{5},{6},{7}", realEstate.Id, realEstate.OwnerName, realEstate.OwnerSurname, realEstate.Price, realEstate.City, realEstate.EstateAddress,realEstate.Area,realEstate.Price);
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
