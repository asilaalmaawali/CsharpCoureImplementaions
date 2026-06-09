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
        static Queue <string> checkedInQueue = new Queue <string>();
        static Stack <string> boardingStack = new Stack <string>();
        static List<string> cancelledTickets = new List<string>();
        static Dictionary<int, string> passengerSeatMap = new Dictionary<int, string>();
        static string passengerName;
        static string ticketID;
        static string status;
        static string bookingInfo;
        static Queue<string> waitlistQueue = new Queue<string>();
        static int i;

        public static void AddPassenger()
        {
           
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
                Console.WriteLine("This ticket has been cancelled");
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
         

            bookingRecord.Add(ticketID ,selectedFlight + "|" + selectedDate);  // store booking
            Console.WriteLine(ticketID + "|" + passengerName + "|" + selectedFlight + "|" + selectedDate);
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

            bookingInfo = bookingRecord[ticketID];   // to store  bookingRecord in booking info    --- i will declare it outside to be used anywhere
            string[] parts = bookingInfo.Split('|');  // here to split the bookingRecord dictinary to be a parts not be linked

            Console.WriteLine("===== BOOKING SUMMARY =====");
            Console.WriteLine("Passenger Name : " + passengerName);
            Console.WriteLine("Ticket ID      : " + ticketID);
            Console.WriteLine("Flight Number  : " + parts[0]);
            Console.WriteLine("Flight Date    : " + parts[1]);
            Console.WriteLine("===========================");

        }

        public static void UpdateBooking()
        {

            if (!ticketNumbers.Contains(ticketID))  // if the ticketNumbers not contain in ticketID
            {
               
                Console.WriteLine("The Ticket not exists yet");
                return;
            }
            else if (cancelledTickets.Contains(ticketID))   // i need to check the ticket cancelled or not , check cancelledTickets contain ticketID
            {
                Console.WriteLine("This ticket has been cancelled");
                return;
            }


            if (!bookingRecord.ContainsKey(ticketID))
            {
                Console.WriteLine("No booking found for this ticket");
                return;
            }

            string bookingInfo = bookingRecord[ticketID];   // every time i declare it becuase i dont do it in static

            string[] parts = bookingInfo.Split('|');   // to split the dictionary

            Console.WriteLine("Current Flight : " + parts[0]);
            Console.WriteLine("Current Date   : " + parts[1]);


            Console.WriteLine("=====  sub-menu: =====");
            Console.WriteLine("1. Change flight only ");
            Console.WriteLine("2. Change date only  ");
            Console.WriteLine("3. Change both ");
            Console.WriteLine("0. Cancel update. ");
            Console.Write("Select choice: ");
            int Choice = int.Parse(Console.ReadLine());

          
            int flightIndex=0;
            int dateIndex =0;

            string selectedFlight = flightNumbers[flightIndex];
            string selectedDate = availableDates[dateIndex];


            if (Choice == 1)
            {
                for (int i = 0; i < flightNumbers.Length; i++)
                {
                    Console.WriteLine(i + " - " + flightNumbers[i]);
                }

                Console.Write("Select new flight: ");
                flightIndex = int.Parse(Console.ReadLine());

                if (flightIndex < 0 || flightIndex >= flightNumbers.Length)    // to vlidate input // should not be more than the selection
                {
                    Console.WriteLine("Invalid flight selection.");
                    return;
                }

                selectedFlight = flightNumbers[flightIndex];

                bookingRecord[ticketID] = selectedFlight + "|" + parts[1];  // update the booking for this ticket with the new flight, but keep the old date.

                Console.WriteLine("Flight updated successfully");
            }
            else if (Choice == 2)
            {
                for (int i = 0; i < availableDates.Count; i++)
                {
                    Console.WriteLine(i + " - " + availableDates[i]);
                }

                Console.Write("Select new date: ");
                dateIndex = int.Parse(Console.ReadLine());

                selectedDate = availableDates[dateIndex];

                if (dateIndex < 0 || dateIndex >= availableDates.Count)       // to vlidate input // should not be more than the selection
                {
                    Console.WriteLine("Invalid date selection.");
                    return;
                }

                bookingRecord[ticketID] = parts[0] + "|" + selectedDate;  // here update the date and keep old flight as is it

                Console.WriteLine("Date updated successfully.");
            }
            else if (Choice == 3)
            {
                for (int i = 0; i < flightNumbers.Length; i++)
                {
                    Console.WriteLine(i + " - " + flightNumbers[i]);
                }

                Console.Write("Select new flight: ");         // to choose from flight index
                flightIndex = int.Parse(Console.ReadLine());

                if (flightIndex < 0 || flightIndex >= flightNumbers.Length)    // to vlidate input // should not be more than the selection
                {
                    Console.WriteLine("Invalid flight selection.");
                    return;
                }


                for (int i = 0; i < availableDates.Count; i++)
                {
                    Console.WriteLine(i + " - " + availableDates[i]);
                }

                Console.Write("Select new date: ");
                dateIndex = int.Parse(Console.ReadLine());  // to choose from date index

                if (dateIndex < 0 || dateIndex >= availableDates.Count)       // to vlidate input // should not be more than the selection
                {
                    Console.WriteLine("Invalid date selection.");
                    return;
                }

                //string selectedFlight = flightNumbers[flightIndex];   // i need to do it outside the if
                //string selectedDate = availableDates[dateIndex];

                bookingRecord[ticketID] = selectedFlight + "|" + selectedDate;  

                Console.WriteLine("Booking updated successfully");
            }
            else if (Choice == 0) 
            {
                Console.WriteLine("Update cancelled");
                return;
            }

        

            Console.WriteLine("--------------------------------");
            Console.WriteLine("      BOOKING CONFIRMATION      ");
            Console.WriteLine("--------------------------------");

            Console.WriteLine("Old Flight:    " +parts[0]);
            Console.WriteLine("Old Date:      " +parts[1]);

            Console.WriteLine("--------------------------------");

            Console.WriteLine("New Flight:   " +selectedFlight);
            Console.WriteLine("New Date:     "+selectedDate);

            Console.WriteLine("--------------------------------");
        }

        public static void CancelBooking()
        {


            Console.Write("Enter Ticket ID: ");
            ticketID = Console.ReadLine();


            if (!ticketNumbers.Contains(ticketID))  // if the ticketNumbers not contain in ticketID
            {

                Console.WriteLine("The Ticket not exists yet");
                return;
            }
            else if (cancelledTickets.Contains(ticketID))   // i need to check the ticket cancelled or not , check cancelledTickets contain ticketID
            {
                Console.WriteLine("This ticket has been cancelled");
                return;
            }


           

            //  Retrieve the associated passenger name from passengerNames using the index match.
            int TicketIndex = ticketNumbers.IndexOf(ticketID);

            passengerName = passengerNames[TicketIndex];   // give us the passenger name that stored in the same Ticket  

            Console.WriteLine("Passenger Name: " + passengerName);


            if (bookingRecord.ContainsKey(ticketID)) // if ticket exists in booking record
            {
               
                Console.WriteLine("Removed Booking: " +ticketID + " -- " + bookingRecord[ticketID]); // to print

                bookingInfo = bookingRecord[ticketID];  // save flight details
                bookingRecord.Remove(ticketID);  // here to remove it from dictionary , i do it after the print because i need the booking record to be displayed , if i do it before the booking record will be empty and nothing to display.

            }
             
            cancelledTickets.Add(ticketID); // to cancel ticket add ticketID inside cancelledTickets

            // to remove passenger name from checkedInQueue using temporary Queue.
            if (checkedInQueue.Contains(passengerName))   // if passengerName inside checkedInQueue
            {
                Queue<string> tempQueue = new Queue<string>();  // temprory queue to move all passenger their except what we want to remove it

                while (checkedInQueue.Count > 0)
                {
                    string passenger = checkedInQueue.Dequeue();  // to remove pssenger from checkedInQueue

                    if (passenger != passengerName)  // if passenger not equal to passengerName then add passenger inside tempQueue
                    {
                        tempQueue.Enqueue(passenger);  // to add it inside tempQueue
                    }
                }

                checkedInQueue = tempQueue;   // replace old queue with the updated queue

                Console.WriteLine(passengerName + " was removed from the check-in queue");
            }

            if (boardingStack.Contains(passengerName))   // if passengerName inside tempStack
            {
                Stack<string> tempStack = new Stack<string>();  // temprory stack to move all passenger their except what we want to remove it .    this tempstack to take all passengers but the order will be reverse 
                Stack<string> finalStack = new Stack<string>(); // final stack also temprory but to do it in preserves order

                while (boardingStack.Count > 0)
                {
                    string passenger = boardingStack.Pop();  // to remove pssenger from boardingStack

                    if (passenger != passengerName)  // if passenger not equal to passengerName then add passenger inside tempStack
                    {
                        tempStack.Push(passenger);  // to add it inside tempStack
                    }
                }

                while (tempStack.Count > 0)      
                {
                        finalStack.Push(tempStack.Pop());  // to add it inside finalStack .    //moves everything again and re-order it again back to normal

                }

                boardingStack = finalStack;   // to take the last updated stack

                Console.WriteLine(passengerName + " was removed from the boarding stack ");
            }

           
                Console.WriteLine("===== Cancellation Summary =====");
                Console.WriteLine("Ticket ID      : " + ticketID);
                Console.WriteLine("Passenger Name : " + passengerName);
                Console.WriteLine("Flight Details : " + bookingInfo);
                Console.WriteLine("Status         :   Cancelled ");
                Console.WriteLine("===============================");


        }

