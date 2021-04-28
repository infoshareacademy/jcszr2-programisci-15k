using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using RealEstateOfficeMvc.Helpers;
using RealEstateOfficeMvc.Models;
using System.Linq;

namespace RealEstateOfficeMvc.Controllers
{
    public class RealEstateController : Controller
    {

        [Authorize(Roles = "Administrator,Worker")]
        [HttpPost]
        public IActionResult AddRealEstate()
        {
            bool isFormCorrect = true;

            if (!int.TryParse(HttpContext.Request.Form["realestateType"], out var realEstateType))
                isFormCorrect = false;
            if (!decimal.TryParse(HttpContext.Request.Form["Price"], out var price))
                isFormCorrect = false;
            if (!int.TryParse(HttpContext.Request.Form["Area"], out var area))
                isFormCorrect = false;
            if (!int.TryParse(HttpContext.Request.Form["RoomsAmount"], out var roomsAmount))
                isFormCorrect = false;

            string ownerName = HttpContext.Request.Form["OwnerName"];
            if (String.IsNullOrEmpty(ownerName))
                isFormCorrect = false;

            string ownerSurname = HttpContext.Request.Form["OwnerSurname"];
            if (String.IsNullOrEmpty(ownerSurname))
                isFormCorrect = false;

            string city = HttpContext.Request.Form["City"];
            if (String.IsNullOrEmpty(city))
                isFormCorrect = false;

            string street = HttpContext.Request.Form["Street"];
            if (String.IsNullOrEmpty(street))
                isFormCorrect = false;

            string estateAddress = HttpContext.Request.Form["EstateAddress"];
            if (String.IsNullOrEmpty(estateAddress))
                isFormCorrect = false;

            if (isFormCorrect == false)
            {
                return RedirectToAction("Index", "RealEstate"); //tymczasowo, powinien być error
            }

            DateTime dt = DateTime.Now;
            dt.ToShortDateString();
            
             using (var context = new RealEstateOfficeContext())
            {
                var realest = new Domain.RealEstate();

                realest.Typeofrealestate = realEstateType;
                realest.Price = price;
                realest.Area = area;
                realest.Roomamount = roomsAmount;
                realest.Ownername = ownerName;
                realest.Ownersurname = ownerSurname;
                realest.City = city;
                realest.Street = street;
                realest.EstateAddress = estateAddress;
                realest.Creationdate = dt;
                realest.Modificationdate = dt;

               
                context.RealEstates.Add(realest);

                context.SaveChanges();
          }

            return RedirectToAction("Index", "Home");

        }

        [Authorize(Roles = "Administrator,Worker")]
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Administrator,Worker")]
        [HttpGet("edit/{id:int}")]
        public IActionResult EditEstate(int id)
        {

            var viewModel = DatabaseContext.Get(id);


            return View(viewModel);
        }

        [Authorize(Roles = "Administrator,Worker")]
        [HttpPost]
        public IActionResult SaveEditedEstate()
        {
            int id = Convert.ToInt32(HttpContext.Request.Form["id"]);
           
            using (var context = new RealEstateOfficeContext())
            {
                var realEstate = context.RealEstates.Single(r => r.Id == id);

                realEstate.Price = Convert.ToDecimal(HttpContext.Request.Form["Price"]);
                realEstate.Area = Convert.ToInt32(HttpContext.Request.Form["Area"]);
                realEstate.Roomamount = Convert.ToInt32(HttpContext.Request.Form["RoomsAmount"]);
                realEstate.Ownername = HttpContext.Request.Form["OwnerName"];
                realEstate.Ownersurname = HttpContext.Request.Form["OwnerSurname"];
                realEstate.City = HttpContext.Request.Form["City"];
                realEstate.Street = HttpContext.Request.Form["Street"];
                realEstate.EstateAddress = HttpContext.Request.Form["EstateAddress"];
                realEstate.Modificationdate = DateTime.Now;
                realEstate.Typeofrealestate = Convert.ToInt32(HttpContext.Request.Form["realestateType"]);

                context.SaveChanges();
            }
           
            return RedirectToAction("Index", "Home");
        }



        [HttpGet("details/{id:int}")]
        public IActionResult Details(int id)
        {
            var images = ImagesContext.GetImages(id);

            var viewModel = DatabaseContext.Get(id);

            ViewData["typeOfRealEstate"] =  (Models.RealEstate.TypeOfRealEstate)viewModel.Typeofrealestate;
            ViewData["Area"] = viewModel.Area;
            ViewData["City"] = viewModel.City;
            ViewData["CreationDate"] = viewModel.Modificationdate;
            ViewData["Price"] = viewModel.Price;
            ViewData["Pricem2"] = Convert.ToInt32(viewModel.Price / viewModel.Area);
            ViewData["RoomsAmount"] = viewModel.Roomamount;


            return View(images);
        }

        [Authorize(Roles = "Administrator,Worker")]
        [HttpPost]
        public IActionResult UploadFile(IFormFile file)
        {
            if (file != null || file.Length != 0)
            {
                var number = Convert.ToInt32(HttpContext.Request.Form["realedit"]);
                NewImageFolder(number);

                var path = Path.Combine(
                    Directory.GetCurrentDirectory(), "wwwroot\\Images" + "\\" + number,
                    file.FileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                                
                Domain.Image img = new Domain.Image();
                img.RealEstateId = number;
                img.Nazwapliku = file.FileName;

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

        [Authorize(Roles = "Administrator,Worker")]
        [HttpPost]
        public IActionResult RemoveRealEstate()
        {
            string realestateid = HttpContext.Request.Form["realestateid"];
            if (!int.TryParse(realestateid, out var id))
            { 
                //error
            }

            using (var context = new RealEstateOfficeContext())
            {
               context.Remove(context.RealEstates.Single(r => r.Id == id));
               context.SaveChanges();
            }
            return RedirectToAction("Index", "Home");
        }




    }
}
