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
            var model = new HomeViewModel()
            { realEstateList = DatabaseContext.RealEstateChoice(filter), filter = filter, filtersShow = true };

            ViewBag.login = HttpContext.Session.GetString("Sessionlogin");
            ViewBag.typuser = HttpContext.Session.GetString("Sessiontypuser");

            return View(model);
        }


        [Route("/Home/Index")]
        public IActionResult Index()
        {
            Filter filter = new Filter();

            if (HttpContext.Request.Method == HttpMethod.Post.Method)
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
                    filter.RoomAmountSmallest = int.TryParse(HttpContext.Request.Form["RoomsAmountSmallest"], out int number)
                        ? number
                        : null;

                }

                {
                    filter.RoomAmountBiggest = int.TryParse(HttpContext.Request.Form["RoomsAmountBiggest"], out int number)
                        ? number
                        : null;

                }

                {
                    for (int i = 0; i < 5; i++)
                    {
                        if (bool.TryParse(HttpContext.Request.Form[$"filter.TypesOfRealEstate[{i}]"][0], out bool value))
                            filter.TypesOfRealEstate[i] = value;
                    }


                }

                filter.OwnerName = HttpContext.Request.Form["OwnerName"];

                filter.OwnerSurname = HttpContext.Request.Form["OwnerSurname"];

                filter.City = HttpContext.Request.Form["City"];

                filter.Street = HttpContext.Request.Form["Street"];

            }

            var model = new HomeViewModel()
            {
                realEstateList = DatabaseContext.RealEstateChoice(filter),
                filter = filter,
                filtersShow = true
            };

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
