using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;


namespace RealEstateOfficeMvc.Controllers
{
    public class RaportsController : Controller
    {
        [Authorize(Roles = "Administrator")]
        public IActionResult Index()
        {
          
            return View();
        }
    }
}
