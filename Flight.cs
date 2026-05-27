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
    }
}
