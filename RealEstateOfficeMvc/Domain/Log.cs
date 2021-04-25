using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstateOfficeMvc.Domain
{
    public class Log
    {
        public int Id { get; set; }
        public DateTime Logdate { get; set; }
        public string Typeofcrudoperation { get; set; }
        public string UserName { get; set;}
    }
}
