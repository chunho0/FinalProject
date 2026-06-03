using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject_ChunHoChoy_PeilinWu
{
    public class Booking
    {
        private string bookingDate;
        private string passengerName;
        
        public string BookingDate { get; set; }
        public string PassengerName { get; set; }
        public string UserId {  get; set; }

        public Flight BookedFlight;


        public Booking(string bDate, string passName, Flight bookedF)
        {
            BookingDate = bDate;
            PassengerName = passName;
            UserId = User.userLoggedIn?.Username;

            if (bookedF != null)
            {
                BookedFlight = bookedF;//fixing problem 1 P.WUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUU
                BookedFlight.AvailableSeats--;
            }
            else
            {
                BookedFlight = null;
            }
        }

        public void bookingDetail()
        {
            Console.WriteLine();
            Console.WriteLine($"Booked By: \t\t\t{UserId}");//fixing User Experience P1 P.WUUUUUUUUUUUUUUUUUUU
            Console.WriteLine($"Booking Date: \t\t\t{BookingDate}");
            Console.WriteLine($"PassengerName: \t\t\t{PassengerName}");
            Console.WriteLine($"Flight Number: \t\t\t{BookedFlight.FlightNumber}");
            Console.WriteLine($"Departure Airport: \t\t{BookedFlight.DepartureAirport}");
            Console.WriteLine($"Landing Airport: \t\t{BookedFlight.LandingAirport}");
            Console.WriteLine($"Departure Time: \t\t{BookedFlight.DepartureTime}");
            Console.WriteLine($"Price: \t\t\t\t${BookedFlight.Price}");
            Console.WriteLine();
            
        }
        
        public void BookingManagement()
        {
            Console.WriteLine();
            Console.WriteLine($"Booked By: \t\t\t{UserId}");//fixing User Experience P1 P.WUUUUUUUUUUUUUUUUUUU
            Console.WriteLine($"Booking Date: \t\t\t{BookingDate}");
            Console.WriteLine($"PassengerName: \t\t\t{PassengerName}");
            Console.WriteLine($"Flight Number: \t\t\t{BookedFlight.FlightNumber}");
            Console.WriteLine($"Departure Airport: \t\t{BookedFlight.DepartureAirport}");
            Console.WriteLine($"Landing Airport: \t\t{BookedFlight.LandingAirport}");
            Console.WriteLine($"Departure Time: \t\t{BookedFlight.DepartureTime}");
            Console.WriteLine($"Price: \t\t\t\t${BookedFlight.Price}");
            Console.WriteLine($"Aircraft Model: \t\t{BookedFlight.AircraftModel}");
            Console.WriteLine($"Available Seats: \t\t{BookedFlight.AvailableSeats}");
            Console.WriteLine($"Last Minute Flight: \t\t{BookedFlight.IsLastMinute}");
            Console.WriteLine();
        }



    }

    
}
