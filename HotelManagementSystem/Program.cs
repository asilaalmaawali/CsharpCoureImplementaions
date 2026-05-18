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
            string guestPhone = "";
            int roomNumber = 0;
            string roomType = "";
            string nightlyRate = "";
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


                        break;

                    case 1:                                  // 1. View Guest Information



                        break;

                    case 2:                                 // 2. Check-In Guest 

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
