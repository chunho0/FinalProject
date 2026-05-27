using System;
using System.Collections.Generic;
using System.Linq;
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
        public User(string username, string password, string role, string membership)
        {
            Username = username;
            Password = password;
            Role = role;
            Membership = membership;

        }

        public void DisplayUserDetails()
        {
            Console.WriteLine($"Username: \t\t{Username}");
            Console.WriteLine($"Password: \t\t{new string('*', Password.Length)}");//fun lil function to display the password as asterisks for security reasons
            Console.WriteLine($"Role: \t\t\t{Role}");
            Console.WriteLine($"Membership: \t\t{Membership}");
        }
        public virtual void DisplayGuestDetails()
        {
            //this method will be overridden in the guest class to display the guest details
            
        }
    }
}
