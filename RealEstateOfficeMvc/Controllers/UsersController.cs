using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using RealEstateOfficeMvc.Models;
using Microsoft.EntityFrameworkCore;

namespace RealEstateOfficeMvc.Controllers
{
    public class UsersController : Controller
    {

        [Authorize(Roles = "Administrator")]
        public IActionResult Index()
        {
            var model = UserDatabaseContext.ListOfUser();
            return View(model);
        }

        [HttpPost]
        public IActionResult RemoveUser()
        {
            string userid = HttpContext.Request.Form["userid"];
            int userToDelete = Convert.ToInt32(userid);
          
            using (var context = new  RealEstateOfficeContext())
            {
                context.Remove(context.Users.Single(u => u.Id == userToDelete));
                context.SaveChanges();
            }

            return RedirectToAction("Index", "Users");
        }

        public async Task<IActionResult> EditUser()
        {
            string userid = HttpContext.Request.Form["useredit"];

            var model = await  GetUserAsync(Convert.ToInt32(userid));
        
            return View(model);
        }

        

        public async static Task<RealEstateOfficeMvc.Domain.User> GetUserAsync(int id)
        {
            RealEstateOfficeMvc.Domain.User user = null;
            using (var context = new RealEstateOfficeContext())
            {
              user = await (context.Users.SingleAsync(x => x.Id == id));
              
            }
            return user;

        }
    }
}
