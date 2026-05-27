using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject_ChunHoChoy_PeilinWu
{
    public class User
    {
        //fields for user details
        //this is the parent class for all the users
        //including the admin and the customer
        private string username;
        private string password;
        private string role;
        private string membership;//adding this for future use

        //properties for the fields
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string Membership { get; set; }


        //constructor for the user class
        public User(string username, string password, string role)
        {
            Username = username;
            Password = password;
            Role = role;
        }

        public void DisplayUserDetails()
        {
            Console.WriteLine($"Username: \t\t{Username}");
            Console.WriteLine($"Password: \t\t{new string('*', Password.Length)}");//fun lil function to display the password as asterisks for security reasons
            Console.WriteLine($"Role: \t\t\t{Role}");
        }
        public virtual void DisplayGuestDetails()
        {
            //this method will be overridden in the guest class to display the guest details
            
        }

        public static string ChooseMembership()
        {
            Console.WriteLine("\nChoose a membership type:");
            Console.WriteLine("1. null");
            Console.WriteLine("2. Bronze");
            Console.WriteLine("3. Silver");
            Console.WriteLine("4. Gold");
            Console.Write("Selection: ");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    Console.WriteLine("No membership.");
                    return "null";
                case "2":
                    Console.WriteLine("You have selected Bronze membership.");
                    return "bronze";             
                case "3":
                    Console.WriteLine("You have selected Silver membership.");
                    return "silver";
                case "4":
                    Console.WriteLine("You have selected Gold membership.");
                    return "gold";
                default:
                    Console.WriteLine("Invalid choice. Defaulting to No membership.");
                    return "null";
            }       
        }

        public static User AddAdmin(string role)
        {
            Console.WriteLine("\nEnter admin details:");
            Console.Write("Username: ");
            string username = Console.ReadLine();
            Console.Write("Password: ");
            string password = Console.ReadLine();

            Console.WriteLine("------Confirm admin Details------");
            Console.WriteLine($"Username: {username}");
            Console.WriteLine($"Password: {password}");

            Console.Write("Are the details correct? (Y/N): ");
            string confirmation = Console.ReadLine().ToUpper();
            if (confirmation == "Y")
            {
                Console.WriteLine("Admin Added");
                return new User(username, password, "admin");
            }
            else
            {
                Console.WriteLine("Cancelled adding.");
                return null;
            }
        }
    }
}
