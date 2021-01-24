using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstateOffice
{
    class DatabaseContext
    {
        void RealEstatesFilter(Filter filter)
        {
            
            //metoda przyjmuje obiekt klasy Filter z filtrami z frontendu
            //output to będzie lista wpisów (lista obiektów RealEstate)
        }

        void AddToDatabase(RealEstate realEstate)
        {
            //ID zostaje ustalony automatycznie
            //Data stworzenia wpisu zostaje ustalona automatycznie
            //funkcja przyjmuje obiekt RealEstate
            //task 3
        }

        void RemoveFromDatabase()
        {
            //funkcja przyjmuje realEstate.ID
            //
            //task 3
        }

        void EditRecordInDatabase()
        {
            //Data modyfikacji wpisu zostaje ustalona/nadpisana automatycznie
            //funkcja przyjmuje realEstate.ID
            //funkcja przyjmuje też pola RealEstate które użytkownik chce zmodyfikować
            //task 3
        }
    }
}
