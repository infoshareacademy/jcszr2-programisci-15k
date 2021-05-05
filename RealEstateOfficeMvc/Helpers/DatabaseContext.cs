using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Castle.Core.Internal;
using Microsoft.EntityFrameworkCore;
using RealEstateOfficeMvc.Models;

namespace RealEstateOfficeMvc
{
    class DatabaseContext
    {
        public static List<Domain.RealEstate> RealEstatesFilter(Filter filter)
        {
            using (var context = new RealEstateOfficeContext())
            {
                IQueryable<Domain.RealEstate> query = context.RealEstates;

                if (!filter.Street.IsNullOrEmpty())
                    query = query
                        .Where(x => x.Street == filter.Street);

                if (!filter.City.IsNullOrEmpty())
                    query = query
                        .Where(x => x.City == filter.City);

                if (!filter.OwnerName.IsNullOrEmpty())
                    query = query
                        .Where(x => x.Ownername == filter.OwnerName);

                if (!filter.OwnerSurname.IsNullOrEmpty())
                    query = query
                        .Where(x => x.Ownersurname == filter.OwnerSurname);

                if (filter.TypesOfRealEstate.Any(x => x == true))
                {
                    List<int> chosenRealEstateTypes = new List<int>();
                    for (int i = 0; i < 5; i++)
                    {
                        if(filter.TypesOfRealEstate[i])
                            chosenRealEstateTypes.Add(i);
                    }
                    query = query
                        .Where(x => chosenRealEstateTypes.Contains(x.Typeofrealestate));
                }

                if (filter.PriceHighest != null)
                    query = query
                        .Where(x => x.Price <= filter.PriceHighest);

                if (filter.PriceLowest != null)
                    query = query
                        .Where(x => x.Price >= filter.PriceLowest);

                if (filter.AreaBiggest != null)
                    query = query
                        .Where(x => x.Area <= filter.AreaBiggest);

                if (filter.AreaSmallest != null)
                    query = query
                        .Where(x => x.Area >= filter.AreaSmallest);

                if (filter.RoomAmountBiggest != null)
                    query = query
                        .Where(x => x.Roomamount <= filter.RoomAmountBiggest);

                if (filter.RoomAmountSmallest != null)
                    query = query
                        .Where(x => x.Roomamount >= filter.RoomAmountSmallest);

                if (filter.CreationDateEarliest != null)
                    query = query
                        .Where(x => DateTime.Compare(x.Creationdate, (DateTime)filter.CreationDateEarliest) <= 0);

                if (filter.CreationDateLatest != null)
                    query = query
                        .Where(x => DateTime.Compare(x.Creationdate, (DateTime)filter.CreationDateLatest) >= 0);

                return query
                    .ToList();
            }
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
            var realEstateList = RealEstatesFilter(filter);  //gets hole list of Real Estates

            return realEstateList;

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
