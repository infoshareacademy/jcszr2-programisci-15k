using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstateOfficeMvc.Controllers
{
    public class LogsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
