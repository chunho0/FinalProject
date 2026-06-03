using System.Diagnostics;
using System.Globalization;

namespace FinalProject_ChunHoChoy_PeilinWu
{
    internal class Program
    {
        //create a users list
        static List<User> users = new List<User>();
        //create a flight list
        static List<Flight> flights = new List<Flight>();
        //create a customer list
        //static List<Guest> customer = new List<Guest>();
        //create a booking list
        static List<Booking> bookList = new List<Booking>();
        

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
                Console.WriteLine("\t\t 3. Exit");

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
                        DisplayCustomerMenu();
                        break;

                    case "3":
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
                Console.WriteLine("\t6. Booking Management");
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
                        Console.WriteLine($"\nYou have selected {choice}. Booking Management...");
                        BookingMenu();
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

            //int matchCount = 0;

            //user interface for search by flight number
            if (choice == "1")
            {
                Console.Write("Enter flight number: ");
                string searchNumber = Console.ReadLine().ToUpper();

                ////use foreach loop to search the flight in the flight list
                //foreach (Flight flight in flights)
                //{
                //  if (flight.FlightNumber.ToUpper() == searchNumber.ToUpper())
                //    {
                //        Console.WriteLine();
                //        Console.WriteLine($"\n\n----------Flight Detail ----------");
                //        flight.DisplayFlightDetails();
                //        matchCount++;
                //    }
                //}
                //use method from the class
                Flight foundFlight = Flight.SearchByFlightNumber(flights, searchNumber);

                if(foundFlight != null)
                {
                    foundFlight.DisplayFlightDetails();
                }
                else
                {
                    Console.WriteLine("\nNo matching flight available");
                }

                ////display match count
                //if (matchCount == 0)
                //{
                //    Console.WriteLine("\nNo matching flight available");

                //}
                //else if (matchCount == 1)
                //{
                //    Console.WriteLine("\nThere is 1 flight available");
                //}
                //else
                //{
                //    Console.WriteLine($"\nThere are {matchCount} flights available");
                //}
            }
            else if (choice == "2")
            {
                Console.WriteLine("Enter departure airport: ");
                string searchDepartureAirport = Console.ReadLine().ToUpper();

                Console.WriteLine("Enter landing airport: ");
                string searchLandingAirport = Console.ReadLine().ToUpper();

                Console.WriteLine("\nEnter departure date (dd/mm/yyyy): ");
                DateTime searchDate = Convert.ToDateTime(Console.ReadLine());

                List<Flight> matchingFlights = Flight.SearchByRouteAndDate(flights, searchDepartureAirport, searchLandingAirport, searchDate);
                //add search to the search temp list

                //use foreach loop to search the flight in the flight list
                foreach (Flight flight in matchingFlights)
                {
                    flight.DisplayFlightDetails();
                }
                if (matchingFlights.Count == 0)//moving the count logic out of the foreach loop to make sure it only run once after search-P.Wu
                {
                    Console.WriteLine("\nNo matching flight available");
                }
                else if (matchingFlights.Count == 1)
                {
                    Console.WriteLine("\nThere is 1 matching flight available");

                }
                else
                {
                    Console.WriteLine($"\nThere are {matchingFlights.Count} matching flights available");
                }
                
                
                

                ////display match count
                //if (matchCount == 0)
                //{
                //    Console.WriteLine("\nNo matching flight available");

                //}
                //else if (matchCount == 1)
                //{
                //    Console.WriteLine("\nThere is 1 flight available");
                //}
                //else
                //{
                //    Console.WriteLine($"\nThere are {matchCount} flights available");
                //}
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
                    foreach (Booking booking in bookList)//adding this logic to make sure when there is a booking with the flight, the flight can not be removed
                    {
                        if (booking.BookedFlight.FlightNumber.ToUpper() == removeFlightNumber.ToUpper())
                        {
                            Console.WriteLine("\nThis flight has bookings and cannot be removed...");
                            return;
                        }
                    }
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
                        
                        Console.WriteLine("\n\n---------- User Detail ----------");
                        int userIndex = 0;
                        foreach (User user in users)
                        {
                            Console.WriteLine();
                            Console.WriteLine($"User {userIndex + 1}:");
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
                                if (newAdmin != null)//fixing problem 3 P.WUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUU
                                {
                                    users.Add(newAdmin);
                                    Console.WriteLine("\nUser added successfully...");
                                }
                                break;

                            case "2":
                                Console.WriteLine("\nYou have selected to add a Guest...");
                                Guest newGuest = Guest.AddGuest("guest", User.ChooseMembership());//calling addguest method and admin can choose membership
                                if (newGuest != null)//fixing problem 3 P.WUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUU
                                {
                                    users.Add(newGuest);
                                    Console.WriteLine("\nUser added successfully...");
                                }
                                break;

                            default:
                                Console.WriteLine("\nInvalid user type option...");
                                return;
                        }
                        break;
                        
                    case "3":
                        Console.WriteLine($"\nYou have selected {choice}. Remove User...");
                        RemoveUserByAdmin();
                        break;
                    case "4":
                        Console.WriteLine($"\nYou have selected {choice}. Modify User...");
                        ModifyUserByAdmin();//this is the modify user method for admin, because admin need to select which account to modify
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

        //display the customer mean for login and create new account
        public static void DisplayCustomerMenu()
        {
            char answer = 'y';
            do
            {
                Console.WriteLine("1, Guest Login");
                Console.WriteLine("2, Register a new account");
                Console.WriteLine("3, Back to the login menu");
                string option = Console.ReadLine();
                switch (option)
                {
                    case "1":
                        Console.WriteLine($"\nYou have selected {option}. Guest Login");

                        Console.Write("Guest user name: ");
                        string guestLogin = Console.ReadLine();

                        Console.Write("Guest password: ");
                        string guestPassword = Console.ReadLine();
                        

                        foreach (User user in users)
                        {
                            if (user.Username.ToLower() == guestLogin.ToLower())
                            {
                                if (user.Password != guestPassword)
                                {
                                    Console.WriteLine("\nWrong password...");
                                    return;
                                }

                                if (user.Role.ToLower() != "guest")
                                {
                                    Console.WriteLine("\nUnauthorized...");
                                    return;
                                }
                                
                                User.userLoggedIn = user;
                                Console.WriteLine("\nGuest Login Successful........");
                                GuestMenu(user.Username);
                                return;
                            }
                        }

                        Console.WriteLine("\nGuest Username not found...");

                        break;

                    case "2":
                        //Console.WriteLine($"\nYou have selected {option}. Register a new account ");
                        //Console.Write("Please enter your user name:  ");
                        //string newGuestName = Console.ReadLine();
                        //Console.Write("Please enter your password: ");
                        //string newPassword = Console.ReadLine();
                        Guest newCustomer = Guest.AddGuest("guest", "null");

                        if (newCustomer == null)// fixing problem 2 P.WUUUUUUUUUUUUUUUUUUUUUUUUUUUUU
                        {
                            return;
                        }
                        foreach (User user in users)
                        {
                            if (user.Username.ToLower() == newCustomer.Username.ToLower())
                            {
                                Console.WriteLine("\nUsername already exists...");
                                return;
                            }
                        }

                        users.Add(newCustomer);

                        break;
                    case "3":
                        Console.WriteLine($"\nYou have selected {option}. back to login menu");
                        Console.WriteLine("Exiting.........");
                        return;
                    default:
                        Console.WriteLine("Please enter the correct number");
                        break;
                }
                Console.WriteLine("Do you wish to continue? (y/n)");
                answer = Convert.ToChar(Console.ReadLine());
            } while (answer != 'n');
        }//end of customer login menu

        //guest menu
        public static void GuestMenu(string userName)
        {
            bool guestRun = true;

            while (guestRun)
            {
                Console.WriteLine("\n\n---------- Guest Menu ----------");
                Console.WriteLine("\t1. Display Flight");
                Console.WriteLine("\t2. Search Flight");
                Console.WriteLine("\t3. Booking Flight");
                Console.WriteLine("\t4. Modify Flight Booking");
                Console.WriteLine("\t5. Remove Flight Booking");
                Console.WriteLine("\t6. View Flight Booking");
                Console.WriteLine("\t7. Display Guest Account");
                Console.WriteLine("\t8. Modify Guest Account");
                Console.WriteLine("\t9. Logout");
                Console.Write("\nChoose an option: ");

                string choice = Console.ReadLine();


                switch (choice)
                {

                    case "1":
                        Console.WriteLine($"\nYou have selected {choice}. Display Flight...");
                        DisplayFlights();//adding displayflight method
                        break;

                    case "2":
                        Console.WriteLine($"\nYou have selected {choice}. Search Flight...");
                        SearchFlight();//adding search flight method
                        break;

                    case "3":
                        Console.WriteLine($"\nYou have selected {choice}. Booking Flight...");
                        BookingFlight();
                        break;
                    case "4":
                        Console.WriteLine($"\nYou have selected {choice}. Modify Flight Booking...");
                        ModifyMyBooking();
                        break;
                    case "5":
                        Console.WriteLine($"\nYou have selected {choice}. Remove Flight Booking...");
                        RemoveMyBooking();
                        break;
                    case "6":
                        Console.WriteLine($"\nYou have selected {choice}. View Flight Booking...");
                        foreach(Booking booking in bookList)   
                        {
                            if (User.userLoggedIn != null)
                            {
                                string loginUser = User.userLoggedIn.Username;
                                string bookingOwner = booking.UserId;

                                if (bookingOwner.Equals(loginUser, StringComparison.OrdinalIgnoreCase))
                                {
                                    booking.bookingDetail();
                                }
                            }
                           

                        }

                        break;
                    case "7":
                        Console.WriteLine($"\nYou have selected {choice}. Display Guest Account...");
                        if(User.userLoggedIn != null)//display the guest account details
                        {
                            Console.WriteLine("\n*********Account Detail**********");

                            User.userLoggedIn.DisplayUserDetails();
                            User.userLoggedIn.DisplayGuestDetails();
                        }
                       
                        break;
                    case "8":
                        Console.WriteLine($"\nYou have selected {choice}. Modify Guest Account...");
                        ModifyAccount();
                        break;

                    case "9":
                        Console.WriteLine($"\nYou have selected {choice}. Logout...");
                        Console.WriteLine("Logging out...");
                        Console.WriteLine("Logged out...");
                        return;
                        

                    default:
                        Console.WriteLine("\nInvalid option...");
                        break;
                }

            }
        }//end of guest menu
        
        //create a modify account method
        public static void ModifyAccount()
        {
            User userFind = User.userLoggedIn;// storing userloggedin from the user class to a new variable
            if (userFind is Guest guestfind)
            {
                Console.WriteLine("----------Current User Detail----------");//fixing problem 4 P.WUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUU
                userFind.DisplayUserDetails();
                guestfind.DisplayGuestDetails();// display current detail before modification, more user friendly
                Console.WriteLine("\tWhich detail do you want to modify?");
                Console.WriteLine("\t1,User Name");
                Console.WriteLine("\t2,Password");
                Console.WriteLine("\t3,Email");
                Console.WriteLine("\t4,PhoneNumber");
                Console.WriteLine("\t5,Address");
                string choise = Console.ReadLine();

                switch (choise)
                {
                    case "1":
                        Console.Write("Enter the new user name: \n");
                        userFind.Username = Console.ReadLine();
                        Console.WriteLine("User name updated successful!");
                        break;
                    case "2":
                        Console.Write("Enter the new password: \n");
                        userFind.Password = Console.ReadLine();
                        Console.WriteLine("Password updated successful!");
                        break;
                    case "3":
                        Console.Write("Enter the new email: \n");
                        guestfind.Email = Console.ReadLine();
                        Console.WriteLine("Email updated successful!");
                        break;
                    case "4":
                        Console.Write("Enter the new phone number: \n");
                        guestfind.PhoneNumber = Console.ReadLine();
                        Console.WriteLine("Phone number updated successful!");
                        break;
                    case "5":
                        Console.Write("Enter the new address: \n");
                        guestfind.Address = Console.ReadLine();
                        Console.WriteLine("Address updated successful!");
                        break;
                    default:
                        Console.WriteLine("Worng option....Please select the correct number.");
                        break;
                }
            }
        }//end of modify account

        public static void ModifyUserByAdmin()//modify acc method for admin cuz this will need admin to select which acc to modify
        {
            Console.WriteLine("\n----------User List----------");
            int i = 1;
            foreach (User user in users)
            {
                Console.WriteLine($"{i}. {user.Username} ({user.Role})");
                i++;
            }
            Console.Write("\nEnter User Index to modify: ");
            int userIndex = Convert.ToInt32(Console.ReadLine());
            if (userIndex < 1 || userIndex > users.Count)
            {
                Console.WriteLine("\nInvalid User Index...");
                return;
            }
            User userFind = users[userIndex - 1];//take the object out by index and store it in the new local variable
            Console.WriteLine("\n********* Current Account Detail **********");
            userFind.DisplayUserDetails();
            userFind.DisplayGuestDetails();
            Console.WriteLine("\nWhich detail do you want to modify?");// if the account is admin, only allow to modify these details
            Console.WriteLine("1. Username");
            Console.WriteLine("2. Password");
            Console.WriteLine("3. Role");
            if (userFind.Role.ToLower() == "guest")//if the account is guest, allow to modify all details
            {
                Console.WriteLine("4. Membership");
                Console.WriteLine("5. Email");
                Console.WriteLine("6. Phone Number");
                Console.WriteLine("7. Address");
            }
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Enter new username: ");
                    string tempUsername = Console.ReadLine();
                    Console.WriteLine($"New username: {tempUsername}");//add this for user experience, you always want modification to be confirmed before its done
                    Console.WriteLine("Confirm username update? (Y/N): ");
                    string confirmUsername = Console.ReadLine().ToUpper();
                    if (confirmUsername == "Y")
                    {
                        userFind.Username = tempUsername;//only assign the new username to the list object after confirmation
                        Console.WriteLine("Username updated successfully...");
                    }
                    else
                    {
                        Console.WriteLine("Username update canceled...");
                    }
                    break;

                case "2":
                    Console.Write("Enter new password: ");
                    string tempPassword = Console.ReadLine();
                    Console.WriteLine($"New password: {tempPassword}");
                    Console.WriteLine("Confirm password update? (Y/N): ");
                    string confirmPw = Console.ReadLine().ToUpper();
                    if (confirmPw == "Y")
                    {
                        userFind.Password = tempPassword;
                        Console.WriteLine("Password updated successfully...");
                    }
                    else
                    {
                        Console.WriteLine("Password update canceled...");
                    }
                    break;

                case "3":
                    Console.Write("Enter new role: ");
                    string tempRole = Console.ReadLine().ToLower();
                    Console.WriteLine($"New role: {tempRole}");
                    Console.WriteLine("Confirm role update? (Y/N): ");
                    string confirmRl = Console.ReadLine().ToUpper();
                    if (confirmRl == "Y")
                    {
                        userFind.Role = tempRole;
                        Console.WriteLine("Role updated successfully...");
                    }
                    else
                    {
                        Console.WriteLine("Role update canceled...");
                    }
                    break;

                case "4":
                    if (userFind.Role.ToLower() == "guest")
                    {
                        Guest guestfind = (Guest)userFind;
                        string tempMembership = User.ChooseMembership();
                        Console.WriteLine($"New role: {tempMembership}");
                        Console.WriteLine("Confirm role update? (Y/N): ");
                        string confirmMBS = Console.ReadLine().ToUpper();
                        if (confirmMBS == "Y")
                        {
                            guestfind.Membership = tempMembership;
                            Console.WriteLine("Membership updated successfully...");
                        }
                        else
                        {
                            Console.WriteLine("Role update canceled...");
                        }
                        
                    }
                    //else
                    //{
                    //    Console.WriteLine("This option is only for guest accounts...");//this menu won't show
                    //}
                    break;

                case "5":
                    if (userFind.Role.ToLower() == "guest")
                    {
                        Guest guestfind = (Guest)userFind;
                        Console.Write("Enter new email: ");
                        string tempEmail = Console.ReadLine();
                        Console.WriteLine($"New email: {tempEmail}");
                        Console.WriteLine("Confirm email update? (Y/N): ");
                        string confirmEm = Console.ReadLine().ToUpper();
                        if (confirmEm == "Y")
                        {
                            guestfind.Email = tempEmail;
                            Console.WriteLine("Email updated successfully...");
                        }
                        else
                        {
                            Console.WriteLine("Email update canceled...");
                        }
                    }
                    //else
                    //{
                    //    Console.WriteLine("This option is only for guest accounts...");
                    //}
                    break;

                case "6":
                    if (userFind.Role.ToLower() == "guest")
                    {
                        Guest guestfind = (Guest)userFind;
                        Console.Write("Enter new phone number: ");
                        string tempPhone = Console.ReadLine();
                        Console.WriteLine($"New phone number: {tempPhone}");
                        Console.WriteLine("Confirm phone number update? (Y/N): ");
                        string confirmPh = Console.ReadLine().ToUpper();
                        if (confirmPh == "Y")
                        {
                            guestfind.PhoneNumber = tempPhone;
                            Console.WriteLine("Phone number updated successfully...");
                        }
                        else
                        {
                            Console.WriteLine("Phone number update canceled...");
                        }
                    }
                    //else
                    //{
                    //    Console.WriteLine("This option is only for guest accounts...");
                    //}
                    break;

                case "7":
                    if (userFind.Role.ToLower() == "guest")
                    {
                        Guest guestfind = (Guest)userFind;
                        Console.Write("Enter new address: ");
                        string tempAddress = Console.ReadLine();
                        Console.WriteLine($"New address: {tempAddress}");
                        Console.WriteLine("Confirm address update? (Y/N): ");
                        string confirmAdrs = Console.ReadLine().ToUpper();
                        if (confirmAdrs == "Y")
                        {
                            guestfind.Address = tempAddress;
                            Console.WriteLine("Address updated successfully...");
                        }
                        else
                        {
                            Console.WriteLine("Address update canceled...");
                        } 
                    }
                    //else
                    //{
                    //    Console.WriteLine("This option is only for guest accounts...");
                    //}
                    break;

                default:
                    Console.WriteLine("Invalid option...");
                    break;
            }
        }

