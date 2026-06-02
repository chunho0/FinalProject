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
        
        public string BookingDate;
        public string PassengerName;

        public Flight BookedFlight;

        public Booking(string bDate, string passName, Flight bookedF)
        {  
            
            BookingDate = bDate;
            PassengerName = passName;
            
            
            if (bookedF != null)
            {
                this.BookedFlight = new Flight()
                {
                    FlightNumber = bookedF.FlightNumber,
                    DepartureAirport = bookedF.DepartureAirport,
                    LandingAirport = bookedF.LandingAirport,
                    DepartureTime = bookedF.DepartureTime,
                    Price = bookedF.Price,
                    AvailableSeats = bookedF.AvailableSeats,
                    IsLastMinute = bookedF.IsLastMinute,
                    AircraftModel = bookedF.AircraftModel,
                };

                bookedF.AvailableSeats--;
            }
            else
            {
                this.BookedFlight = null;
            }
        }

        public void bookingDetail()
        {
            
            Console.WriteLine($"Booking Date: \t\t{BookingDate}");
            Console.WriteLine($"PassengerName: \t\t{PassengerName}");
            Console.WriteLine($"Flight Number: \t\t\t{BookedFlight.FlightNumber}");
            Console.WriteLine($"Departure Airport: \t\t{BookedFlight.DepartureAirport}");
            Console.WriteLine($"Landing Airport: \t\t{BookedFlight.LandingAirport}");
            Console.WriteLine($"Departure Time: \t\t{BookedFlight.DepartureTime}");
            Console.WriteLine($"Price: \t\t\t\t${BookedFlight.Price}");
            Console.WriteLine($"Aircraft Model: \t\t{BookedFlight.AircraftModel}");
            Console.WriteLine($"Available Seats: \t\t{BookedFlight.AvailableSeats}");
            Console.WriteLine($"Last Minute Flight: \t\t{BookedFlight.IsLastMinute}");
        }
        
   
    
    
    }

    
}
