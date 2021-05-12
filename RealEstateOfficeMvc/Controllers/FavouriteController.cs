using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using RealEstateOfficeMvc.Helpers;
using RealEstateOfficeMvc.Models;
using Microsoft.AspNetCore.Http;
using RealEstateOfficeMvc.Domain;

namespace RealEstateOfficeMvc.Controllers
{
    public class FavouriteController : Controller
    {
        public async Task<List<RealEstateOfficeMvc.Domain.FavouriteRealEstate>> GetFavouriteRealEstates()
        {
            var userid = HttpContext.Session.GetString("SESSIONLOGINID");
            return await FavouriteContext.ListOfFavourites();
             
        }


        [Authorize(Roles = "Client")]
        public async Task<IActionResult> Index()
        {
            SearchResults searchResults = new SearchResults();

            var userid = Convert.ToInt16(HttpContext.Session.GetString("SESSIONLOGINID"));
            Filter filter = new Filter();
            var realmodel = DatabaseContext.RealEstateChoice(filter, searchResults);
            var favouritemodel = await GetFavouriteRealEstates();

            var model = from f in favouritemodel
                        join r in realmodel
                        on f.RealEstateId equals r.Id
                        where (f.UserId == userid)
                        select new Domain.RealEstate()
                        {   
                        Id = r.Id,
                        Typeofrealestate = r.Typeofrealestate,
                        Price = r.Price,
                        Area = r.Area,
                        Roomamount = r.Roomamount,
                        Ownername = r.Ownername,
                        Ownersurname = r.Ownersurname,
                        City = r.City,
                        Street = r.Street, 
                        EstateAddress = r.EstateAddress,
                        };

         return View(model);

        }

        [Authorize(Roles = "Client")]
        public async Task<IActionResult> Like()
        {
            var number = Convert.ToInt32(HttpContext.Request.Form["realestateid"]);
            var userid = Convert.ToInt32(HttpContext.Session.GetString("SESSIONLOGINID"));
            
            var favourite = new FavouriteRealEstate();
            favourite.UserId = userid;
            favourite.RealEstateId = number;

            using (var context = new RealEstateOfficeContext())
            {
                context.FavouriteRealEstates.Add(favourite);
                await context.SaveChangesAsync();
            }
            return RedirectToAction("Index", "Home");
        }

        [Authorize(Roles = "Client")]
        [HttpPost]
        public async Task<IActionResult> Unlike()
        {
            int  realestateid = Convert.ToInt32(HttpContext.Request.Form["realestateid"]);

            using (var context = new RealEstateOfficeContext())
            {
                var unlike = context.FavouriteRealEstates.Single(x => x.RealEstateId == realestateid);
                context.Remove(unlike);
                await context.SaveChangesAsync();
            }

            return RedirectToAction("Index", "Favourite");
           
        }
     
    }
}