        public static void RemoveUserByAdmin()
        {
            Console.WriteLine("\n********* User List *********");
            int i = 1;
            foreach (User user in users)
            {
                Console.WriteLine($"{i}. {user.Username} ({user.Role})");
                i++;
            }
            Console.Write("\nEnter User Index to remove: ");
            int userIndex = Convert.ToInt32(Console.ReadLine());
            if (userIndex < 1 || userIndex > users.Count)
            {
                Console.WriteLine("\nInvalid User Index...");
                return;
            }
            User userToRemove = users[userIndex - 1];//take the object out by index and store it in the new local variable,
            if (userToRemove.Role.ToLower() == "admin")
            {
                Console.WriteLine("\nAdmin account cannot be removed...");
                return;
            }
            Console.WriteLine("\n********* User Detail **********");
            userToRemove.DisplayUserDetails();
            userToRemove.DisplayGuestDetails();
            Console.Write("\nConfirm removing this user? (Y/N): ");
            string confirmRemove = Console.ReadLine().ToUpper();
            if (confirmRemove == "Y")
            {
                users.Remove(userToRemove);
                Console.WriteLine("\nUser removed successfully...");
            }
            else
            {
                Console.WriteLine("\nRemove cancelled...");
            }
        }

        //Console.WriteLine("Please enter your user name ");
        //string findUserName = Console.ReadLine();
        //User userFind = users.Find(u => u.Username.Equals(findUserName, StringComparison.OrdinalIgnoreCase));
        //if (userFind == null)
        //{
        //    Console.WriteLine("User name is not found");
        //    return;
        //}

