using System.Diagnostics;

namespace FinalProject_ChunHoChoy_PeilinWu
{
    internal class Program
    {
        //create a users list
        static List<User> users = new List<User>();
        //create a flight list
        static List<Flight> flights = new List<Flight>();
        
        

        static void Main(string[] args)
        {
            //defining the bool variable for the menu's while loop
            bool run = true;

            // add admin object in user class
            User admin = new User("admin", "admin", "admin");
            Guest test1 = new Guest("test1", "00000000", "guest", "bronze", "test001@example.com", "02000000001", "WELLINGTON");
            Guest test2 = new Guest("test2", "00000000", "guest", "silver", "test002@example.com", "02000000002", "AUCKLAND");
            Guest test3 = new Guest("test3", "00000000", "guest", "gold", "test003@example.com", "02000000003", "CHRISTCHURCH");
            //added 3 test users for testing purpose
            //add object to list
            users.Add(admin);
            users.Add(test1);
            users.Add(test2);
            users.Add(test3);

            //adding 3 demo flights
            //this is for testing purposes
            //because i was writing the code without those 3 demo flight
            //and when i did the test runs i have to manually add flights everytime which is very annoying
            Flight demoFlight1 = new Flight("NZ001", "WEL", "AUC", "29/06/2026 08:30", 110, 180, false, "Airbus A320");
            Flight demoFlight2 = new Flight("NZ002", "AUC", "WEL", "30/06/2026 05:30", 155, 350, false, "Boeing 777");
            Flight demoFlight3 = new Flight("NZ003", "WEL", "AUC", "29/06/2026 11:30", 125, 70, false, "ATR 72");

            //add demo flights to flight list
            flights.Add(demoFlight1);
            flights.Add(demoFlight2);
            flights.Add(demoFlight3);

            //creating the menu using do while loop
            do
            {
                Console.WriteLine("\n\n---------- Flight Reservation System ----------");

                Console.WriteLine("\t\t 1. Admin Login");
                Console.WriteLine("\t\t 2. Guest Login");
                Console.WriteLine("\t\t 3. Guest Register");
                Console.WriteLine("\t\t 4. Exit");

                Console.Write("\n\nChoose an option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine($"\nYou have selected {choice}. Admin Login");
                        AdminLogin();//call the admin login method
                        break;

                    case "2":
                        Console.WriteLine($"\nYou have selected {choice}. Guest Login");
                        break;

                    case "3":
                        Console.WriteLine($"\nYou have selected {choice}. Guest Register");
                        break;

                    case "4":
                        Console.WriteLine($"\nYou have selected {choice}. Exit");
                        run = false;
                        break;

                    default:
                        Console.WriteLine("\nInvalid option");
                        break;
                }

            } while (run);//end of menu
        }//end of main

        static void AdminLogin()
        {
            Console.WriteLine("\n\n---------- Admin Login ----------");

            //ask user for username and password(this is for the admin to login
            Console.Write("\nUsername:");
            string username = Console.ReadLine();
            Console.Write("\nPassword:");
            string password = Console.ReadLine();


            //this is the logic for admin login
            //my logic is to check the username first, if the username is correct then check the password
            //if the password is correct then check the role, if the role is correct then login successful
            //if any of them is wrong then show the error message and return to the menu
            foreach (User user in users)
            {
                if (user.Username.ToUpper() == username.ToUpper())//check username first//added new thing !!! toupper is to make it more user friendly
                    //i have noticed most of the website with the user login system will ignore the case of the user name
                {
                    if (user.Password != password)//wrong password
                    {
                        Console.WriteLine("\nWrong password...");
                        return;
                    }
                    if (user.Role != "admin")//wrong role
                    {
                        Console.WriteLine("\nUnauthorized...");
                        return;
                    }

                    Console.WriteLine("\nAdmin login successful..."); //successful
                    AdminMenu();//call AdminMenu method
                    return;
                }
            }

            Console.WriteLine("\nUsername not found...");//this is for the wrong username
        }//end of admin login method