<<<<<<< HEAD
=======
        public static void PassengerCheckIn()
        {


            Console.WriteLine("=====  sub-menu: =====");
            Console.WriteLine("1. Check in a passenger");
            Console.WriteLine("2. View check-in queue");
            Console.WriteLine("3. Process next passenger");
            Console.WriteLine("0. Back");
            Console.Write("Select choice: ");
            int Choice = int.Parse(Console.ReadLine());

            


            if (Choice == 1)
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
                    Console.WriteLine("This ticket has been cancelled");
                    return;
                }


                if (!bookingRecord.ContainsKey(ticketID))
                {
                    Console.WriteLine("No booking record found.");
                    return;
                }

                if (checkedInQueue.Contains(ticketID))   // if tickets inside checkedInQueue
                {
                    Console.WriteLine("Passenger is already in the queue");
                    return;
                }


                if (checkedInQueue.Contains(ticketID) || waitlistQueue.Contains(ticketID))          // i do ticket becuase when i use to for passenger name it be conflict
                {
                    Console.WriteLine("Ticket already processed or waitlisted");
                    return;
                }

                if (checkedInQueue.Count < 10)  // checkedInQueue.Count or length should be less than 10
                {
                    checkedInQueue.Enqueue(passengerName);
                    Console.WriteLine("Check-in successful   " +passengerName +"  has been added to the check-in queue");
                }
               
                else if (checkedInQueue.Count == 10)  // if checkedInQueue full
                {
                    waitlistQueue.Enqueue(passengerName);
                    Console.WriteLine("Check-in queue is full. " +passengerName+ "  has been placed on the waitlist.");
                }

            }

            else if (Choice == 2)
            {
                Console.WriteLine("==== View Check-In Queue =====");

                if (checkedInQueue.Count == 0)   // if checkedInQueue empty 
                {
                    Console.WriteLine("No passengers in the check-in queue");
                }
                else
                {
                    int position = 1;

                    foreach ( string passengerName in checkedInQueue)
                    {
                        Console.WriteLine(position +"  " +passengerName);      // view passengers in check in queue  foreach with position labels.
                        position++;
                    }
                }

                Console.WriteLine("Waitlist Count:" + waitlistQueue.Count);
            }
        
            else if (Choice == 3)
            {

                if (checkedInQueue.Count == 0)
                {
                    Console.WriteLine("No passengers in the check-in queue.");
                }
                else
                {
                   
                    string processedNextPassenger = checkedInQueue.Dequeue();

                    Console.WriteLine("Processed passenger:  " + processedNextPassenger);

                  
                    if (waitlistQueue.Count > 0) // here to move fisrt waitlisted passenger into check-in queue  , in queue fisrt in first out
                    {
                        string waitlistedPassenger = waitlistQueue.Dequeue();  // to save inside waitlistedPassenger

                        checkedInQueue.Enqueue(waitlistedPassenger);

                        Console.WriteLine( "" +waitlistedPassenger +"has been moved from the waitlist to the check-in queue");
                    }
                }

            }
            else if (Choice == 0)
            {
                
                return;
            }
        }


>>>>>>> 2db6e4530150062160db01d01dc2ed92336e38aa
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

                Console.Write("Enter your choice from main menu: : ");
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
                        UpdateBooking();
                        break;


                    case 6:                            //  Cancel a Ticket
                        CancelBooking();
                        break;


                    case 7:                            //  Passenger Check-In
<<<<<<< HEAD
                        
=======
                        PassengerCheckIn();
>>>>>>> 2db6e4530150062160db01d01dc2ed92336e38aa
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

                Console.Write("Enter your choice from main menu: ");
                choice = int.Parse(Console.ReadLine());
            }
        }
    }
}
