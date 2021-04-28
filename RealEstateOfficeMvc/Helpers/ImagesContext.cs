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

        public static List<RealEstateOfficeMvc.Domain.Image>  GetImages(int id)
        {
            List<RealEstateOfficeMvc.Domain.Image> imageList = new List<RealEstateOfficeMvc.Domain.Image>();
            using ( var context = new RealEstateOfficeContext())
            {
                imageList = context.Images.Where(x => x.RealEstateId == id).ToList();
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
