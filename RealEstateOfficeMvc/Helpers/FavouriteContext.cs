using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateOfficeMvc.Helpers
{
    public class FavouriteContext
    {

        public static void AddToDatabase(RealEstateOfficeMvc.Domain.FavouriteRealEstate favourite)
        {
            using (var context = new RealEstateOfficeContext())
            {
                context.FavouriteRealEstates.Add(favourite);
                context.SaveChanges();
            }
                  
        }

        public static List<RealEstateOfficeMvc.Domain.FavouriteRealEstate> ListOfFavourites()
        {
           
            using ( var context = new RealEstateOfficeContext())
            {
                var FavouriteList = context.FavouriteRealEstates.ToList();
                return FavouriteList;
            }
          
        }

        static string ParseTextLine(string Line, int column)
        {
            string[] columns = Line.Split(";");
            string output = columns[column];
            return output;
        }


    }
}
