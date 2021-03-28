using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RealEstateOfficeMvc.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace RealEstateOfficeMvc.Controllers
{
    public class HomeController : Controller
    {
      
        
        public IActionResult Index()
        {
            Filter filter = new Filter();

            if (HttpContext.Request.Method == "POST")
            {
                {
                    filter.PriceLowest = int.TryParse(HttpContext.Request.Form["PriceLowest"], out int number)
                        ? number
                        : null;
                }

                {
                    filter.PriceHighest = int.TryParse(HttpContext.Request.Form["PriceHighest"], out int number)
                        ? number
                        : null;
                }

                {
                    filter.AreaSmallest = int.TryParse(HttpContext.Request.Form["AreaSmallest"], out int number)
                        ? number
                        : null;

                }

                {
                    filter.AreaBiggest = int.TryParse(HttpContext.Request.Form["AreaBiggest"], out int number)
                        ? number
                        : null;

                }

                {
                    filter.RoomAmountSmallest = int.TryParse(HttpContext.Request.Form["RoomsAmount"], out int number)
                        ? number
                        : null;

                }

                {
                    filter.TypeOfRealEstate = (int.TryParse(HttpContext.Request.Form["realestateType"], out int number) && number <= 4 && number >= 0)
                        ? (RealEstate.TypeOfRealEstate)number
                        : null;

                }

                filter.OwnerName = HttpContext.Request.Form["OwnerName"];
                
                filter.OwnerSurname = HttpContext.Request.Form["OwnerSurname"];

                filter.City = HttpContext.Request.Form["City"];

                filter.Street = HttpContext.Request.Form["Street"];

            }


            var model = DatabaseContext.RealEstateChoice(filter);

            ViewBag.login = HttpContext.Session.GetString("Sessionlogin");
            ViewBag.typuser = HttpContext.Session.GetString("Sessiontypuser");
            
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }
                
    }
}
