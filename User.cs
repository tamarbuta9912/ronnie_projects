using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace RonnieProject
{
    internal class User
    {
        public static List<User> UserList = new List<User>();//רשימה שמכילה את כל היוזרים

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int URLIndex { get; set; }
        
        public static string[] ArrayUrl = { "https://randomuser.me/api/",
                                        "https://jsonplaceholder.typicode.com/users",
                                           " https://dummyjson.com/users",
                                           "https://reqres.in/api/users"
        };
        
        public User(string firstName, string lastName, string email, int index_of_url)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            URLIndex = index_of_url;

        }
        public static string GetUrl(int i)
        {
            return ArrayUrl[i];
        }
        public static void AddUrl(string url)
        {

            string[] newArray = new string[ArrayUrl.Length + 1];

            for (int i = 0; i < ArrayUrl.Length; i++)
            {
                newArray[i] = ArrayUrl[i];
            }

            newArray[newArray.Length - 1] = url;

        }

        public static List<User> GetUserFromSourse()
        {
            for (int i = 0; i < ArrayUrl.Length; i++)
            {
                string UrlPath = GetUrl(i);

                using (StreamReader reader = new StreamReader(UrlPath))
                {
                    Console.WriteLine(UrlPath);
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        string[] values = line.Split(',');

                        string FirstName = values[0];
                        string LasttName = values[1];
                        string email = values[2];

                        Console.WriteLine($"Name: {FirstName}, Age: {LasttName}, Email: {email}");


                        // בניית משתמש חדש מהנתונים שקיבלנו
                        User u = new User(FirstName, LasttName, email, i);
                        UserList.Add(u);
                    }
                }

            }
            return UserList;
        }



        public static void BuildJsonSorce(string path)//מקבלת נתיב של מיקום לשמירת קובץ JSON ושומרת שם את הנתונים
        {
            Console.WriteLine(path); ;
            try
            {
                // Write the JSON string to the specified file
                List<User> List = GetUserFromSourse();//getting the user list
                string json = JsonConvert.SerializeObject(List, Formatting.Indented);

                File.WriteAllText(path, json);

                Console.WriteLine("JSON data has been saved to the file.");
            }
            catch (IOException ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }

        public static void BuildCSVSorce(string path)//מקבלת נתיב של מיקום לשמירת קובץ SCV ושומרת שם את הנתונים
        {
            Console.WriteLine(path);

            List<User> List = GetUserFromSourse();//getting the user list



            StringBuilder csvData = new StringBuilder();

            // Add CSV headers
            csvData.AppendLine("FirsName,LastName,Email");

            foreach (var User in List)
            {
                csvData.AppendLine($"{User.FirstName},{User.LastName},{User.Email}");
            }



            string csvString = csvData.ToString();

            

            try
            {
                // Write the CSV data to the specified file
                File.WriteAllText(path, csvString);

                Console.WriteLine("CSV data has been saved to the file.");
            }
            catch (IOException ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }

        }

    }

    
}