        //Console.WriteLine($"Account {findUserName} has been found ");

        //if (userFind is Guest guestfind)
        //{
        //    Console.WriteLine("\tWhich detail do you want to modify?");
        //    Console.WriteLine("\t1,User Name");
        //    Console.WriteLine("\t2,Password");
        //    Console.WriteLine("\t3,Email");
        //    Console.WriteLine("\t4,PhoneNumber");
        //    Console.WriteLine("\t5,Address");
        //    string choise = Console.ReadLine();

        //    switch (choise)
        //    {
        //        case "1":
        //            Console.Write("Enter the new user name: \n");
        //            userFind.Username = Console.ReadLine();
        //            Console.WriteLine("User name updated successful!");
        //            break;
        //        case "2":
        //            Console.Write("Enter the new password: \n");
        //            userFind.Password = Console.ReadLine();
        //            Console.WriteLine("Password updated successful!");
        //            break;
        //        case "3":
        //            Console.Write("Enter the new email: \n");
        //            guestfind.Email =  Console.ReadLine();
        //            Console.WriteLine("Email updated successful!");
        //            break;
        //        case "4":
        //            Console.Write("Enter the new phone number: \n");
        //            guestfind.PhoneNumber = Console.ReadLine();
        //            Console.WriteLine("Phone number updated successful!");
        //            break;
        //        case "5":
        //            Console.Write("Enter the new address: \n");
        //            guestfind.Address = Console.ReadLine();
        //            Console.WriteLine("Address updated successful!");
        //            break;
        //        default:
        //            Console.WriteLine("Worng option....Please select the correct number.");
        //            break;


