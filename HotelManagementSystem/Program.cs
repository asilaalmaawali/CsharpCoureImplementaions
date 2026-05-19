using System.ComponentModel.Design;
using System.Net.NetworkInformation;
using System.Reflection.PortableExecutable;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HotelManagementSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // System Storage 

            string guestName = "";
            int guestPhone = 0;
            int roomNumber = 0;
            string roomType = "";        //  Single , Double , Suite
            double nightlyRate = 0.00;    
            DateTime check_inDate;
            DateTime check_outDate;
            int number_of_nights = 0;
            string room_notes = "";
            double discount_percentage = 0;
            int loyaltyPoints;
            bool flag_guest=false;
            bool flag_checked=false;

            //processing

            bool exit = false;
            while (exit == false)
            {
                Console.WriteLine("Hotel Main Menu ");
                Console.WriteLine("0. Register New Guest");
                Console.WriteLine("1. View Guest Information");
                Console.WriteLine("2. Check-In Guest ");
                Console.WriteLine("3. Check-Out & Bill ");
                Console.WriteLine("4. Apply Discount ");
                Console.WriteLine("5. Upgrade Room  ");
                Console.WriteLine("6. Add Room Service Note ");
                Console.WriteLine("7. Search Guest by Name");
                Console.WriteLine("8. Calculate Loyalty Points");
                Console.WriteLine("9. Print Receipt");
                Console.WriteLine("10. Edit Guest Name ");
                Console.WriteLine("11. Exit");

                Console.WriteLine("please select an option from the menu:");
                int option = int.Parse(Console.ReadLine());

                switch (option)
                {
                    case 0:                                       // 0. Register New Guest"

                        Console.WriteLine(" ========== Registration ============");

                        if (flag_guest == true)       // if its already their is a guest 
                        {
                            Console.WriteLine("Guest already exists, You cannot register another guest.");
                            break;
                        }
                        else                          // // if their is no Guest 
                        {
                            bool RegisterationMenu = true;

                            while (RegisterationMenu)
                            {
                                Console.WriteLine("1. Guest registration ");
                                Console.WriteLine("2. Room type option");
                                Console.WriteLine("0. Exit ");

                                int choice = int.Parse(Console.ReadLine());
                                Random random = new Random();

                                if (choice == 1)
                                {
                                    Console.WriteLine("Enter guest name:");
                                    guestName = Console.ReadLine().Trim();  //  // removes the space from the begining and end (not in between)

                                    Console.WriteLine("Enter guest phone:");
                                    guestPhone = int.Parse(Console.ReadLine());

                                    roomNumber = random.Next(1, 100);   // set random number from 1 to 100

                                    flag_guest = true;    // here to set it as full or their is a Guest

                                    Console.WriteLine("Guest registered successfully");
                                }
                                else if (choice == 2)
                                {
                                    bool roomTypeMenu = true;

                                    while (roomTypeMenu)
                                    {
                                        Console.WriteLine("===== Room Type =====");
                                        Console.WriteLine("1. Single room ");
                                        Console.WriteLine("2. Double room ");
                                        Console.WriteLine("3. Suite room ");
                                        Console.WriteLine("0. Exit ");

                                        int number = int.Parse(Console.ReadLine());

                                        if (number == 1)
                                        {
                                            roomType = "Single room";
                                            nightlyRate = 25;
                                            Console.WriteLine("A single room has been booked");
                                        }
                                        else if (number == 2)
                                        {
                                            roomType = "Double room";
                                            nightlyRate = 50;
                                            Console.WriteLine("A double room has been booked");
                                        }
                                        else if (number == 3)
                                        {
                                            roomType = "Suite room";
                                            nightlyRate = 100;
                                            Console.WriteLine("A suite room has been booked");
                                        }
                                        else if (number == 0)
                                        {
                                            roomTypeMenu = false;   // exit

                                            Console.WriteLine("Returning to Registration Menu...");
                                            Console.ReadKey();
                                            Console.Clear();

                                        }
                                        else
                                        {
                                            Console.WriteLine("Invalid number");
                                        }


                                    }
                                }
                                else if (choice == 0)
                                {
                                    RegisterationMenu = false;             //exit

                                    Console.WriteLine("Returning to  Hotel Main Menu...");
                                    Console.ReadKey();
                                    Console.Clear();

                                }
                            }
                        }
                        break;

                    case 1:                                  // 1. View Guest Information


                        Console.WriteLine(" ========== View Guest Information ============");
                        Console.WriteLine(" Guest name : " + guestName.ToUpper()); // display name with Upper case
                        Console.WriteLine(" Guest Phone : " + guestPhone.ToString()); // convert phone to string
                        Console.WriteLine(" room type :" + roomType);
                        Console.WriteLine(" room number :" + roomNumber);
                        Console.WriteLine(" nightly rate " + Math.Round(nightlyRate).ToString()); //  when we use round , the data type should be double + converted to string

                        break;

                    case 2:                                 // 2. Check-In Guest 

                        Console.WriteLine(" ========== Check-In Guest  ============");

                        if (flag_checked == true)          // if 
                        {

                            Console.WriteLine(" The guest already check-in");

                        }
                        else
                        {

                            Console.WriteLine("Enter guest name:");
                            string name = Console.ReadLine().Trim();

                            if (guestName == name)

                            {


                                Console.WriteLine(" Enter the number of nights :");
                                number_of_nights = int.Parse(Console.ReadLine());
                                DateTime Today = DateTime.Today;                            // current date , i cant use both (today and now)
                                check_inDate = DateTime.Now;                              // to have current date with clock
                                check_outDate = check_inDate.AddDays(number_of_nights);     // adding nights in check_inDate , they give us the check out date
           
                              
                                Console.WriteLine("Today : " + Today.ToString("dd/MM/yyyy HH:mm:ss"));
                                Console.WriteLine("Check-In Date: " + check_inDate.ToString("dd/MM/yyyy HH:mm:ss")); // to convert date to string and specific format to show
                                Console.WriteLine("Check-Out Date: " + check_outDate.ToString("dd/MM/yyyy HH:mm:ss"));

                                Console.WriteLine(" Enter the Special note from guest :");  // here after he check-in , he can tell us the service note ( which time he want room service come or want he need)
                                room_notes = Console.ReadLine();


                                flag_checked = true;             // to fill it not be empty

                            }
                            else
                            {
                                Console.WriteLine(" there is no guest with this name ");

                            }
                        }
                        break;

                    case 3:                            // 3 Check-Out & Bill

                        Console.WriteLine("===== Check-Out & Bill =====");

                        //it should be outside the if or scope
                        double totalBill = nightlyRate * number_of_nights;         // declare total bill 
                        double finalBill = totalBill - discount_percentage;        // declare final bill after discount

                        if (flag_guest == false)    // no guest
                        {
                            Console.WriteLine("No guest registered ");
                        }
                        else if (flag_checked == false)      // no guest check in
                        {
                            Console.WriteLine("Guest has not checked in yet ");
                        }
                        else
                        {

                            check_inDate = DateTime.Now;                              // to have current date with clock                
                            check_outDate = check_inDate.AddDays(number_of_nights);
                            Console.WriteLine(" Check-Out Date: " + check_outDate.ToString("dd/MM/yyyy HH:mm"));


                            if (finalBill < 0)
                                finalBill = 0;       // force it to be zero , to not accept negative value

                            Console.WriteLine("Total Bill: " + Math.Round(totalBill, 2).ToString());
                            Console.WriteLine("Discount: " + discount_percentage.ToString());
                            Console.WriteLine("Final Bill: " + Math.Round(finalBill, 2).ToString());

                        }
                        break;

                    case 4:                         //4. Apply Discount 

                        Console.WriteLine("Enter discount percentage:");
                        discount_percentage = double.Parse(Console.ReadLine());

                        totalBill = nightlyRate * number_of_nights;   // i do it again because the firat one inside (if)

                        double amountSaved = Math.Round(totalBill, 2) * (discount_percentage / 100);  // how much he saved money after applying discount
                        finalBill = Math.Round(totalBill, 2) - Math.Round(amountSaved, 2);  // final bill 

                        Console.WriteLine("===== BILL SUMMARY =====");
                        Console.WriteLine("original amount : " + Math.Round(totalBill, 2).ToString());
                        Console.WriteLine("discount %: " + discount_percentage + "%");
                        Console.WriteLine("Amount Saved: " + Math.Round(amountSaved, 2).ToString());
                        Console.WriteLine("Final bill: " + Math.Abs(finalBill).ToString());


                        break;


                    case 5:                                  // 5. Upgrade Room 
                   
                        // Upgrade Room
                        Console.Clear();

                        
                        string oldRoomType = roomType;   // i store here the old room type
                        double oldRate = nightlyRate;   // i store here the old night rate

                        Console.WriteLine("===== Upgrade Room =====");
                        Console.WriteLine("1. Single room ");
                        Console.WriteLine("2. Double room ");
                        Console.WriteLine("3. Suite room ");
                        Console.WriteLine(" Enter choice to upgrade the room ");
                        int upgradeChoice = int.Parse(Console.ReadLine());

                        // New upgraded room
                        if (upgradeChoice == 1)
                        {
                            roomType = "Single room";
                            nightlyRate = 25;
                        }
                        else if (upgradeChoice == 2)
                        {
                            roomType = "Double room";
                            nightlyRate = 50;
                        }
                        else if (upgradeChoice == 3)
                        {
                            roomType = "Suite room";
                            nightlyRate = 100;
                        }
                        else
                        {
                            Console.WriteLine("Invalid number");
                        }

                     
                        double higherRate = Math.Max(oldRate, nightlyRate);
                        double lowerRate = Math.Min(oldRate, nightlyRate);
                        double difference = Math.Abs(nightlyRate - oldRate);  // to take difference amount ( remaining price )

                        // Output
                        Console.WriteLine("===== Upgrade Details =====");

                        Console.WriteLine("Old Room Type : " + oldRoomType);
                        Console.WriteLine("New Room Type : " + roomType);

                        Console.WriteLine("Higher Rate : " + higherRate);
                        Console.WriteLine("Lower Rate : " + lowerRate);

                        Console.WriteLine("Difference Per Night : " + difference);


                        break;

                    case 6:                                  //6. Add Room Service Note


                        Console.WriteLine("=== Add Room Service Note ===");          // we take the note from the guest and recorded

                        Console.Write("Enter service note: ");
                        string newNote = Console.ReadLine().Trim();         


                     
                        if (newNote == "")         // should not be blank
                        {
                            Console.WriteLine("Error: Note cannot be empty.");
                            break;
                        }

                        // Existing notes variable

                        room_notes = room_notes + " | " + newNote;

                        room_notes = room_notes.Replace("bad", "***");  // replace bad to *** in the system

                       
                        Console.WriteLine("Updated Notes:");
                        Console.WriteLine(room_notes);   // will print old note  |  newNote



                        Console.WriteLine("Total Notes Length: " + room_notes.Length);  // to total length of the note

                        break;

                    case 7:                                  // 7. Search Guest by Name 
                        Console.WriteLine("===== Search Guest by Name =====");


                        if (flag_guest == false)  // if there is no guest yet
                        {
                            Console.WriteLine("No guest registered yet");
                        }
                        else
                        {
                            Console.WriteLine("Enter search keyword:");
                            string keyword = Console.ReadLine().ToLower();    // whatever i press will be in lower case

                            string SearchName = guestName.ToLower();       // because in the beginning i used upper case for guest name, i need to converted to lower case to be easy to search

                            if (SearchName.Contains(keyword))
                            {
                                Console.WriteLine("Guest Name: " + guestName);
                                Console.WriteLine("Phone: " + guestPhone);
                                Console.WriteLine("Room Type: " + roomType);
                            }
                            else
                            {
                                Console.WriteLine("No matching guest found.");
                            }
                        }

                        break;

                    case 8:                                // 8. Calculate Loyalty Points"


                        break;

                    case 9:                                //9. Print Receipt


                        break;

                    case 10:                               //10. Edit Guest Name

                        Console.WriteLine("===== Edit Guest Name =====");

                        if (flag_guest == false)
                        {
                            Console.WriteLine("No guest registered yet.");
                        }
                        else
                        {
                            Console.WriteLine("Enter guest name keyword to search:");
                            string keyword = Console.ReadLine().ToLower();  // will read in lower case

                            if (guestName.ToLower().Contains(keyword))
                            {
                         
                                Console.WriteLine("Enter new guest name:");
                                guestName = Console.ReadLine().Trim();  // delete the spaces

                                Console.WriteLine("guest name updated successfully");
                            }
                            else
                            {
                                Console.WriteLine("guest not found");
                            }
                        }
                
                        break;
                        



                    case 11:
                        exit = true;
                        break;


                }

                Console.WriteLine("press any key to continue...");
                Console.ReadKey();  // to press any key to clear
                Console.Clear(); // clear the console 



            }

        }


   
    }
}
