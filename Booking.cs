using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject_ChunHoChoy_PeilinWu
{
    public class Booking
    {
        public string BookingFlightID;
        public string BookingDate;
        public string PassengerName;
        public string BookedFlight;
        public Booking(string bFlightID, string bDate, string passName, string bookedf)
        {  
            BookingFlightID = bFlightID;
            BookingDate = bDate;
            PassengerName = passName;
            BookedFlight = bookedf;

        }
   
    
    
    }

    
}
