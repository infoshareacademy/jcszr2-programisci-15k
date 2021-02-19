using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstateOffice
{
   public static class MyIdentity
    {
        private static string _login;

        public static string GetLogin()
        {
            return _login;
        }

        public static void SetLogin(string login)
        {
            _login = login;
        }

    }
}
