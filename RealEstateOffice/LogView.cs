using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstateOffice
{
    class LogView
    {
        public static void LogList(List<Log> logs)
        {
           // ID; LogDate; TypeOfCRUDOperation; UserName;
            //Oczekujemy listy obiektów logów z backendu
            Console.Clear();
            //test formatowania tabelki:
            Console.WriteLine(
                "----------------------------------------------------------------------------------------------------------------------");
            foreach (var log in logs)
            {
                Console.WriteLine($"|ID#{log.Id,-3} | {log.LogDate,-10} | {log.TypeOfCRUDOperation,10}| {log.UserName,15}|");
                Console.WriteLine(
                    "----------------------------------------------------------------------------------------------------------------------");
            }

            Console.ReadLine();
        }


    }
}
