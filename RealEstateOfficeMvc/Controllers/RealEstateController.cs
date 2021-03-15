using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstateOfficeMvc.Controllers
{
    public class RealEstateController : Controller
    {
        [HttpPost]
        public IActionResult AddRealEstate()
        {
            string realestateType = HttpContext.Request.Form["realestateType"];
            string price = HttpContext.Request.Form["Price"];
            string area = HttpContext.Request.Form["Area"];
            string roomsAmount = HttpContext.Request.Form["RoomsAmount"];
            string ownerName = HttpContext.Request.Form["OwnerName"];
            string ownerSurname = HttpContext.Request.Form["OwnerSurname"];
            string city = HttpContext.Request.Form["City"];
            string street = HttpContext.Request.Form["Street"];
            string estateAddress = HttpContext.Request.Form["EstateAddress"];

            DateTime dt = new DateTime();
            dt.ToShortDateString();
            RealEstateOfficeMvc.Models.RealEstate realEstate = new RealEstateOfficeMvc.Models.RealEstate(1, Convert.ToInt32(realestateType), Convert.ToDecimal(price), Convert.ToInt32(area), Convert.ToInt32(roomsAmount), ownerName, ownerSurname, city, street, estateAddress, dt, dt);
            DatabaseContext.AddToDatabase(realEstate);
            return RedirectToAction("Index", "Home");

        }

       
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult EditEstate()
        {
            return View();
        }


        public IActionResult Search()
        {
            return View();
        }
        

        [HttpPost]
        public IActionResult VSearch()
        {
            var filter = new Filter();

            //filter.TypeOfRealEstate = (int)HttpContext.Request.Form["realestateType"];
            //filter.PriceLowest = Convert.ToInt32(HttpContext.Request.Form["PriceLowest"]);
            //filter.PriceHighest = Convert.ToInt32(HttpContext.Request.Form["PriceHighest"]);
            filter.AreaSmallest = Convert.ToInt32(HttpContext.Request.Form["AreaSmallest"]);
            filter.AreaBiggest = Convert.ToInt32(HttpContext.Request.Form["AreaBiggest"]);
            

            var model = DatabaseContext.RealEstateChoice(filter);
            return View(model);

        }

        [HttpGet]
        public IActionResult Liked()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Details()
        {
            return View();
        }



        [HttpPost]
        public IActionResult  RemoveFromDatabase()
        {
            string realestateid = HttpContext.Request.Form["realestateid"];
            int LineToDelete = Convert.ToInt32(realestateid);

            String path = "\\Files\\RealEstates.csv";
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
                        if (LineToDelete != Convert.ToInt32(columns[0]))
                        {
                            writer.WriteLine(line);
                        }
                        else
                        {
                            linesDeleted++;
                        }

                    }

                }
            }
            sr.Close();
            
            System.IO.File.Copy(relativePathTemp, relativePath, true);
            System.IO.File.WriteAllText(relativePathTemp, string.Empty); //temp is clean

            return RedirectToAction("Index", "Home");
        }

    }
}
