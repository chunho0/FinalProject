using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace FinalProject_ChunHoChoy_PeilinWu
{
    public class Customer
    {
        private string firstName;
        private string lastName;
        private int phoneNumber;
        private string email;

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int PhoneNumber { get; set; }
        public string Email { get; set; }

        public Customer( string fn, string ln, int pn, string eml) 
        { 
            FirstName = fn;
            LastName = ln;
            PhoneNumber = pn;
            Email = eml;
        }
        
       

    }
}
