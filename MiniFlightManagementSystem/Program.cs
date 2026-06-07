using System.ComponentModel.DataAnnotations;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MiniFlightManagementSystem
{
    internal class Program
    {

        // Storage system

        static List <string> passengerNames = new List<string> (5);
        static List <string> ticketNumbers = new List<string> (5);
        static string[] flightNumbers = new string[6] { "OA101", "OA102", "OA103" , "OA104" , "OA105" , "OA106" };
        static List<string> availableDates = new List<string>(4){"7-June-2026", "8-June-2026", "9-June-2026", "10-June-2026" };
        static Dictionary<string,string> bookingRecord = new Dictionary<string,string>(); //  Key = ticketNumber, Value = flightNumber+date (e.g.'OA101|12-Jan-2026')
        static Queue <int> checkedInQueue = new Queue <int>();
        static Stack <int> boardingStack = new Stack <int>();
        static List<string> cancelledTickets = new List<string>();
        static Dictionary<int, string> passengerSeatMap = new Dictionary<int, string>();
        static string passengerName;
        static string ticketID;
        static string status;
       
        public static void AddPassenger()
        {
            //string passengerName;
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

            ticketID = "TKT-" + (passengerNames.Count).ToString().PadLeft(3, '0');  // fortmat "TXT-XXX" ---- 
            ticketNumbers.Add(ticketID);  // to add it

            Console.WriteLine("Passenger added successfully");
            Console.WriteLine(passengerName +"  "+ ticketID);  // to print passenger name and their assigned ticket ID
        }

        public static void ViewPassenger()
        {


            if (passengerName == "")
            {
                Console.WriteLine(" 'No passengers registered yet");
                return;
            }
            else
            {
                Console.WriteLine("No.|Passenger Name |Ticket ID|  Status");
                
            }

            //string status;
            for (int i = 0; i < passengerNames.Count; i++)
            {

                if (cancelledTickets.Contains(ticketNumbers[i]))

                {
                    status = "CANCELLED";

                }
                else
                {

                    status = "ACTIVE";

                }

                Console.WriteLine("{0,-4} {1,-15} {2,-10} {3}" ,i ,passengerNames[i] ,ticketNumbers[i] ,status);  // i do spaces first to be organized

            }
                Console.WriteLine("total passenger count:   " + passengerNames.Count);

        }

      
        public static void BookingTicket()
        {
            Console.Write("Enter Ticket ID:  ");
            ticketID = Console.ReadLine().Trim();

            if (!ticketNumbers.Contains(ticketID))  // if the ticketNumbers not contain in ticketID
            {

                Console.WriteLine("The Ticket not exists yet");
                return;
            }
            else if (cancelledTickets.Contains(ticketID))   // i need to check the ticket cancelled or not , check cancelledTickets contain ticketID
            {
                Console.WriteLine("Ticket is already cancelled");
                return;
            }


            if (bookingRecord.ContainsKey(ticketID))   // to check key
            {
                Console.WriteLine("Ticket already has a booking ");
                return;
            }

        
            Console.WriteLine("Select a flight:  ");

            for (int i = 0; i < flightNumbers.Length; i++)
            {
                Console.WriteLine(i + "     " + flightNumbers[i]);
            }

            Console.Write("enter flight index: ");
            int Flightindex = int.Parse(Console.ReadLine());   // select a flight by entering index number

       
            if (Flightindex < 0 || Flightindex >= flightNumbers.Length) // if index less than 0 or index more than or equal  flightNumbers.Length (range) //Validate the input is within range

            {
            Console.WriteLine("Invalid flight selection");
                return;
            }



            Console.WriteLine("Select a Date:  ");

            for (int i = 0; i < availableDates.Count; i++)
            {
                Console.WriteLine(i + "     " + availableDates[i]);
            }

            Console.Write("enter Date index : ");
            int Dateindex = int.Parse(Console.ReadLine());   // select a date by entering index number


            if (Dateindex < 0 || Dateindex >= availableDates.Count) // if index less than 0 or index more than or equal  availableDates.Count (range) //Validate the input is within range

            {
                Console.WriteLine("Invalid Date selection");
                return;
            }

            string selectedFlight = flightNumbers[Flightindex];   // to store 
            string selectedDate = availableDates[Dateindex];

           
            bookingRecord.Add(ticketID , selectedFlight + "|" + selectedDate);  // store booking
            Console.WriteLine(ticketID +"|"+ passengerName +"|" + selectedFlight + "|" + selectedDate);
            Console.WriteLine("Booking saved successfully ");

        }

        public static void ViewBooking()
        {
            Console.Write("Enter Ticket ID: ");
            ticketID = Console.ReadLine().Trim();          // the passengers enters the ticket ID to view the booking details


            if (!ticketNumbers.Contains(ticketID))  // if the ticketNumbers not contain in ticketID
            {

                Console.WriteLine("The Ticket not exists yet");
                return;
            }

            int index = ticketNumbers.IndexOf(ticketID); //search for Ticket Id

            // view booking
            Console.WriteLine("Passenger Name: " + passengerNames[index]);
            Console.WriteLine("Ticket ID: " + ticketID);
            Console.WriteLine("Booking: " + bookingRecord[ticketID]);


            if (cancelledTickets.Contains(ticketID))   // i need to check the ticket cancelled or not , check cancelledTickets contain ticketID   
            {
                Console.WriteLine("This ticket has been cancelled");
                return;
            }


            if (!bookingRecord.ContainsKey(ticketID))   // must mention key to know that i mean to contain the key //  Use the bookingRecord dictionary to retrieve the booking value. 
            {

                Console.WriteLine("No booking found for this ticket");
                return;
            }

            string bookingInfo = bookingRecord[ticketID];   // to store  bookingRecord in booking info
            string[] parts = bookingInfo.Split('|');  // here to split the bookingRecord dictinary to be a parts not be linked

            Console.WriteLine("===== BOOKING SUMMARY =====");
            Console.WriteLine("Passenger Name : " + passengerName);
            Console.WriteLine("Ticket ID      : " + ticketID);
            Console.WriteLine("Flight Number  : " + parts[0]);
            Console.WriteLine("Flight Date    : " + parts[1]);
            Console.WriteLine("===========================");
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
                        ViewPassenger();

                        break;



                    case 3:                              //  Book a Flight Ticket
                        BookingTicket();

                        break;


                    case 4:                             //  View Booking Details
                        ViewBooking();

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
