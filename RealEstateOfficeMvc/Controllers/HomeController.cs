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
            Filter emptyFilter = new Filter();
            var model = DatabaseContext.RealEstatesFilter(emptyFilter);

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