        //    }

        //}
        //else
        //{
        //    Console.WriteLine("This is not a guest account, so you cannot modify the account.");
        //}



        //Booking Flight method
        public static void BookingFlight()
        {
            DisplayFlights();
            Console.WriteLine();
            Console.Write("Enter the Flight number that you want to make a booking: ");
            string FlightNumber = Console.ReadLine();
            Flight flightFind = flights.Find(f=>f.FlightNumber.Equals(FlightNumber, StringComparison.OrdinalIgnoreCase));
            if (flightFind == null)
            {
                Console.WriteLine("Flight number is not found");
                return;
            }

            string newbookingDate = DateTime.Now.ToString("dd/MM/yyyy");
            Console.Write("Enter passenger name: ");
            string newpassName = Console.ReadLine();
            if (flightFind.AvailableSeats <= 0)//for making sure there are still remaining seats availivale before actually booking -PWUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUU
            {
                Console.WriteLine("\nNo seats available for this flight...");
                return;
            }
            Console.WriteLine($"Flight Number: \t\t{FlightNumber}\nPassenger Name:\t\t{newpassName}\n");
            Console.Write("\nConfirm this booking ?(Y/N): ");
            string confirmbooking = Console.ReadLine().ToUpper();
            Console.WriteLine();
            if (confirmbooking != "Y")
            {
                Console.WriteLine("\nBooking cancelled...");
            }
            else
            {


                /*flightFind.AvailableSeats--;*/ // adding real world logic, after booking, the available seats will need to reduce -PWUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUU
                                                 //just noticed this logic is written in the booking class, my bad -PWUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUU

                Booking newbookList = new Booking(newbookingDate, newpassName, flightFind);

                bookList.Add(newbookList);

                Console.WriteLine("Booking successful!!!!!");
            }
        }

