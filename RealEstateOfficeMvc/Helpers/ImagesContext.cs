using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateOfficeMvc.Helpers
{
    public class ImagesContext
    {

        public static async Task<List<RealEstateOfficeMvc.Domain.Image>>  GetImagesAsync(int id)
        {
            List<RealEstateOfficeMvc.Domain.Image> imageList = new List<RealEstateOfficeMvc.Domain.Image>();
            using ( var context = new RealEstateOfficeContext())
            {
                imageList = await context.Images.Where(x => x.RealEstateId == id).ToListAsync();
            }
            return imageList;
 

        }

        public static void AddToDatabase(RealEstateOfficeMvc.Domain.Image image)
        {
            using (var context = new RealEstateOfficeContext())
            {
                context.Images.Add(image);
                context.SaveChanges();
            }
                        
        }

    }
}
