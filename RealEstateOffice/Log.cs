using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstateOffice
{
    //ID; LogDate; TypeOfCRUDOperation; UserName;
    class Log
    {
        public Log(int ID, DateTime LogDate,string TypeOfCRUDOperation,string UserName)
        {
            this.Id = ID;
            this._logDate = LogDate;
            this._typeOfCRUDOperation = TypeOfCRUDOperation;
            this._userName = UserName;

        }


        private int _id;
        private DateTime _logDate;
        private string _typeOfCRUDOperation;
        private string _userName;

        public DateTime LogDate { get => _logDate; set => _logDate = value; }
        public string TypeOfCRUDOperation { get => _typeOfCRUDOperation; set => _typeOfCRUDOperation = value; }
        public string UserName { get => _userName; set => _userName = value; }
        public int Id { get => _id; set => _id = value; }
    }
}
