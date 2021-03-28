using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstateOfficeMvc.Models
{
    public class Favourite
    {

        //properties  userid  , realestateid


        public Favourite(int ID, int UserID, int Realestateid)
        {
            this._id = ID;
            this._userid = UserID;
            this._realestateid = Realestateid;
            

        }


        private int _id;
        private int _userid;
        private int _realestateid;

        public int Id { get => _id; set => _id = value; }
        public int UserID { get => _userid; set => _userid = value; }
        public int Realestateid { get => _realestateid; set => _realestateid = value; }
    }

        

}

