using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstateOfficeMvc.Domain
{
    public class RealEstate
    {
        public int Id { get; set; }
        public int Typeofrealestate { get; set; }

        public int Area {get; set;}
        public decimal Price {get; set; }
        public int Roomamount {get; set; }
        public string Ownername {get; set; }
        public string Ownersurname {get; set; }
        public string City {get; set; }
        public string Street {get; set; }
        public string EstateAddress {get; set; }
        public DateTime Creationdate {get; set; }
        public DateTime Modificationdate {get; set;}
    }
}
