using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstateOfficeMvc.Controllers
{
    public class RegisterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddUser()
        {
            string email = HttpContext.Request.Form["email"];
            string name = HttpContext.Request.Form["Name"];
            string surname = HttpContext.Request.Form["Surname"];
            string login = HttpContext.Request.Form["Login"];
            string password = HttpContext.Request.Form["Password"];
            string userTyp = HttpContext.Request.Form["userTyp"];

            RealEstateOfficeMvc.Models.User usr = new RealEstateOfficeMvc.Models.User(1,login,password,name,surname,email, Convert.ToInt32(userTyp));
            UserDatabaseContext.AddToDatabase(usr);
            return RedirectToAction("Index", "Users");
        }

    }
}
