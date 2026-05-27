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

        public string FlightNumber
        {
            get { return flightNumber; }
            set { flightNumber = value; }
        }

        public string DepartureAirport
        {
            get { return departureAirport; }
            set { departureAirport = value; }
        }

        public string LandingAirport
        {
            get { return landingAirport; }
            set { landingAirport = value; }
        }

        public string DepartureTime
        {
            get { return departureTime; }
            set { departureTime = value; }
        }

        public double Price
        {
            get { return price; }
            set { price = value; }
        }

        public int AvailableSeats
        {
            get { return availableSeats; }
            set { availableSeats = value; }
        }

        public bool IsLastMinute
        {
            get { return isLastMinute; }
            set { isLastMinute = value; }
        }

        public string AircraftModel
        {
            get { return aircraftModel; }
            set { aircraftModel = value; }
        }

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