        //adminMenu method
        static void AdminMenu()
        {
            bool adminRun = true;

            while (adminRun)
            {
                Console.WriteLine("\n\n---------- Admin Menu ----------");
                Console.WriteLine("\t1. Add Flight");
                Console.WriteLine("\t2. Update Flight");
                Console.WriteLine("\t3. Remove Flight");
                Console.WriteLine("\t4. Display Flight");
                Console.WriteLine("\t5. Search Flight");
                Console.WriteLine("\t6. View Booking");
                Console.WriteLine("\t7. Manage User Account");
                Console.WriteLine("\t8. Logout");
                Console.Write("\nChoose an option: ");

                string choice = Console.ReadLine();


                switch (choice)
                {
                    case "1":
                        Console.WriteLine($"\nYou have selected {choice}. Add Flight...");
                        AddFlight();//call the add flight method
                        break;

                    case "2":
                        Console.WriteLine($"\nYou have selected {choice}. Update Flight...");
                        UpdateFlight();//adding update flight method
                        break;

                    case "3":
                        Console.WriteLine($"\nYou have selected {choice}. Remove Flight...");
                        RemoveFlight();//adding remove flight method
                        break;

                    case "4":
                        Console.WriteLine($"\nYou have selected {choice}. Display Flight...");
                        DisplayFlights();//adding displayflight method
                        break;

                    case "5":
                        Console.WriteLine($"\nYou have selected {choice}. Search Flight...");
                        SearchFlight();//adding search flight method
                        break;

                    case "6":
                        Console.WriteLine($"\nYou have selected {choice}. View Booking...");
                        break;

                    case "7":
                        Console.WriteLine($"\nYou have selected {choice}. Manage User Account...");
                        UserAccountManager();//adding user account manager method
                        break;

                    case "8":
                        Console.WriteLine($"\nYou have selected {choice}. Logout...");
                        Console.WriteLine("Logging out...");
                        Console.WriteLine("Logged out...");
                        adminRun = false;
                        break;

                    default:
                        Console.WriteLine("\nInvalid option...");
                        break;
                }

            }
        }//end of adminmenu method

        //DisplayFlights method
        static void DisplayFlights()
        {

            int flightIndex = 1;

            Console.WriteLine("\n\n----------Flight Details----------");

            if (flights.Count == 0)
            {
                Console.WriteLine("\nNo flights available...");
                return;
            }//end of if statement
            foreach (Flight flightD in flights)
            {
                Console.WriteLine($"\n\n----------Flight{flightIndex} Detail ----------");
                flightD.DisplayFlightDetails();
                flightIndex++;
            }//end of foreach loop
        }//end of display method

        //creating the add flight method
        static void AddFlight()
        {
            Console.WriteLine("\n\n---------- Add Flight ----------");

            Console.Write("Flight Number: ");
            string flightNumber = Console.ReadLine().ToUpper(); ;

            Console.Write("Departure Airport: ");
            string departureAirport = Console.ReadLine().ToUpper();

            Console.Write("Landing Airport: ");
            string landingAirport = Console.ReadLine().ToUpper();

            Console.Write("Departure Time (dd/mm/yyyy hh:mm(in 24 hour)): ");
            string departureTimeInput = Console.ReadLine();
            DateTime departureTime = DateTime.Parse(departureTimeInput);

            Console.Write("Price: ");
            double price = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("\nChoose Aircraft Model:");
            Console.WriteLine("Modle\t\t\tAvailable Seats");
            Console.WriteLine("1. ATR 72\t\t70 Seats");
            Console.WriteLine("2. Airbus A320\t\t180 Seats");
            Console.WriteLine("3. Boeing 777\t\t350 Seats");

            Console.Write("Selection: ");
            int aircraftChoice = Convert.ToInt32(Console.ReadLine());

            string aircraftModel = Flight.GetAircraftModel(aircraftChoice);
            int availableSeats = Flight.GetAvailableSeats(aircraftModel);
            bool isLastMinute = Flight.CheckLastMinute(departureTime);

            Flight newFlight = new Flight(flightNumber, departureAirport, landingAirport, departureTimeInput, price, availableSeats, isLastMinute, aircraftModel);

            //asking for confirmation before adding the flight
            Console.WriteLine("\n\n---------- Confirm Flight Details ----------");

            //calling the method in the flight class to display
            //this is exactly the part to save some coding
            newFlight.DisplayFlightDetails();

            Console.Write("\n\nConfirm Flight? (Y/N): ");
            string confirmFlightAdd = Console.ReadLine();

            if (confirmFlightAdd.ToLower() == "y")
            {
                flights.Add(newFlight);

                Console.WriteLine("\nFlight has been added...");
            }
            else
            {
                Console.WriteLine("\nCancelled...");

            }
        }//end of add flight method

