namespace Airline_Reservation_Console_SystemCSharp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DisplayWelcomeMessage();
            ShowMainMenu();
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
                    break;
                default:
                    Console.WriteLine("Invalid Option");
                    break;
            }
            return choice;

        }
    }

}