        public static void ModifyBooking()
        {
            Console.WriteLine("Please enter your passenger name ");
            string findPassName = Console.ReadLine();
            Booking PassNameFind = bookList.Find(b => b.PassengerName.Equals(findPassName, StringComparison.OrdinalIgnoreCase));
            if (PassNameFind == null)
            {
                Console.WriteLine("passenger name is not found");
                return;
            }

            Console.WriteLine($"Passenger {findPassName} has been found ");

            
                Console.WriteLine("\tWhich detail do you want to modify?");
                Console.WriteLine("\t1,Passenger Name");
            //Console.WriteLine("\t2,Available Seats"); // fixing the logic, the available seats can not be modified by user, it is auto genarate by the method in the flights class based on the different model -PWUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUU

            string choise = Console.ReadLine();

                switch (choise)
                {
                    case "1":
                        Console.Write("Enter the new passenger name: \n");
                        PassNameFind.PassengerName = Console.ReadLine();
                        Console.WriteLine("Passenger name updated successful!");
                        break;
                    //case "2":
                    //    Console.Write("Enter the new Available Seats: \n");
                    //     PassNameFind.BookedFlight.AvailableSeats = Convert.ToInt32( Console.ReadLine());
                    //    Console.WriteLine("New available seats updated successful!");
                    //    break;
                    
                    default:
                        Console.WriteLine("Worng option....Please select the correct number.");
                        break;


                }
        }//end of modify booking