        //adding search flight method
        //my plan is to use 2 ways to search the flight, one is by flight number and the other is by departure and landing airport
        //i will make the basic structure first and i am trying to make the user interface in the program cs and the logic in the flight class
        static void SearchFlight()
        {
            Console.WriteLine("\n\n----------Search Flights----------");

            // this is for displaying when there are no flight available for the search
            //
            if (flights.Count == 0)
            {
                Console.WriteLine("\nNo flights available...");
                return;
            }

            //this is the search type menu
            Console.WriteLine("1. Search by Flight Number");
            Console.WriteLine("2. Search by Route and Date");

            Console.Write("\nChoose search type: ");
            string choice = Console.ReadLine();

            int matchCount = 0;

            //user interface for search by flight number
            if (choice == "1")
            {
                Console.Write("Enter flight number: ");
                string searchNumber = Console.ReadLine().ToUpper();

                //use foreach loop to search the flight in the flight list
                foreach (Flight flight in flights)
                {
                  if (flight.FlightNumber.ToUpper() == searchNumber.ToUpper())
                    {
                        Console.WriteLine();
                        Console.WriteLine($"\n\n----------Flight Detail ----------");
                        flight.DisplayFlightDetails();
                        matchCount++;
                    }
                }
                //display match count
                if (matchCount == 0)
                {
                    Console.WriteLine("\nNo matching flight available");

                }
                else if (matchCount == 1)
                {
                    Console.WriteLine("\nThere is 1 flight available");
                }
                else
                {
                    Console.WriteLine($"\nThere are {matchCount} flights available");
                }
            }
            else if (choice == "2")
            {
                Console.WriteLine("Enter departure airport: ");
                string searchDepartureAirport = Console.ReadLine().ToUpper();

                Console.WriteLine("Enter landing airport: ");
                string searchLandingAirport = Console.ReadLine().ToUpper();

                Console.WriteLine("\nEnter departure date (dd/mm/yyyy): ");
                DateTime searchDate = Convert.ToDateTime(Console.ReadLine());

                //use foreach loop to search the flight in the flight list
                foreach (Flight flight in flights)
                {
                    DateTime flightDepartureDate = Convert.ToDateTime(flight.DepartureTime);//converting the departuretime in the list from string to DateTime datatype
                    if (flight.DepartureAirport.ToUpper() == searchDepartureAirport.ToUpper() &&
                        flight.LandingAirport.ToUpper() == searchLandingAirport.ToUpper() &&
                        flightDepartureDate.Date == searchDate.Date)//only need to compare the date part because this is accoring to the user habbit
                    {
                        Console.WriteLine();
                        Console.WriteLine($"\n\n----------Flight Detail ----------");
                        flight.DisplayFlightDetails();
                        matchCount++;
                    }
                }
                //display match count
                if (matchCount == 0)
                {
                    Console.WriteLine("\nNo matching flight available");

                }
                else if (matchCount == 1)
                {
                    Console.WriteLine("\nThere is 1 flight available");
                }
                else
                {
                    Console.WriteLine($"\nThere are {matchCount} flights available");
                }
            }
        }//end of search flight method

