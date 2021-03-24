using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstateOfficeMvc.Helpers
{
    public class ImagesContext
    {


        public static List<RealEstateOfficeMvc.Models.Image> ListOfImages()
        {
            String path = "\\Files\\Images.csv";
            // pobieram ID z ostatniej linijki w users.csv
            string testpath = System.IO.Directory.GetCurrentDirectory();
            string relativePath = testpath + path;  // fullpath
            var lastLine = File.ReadLines(relativePath).Last();

            List<RealEstateOfficeMvc.Models.Image> imageList = new List<RealEstateOfficeMvc.Models.Image>();

            using (StreamReader reader = new StreamReader(relativePath))
            {
                string line;

                while ((line = reader.ReadLine()) != null)
                {
                    // ID; Login; Password; Name; Surname; EmailAddress; UserType;
                    imageList.Add(new RealEstateOfficeMvc.Models.Image(Convert.ToInt32(ParseTextLine(line, 0)), Convert.ToInt32(ParseTextLine(line, 1)), ParseTextLine(line, 2)));

                }
            }
            return imageList;

        }


        public static List<RealEstateOfficeMvc.Models.Image>  GetImages(int id)
        {
            String path = "\\Files\\Images.csv";
            string testpath = Directory.GetCurrentDirectory();
            string relativePath = testpath + path;  // fullpath

            List<RealEstateOfficeMvc.Models.Image> imageList = new List<RealEstateOfficeMvc.Models.Image>();

            using (StreamReader reader = new StreamReader(relativePath))
            {
                string line;

                while ((line = reader.ReadLine()) != null)
                {
                    if (Convert.ToInt32(ParseTextLine(line, 1)) == id)
                    {

                        imageList.Add(new RealEstateOfficeMvc.Models.Image(Convert.ToInt32(ParseTextLine(line, 0)), Convert.ToInt32(ParseTextLine(line, 1)), ParseTextLine(line, 2)));
                    }

                }
            }
            return imageList;
        }






        static string ParseTextLine(string Line, int column)
        {
            string[] columns = Line.Split(";");
            string output = columns[column];
            return output;
        }
    }
}
