using Microsoft.EntityFrameworkCore;
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
        public static async Task<List<RealEstateOfficeMvc.Domain.FavouriteRealEstate>> ListOfFavourites()
        {
            using ( var context = new RealEstateOfficeContext())
            {
                return await context.FavouriteRealEstates.ToListAsync();
            }
          
        }
    }
}
