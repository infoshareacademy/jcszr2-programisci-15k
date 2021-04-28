using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Http;
using RealEstateOfficeMvc.Helpers;

namespace RealEstateOfficeMvc
{
    class UserDatabaseContext
    {
        public static List<Domain.User> ListOfUser()
        {
            List<Domain.User> UserList = new List<Domain.User>();

            using (var context = new RealEstateOfficeContext())
            {
                UserList = context.Users.ToList();
            }
            
            return UserList;

        }
             
        public static int Login(string login,string password,int usertypeorid)
        {

            List<Domain.User> userList = new List<Domain.User>();
            userList = UserDatabaseContext.ListOfUser();

            password = codePassword(password);
            var userToLog = (from x in userList where x.Login ==login && x.Password == password select x).SingleOrDefault<Domain.User>(); //codePassword(password)
            int userid = userToLog.Id;
            int output = 0;

            switch (usertypeorid)
            {
                case 1:
                    if (userToLog == null)
                    {
                        output = 0;
                    }
                    else
                    {
                        int typUser = (int)userToLog.UserType;
                        output = typUser;
                    };
                    break;
                    
                case 2:
                    output = userid;
                    break;
                default:
                    
                 break;
            }

            return output;

        }
      
       
        public static string  codePassword(string pass)
        {

            string hash;
            using (SHA256 sha256Hash = SHA256.Create())
            {
                //From String to byte array
                byte[] sourceBytes = Encoding.UTF8.GetBytes(pass);
                byte[] hashBytes = sha256Hash.ComputeHash(sourceBytes);
                hash = BitConverter.ToString(hashBytes).Replace("-", String.Empty);
            }
            return hash;
        }
        
    }
}
