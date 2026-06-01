using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace FinalProject_ChunHoChoy_PeilinWu
{
    public class Customer : User
    {
        private string guestUserName;
        private string guestPassword;

        public string GuestUserName { get; set; }
        public string GuestPassword { get; set; }

        public Customer( string gusetN,string guestPw, string role): base(gusetN, guestPw, role)
        { 
            GuestUserName = gusetN;
            GuestPassword = guestPw;

        }
        
       

    }
}
