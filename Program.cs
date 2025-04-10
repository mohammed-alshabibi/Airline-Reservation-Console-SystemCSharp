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
        static void Main(string[] args)
        {
            DisplayWelcomeMessage();
            ShowMainMenu();
            Console.WriteLine("Add Flight code:");
            string flightcode = Console.ReadLine();
           
        }
        public static void DisplayWelcomeMessage()
        {
            Console.WriteLine("Welcome To Airline Reservation System");
        }
        public static int ShowMainMenu()
        {
            Console.WriteLine("Select Options:");
            Console.WriteLine("1. Book Flight");
            Console.WriteLine("2. Cancel");
            Console.WriteLine("3. View Flights");
            Console.WriteLine("4. Exit");
            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    ExitApplication();
                    break;
                default:
                    Console.WriteLine("Invalid Option");
                    break;
            }
            return choice;
        }
        public static void ExitApplication()
        {
            Console.WriteLine("Thank you for using Airline Reservation");
        }
        public static void AddFlight(string flightCode, string fromCity, string toCity, DateTime departureTime, int duration)
        {
            if(FlightCounter < 100)
            {
                flightCodeArray[FlightCounter] = flightCode;
                fromCityArray[FlightCounter] = fromCity;
                toCityArray[FlightCounter] = toCity;
                departureTimeArray[FlightCounter] = departureTime;
                departureTimeArray[FlightCounter]= departureTime;
                FlightCounter++;
            }
            else
            {
                Console.WriteLine("There is not space for add more flight ");
            }
        }
    }

}