        //creating update flight method
        static void UpdateFlight()
        {      
            Console.WriteLine("\n\n---------- Update Flight ----------");

            if (flights.Count == 0)
            {
                Console.WriteLine("\nNo flights available...");
                return;
            }

            Console.Write("Enter flight number to update: ");
            string updateFlightNumber = Console.ReadLine().ToUpper();

            foreach (Flight flight in flights)
            {
                if (flight.FlightNumber.ToUpper() == updateFlightNumber)
                {
                    flight.DisplayFlightDetails();
                    Console.WriteLine();
                    Console.WriteLine("----------------------------------");
                    Console.WriteLine("\nWhat do you want to update?");
                    Console.WriteLine("1. Departure Airport");
                    Console.WriteLine("2. Landing Airport");
                    Console.WriteLine("3. Departure Time");
                    Console.WriteLine("4. Price");
                    Console.WriteLine("5. Aircraft Model");

                    Console.Write("\nChoose an option: ");
                    string updateChoice = Console.ReadLine();

                    //i just find that i have to add a corfirmation befor actually changing the details
                    //because if i dont, the moment the switch case runs, the details will be changed
                    //im planning to add some new tempNew variables to temperarily store the new details and
                    //after the confirmation, i will assign those tempNew values to the list object
                    string tempNewDepartureAirport = flight.DepartureAirport;
                    string tempNewLandingAirport = flight.LandingAirport;
                    string tempNewDepartureTime = flight.DepartureTime;
                    double tempNewPrice = flight.Price;
                    string tempNewAircraftModel = flight.AircraftModel;
                    int tempNewAvailableSeats = flight.AvailableSeats;
                    bool tempNewIsLastMinute = flight.IsLastMinute;

                    switch (updateChoice)
                    {
                        case "1":
                            Console.Write("New Departure Airport: ");
                            tempNewDepartureAirport = Console.ReadLine().ToUpper();
                            break;

                        case "2":
                            Console.Write("New Landing Airport: ");
                            tempNewLandingAirport = Console.ReadLine().ToUpper();
                            break;

                        case "3":
                            Console.Write("New Departure Time (dd/mm/yyyy hh:mm): ");
                            tempNewDepartureTime = Console.ReadLine();
                            tempNewIsLastMinute = Flight.CheckLastMinute(Convert.ToDateTime(tempNewDepartureTime));
                            //Flight.CheckLastMinute(Convert.ToDateTime(tempNewDepartureTime));
                            //got an error when i try to do the update and this is for debugging purpose to check the time left until departure
                            break;

                        case "4":
                            Console.Write("New Price: ");
                            tempNewPrice = Convert.ToDouble(Console.ReadLine());
                            break;

                        case "5":
                            Console.WriteLine("\nChoose New Aircraft Model:");
                            Console.WriteLine("1. ATR 72");
                            Console.WriteLine("2. Airbus A320");
                            Console.WriteLine("3. Boeing 777");

                            Console.Write("Selection: ");
                            int aircraftChoice = Convert.ToInt32(Console.ReadLine());
                            tempNewAircraftModel = Flight.GetAircraftModel(aircraftChoice);
                            tempNewAvailableSeats = Flight.GetAvailableSeats(tempNewAircraftModel);
                            break;

                        default:
                            Console.WriteLine("\nInvalid update option...");
                            return;
                    }

                    //displaying the new flight details for confirmation
                    Console.WriteLine("\n\n---------- Updated Flight Preview ----------");

                    Console.WriteLine($"Flight Number: \t\t\t{flight.FlightNumber}");
                    Console.WriteLine($"Departure Airport: \t\t{tempNewDepartureAirport}");
                    Console.WriteLine($"Landing Airport: \t\t{tempNewLandingAirport}");
                    Console.WriteLine($"Departure Time: \t\t{tempNewDepartureTime}");
                    Console.WriteLine($"Price: \t\t\t\t${tempNewPrice}");
                    Console.WriteLine($"Aircraft Model: \t\t{tempNewAircraftModel}");
                    Console.WriteLine($"Available Seats: \t\t{tempNewAvailableSeats}");
                    Console.WriteLine($"Last Minute Flight: \t\t{tempNewIsLastMinute}");

                    Console.WriteLine("\nConfirm update? (Y/N): ");
                    string confirmUpdate = Console.ReadLine().ToUpper();

                    if (confirmUpdate == "Y")//when confirmed, assign the tempNew values to the list object
                    {
                        flight.DepartureAirport = tempNewDepartureAirport;
                        flight.LandingAirport = tempNewLandingAirport;
                        flight.DepartureTime = tempNewDepartureTime;
                        flight.Price = tempNewPrice;
                        flight.AircraftModel = tempNewAircraftModel;
                        flight.AvailableSeats = tempNewAvailableSeats;
                        flight.IsLastMinute = tempNewIsLastMinute;

                        Console.WriteLine("\nFlight updated successfully.");
                        flight.DisplayFlightDetails();
                    }
                    else
                    {
                        Console.WriteLine("\nUpdate cancelled...");
                    }
                    return;
                }
            }

            Console.WriteLine("\nFlight not found...");

            //this logic is almost the same as the search flight and add flight method
        }//end of update flight method

