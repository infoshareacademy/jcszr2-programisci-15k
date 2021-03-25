using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstateOfficeMvc.Models
{
    public class Image
    {
        //ID; RealEstateID; NazwaPliku

        public Image(int ID, int RealEstateID,  string FileName)
        {
            this._id = ID;
            this._realestateid = RealEstateID;
            this._filename = FileName;

        }


        private int _id;
        private int _realestateid;
        private string _filename;

        public int Id { get => _id; set => _id = value; }
        public int RealEstateID { get => _realestateid; set => _realestateid = value; }
        public string FileName { get => _filename; set => _filename = value; }
    }
}
