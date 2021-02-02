using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstateOffice
{
    class User
    {
       //odpowiednik jednego wiersza w Users.csv
       //posiada pola ID;UserType; Login; Password; Name; Surname; EmailAddress;
       //pole enum userType które wyznacza uprawnienia (admin = 0, pracownik biura nieruchomości = 1, klient = 2
       private int _id;
       private UserType _userType;
       private string _login;
       private string _password;
       private string _name;
       private string _surname;
       private string _emailAddress;

        public int Id { get => _id; set => _id = value; }
        public UserType UserType { get => _userType; set => _userType = value; }
        public string Login { get => _login; set => _login = value; }
        public string Password { get => _password; set => _password = value; }
        public string Name { get => _name; set => _name = value; }
        public string Surname { get => _surname; set => _surname = value; }
        public string EmailAddress { get => _emailAddress; set => _emailAddress = value; }
        
    }

    public enum UserType
    {
        Admin,    // 0
        Employee,   // 1
        Client,      // 2
       
    }
}
