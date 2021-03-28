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

        public static void AddToDatabase(RealEstateOfficeMvc.Models.Favourite favourite)
        {
            String path = "\\Files\\FavouriteRealEstate.csv";
            // pobieram ID z ostatniej linijki w Images.csv
            string testpath = Directory.GetCurrentDirectory();
            string relativePath = testpath + path;  // fullpath

            string lastLine = "0";
            if (new FileInfo(relativePath).Length != 0)
            {
                lastLine = File.ReadLines(relativePath).Last();
            }
           
            string[] columns = lastLine.Split(";");
            var lastId = Convert.ToInt32(columns[0]);

            //ID; UserID,RealEstateID

            StringBuilder sb = new StringBuilder();
            if (Convert.ToInt16(lastId) > 0)
            {
                sb.AppendLine("");
            }
            sb.Append(lastId + 1); //Id = lastId + 1
            sb.Append(";");
            sb.Append(favourite.UserID);
            sb.Append(";");
            sb.Append(favourite.Realestateid);
            sb.Append(";");
            
            using (StreamWriter sw = File.AppendText(relativePath))
            {
                sw.Write(sb);
            }
        }




        public static List<RealEstateOfficeMvc.Models.Favourite> ListOfFavourites()
        {
            String path = "\\Files\\FavouriteRealEstate.csv";
            // pobieram ID z ostatniej linijki w FavouriteRealEstate.csv
            string testpath = Directory.GetCurrentDirectory();
            string relativePath = testpath + path;  // fullpath


            string lastLine = "0";
            if (new FileInfo(relativePath).Length != 0)
            {
                lastLine = File.ReadLines(relativePath).Last();
            }

            
            List<RealEstateOfficeMvc.Models.Favourite> FavouriteList = new List<RealEstateOfficeMvc.Models.Favourite>();

            using (StreamReader reader = new StreamReader(relativePath))
            {
                string line;

                while ((line = reader.ReadLine()) != null)
                {
                    // ID; Login; Password; Name; Surname; EmailAddress; UserType;
                    FavouriteList.Add(new RealEstateOfficeMvc.Models.Favourite(Convert.ToInt32(ParseTextLine(line, 0)), Convert.ToInt32(ParseTextLine(line, 1)), Convert.ToInt32(ParseTextLine(line, 2))));

                }
            }
            return FavouriteList;

        }

        static string ParseTextLine(string Line, int column)
        {
            string[] columns = Line.Split(";");
            string output = columns[column];
            return output;
        }


    }
}
