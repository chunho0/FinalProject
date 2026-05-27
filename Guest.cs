using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject_ChunHoChoy_PeilinWu
{
    public class Guest : User
    {
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }

        public Guest(string username, string password, string role, string membership, string email, string phoneNumber, string address) : base(username, password, role, membership)
        {
            Email = email;
            PhoneNumber = phoneNumber;
            Address = address;
        }

        public override void DisplayGuestDetails()
        {
            

            Console.WriteLine($"Email: \t\t\t{Email}");
            Console.WriteLine($"Phone Number: \t\t{PhoneNumber}");
            Console.WriteLine($"Address: \t\t{Address}");
        }
    }
}