        public static void ModifyMyBooking()// for making sure only the user who made the booking can modify the booking, fixing problem 5 P.WUUUUUUUUUUUUUUUUUUUUUUUU
        {
            Console.Write("Enter passenger name: ");
            string findPassName = Console.ReadLine();

            Booking PassNameFind = null;//creating a new object to store the matched booking

            foreach (Booking booking in bookList)
            {
                if (booking.PassengerName.ToUpper() == findPassName.ToUpper() && booking.UserId.ToUpper() == User.userLoggedIn.Username.ToUpper())//adding the username comparison to make sure only
                                                                                                        //the user who made the booking can modify the booking
                {
                    PassNameFind = booking;// making the new object refer to the booking object in the booking class.
                    break;
                }
            }
            if (PassNameFind == null)
            {
                Console.WriteLine("Booking not found...");
                return;
            }
            Console.WriteLine($"\nPassenger {findPassName} has been found");
            PassNameFind.bookingDetail();//display the current booking details before modification, more user friendly
            Console.WriteLine("\nWhich detail do you want to modify?");
            Console.WriteLine("1. Passenger Name");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    Console.Write("Enter new passenger name: ");
                    PassNameFind.PassengerName =
                        Console.ReadLine();
                    Console.WriteLine(
                        "Passenger name updated successfully!"
                    );
                    break;
                default:
                    Console.WriteLine("Invalid option...");
                    break;
            }
        }
        
