using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstateOfficeMvc.Controllers
{
    public class UsersController : Controller
    {
        public IActionResult Index()
        {
            var model = UserDatabaseContext.ListOfUser();
            return View(model);
        }
    }
}
