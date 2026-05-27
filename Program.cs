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

            //add object to list
            users.Add(admin);

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
            Console.Write("\nUsername:");
            string username = Console.ReadLine();
            Console.Write("\nPassword:");
            string password = Console.ReadLine();

            foreach (User user in users)
            {
                if (user.Username == username)//check username first
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
            Console.WriteLine("admin method");
        }
    }
}
