using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstateOffice
{
    class RealEstate
    {
        //pola obiektu: ID; TypeOfRealEstate; Price; Area; OwnerName; OwnerSurname; City; Street; EstateAddress; CreationDate; ModificationDate;

        private int typeOfRealEstate;
        private Decimal price;
        private int area;
        private string ownerName;
        private string ownerSurname;
        private string city;
        private string street;
        private int estateAddress;

        public int TypeOfRealEstate { get => typeOfRealEstate; set => typeOfRealEstate = value; }
        public decimal Price { get => price; set => price = value; }
        public int Area { get => area; set => area = value; }
        public string OwnerName { get => ownerName; set => ownerName = value; }
        public string OwnerSurname { get => ownerSurname; set => ownerSurname = value; }
        public string City { get => city; set => city = value; }
        public string Street { get => street; set => street = value; }
        public int EstateAddress { get => estateAddress; set => estateAddress = value; }
    }
}
