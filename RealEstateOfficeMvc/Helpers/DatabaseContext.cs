using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using RealEstateOfficeMvc.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace RealEstateOfficeMvc
{
    class DatabaseContext
    {
        public static List<Domain.RealEstate> RealEstatesFilter(Filter filter)
        {
           
            List<Domain.RealEstate> RealEstateList = new List<Domain.RealEstate>();

            using(var context = new RealEstateOfficeContext())
            {
                RealEstateList = context.RealEstates.ToList();
            }


            return RealEstateList;
        }


        public static async Task<Domain.RealEstate> GetAsync(int id)
        {
            using (var context = new RealEstateOfficeContext())
            {
                var realEstate = await context.RealEstates.SingleAsync(x => x.Id == id);
                return realEstate;
            }
         
        }

        public static List<Domain.RealEstate> RealEstateChoice(Filter filter)   //List<RealEstate> 
        {
            List<Domain.RealEstate> realEstateList;
            List<Domain.RealEstate> filteredRealEstateList = new List<Domain.RealEstate>();
            realEstateList = RealEstatesFilter(filter);  //gets hole list of Real Estates

            for (var i = 0; i < realEstateList.Count; i++)
            {
                if (filter.TypeOfRealEstate != null &&
                    realEstateList[i].Typeofrealestate != (int)filter.TypeOfRealEstate)
                {
                    continue;
                }

                if (filter.PriceLowest != null &&
                    (realEstateList[i].Price < filter.PriceLowest))
                {
                    continue;
                }

                if (filter.PriceHighest != null &&
                    (realEstateList[i].Price > filter.PriceHighest))
                {
                    continue;
                }

                if (filter.AreaSmallest != null &&
                    (realEstateList[i].Area < filter.AreaSmallest))
                {
                    continue;
                }

                if (filter.AreaBiggest != null &&
                    (realEstateList[i].Area > filter.AreaBiggest))
                {
                    continue;
                }

                if (filter.RoomAmountSmallest != null &&
                    (realEstateList[i].Roomamount < filter.RoomAmountSmallest))
                {
                    continue;
                }

                if (filter.RoomAmountBiggest != null &&
                    (realEstateList[i].Roomamount > filter.RoomAmountBiggest))
                {
                    continue;
                }

                if (!string.IsNullOrEmpty(filter.OwnerName) &&
                    realEstateList[i].Ownername != filter.OwnerName)
                {
                    continue;
                }

                if (!string.IsNullOrEmpty(filter.OwnerSurname) &&
                    realEstateList[i].Ownersurname != filter.OwnerSurname)
                {
                    continue;
                }

                if (!string.IsNullOrEmpty(filter.City) &&
                    realEstateList[i].City != filter.City)
                {
                    continue;
                }

                if (!string.IsNullOrEmpty(filter.Street) &&
                    realEstateList[i].Street != filter.Street)
                {
                    continue;
                }

                if (filter.CreationDateEarliest != null &&
                    (DateTime.Compare(realEstateList[i].Creationdate, (DateTime)filter.CreationDateEarliest) < 0))
                {
                    continue;
                }

                if (filter.CreationDateLatest != null &&
                    (DateTime.Compare(realEstateList[i].Creationdate, (DateTime)filter.CreationDateLatest) > 0))
                {
                    continue;
                }

                filteredRealEstateList.Add(realEstateList[i]);
            }

            return filteredRealEstateList;

        }

         
        public static string bingPathToAppDir(string localPath)
        {
            string currentDir = Environment.CurrentDirectory;
            DirectoryInfo directory = new DirectoryInfo(
            Path.GetFullPath(Path.Combine(currentDir, @"..\..\" + localPath)));
            return directory.ToString();
        }

      
    }
}
