using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Resources;
using System.Text;
using Microsoft.VisualBasic;

namespace RealEstateOffice
{
    class Filter
    {
        public Filter()
        {
            _typeOfRealEstate = null;
            OwnerName = null;
            OwnerSurname = null;
            City = null;
            Street = null;
            PriceLowest = null;
            PriceHighest = null;
            AreaSmallest = null;
            AreaBiggest = null;
            CreationDateEarliest = null;
            CreationDateLatest = null;
            ModificationDateEarliest = null;
            ModificationDateLatest = null;
        }

        public void FilterReset()
        {
            _typeOfRealEstate = null;
            NoType = 0;
            OwnerName = null;
            NoName = 0;
            OwnerSurname = null;
            NoSurname = 0;
            City = null;
            NoCity = 0;
            Street = null;
            NoStreet = 0;
            PriceLowest = null;
            PriceHighest = null;
            NoPrice = 0;
            AreaSmallest = null;
            AreaBiggest = null;
            NoArea = 0;
            CreationDateEarliest = null;
            CreationDateLatest = null;
            ModificationDateEarliest = null;
            ModificationDateLatest = null;
        }

        public void ShowActiveFilters()
        {
            if(_typeOfRealEstate != null) {
                Console.WriteLine($"Kategoria nieruchomości: {_typeOfRealEstate}");
            }
            if (OwnerName != null && OwnerSurname != null)
            {
                Console.WriteLine($"Właściciel: {OwnerName} {OwnerSurname}");
            }
            if (City != null)
            {
                Console.WriteLine($"Miejscowość: {City}");
            }
            if (Street != null)
            {
                Console.WriteLine($"Ulica: {Street}");
            }
            if (PriceLowest != null && PriceHighest != null)
            {
                Console.WriteLine($"Cena: od {PriceLowest} PLN do {PriceHighest} PLN");
            }
            if (AreaSmallest != null && AreaBiggest != null)
            {
                Console.WriteLine($"Powierzchnia: od {AreaSmallest} m^2 do {AreaBiggest} m^2");
            }
            if (CreationDateEarliest != null && CreationDateLatest != null)
            {
                Console.WriteLine("Wpis nieruchomości dodany między {0:dd/MM/yyyy} a {1:dd/MM/yyyy}", CreationDateEarliest, CreationDateLatest);
            }
            if (ModificationDateEarliest != null && ModificationDateLatest != null)
            {
                Console.WriteLine("Wpis nieruchomości zaktualizowany między {0:dd/MM/yyyy} a {1:dd/MM/yyyy}", ModificationDateEarliest, ModificationDateLatest);
            }
        }

        private RealEstate.TypeOfRealEstate ? _typeOfRealEstate;
        public int NoType;
        public string OwnerName;
        public int NoName;
        public string OwnerSurname;
        public int NoSurname;
        public string City;
        public int NoCity;
        public string Street;
        public int NoStreet;
        public int ? PriceLowest;
        public int ? PriceHighest;
        public int NoPrice;
        public int ? AreaSmallest;
        public int ? AreaBiggest;
        public int NoArea;
        public DateTime ? CreationDateEarliest;
        public DateTime ? CreationDateLatest;
        public DateTime ? ModificationDateEarliest;
        public DateTime ? ModificationDateLatest;
        public RealEstate.TypeOfRealEstate ? TypeOfRealEstate
        {
            set
            {
                _typeOfRealEstate = value;
            }

            get
            {
                return _typeOfRealEstate;
            }
        }
    }
}