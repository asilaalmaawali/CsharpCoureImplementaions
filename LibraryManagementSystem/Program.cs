using System.Net.NetworkInformation;
using System.Reflection.PortableExecutable;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LibraryManagementSystem
{
    internal class Program
    {
        // Storage system
        static string MemName = "";
        static int MembID = 0;
        static string MemEmail = "";
        static string membership_expiry_date = "";
        static bool Memisregistered = false;  // whether a member is registered
        static string BoolTitle = "";  
        static string BookAuthor = "";
        static string book_genre = "";
        static int available_copies = 0;   // number of available copies
        static bool Bookisregistered = false;  // whether a book is registered
        static int total_books_borrowed = 0; //  total books borrowed this session
        static int TotalFinesPaid = 0; // total fines paid this session
       


        public static void PrintLMSMainMenu()  // no return , no parameters
        {
            Console.WriteLine("LMS Main Menu:");
            Console.WriteLine("0. Register Member");
            Console.WriteLine("1. Display Member Profile");
            Console.WriteLine("2. Search Book by Title");
            Console.WriteLine("3. Borrow a Book");
            Console.WriteLine("4. Return a Book");
            Console.WriteLine("5. Calculate Late Fine");
            Console.WriteLine("6. Apply Member Discount");
            Console.WriteLine("7. Check Borrowing Eligibility");
            Console.WriteLine("8. Register Book");
            Console.WriteLine("9. Generate Member ID");
            Console.WriteLine("10. Display Book Details");
            Console.WriteLine("11. Calculate Renewal Fee");
            Console.WriteLine("12. Update Member Email ");
            Console.WriteLine("13. Session Summary");
            Console.WriteLine("14. Exit");

        }




        static void Main(string[] args)
        {
            bool exit = false;
            while (exit == false)
            {
                PrintLMSMainMenu();

                Console.WriteLine("please select an option from the menu:");
                int option = int.Parse(Console.ReadLine());

                switch (option)
                {
                    case 0:                                                // 0. Register Member


                        break;

                    case 1:                                  // 1. Display Member Profile

                        break;

                    case 2:                                 //2. Search Book by Title

                        break;

                    case 3:                            // 3. Borrow a Book



                    case 4:                            // 4. Return a Book 

                        break;
                    case 5:                         //5. Calculate Late Fine 

                        break;


                    case 6:                                  // 6. Apply Member Discount


                        break;

                    case 7:                                  // 7. Check Borrowing Eligibility


                        break;

                    case 8:                                  // 8. Register Book


                        break;

                    case 9:                                  // 9. Generate Member ID 


                        break;

                    case 10:                                  // 10. Display Book Details


                        break;

                    case 11:                                  // 11. Calculate Renewal Fee


                        break;

                    case 12:                                // 12. Update Member Email 
                        break;



                    case 13:                                // 13. Session Summary
                        break;

                    case 14:
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
