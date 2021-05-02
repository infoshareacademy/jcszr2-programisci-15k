using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
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
        public async Task<IActionResult> AddUser()
        {
            string email = HttpContext.Request.Form["email"];
            string name = HttpContext.Request.Form["Name"];
            string surname = HttpContext.Request.Form["Surname"];
            string login = HttpContext.Request.Form["Login"];
            string password = HttpContext.Request.Form["Password"];
            string userTyp = HttpContext.Request.Form["userTyp"];

            using (var context = new RealEstateOfficeContext())
            {
                var usr = new Domain.User();
                usr.Emailaddress = email;
                usr.Name = name;
                usr.Surname = surname;
                usr.Login = login;
                usr.Password = UserDatabaseContext.codePassword(password);
                usr.UserType = Convert.ToInt32(userTyp);

                context.Add(usr);
                await  context.SaveChangesAsync();
            }
           
            return RedirectToAction("Index", "Users");
        }

        public IActionResult Login()
        {
           return View();
        }


        [Authorize(Roles = "Administrator,Worker,Client")]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync();
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
           var userid = 0;

           typUser = UserDatabaseContext.Login(login,password,1);
           userid = UserDatabaseContext.Login(login, password, 2);

           HttpContext.Session.SetString(Appsettings.SESSIONLOGIN, login);
           HttpContext.Session.SetString(Appsettings.SESSIONTYPUSER, Convert.ToString(typUser));
           HttpContext.Session.SetString(Appsettings.SESSIONLOGINID, Convert.ToString(userid));

           var claims = new List<Claim>()
           {
               new Claim(ClaimTypes.Role, ((Models.User.UserType)typUser).ToString()),
           };

           var identity = new ClaimsIdentity(claims, "identity");

           var userPrincipal = new ClaimsPrincipal(new[] { identity });
           //-----------------------------------------------------------
           HttpContext.SignInAsync(userPrincipal);

            return RedirectToAction("Index", "Home");

        }

        [HttpPost]
        public async Task<IActionResult> EditUser(RealEstateOfficeMvc.Domain.User user)
        {
            int id = Convert.ToInt32((HttpContext.Request.Form["userid"]));

            using (var context = new  RealEstateOfficeContext())
            {
                var usr = context.Users.Single(x => x.Id == id);
                usr.Login = user.Login;
                usr.Name = user.Name;
                usr.Surname = user.Surname;
                usr.Emailaddress = user.Emailaddress;
                usr.UserType = user.UserType;

                await context.SaveChangesAsync();
            }

            return RedirectToAction("Index", "Users");
        }

        

        public IActionResult RegisterClient()
        {
            return View();
        }


    }
}
