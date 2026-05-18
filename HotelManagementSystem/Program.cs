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
            double discount_percentage;
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


                        bool RegisterationMenu = false;

                        while (RegisterationMenu == false)
                        {


                            Console.WriteLine(" ========== Registeration ============");
                            Console.WriteLine("1. Guest registeration ");
                            Console.WriteLine("2. Room type option");
                            Console.WriteLine("0. Exit ");
                            Console.WriteLine("Enter the choice :   ");
                            int choice = int.Parse(Console.ReadLine());
                            Random random = new Random();   // here we need first to generate a random genrator

                            if (choice == 1)
                            {

                                Console.WriteLine(" Enter the guest Name :    ");
                                guestName = Console.ReadLine().Trim();           // removes the space from the begining and end (not in between)
                                Console.WriteLine(" Enter the guest Phone:  ");
                                guestPhone = int.Parse(Console.ReadLine());
                                roomNumber = random.Next(1, 100);

                                int exit_gr = -1;
                                Console.WriteLine("Enter number 0 to exit");
                                exit_gr = int.Parse(Console.ReadLine());


                                if (exit_gr == 0)
                                {
                                    Console.WriteLine("press any key to continue...");
                                    Console.ReadKey();  // to press any key to clear
                                    Console.Clear(); // clear the console 
                                }
                                else
                                {

                                    Console.WriteLine("Invalid number");


                                }

                            }

                            else if (choice == 2)
                            {


                                bool roomTypeMenu = false;

                                while (roomTypeMenu == false)
                                {

                                    Console.WriteLine("===== Room Type =====");
                                    Console.WriteLine("1. Single room ");
                                    Console.WriteLine("2. Double room ");
                                    Console.WriteLine("3. Suite room ");
                                    Console.WriteLine("0. Exit ");
                                    Console.WriteLine("Enter the number :    ");
                                    int number = int.Parse(Console.ReadLine());


                                    if (number == 1)

                                    {
                                        roomType = "Single room";
                                        nightlyRate = 25;
                                        Console.WriteLine(" A single room has been booked ");

                                    }
                                    else if (number == 2)
                                    {
                                        roomType = " Double room";
                                        nightlyRate = 50;
                                        Console.WriteLine(" A Double room has been booked ");

                                    }
                                    else if (number == 3)
                                    {
                                        roomType = " Suite room";
                                        nightlyRate = 100;
                                        Console.WriteLine(" A Suite room has been booked ");

                                    }
                                    else if (number == 0)
                                    {
                                        roomTypeMenu = true;

                                        Console.WriteLine("Returning to Registration Menu...");
                                        Console.ReadKey();
                                        Console.Clear();
                                    }
                                    else
                                    {
                                        Console.WriteLine(" Invalied number ");
                                    }
                                }


                            }
                            else if (choice == 0)
                            {

                                RegisterationMenu = true;

                                Console.WriteLine("Returning to  Hotel Main Menu...");
                                Console.ReadKey();
                                Console.Clear();



                            }
                            else
                                {

                                Console.WriteLine(" Invalied choice ");

                            }


                        }
                            break;

                    case 1:                                  // 1. View Guest Information


                        Console.WriteLine(" ========== View Guest Information ============"); 
                        Console.WriteLine(" Guest name : " + guestName.ToUpper()); // display name with Upper case
                        Console.WriteLine(" Guest Phone : " + guestPhone.ToString()); // convert phone to string
                        Console.WriteLine(" room type :" + roomType);
                        Console.WriteLine(" nightly rate " + Math.Round(nightlyRate).ToString()); //  when we use round , the data type should be double + converted to string
                        break;

                    case 2:                                 // 2. Check-In Guest 

                        Console.WriteLine(" ========== Check-In Guest  ============");

                        Console.WriteLine(" Enter the guest Name :    ");
                        string name = Console.ReadLine().Trim();


                        if (guestName == name )

                        {
                            Console.WriteLine(" Enter the number of nights :");
                            number_of_nights = int.Parse(Console.ReadLine());
                            check_inDate = DateTime.Now;
                            check_inDate = DateTime.Today;
                            check_outDate = check_inDate.AddDays(number_of_nights);

                            Console.WriteLine("Check-In Date: " + check_inDate.ToString());  // to convert date to string
                            Console.WriteLine("Check-Out Date: " + check_outDate.ToString());
               
                        }
                        else
                        {
                            Console.WriteLine(" there is no guest with this name ");

                        }

                        break;

                    case 3:                            // 3 Check-Out & Bill





                        break;

                    case 4:                         //4. Apply Discount 


                        break;


                    case 5:                                  // 5. Upgrade Room 


                        break;

                    case 6:                                  //6. Add Room Service Note


                        break;

                    case 7:                                  // 7. Search Guest by Name 


                        break;

                    case 8:                                // 8. Calculate Loyalty Points"


                        break;

                    case 9:                                //9. Print Receipt


                        break;

                    case 10:                               //10. Edit Guest Name


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