        //create the remove booking method
        public static void RemoveBooking()
        {
            Console.WriteLine("\n\n---------- Remove Booking ----------");
            if (bookList.Count == 0)
            {
                Console.WriteLine("\nNo booking available...");
                return;
            }
            Console.Write("Enter booking passenger name to remove: ");
            string passNameRemove = Console.ReadLine();
            foreach (Booking booking in bookList)
            {
                if (booking.PassengerName == passNameRemove)
                {
                    booking.bookingDetail();
                    Console.WriteLine();
                    Console.WriteLine("----------------------------------");
                    Console.Write("\nConfirm removing this booking?(Y/N): ");
                    string confirmRemove = Console.ReadLine().ToUpper();
                    if (confirmRemove == "Y")
                    {
                        booking.BookedFlight.AvailableSeats++; //returning the seat back after canceling the booking -PWUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUU
                        bookList.Remove(booking);
                        Console.WriteLine("\nBooking removed successfully...");
                    }
                    else
                    {
                        Console.WriteLine("\nRemove cancelled...");
                    }
                    return;
                }
            }
            Console.WriteLine("\nBooking not found...");
        }//end of remove booking

        public static void RemoveMyBooking()//exactly same as the privous modify booking  logic same code here
        {
            Console.WriteLine("\n\n---------- Remove My Booking ----------");
            if (bookList.Count == 0)
            {
                Console.WriteLine("\nNo booking available...");
                return;
            }
            Console.Write("Enter booking passenger name to remove: ");
            string passNameRemove = Console.ReadLine();
            Booking bookingToRemove = null;
            foreach (Booking booking in bookList)
            {
                if (booking.PassengerName.ToUpper() == passNameRemove.ToUpper() && booking.UserId.ToUpper() == User.userLoggedIn.Username.ToUpper())//same fix
                {
                    bookingToRemove = booking;
                    break;
                }
            }
            if (bookingToRemove == null)
            {
                Console.WriteLine("\nBooking not found...");
                return;
            }
            bookingToRemove.bookingDetail();
            Console.Write("\nConfirm removing this booking? (Y/N): ");
            string confirmRemove = Console.ReadLine().ToUpper();
            if (confirmRemove == "Y")
            {
                bookingToRemove.BookedFlight.AvailableSeats++;
                bookList.Remove(bookingToRemove);
                Console.WriteLine("\nBooking removed successfully...");
            }
            else
            {
                Console.WriteLine("\nRemove cancelled...");
            }
        }

        //create the booking menu
        public static void BookingMenu()
        {
            bool guestRun = true;

            while (guestRun)
            {
                Console.WriteLine("\n\n---------- Booking Menu ----------");
                Console.WriteLine("\t1. Booking Flight");
                Console.WriteLine("\t2. Modify Flight Booking");
                Console.WriteLine("\t3. Remove Flight Booking");
                Console.WriteLine("\t4. View Flight Booking");
                Console.WriteLine("\t5. Preceding menu");
                Console.Write("\nChoose an option: ");

                string choice = Console.ReadLine();


                switch (choice)
                {
                    case "1":
                        Console.WriteLine($"\nYou have selected {choice}. Booking Flight...");
                        BookingFlight();
                        break;

                    case "2":
                        Console.WriteLine($"\nYou have selected {choice}. Modify Flight Booking...");
                        ModifyBooking();
                        break;

                    case "3":
                        Console.WriteLine($"\nYou have selected {choice}. Remove Flight Booking...");
                        RemoveBooking();
                        break;

                    case "4":
                        Console.WriteLine($"\nYou have selected {choice}. View Flight Booking...");
                        foreach (Booking booking in bookList)
                        {
                            booking.BookingManagement();
                        }
                        break;

                    case "5":
                        Console.WriteLine($"\n Preceding menu..");
                        
                        return;

                    default:
                        Console.WriteLine("\nInvalid option...");
                        break;
                }

            }
        }//end of booking menu

    }//end of program
}
