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
        }//end of DisplayFlightDetails method


        //add aircraft model method
        //previously i did it in the main and this is done by a huge block of code
        //with bunch of if statement but i think it is better to put it in the flight class
        public static string GetAircraftModel(int aircrafChoice)//passing the aircrafChoice parameter from the user input
        {
            if (aircrafChoice == 1)
            {
                return "ATR 72";
            }
            else if (aircrafChoice == 2)
            {
                return "Airbus A320";

            }
            else if (aircrafChoice == 3)
            {
                return "Boeing 777";
            }
            else
            { 
                return "Invalid choice. Please select a valid aircraft model.";
            }
        }//end of GetAircraftModel method

        //adding the seat count method with the input of the aircraft model
        //as the method above returned the model as string
        //i am gonna use sting to compare the models
        public static int GetAvailableSeats(string aircraftModel)
        {
            if (aircraftModel == "ATR 72")
            {
                return 70;
            }
            else if (aircraftModel == "Airbus A320")
            {
                return 180;
            }
            else if (aircraftModel == "Boeing 777")
            {
                return 350;
            }
            else
            {
                return 0;//if the model is invalid then return 0 available seats
            }
        }//end of GetAvailableSeats method

        //this is a upgraded fuction i would like to add later on but i will do the 
        //basic coding here and then i might add this feature later on
        public static bool CheckLastMinute(DateTime departureTime)
        {
            TimeSpan timeLeft = departureTime - DateTime.Now;
            //i will set the last minute flight 2 hours before departure
            if(timeLeft.TotalMinutes <= 120 && timeLeft.TotalMinutes >= 0)
            {
                return true;
            }
            return false;
        }//end of CheckLastMinute method

        //search method by flight number
        public bool MatchFlightNumber(string searchNumber)
        {
            return FlightNumber.ToUpper() == searchNumber.ToUpper();
        }//end of MatchFlightNumber method

    }
}
