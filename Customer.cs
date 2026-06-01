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
        private string guestUserName;
        private string guestPassword;

        public string GuestUserName { get; set; }
        public string GuestPassword { get; set; }

        public Customer( string gusetN,string guestPw) 
        { 
            GuestUserName = gusetN;
            GuestPassword = guestPw;

        }
        
       

    }
}