        //creating removeflight method
        static void RemoveFlight()
        {
            Console.WriteLine("\n\n---------- Remove Flight ----------");
            if (flights.Count == 0)
            {
                Console.WriteLine("\nNo flights available...");
                return;
            }
            Console.Write("Enter flight number to remove: ");
            string removeFlightNumber = Console.ReadLine().ToUpper();
            foreach (Flight flight in flights)
            {
                if (flight.FlightNumber.ToUpper() == removeFlightNumber)
                {
                    flight.DisplayFlightDetails();
                    Console.WriteLine();
                    Console.WriteLine("----------------------------------");
                    Console.Write("\nConfirm removing this flight?(Y/N): ");
                    string confirmRemove = Console.ReadLine().ToUpper();
                    if (confirmRemove == "Y")
                    {
                        flights.Remove(flight);
                        Console.WriteLine("\nFlight removed successfully...");
                    }
                    else
                    {
                        Console.WriteLine("\nRemove cancelled...");
                    }
                    return;
                }
            }
            Console.WriteLine("\nFlight not found...");
        }//end of remove flight method


        //creating user account manager method
        static void UserAccountManager()
        {
            bool userAccountManagerRun = true;
            while (userAccountManagerRun)
            {
                Console.WriteLine("\n\n------------ User Account Manager ----------");
                Console.WriteLine("\t1. Display Users");
                Console.WriteLine("\t2. Add User");
                Console.WriteLine("\t3. Remove User");
                Console.WriteLine("\t4. Modify User");
                Console.WriteLine("\t5. Back to Admin Menu");

                Console.Write("\nChoose an option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine($"\nYou have selected {choice}. Display Users...");
                        Console.WriteLine();
                        Console.WriteLine("\n\n---------- User Detail ----------");
                        int userIndex = 0;
                        foreach (User user in users)
                        {
                            Console.WriteLine($"User {userIndex + 1}:");
                            Console.WriteLine();
                            user.DisplayUserDetails();
                            user.DisplayGuestDetails();
                            userIndex++;
                        }
                        break;
                    case "2":
                        Console.WriteLine($"\nYou have selected {choice}. Add User...");
                        Console.WriteLine();
                        Console.WriteLine("\n\n---------- Add User ----------");
                        Console.WriteLine("1. Admin");
                        Console.WriteLine("2. Guest");

                        Console.Write("Enter Choice: ");
                        string userTypeChoice = Console.ReadLine();
                        switch (userTypeChoice)
                        {
                            case "1":
                                Console.WriteLine("\nYou have selected to add an Admin...");
                                User newAdmin = User.AddAdmin("admin");//calling add admin method
                                if (newAdmin != null)
                                {
                                    users.Add(newAdmin);
                                }
                                break;

                            case "2":
                                Console.WriteLine("\nYou have selected to add a Guest...");
                                Guest newGuest = Guest.AddGuest("guest", User.ChooseMembership());//calling addguest method and admin can choose membership
                                if (newGuest != null)
                                {
                                    users.Add(newGuest);
                                }
                                break;

                            default:
                                Console.WriteLine("\nInvalid user type option...");
                                return;
                        }

                        
                        Console.WriteLine("\nUser added successfully...");
                        break;
                    case "3":
                        Console.WriteLine($"\nYou have selected {choice}. Remove User...");
                        break;
                    case "4":
                        Console.WriteLine($"\nYou have selected {choice}. Modify User...");
                        break;
                    case "5":
                        Console.WriteLine($"\nYou have selected {choice}. Back to Admin Menu...");
                        userAccountManagerRun = false;
                        return;
                    default:
                        Console.WriteLine("\nInvalid option...");
                        break;
                }
            }
        }//end of user account manager method








    }//end of program
}
