using System;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstateOfficeMvc.Models;
using Microsoft.AspNetCore.Http;

namespace RealEstateOfficeMvc.Controllers
{
    public class HomeController : Controller
    {
        [Route("/")]
        public IActionResult Main()
        {
            Filter filter = new Filter();
            SearchSettings searchSettings = new SearchSettings();
            var model = new HomeViewModel()
            { realEstateList = DatabaseContext.RealEstateChoice(filter, searchSettings), filter = filter, filtersShow = true };

            ViewBag.login = HttpContext.Session.GetString("Sessionlogin");
            ViewBag.typuser = HttpContext.Session.GetString("Sessiontypuser");

            return View(model);
        }

        [Route("/Home/Index/{page:int}")]
        [HttpGet]
        public IActionResult DefaultList(int page)
        {
            var filter = new Filter();
            var searchSettings = new SearchSettings();
            searchSettings.PageNumber = page;

            

            return Index(filter, searchSettings);
        }

        [Route("/Home/Index/{page:int}")]
        [HttpPost]
        public IActionResult FilteredList(int page)
        {
            var filter = new Filter();

            { filter.PriceLowest = int.TryParse(HttpContext.Request.Form["PriceLowest"], out int number) ? number : null; }

            { filter.PriceHighest = int.TryParse(HttpContext.Request.Form["PriceHighest"], out int number) ? number : null; }

            { filter.AreaSmallest = int.TryParse(HttpContext.Request.Form["AreaSmallest"], out int number) ? number : null; }

            { filter.AreaBiggest = int.TryParse(HttpContext.Request.Form["AreaBiggest"], out int number) ? number : null; }

            { filter.RoomAmountSmallest = int.TryParse(HttpContext.Request.Form["RoomsAmountSmallest"], out int number) ? number : null; }

            { filter.RoomAmountBiggest = int.TryParse(HttpContext.Request.Form["RoomsAmountBiggest"], out int number) ? number : null; }

            { filter.CreationDateEarliest = DateTime.TryParse(HttpContext.Request.Form["filter.CreationDateEarliest"], out DateTime date)
                    ? date
                    : null; }

            { filter.CreationDateLatest = DateTime.TryParse(HttpContext.Request.Form["filter.CreationDateLatest"], out DateTime date)
                    ? date
                    : null; }

            for (int i = 0; i < 5; i++)
            {
                if (bool.TryParse(HttpContext.Request.Form[$"filter.TypesOfRealEstate[{i}]"][0], out bool value))
                    filter.TypesOfRealEstate[i] = value;
            }

            filter.OwnerName = HttpContext.Request.Form["OwnerName"];
            filter.OwnerSurname = HttpContext.Request.Form["OwnerSurname"];
            filter.City = HttpContext.Request.Form["City"];
            filter.Street = HttpContext.Request.Form["Street"];

            var searchSettings = new SearchSettings();
            searchSettings.PageNumber = page;

            return Index(filter, searchSettings);
        }


        
        private IActionResult Index(Filter filter, SearchSettings SearchSettings)
        {
            var model = new HomeViewModel()
            {
                realEstateList = DatabaseContext.RealEstateChoice(filter, SearchSettings), filter = filter, filtersShow = true 
            };



            ViewBag.login = HttpContext.Session.GetString("Sessionlogin");
            ViewBag.typuser = HttpContext.Session.GetString("Sessiontypuser");

            return View("Index",model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

    }
}
