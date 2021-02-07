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


        public RealEstate(int ID,int TypeOfRealEstate,decimal Price,int Area,string OwnerName,string OwnerSurname, string City,string Street, string EstateAddress)
        {
            this._id = ID;
            this._typeOfRealEstate = (TypeOfRealEstate)TypeOfRealEstate;
            this._price = Price;
            this._area = Area;
            this._ownerName = OwnerName;
            this._ownerSurname = OwnerSurname;
            this._city = City;
            this._street = Street;
            this._estateAddress = EstateAddress;



        }
        
        private bool _isIdSet;
        private bool _isCreationDateSet;  //ustawiane raz w  seterach
        //---------------------------------------------------------
        private TypeOfRealEstate _typeOfRealEstate;
        private DateTime _creationDate;
        private DateTime _modificationDate;
        private Decimal _price;
        private int _area;
        private string _ownerName;
        private string _ownerSurname;
        private string _city;
        private string _street;
        private string _estateAddress;

        //pola obiektu: ID; TypeOfRealEstate; Price; Area; OwnerName; OwnerSurname; City; Street; EstateAddress; CreationDate; ModificationDate;

        private int _id;
                
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

            get 
            {
                return this._id;
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

        public TypeOfRealEstate typeOfRealEstate
        {
            get => _typeOfRealEstate;
            set => _typeOfRealEstate = value;
        }

        public decimal Price { get => _price; set => _price = value; }
        public int Area { get => _area; set => _area = value; }
        public string OwnerName { get => _ownerName; set => _ownerName = value; }
        public string OwnerSurname { get => _ownerSurname; set => _ownerSurname = value; }
        public string City { get => _city; set => _city = value; }
        public string Street { get => _street; set => _street = value; }
        public string EstateAddress { get => _estateAddress; set => _estateAddress = value; }

        public enum TypeOfRealEstate
        {
            Dom,    // 0
            Mieszkanie,   // 1
            Działka,      // 2
            Garaż,      // 3
            Lokal_usługowy, // 4
            None
        }


    }
}
