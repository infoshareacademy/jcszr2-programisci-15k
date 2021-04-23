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

namespace RealEstateOfficeMvc.Controllers
{
    public class FavouriteController : Controller
    {

        public void GetUserFavourites()
        {
            //input : userId 
            //pobieramy rekordy polubien z  Favourites.csv
            //output : lista obiektów typu Favourite 
            
        }

        public List<RealEstateOfficeMvc.Models.Favourite> GetFavouriteRealEstates()
        {

            //input : lista obiektów typu Favourite 
            //output :  listę już konkretnych nieruchomosci
            var userid = HttpContext.Session.GetString("SESSIONLOGINID");
            var fav=FavouriteContext.ListOfFavourites();
            return fav;
        }


        [Authorize(Roles = "Client")]
        public IActionResult Index()
        {
            
            var userid = Convert.ToInt16(HttpContext.Session.GetString("SESSIONLOGINID"));
            Filter filter = new Filter();
            var realmodel = DatabaseContext.RealEstateChoice(filter);
            var favouritemodel = GetFavouriteRealEstates();

            var model = from f in favouritemodel
                                           join r in realmodel
                                           on f.Realestateid equals r.Id
                                           where (f.UserID == userid)
                                           select new RealEstate()
                                           {   
                                            Id = r.Id,
                                            typeOfRealEstate = r.typeOfRealEstate,
                                            Price = r.Price,
                                            Area = r.Area,
                                            RoomsAmount = r.RoomsAmount,
                                            OwnerName = r.OwnerName,
                                            OwnerSurname = r.OwnerSurname,
                                            City = r.City,
                                            Street = r.Street,
                                            EstateAddress = r.EstateAddress,
                                           };

         return View(model);
        }

        [Authorize(Roles = "Client")]
        public IActionResult Like()
        {
            var number = Convert.ToInt32(HttpContext.Request.Form["realestateid"]);
            var userid = HttpContext.Session.GetString("SESSIONLOGINID");
            var favourite = new Favourite(1, Convert.ToInt16(userid), number);

            FavouriteContext.AddToDatabase(favourite);
            return RedirectToAction("Index", "Home");
        }

        [Authorize(Roles = "Client")]
        [HttpPost]
        public IActionResult Unlike()
        {
            string realestateid = HttpContext.Request.Form["realestateid"];       
            var userid = HttpContext.Session.GetString("SESSIONLOGINID");  
           
            String path = "\\Files\\FavouriteRealEstate.csv";
            String pathTemp = "\\Files\\Temp.csv";


            string testpath = Directory.GetCurrentDirectory();
            string relativePath = testpath + path;  // fullpath
            string relativePathTemp = testpath + pathTemp;

            StreamReader sr = new StreamReader(relativePath);

            string line;
            int linesDeleted = 0;


            using (StreamReader reader = new StreamReader(relativePath))
            {
                using (StreamWriter writer = new StreamWriter(relativePathTemp))
                {
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] columns = line.Split(";");
                        if (Convert.ToInt32(columns[2]) == Convert.ToInt32(realestateid) && Convert.ToInt32(columns[1]) == Convert.ToInt32(userid))
                        {
                            linesDeleted++;
                        }
                        else
                        {
                            writer.WriteLine(line);
                        }

                    }

                }
            }
            sr.Close();

            System.IO.File.Copy(relativePathTemp, relativePath, true);
            System.IO.File.WriteAllText(relativePathTemp, string.Empty); //temp is clean

            return RedirectToAction("Index", "Favourite");
        }
        

    }
}
