using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace RealEstateOfficeMvc.Models
{
    public class HomeViewModel
    {
        public List<RealEstate> realEstateList { get; set; }

        public Filter filter { get; set; }

        public bool filtersShow { get; set; }

        public List<SelectListItem> realEstateTypeList = new List<SelectListItem>
        {
            new SelectListItem {Value = "-1", Text = "---"},
            new SelectListItem {Value = "0", Text = "Dom"},
            new SelectListItem {Value = "1", Text = "Mieszkanie"},
            new SelectListItem {Value = "2", Text = "Działka"},
            new SelectListItem {Value = "3", Text = "Garaż"},
            new SelectListItem {Value = "4", Text = "Lokal usługowy"},
        };
    }
}
