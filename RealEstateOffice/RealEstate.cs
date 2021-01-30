using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace RealEstateOffice
{
    class RealEstate
    {
        public RealEstate()
        {
            _isIdSet = false;
            _isCreationDateSet = false;
        }
        
        private bool _isIdSet;
        private bool _isCreationDateSet;
        
        //pola obiektu: ID; TypeOfRealEstate; Price; Area; OwnerName; OwnerSurname; City; Street; EstateAddress; CreationDate; ModificationDate;

        private int _id;
        public enum TypeOfRealEstate
        {
            Dom,    // 0
            Mieszkanie,   // 1
            Działka,      // 2
            Garaż,      // 3
            Lokal_usługowy // 4
        }

        private TypeOfRealEstate _typeOfRealEstate;
        private int _price;
        private int _area;
        private string _ownerName;
        private string _ownerSurname;
        private string _city;
        private string _street;
        private string _estateAddress;
        private DateTime _creationDate;
        private DateTime _modificationDate;

        public int Id
        {
            set
            {
                if (_isIdSet == true)
                {
                    throw new InvalidOperationException("id can only be set once");
                }
                _isIdSet = true;
                _id = value;
            }
        }
        public DateTime CreationDate
        {
            set
            {
                if (_isCreationDateSet == true)
                {
                    throw new InvalidOperationException("creation date can only be set once");
                }
                _isCreationDateSet = true;
                _creationDate = value;
            }
        }

     
        private Decimal price;
        private int area;
        private string ownerName;
        private string ownerSurname;
        private string city;
        private string street;
        private int estateAddress;

       
        public decimal Price { get => price; set => price = value; }
        public int Area { get => area; set => area = value; }
        public string OwnerName { get => ownerName; set => ownerName = value; }
        public string OwnerSurname { get => ownerSurname; set => ownerSurname = value; }
        public string City { get => city; set => city = value; }
        public string Street { get => street; set => street = value; }
        public int EstateAddress { get => estateAddress; set => estateAddress = value; }

    }
}
