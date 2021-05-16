
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace RealEstateOfficeMvc.Models
{
    public class HomeViewModel
    {
        public List<Domain.RealEstate> realEstateList { get; set; }

        public Filter filter { get; set; }

        public SearchSettings SearchSettings { get; set; }

        public bool filtersShow { get; set; }

        public List<string> realEstateTypeList = new List<string>
        {
            RealEstate.TypeOfRealEstate.Dom.ToString(),
            RealEstate.TypeOfRealEstate.Mieszkanie.ToString(),
            RealEstate.TypeOfRealEstate.Działka.ToString(),
            RealEstate.TypeOfRealEstate.Garaż.ToString(),
            RealEstate.TypeOfRealEstate.Lokal_usługowy.ToString(),
        };
    }
}
