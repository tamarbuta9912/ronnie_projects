using System.IO;
using System;
using Newtonsoft.Json;



namespace RonnieProject
{
    class Program
    {

        static void Main()
        {
            Console.WriteLine("please enter your path");
            string path = Console.ReadLine();
            Console.WriteLine("please enter your format");
            string format = Console.ReadLine();



            if (format == "json" || format == "Json" || format == "JSON")
                User.BuildJsonSorce(path);
            if (format == "CSV" || format == "csv" || format == "Csv")
                User.BuildCSVSorce(path);
            else
                Console.WriteLine("enter good format!");


            Console.WriteLine("the amount of all users is: " + User.UserList.Count);


        }

       



        
     }
}


            

