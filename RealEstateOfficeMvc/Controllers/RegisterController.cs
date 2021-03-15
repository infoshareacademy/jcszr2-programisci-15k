using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.WebEncoders.Testing;
using Microsoft.VisualBasic;
using RealEstateOfficeMvc.Helpers;

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

        public IActionResult Login()
        {
           return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Register");
        }



        [HttpPost]
        public IActionResult LoginUser()
        {
          
           string login = HttpContext.Request.Form["Login"];
           string password = HttpContext.Request.Form["Password"];
           string SessionName = login;
           var typUser = 0;

           typUser = UserDatabaseContext.Login(login,password);
            
           HttpContext.Session.SetString(Appsettings.SESSIONLOGIN, login);
           HttpContext.Session.SetString(Appsettings.SESSIONTYPUSER, Convert.ToString(typUser));


           return RedirectToAction("Index", "Home");

        }

        
        public IActionResult RegisterClient()
        {
            return View();
        }


    }
}
