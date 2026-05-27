using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject_ChunHoChoy_PeilinWu
{
    public class Guest : User
    {
        private string email;
        private string phonenumber;
        private string address;
        private string membership;
      
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Membership { get; set; }

        public Guest(string username, string password, string role, string membership, string email, string phoneNumber, string address) : base(username, password, role)
        {
            Email = email;
            PhoneNumber = phoneNumber;
            Address = address;
            Membership = membership;
        }

        public override void DisplayGuestDetails()
        {
            
            Console.WriteLine($"Membership: \t\t{Membership}");
            Console.WriteLine($"Email: \t\t\t{Email}");
            Console.WriteLine($"Phone Number: \t\t{PhoneNumber}");
            Console.WriteLine($"Address: \t\t{Address}");
        }

        public static Guest AddGuest(string role, string membership) // this method can be used in the guset loin as well cuz role and membership can be passed as parameters without user input
        {
            Console.WriteLine("\nEnter guest details:");
            Console.Write("Username: ");
            string username = Console.ReadLine();
            Console.Write("Password: ");
            string password = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Phone Number: ");
            string phoneNumber = Console.ReadLine();
            Console.Write("Address: ");
            string address = Console.ReadLine();

            Console.WriteLine("------Confirm Guest Details------");
            Console.WriteLine($"Username: {username}");
            Console.WriteLine($"Password: {password}");
            Console.WriteLine($"Email: {email}");
            Console.WriteLine($"Phone Number: {phoneNumber}");
            Console.WriteLine($"Address: {address}");

            Console.Write("Are the details correct? (Y/N): ");
            string confirmation = Console.ReadLine().ToUpper();
            if (confirmation == "Y")
            {
                Console.WriteLine("Guest Added");
                return new Guest(username, password, role, membership, email, phoneNumber, address);
            }
            else
            {
                Console.WriteLine("Cancelled adding guest.");
                return null;
            }
            
        }
    }
}
