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

        //properties for the fields
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        


        //constructor for the user class
        public User(string username, string password, string role)
        {
            Username = username;
            Password = password;
            Role = role;

        }
    }
}
