using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstateOffice
{
    public class UserSession
    {
        // Po uwierzytelnieniu uzupelniamy poniższe properties'y i po wylogowaniu nullujemy
        //int userTyp;
        //string login

        public UserSession(int userType, string login)
        {
            this.UserType = userType;
            this.Login = login;
        }

        public int UserType;

        public string Login;

        public static string DisplayCurrentUser(UserSession userSession)
        {
            string nameOfUserType = "nie wiadomo kto";
            switch (userSession.UserType)
            {
                case 1:
                    nameOfUserType = "administrator";
                    break;
                case 2:
                    nameOfUserType = "pracownik biura nieruchomości";
                    break;
                case 3:
                    nameOfUserType = "klient";
                    break;
            }

            return $"Jesteś aktualnie zalogowany jako {userSession.Login}, {nameOfUserType}.";
        }
    }
}
