using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstateOfficeMvc.Domain
{
    public class Image
    {
        public int Id { get; set; }
        public int RealEstateId { get; set; }
        public string Nazwapliku { get; set; }
    }
}
