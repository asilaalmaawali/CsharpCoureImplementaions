using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MiniFlightManagementSystem
{
    internal class Program
    {

        // Storage system

        static List <string> passengerNames = new List<string> (5);
        static List <string> ticketNumbers = new List<string> (5);
        static string[] flightNumbers = new string[6];
        static List<string> availableDates = new List<string>(4);
        static Dictionary<int,string> bookingRecord = new Dictionary<int,string>(); //  Key = ticketNumber, Value = flightNumber+date (e.g.'OA101|12-Jan-2026')
        static Queue <int> checkedInQueue = new Queue <int>();
        static Stack <int> boardingStack = new Stack <int>();
        static List<int> cancelledTickets = new List<int>();
        static Dictionary<int, string> passengerSeatMap = new Dictionary<int, string>();


        //static passengerNames.AddRange(new string[] {});
        public static void AddPassenger()
        {
            string passengerName;
            Console.Write("Enter the new passenger full name: ");
            passengerName = Console.ReadLine().Trim();  // without spaces
    

            if (passengerName == "")
            {
                Console.WriteLine("Passenger name cannot be empty");
                return;
            }
            else if (passengerNames.Contains(passengerName))
            {
                Console.WriteLine("Passenger already exists");
                return;
            }
            else
            {
                passengerNames.Add(passengerName); // to add it   
                Console.WriteLine("Passenger added successfully");
            }

            string ticketID = "TKT-" + (passengerNames.Count).ToString().PadLeft(3, '0');  // fortmat "TXT-XXX" ---- 
            ticketNumbers.Add(ticketID);  // to add it

            Console.WriteLine("Passenger added successfully");
            Console.WriteLine(passengerName +"  "+ ticketID);  // to print passenger name and their assigned ticket ID
        }

        

        static void Main(string[] args)
        {


            bool exit = false;
            while (exit == false)
            {
                Console.WriteLine("-------------------------------------");
                Console.WriteLine("SKY WINGS FLIGHT MANAGEMENT SYSTEM");
                Console.WriteLine("-------------------------------------");
                Console.WriteLine("1. Register New Passenger");
                Console.WriteLine("2. View All Passengers");
                Console.WriteLine("3. Book a Flight Ticket");
                Console.WriteLine("4. View Booking Details");
                Console.WriteLine("5. Update a Booking");
                Console.WriteLine("6. Cancel a Ticket");
                Console.WriteLine("7. Passenger Check-In");
                Console.WriteLine("8. Board Passengers (Boarding Stack)");
                Console.WriteLine("9. Generate Flight Manifest");
                Console.WriteLine("10. Manage Waitlist & Seat Assignment");
                Console.WriteLine("0. Exit");

                Console.Write("Enter your choice: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:                                //  Register New Passenger
                        AddPassenger();
                        break;


                    case 2:                               // View All Passengers
                        break;



                    case 3:                              //  Book a Flight Ticket
                        break;


                    case 4:                             //  View Booking Details
                        break;


                    case 5:                            // Update a Booking
                        break;


                    case 6:                            //  Cancel a Ticket
                        break;


                    case 7:                            //  Passenger Check-In
                        break;


                    case 8:                           // Board Passengers (Boarding Stack)
                        break;


                    case 9:                           // Generate Flight Manifest
                        break;


                    case 10:                         //  Manage Waitlist & Seat Assignment
                        break;


                    case 0:
                        exit = true;
                        break;

                }

                Console.Write("Enter your choice: ");
                choice = int.Parse(Console.ReadLine());
            }
        }
    }
}
