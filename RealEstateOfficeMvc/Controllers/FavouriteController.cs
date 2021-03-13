using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstateOfficeMvc.Controllers
{
    public class FavouriteController : Controller
    {

        public void GetUserFavourites()
        {
            //input : userId 
            //pobieramy rekordy polubien z  Favourites.csv
            //output : lista obiektów typu Favourite 
            
        }

        public void GetFavouriteRealEstates()
        {
            //input : lista obiektów typu Favourite 
            //output :  listę już konkretnych nieruchomosci
        }

       
        public IActionResult Index()
        {
            //input : lista obiektów typu realEstate
            //return view
            return View();
        }

        public  void  Like()
        {
            //tu tworzymy wpisy do pliku favourites.csv
        }

        public void Unlike()
        {
            //tutaj usuwamy wpisy z pliku favourites 
        }

    }
}
