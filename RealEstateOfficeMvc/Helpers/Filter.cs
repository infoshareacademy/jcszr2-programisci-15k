using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Resources;
using System.Text;
using Microsoft.VisualBasic;

namespace RealEstateOfficeMvc
{
    public class Filter
    {
        public Filter()
        {
            TypesOfRealEstate = new List<bool>(){
                false,
                false,
                false,
                false,
                false,
            };
            OwnerName = null;
            OwnerSurname = null;
            City = null;
            Street = null;
            PriceLowest = null;
            PriceHighest = null;
            AreaSmallest = null;
            AreaBiggest = null;
            RoomAmountSmallest = null;
            RoomAmountBiggest = null;
            CreationDateEarliest = null;
            CreationDateLatest = null;
            ModificationDateEarliest = null;
            ModificationDateLatest = null;
        }

        public void FilterReset()
        {
            TypesOfRealEstate = new List<bool>(){
                false,
                false,
                false,
                false,
                false,
            }; ;
            OwnerName = null;
            OwnerSurname = null;
            City = null;
            Street = null;
            PriceLowest = null;
            PriceHighest = null;
            AreaSmallest = null;
            AreaBiggest = null;
            RoomAmountSmallest = null;
            RoomAmountBiggest = null;
            CreationDateEarliest = null;
            CreationDateLatest = null;
            ModificationDateEarliest = null;
            ModificationDateLatest = null;
        }

        public List<bool> TypesOfRealEstate;
        public string OwnerName;
        public string OwnerSurname;
        public string City;
        public string Street;
        public int? PriceLowest;
        public int? PriceHighest;
        public int? AreaSmallest;
        public int? AreaBiggest;
        public int? RoomAmountSmallest;
        public int? RoomAmountBiggest;
        public DateTime? CreationDateEarliest;
        public DateTime? CreationDateLatest;
        public DateTime? ModificationDateEarliest;
        public DateTime? ModificationDateLatest;
    }
}