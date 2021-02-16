using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstateOffice
{
    class UsersView
    {//lista użytkowników
        public static void ListOfUsers(List<User> users)
        {
            //Oczekujemy listy obiektów User z backendu
            Console.Clear();
            //test formatowania tabelki:
            Console.WriteLine(
                "----------------------------------------------------------------------------------------------------------------------");
            foreach (var user in users)
            {
                Console.WriteLine($"|ID#{user.Id,-3} | {user.Login,-10} | {user.Password,10}| " +
                                  $"{user.Name,15} | {user.Surname,-15} | {user.EmailAddress,-12} | " +
                                  $"{user.TypeOfUserType,-7}|");
                Console.WriteLine(
                    "----------------------------------------------------------------------------------------------------------------------");
            }

            Console.ReadLine();
        }


    }

}
