using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstateOfficeMvc.Domain
{
    public class FavouriteRealEstate
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int RealEstateId { get; set; }
    }
}
