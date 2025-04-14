namespace Airline_Reservation_Console_SystemCSharp
{
    internal class Program
    {
        static string[] flightCodeArray = new string[100];
        static string[] fromCityArray = new string[100];
        static string[] toCityArray = new string[100];
        static DateTime[] departureTimeArray = new DateTime[100];
        static int[] durationArray = new int[100];
        static int FlightCounter = 0;
        static string[] passengerNameArray = new string[100];
        static string[] GenerateBookingIDArray = new string[100];
        static int[] basePriceArray = new int[100];

        static void Main(string[] args)
        {
            DisplayWelcomeMessage();

            while (true)
            {
                Console.WriteLine("Select Role:");
                Console.WriteLine("1. Admin");
                Console.WriteLine("2. User");
                Console.WriteLine("3. Exit");
                int roleChoice = int.Parse(Console.ReadLine());

                switch (roleChoice)
                {
                    case 1:
                        ShowAdminMenu();
                        break;
                    case 2:
                        ShowUserMenu();
                        break;
                    case 3:
                        ExitApplication();
                        return;
                    default:
                        Console.WriteLine("Invalid Option. Please try again.");
                        break;
                }
            }
        }

        public static void ShowAdminMenu()
        {
            Console.WriteLine("Welcome Admin");
            while (true)
            {
                Console.WriteLine("\nAdmin Menu:");
                Console.WriteLine("1. Add Flight");
                Console.WriteLine("2. View All Flights");
                Console.WriteLine("3. Update Flight Departure Time");
                Console.WriteLine("4. Exit to Main Menu");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        try
                        {
                            Console.WriteLine("Add Flight code:");
                            string flightCode = Console.ReadLine();
                            Console.WriteLine("Add From city:");
                            string fromCity = Console.ReadLine();
                            Console.WriteLine("Add To city:");
                            string toCity = Console.ReadLine();
                            Console.WriteLine("Add Departure Time (e.g., 2024-04-10 12:03):");
                            DateTime departureTime = DateTime.Parse(Console.ReadLine());
                            Console.WriteLine("Add Duration (in hours):");
                            int duration = int.Parse(Console.ReadLine());
                            Console.WriteLine("Enter Base Price for the Flight:");
                            int basePrice = int.Parse(Console.ReadLine());
                            AddFlight(flightCode, fromCity, toCity, departureTime, duration, basePrice);
                            
                        }
                        catch (FormatException ex)
                        {
                            Console.WriteLine($"{ex.Message}");
                        }
                        break;
                    case 2:
                        DisplayAllFlights();
                        break;
                    case 3:
                        Console.WriteLine("Enter Flight Code to Update:");
                        string updateFlightCode = Console.ReadLine();
                        if (ValidateFlightCode(updateFlightCode))
                        {
                            for (int i = 0; i < FlightCounter; i++)
                            {
                                if (flightCodeArray[i] == updateFlightCode)
                                {
                                    UpdateFlightDepature(ref departureTimeArray[i]);
                                    Console.WriteLine("Departure time updated successfully.");
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Flight not found.");
                        }
                        break;
                    case 4:
                        return;
                    default:
                        Console.WriteLine("Invalid Option. Please try again.");
                        break;
                }
            }
        }

        public static void ShowUserMenu()
        {
            Console.WriteLine("Welcome User");
            while (true)
            {
                Console.WriteLine("\nUser Menu:");
                Console.WriteLine("1. Book Flight");
                Console.WriteLine("2. Cancel Flight Booking");
                Console.WriteLine("3. View Flights");
                Console.WriteLine("4. Search Bookings by Destination");
                Console.WriteLine("5. Exit to Main Menu");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter Passenger Name:");
                        string passengerName = Console.ReadLine();
                        string generatedPassengerNamed=GenerateBookingID(passengerName);
                        BookFlight(generatedPassengerNamed);
                        break;
                    case 2:
                        string passengerToCancel;
                        CancelFlightBooking(out passengerToCancel);
                        Console.WriteLine($"Booking for {passengerToCancel} has been canceled.");
                        break;
                    case 3:
                        DisplayAllFlights();
                        break;
                    case 4:
                        Console.WriteLine("Enter Destination City:");
                        string toCity = Console.ReadLine();
                        SearchBookingsByDestination(toCity);
                        break;
                        case 5:
                        return;
                    default:
                        Console.WriteLine("Invalid Option. Please try again.");
                        break;
                }
            }
        }
        public static void DisplayWelcomeMessage()
        {
            Console.WriteLine("Welcome to Airline Reservation System");
            Console.WriteLine("Please select your role:");
        }
        public static void ExitApplication()
        {
            Console.WriteLine("Thank you for using Airline Reservation");
        }
        public static void AddFlight(string flightCode, string fromCity, string toCity, DateTime departureTime, int duration, int basePrice)
        {
            if(FlightCounter < 100)
            {
                flightCodeArray[FlightCounter] = flightCode;
                fromCityArray[FlightCounter] = fromCity;
                toCityArray[FlightCounter] = toCity;
                departureTimeArray[FlightCounter] = departureTime;
                durationArray[FlightCounter]= duration;
                basePriceArray[FlightCounter]= basePrice;
                FlightCounter++;
                Console.WriteLine("Flight added successfully.");
            }
            else
            {
                Console.WriteLine("There is not space for add more flight ");
            }
        }
        public static void DisplayAllFlights()
        {
            if (FlightCounter == 0)
            {
                Console.WriteLine("No flights available.");
                return;
            }
            for (int i = 0; i < FlightCounter; i++)
            {
                Console.WriteLine($"Flight Code {flightCodeArray[i]}, From {fromCityArray[i]}, To {toCityArray[i]}, Departure Time is {departureTimeArray[i]}, Duration time is {durationArray[i]} ");
                Console.WriteLine("-------------------------------------------------");
            }
        }
        public static bool FindFilghtByCode(string flightCode)
        {
            for (int i = 0; i < FlightCounter; i++)
            {
                if (flightCodeArray[i] == flightCode)
                {
                    return true;
                }
            }
            return false;
        }
        public static DateTime UpdateFlightDepature(ref DateTime departureTime)
        {
            Console.WriteLine("Enter new departure time:");
            string newDepartureTime = Console.ReadLine();
            DateTime newDeparture = DateTime.Parse(newDepartureTime);
            departureTime = newDeparture;
            return departureTime;
        }
        public static string CancelFlightBooking(out string passengerName)
        {
            if(ConfirmAction("Cancel Booking"))
            {
                Console.WriteLine("Enter Booking ID:");
                string bookingID = Console.ReadLine();

                for (int i = 0; i < FlightCounter; i++)
                {
                    // Check if the booking ID matches the generated ID for the passenger
                    if (passengerNameArray[i] != null && GenerateBookingIDArray[i].Contains(bookingID))
                    {
                        passengerName = passengerNameArray[i];
                        passengerNameArray[i] = null; // Remove the booking
                        Console.WriteLine("Booking canceled successfully.");
                        return passengerName;
                    }
                }
                Console.WriteLine("Booking ID not found.");
                
            }
            else
            {
                Console.WriteLine("No Cancelation");
            }
            passengerName = null;
            return null;

        }
        public static void BookFlight(string passengerName, string flightCode = "Default001")
        {
            Console.WriteLine("Enter Flight Code:");
            flightCode = Console.ReadLine();

            for (int i = 0; i < FlightCounter; i++)
            {
                if (flightCodeArray[i] == flightCode)
                {
                    int basePrice = basePriceArray[i];

                    Console.WriteLine("Enter Number of Tickets:");
                    int numTickets = int.Parse(Console.ReadLine());

                    Console.WriteLine("Do you have a discount? (yes/no):");
                    string hasDiscount = Console.ReadLine().ToLower();

                    double totalFare;
                    if (hasDiscount == "yes")
                    {
                        Console.WriteLine("Enter Discount Percentage:");
                        int discount = int.Parse(Console.ReadLine());
                        totalFare = CalculateFare(basePrice, numTickets, discount);
                    }
                    else
                    {
                        totalFare = CalculateFare(basePrice, numTickets);
                    }

                    passengerNameArray[i] = passengerName;
                    GenerateBookingIDArray[i] = GenerateBookingID(passengerName);

                    Console.WriteLine($"Booking ID: {GenerateBookingIDArray[i]}");
                    Console.WriteLine($"Total Fare: {totalFare:C}");
                    Console.WriteLine("Flight booked successfully.");
                    return;
                }
            }

            Console.WriteLine("Flight not found.");
        }
        public static bool ValidateFlightCode(string flightCode)
        {
            for (int i = 0; i < FlightCounter; i++)
            {
                if (flightCodeArray[i] == flightCode)
                {
                    return true;
                }
            }
            return false;
        }
        public static string GenerateBookingID(string passengerName)
        {
            Random random = new Random();
            int bookingIDrandom = random.Next(1000, 9999);
            string bookingID = passengerName + bookingIDrandom.ToString();
            return bookingID ;
        }
        public static void DisplayFlightDetails(string flightCode)
        {
            for (int i = 0; i < FlightCounter; i++)
            {
                if (flightCodeArray[i] == flightCode)
                {
                    Console.WriteLine("Flight code " + flightCodeArray[i]);
                    Console.WriteLine("The Rout From City " + fromCityArray[i] +" To City " + toCityArray[i]);
                    Console.WriteLine("Duration time is " + durationArray[i]);
                }
            }
        }
        public static string SearchBookingsByDestination(string toCity)
        {
            Console.WriteLine("Enter the destination city:");
            toCity = Console.ReadLine();
            for (int i = 0; i < FlightCounter; i++)
            {
                if (toCityArray[i] == toCity)
                {
                    return toCity;
                }
            }
            return null;
        }
        public static int CalculateFare(int basePrice, int numTickets)
        {
            int totalFare = basePrice * numTickets;
            return totalFare;
        }
        public static double CalculateFare(double basePrice, int numTickets)
        {
            double totalFare = basePrice * numTickets;
            return totalFare;
        }
        public static double CalculateFare(int basePrice, int numTickets,int discount)
        {
            double totalFare = basePrice * numTickets;
            double discountAmount = (totalFare * discount) / 100;
            return discountAmount;
        }
        public static bool ConfirmAction(string action)
        {
            Console.WriteLine("Are you sure you want to " + action + "? (yes/no)");
            string response = Console.ReadLine();
            if (response.ToLower() == "yes")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

}
