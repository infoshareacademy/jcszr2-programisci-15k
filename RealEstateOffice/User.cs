using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace RealEstateOffice
{


    class User
    {
        public User()
        {
            _isIdSet = false;
        }


        public User(int ID, string Login, string Password, string Name, string Surname, string EmailAddress, int UserType)
        {
            this._id = ID;
            this._login = Login;
            this._password = Password;
            this._name = Name;
            this._surname = Surname;
            this._emailadress = EmailAddress;
            this._userType = (UserType)UserType;

        }

        private bool _isIdSet;


        private string _login;
        private string _password;
        private string _name;
        private string _surname;
        private string _emailadress;
        private UserType _userType;


        private int _id;

        public int Id
        {
            set
            {
                if (_isIdSet == true)
                {
                    throw new InvalidOperationException("id can only be set once");
                }
                _isIdSet = true;
                _id = value;
            }

            get
            {
                return this._id;
            }

        }

        public UserType TypeOfUserType
        {
            get => _userType;
            set => _userType = value;
        }

        public string Login { get => _login; set => _login = value; }
        public string Password { get => _password; set => _password = value; }
        public string Name { get => _name; set => _name = value; }
        public string Surname { get => _surname; set => _surname = value; }
        public string EmailAddress { get => _emailadress; set => _emailadress = value; }


        public enum UserType
        {
            Administrator =1 ,    // 1
            PracownikBiuraNieruchomości =2,   // 2
            Klient=3,      // 3
        }


    }
}
