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


        [Authorize(Roles = "Administrator,Worker,Client")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            HttpContext.Session.Clear();

            return RedirectToAction("Login", "Register");
        }



        [HttpPost]
        public async Task<IActionResult> LoginUser()
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
           await HttpContext.SignInAsync(userPrincipal);

            return RedirectToAction("Index", "Home");

        }

        [HttpPost]
        public IActionResult EditUser(RealEstateOfficeMvc.Models.User user)
        {

            int id = Convert.ToInt32((HttpContext.Request.Form["userid"]));
            String path = "\\Files\\Users.csv";
            string testpath = Directory.GetCurrentDirectory();
            string relativePath = testpath + path;  // fullpath
            string line;
            string lineToChange = "";
            string s1 = String.Empty;

    
            using (StreamReader reader = new StreamReader(relativePath))
            {

                while ((line = reader.ReadLine()) != null)
                {
                    string[] columns = line.Split(";");
                    if (Convert.ToInt32(columns[0]) == id)
                    {
                        lineToChange = line; // this is  line to be modified
                    }
                }
            }



            if (String.IsNullOrEmpty(lineToChange))
            {
                Console.WriteLine("No User record in our database with this ID !");
                Console.ReadLine();

            }
            else
            {
                string[] columnsToChange = lineToChange.Split(";");
                //ID; Login; Password; Name; Surname; EmailAddress; UserType;

                if (!String.IsNullOrEmpty(user.Login))
                {
                    columnsToChange[1] = user.Login;
                }

                if (!String.IsNullOrEmpty(user.Password))
                {
                    columnsToChange[2] = user.Password;
                }

                if (!String.IsNullOrEmpty(user.Name))
                {
                    columnsToChange[3] = user.Name;
                }

                if (!String.IsNullOrEmpty(user.Surname))
                {
                    columnsToChange[4] = user.Surname;
                }

                if (!String.IsNullOrEmpty(user.EmailAddress))
                {
                    columnsToChange[5] = user.EmailAddress;
                }

                if ((int)user.TypeOfUserType != 0)
                {
                    int type = (int)user.TypeOfUserType;
                    columnsToChange[6] = type.ToString();
                }


                s1 = string.Join(";", columnsToChange);

            }

            UserDatabaseContext.saveLine(id, s1);

            return RedirectToAction("Index", "Users");
            // return s1;

        }

        

        public IActionResult RegisterClient()
        {
            return View();
        }


    }
}
