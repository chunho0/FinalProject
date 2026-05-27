using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject_ChunHoChoy_PeilinWu
{
    public class Flight
    {
        //creting fields
        //this are the variable will be needed for all the flight details
        private string flightNumber;
        private string departureAirport;
        private string landingAirport;
        private string departureTime;
        private double price;
        private int availableSeats;
        private bool isLastMinute;
        private string aircraftModel;

        //properties for the fields
        public string FlightNumber { get; set; }
        public string DepartureAirport { get; set; }

        public string LandingAirport { get; set; }

        public string DepartureTime { get; set; }

        public double Price { get; set; }

        public int AvailableSeats { get; set; }

        public bool IsLastMinute { get; set; }

        public string AircraftModel { get; set; }

        //constructor for the flight class
        public Flight(string flightNumber, string departureAirport, string landingAirport, string departureTime, double price, int availableSeats, bool isLastMinute, string aircraftModel)
        {
            FlightNumber = flightNumber;
            DepartureAirport = departureAirport;
            LandingAirport = landingAirport;
            DepartureTime = departureTime;
            Price = price;
            AvailableSeats = availableSeats;
            IsLastMinute = isLastMinute;
            AircraftModel = aircraftModel;
        }

        //adding display method to display the flight details
        //this was previously in the program class but i think
        //it is better to put it in the flight class because
        //it is more related to the flight details
        //and i can reuse this method whenever i want to display the flight details

        public void DisplayFlightDetails()
        {
            Console.WriteLine($"\n\n----------Flight Detail ----------");
            Console.WriteLine($"Flight Number: \t\t\t{FlightNumber}");
            Console.WriteLine($"Departure Airport: \t\t{DepartureAirport}");
            Console.WriteLine($"Landing Airport: \t\t{LandingAirport}");
            Console.WriteLine($"Departure Time: \t\t{DepartureTime}");
            Console.WriteLine($"Price: \t\t\t\t${Price}");
            Console.WriteLine($"Aircraft Model: \t\t{AircraftModel}");
            Console.WriteLine($"Available Seats: \t\t{AvailableSeats}");
            Console.WriteLine($"Last Minute Flight: \t\t{IsLastMinute}");
        }
    }
}
