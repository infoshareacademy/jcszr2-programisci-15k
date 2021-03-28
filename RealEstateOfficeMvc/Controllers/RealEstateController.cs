using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Connections;
using RealEstateOfficeMvc.Helpers;
using RealEstateOfficeMvc.Models;

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
             
            string realeditID = HttpContext.Request.Form["realedit"];
            ViewBag.realedit = realeditID;
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
            

            var model = DatabaseContext.RealEstateChoice(filter);
            return View(model);

        }

        

        [HttpPost]
        public IActionResult Details()
        {
           

            var number = Convert.ToInt32(HttpContext.Request.Form["realestateid"]);
            var images = ImagesContext.GetImages(number);
            
            var viewModel = DatabaseContext.Get(number);

            ViewData["typeOfRealEstate"] = viewModel.typeOfRealEstate;
            ViewData["Area"] = viewModel.Area;
            ViewData["City"] = viewModel.City;
            ViewData["CreationDate"] = viewModel.CreationDate;
            ViewData["Price"] = viewModel.Price;
            ViewData["Pricem2"] = Convert.ToInt32(viewModel.Price / viewModel.Area);
            ViewData["RoomsAmount"] = viewModel.RoomsAmount;


            return View(images);
        }

        [HttpPost]
        public IActionResult UploadFile(IFormFile file)
        {
            if (file != null || file.Length != 0)
            {
                var number = Convert.ToInt32(HttpContext.Request.Form["realedit"]);
                NewImageFolder(number);
                
                var path = Path.Combine(
                    Directory.GetCurrentDirectory(), "wwwroot\\Images" + "\\"+ number,
                    file.FileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                
                Image img = new Image(0,number, file.FileName);
                ImagesContext.AddToDatabase(img);

            }
            return RedirectToAction("Index", "Home");

        }


        public static void NewImageFolder(int number)
        {
            // Specify the directory you want to manipulate.
            string path = Directory.GetCurrentDirectory() + "\\wwwroot\\Images\\" + number;

            try
            {
                // Determine whether the directory exists.
                if (Directory.Exists(path))
                {
                  return;
                }

                // Try to create the directory.
                DirectoryInfo di = Directory.CreateDirectory(path);
            }
            catch (Exception e)
            {
            }
            finally { }
       
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
