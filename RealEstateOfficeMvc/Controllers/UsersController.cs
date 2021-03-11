using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
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

        [HttpPost]
        public IActionResult RemoveUser()
        {
            string userid = HttpContext.Request.Form["userid"];
            int LineToDelete = Convert.ToInt32(userid);

            String path = "\\Files\\Users.csv";
            String pathTemp = "\\Files\\Temp.csv";

            string testpath = Directory.GetCurrentDirectory();
            string relativePath = testpath + path;  // fullpath
            string relativePathTemp = testpath + pathTemp;

            
            StreamReader sr = new StreamReader(relativePath);
            string line;
            int linesDeleted = 0;

            using (StreamReader reader = new StreamReader(relativePath))
            {
                using (StreamWriter writer = new StreamWriter(relativePathTemp))
                {
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] columns = line.Split(";");
                        if (LineToDelete != Convert.ToInt32(columns[0]))
                        {
                            writer.WriteLine(line);
                        }
                        else
                        {
                            linesDeleted++;
                        }

                    }

                }
            }
            sr.Close();

            System.IO.File.Copy(relativePathTemp, relativePath, true);
            System.IO.File.WriteAllText(relativePathTemp, string.Empty); //temp is clean

            return RedirectToAction("Index", "Users");
        }

        public IActionResult EditUser()
        {
            return View();
        }



    }
}
