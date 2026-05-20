using System.Diagnostics.Metrics;
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
        static string Memtier = "";
        static DateTime membership_expiry_date;
        static bool Memisregistered = false;  // whether a member is registered
        static string BookTitle = "";  
        static string BookAuthor = "";
        static string book_genre = "";
        static int available_copies = 0;   // number of available copies
        static bool Bookisregistered = false;  // whether a book is registered
        static int total_books_borrowed = 0; //  total books borrowed this session
        static int TotalFinesPaid = 0; // total fines paid this session
        //static bool checkResult = CheckisActive();   // inside it checking Memisregistered   , for if condition inside cases ( checkResult) , i declare it here to use it everywhere in cases  || IT CAUSED A CONFUSING ERROR
        DateTime Today = DateTime.Now;  // for today date
        //static bool checkResultB = CheckBisReg();  // inside it checking Bookisregistered ,  for if condition inside cases ( checkResultB) 
     
        static string keyword = "";


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

        public static bool CheckisActive()         // void — with parameters  ( true or false)
        {
            if (Memisregistered == true)   // if there is a member registered
            {
                Console.WriteLine("Member information already exists ");
                return true;
            }
            else
            {
                return false;
            }

        }


        public static void AddMemInformation()           // to add member information
        {
            Console.WriteLine("enter Member name:");
            MemName = Console.ReadLine().Substring(0);   // i dont to delete any character in the name
            Console.WriteLine("enter Member email:");
            MemEmail = Console.ReadLine();
            Console.WriteLine("enter Member Tier:");
            Memtier = Console.ReadLine();
            DateTime Today = DateTime.Now;
            membership_expiry_date = Today.AddDays(183); // 183 days in sex month , from today date after sex month will expired

            Memisregistered = true;
            Console.WriteLine("account information added successfully.");
        }


        public static void ViewMemberInfo()           // here to display member info
        {
            Memisregistered = true;
            Console.WriteLine("Member name:    " + MemName.PadLeft(5)); 
            Console.WriteLine("Member email:     " +MemEmail.PadLeft(5));                // PadLeft it adds spaces to the left side of the text, i do 5 spaces in begining for all.
            Console.WriteLine("Member Tier :      " + Memtier.PadLeft(5));
            DateTime Today = DateTime.Now;
            Console.WriteLine("registered Date :      " + Today.ToString().PadLeft(5));
            Console.WriteLine("membership expiry date :     "+ Today.AddDays(183).ToString().PadLeft(5));


        }

        public static bool CheckBisReg()      // here i want a return ( true or false)  , check if the book registered
        {
            if (Bookisregistered == true)   // if there is a book registered
            {
                Console.WriteLine("book already exists ");
                return true;
            }
            else
            {
                return false;
            }

        }


        public static bool SearchBook(string keyword)            // i want to return if there a book or not
        {
            keyword = keyword.ToLower();
            BookTitle = BookTitle.ToLower();
            
            return BookTitle.Contains(keyword);                 // containing function , whether a BookTitle contains a keyword.
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
                        Console.WriteLine("===Register Member===");

                        
                        if (CheckisActive() == false) //there is no account stored
                        {
                            AddMemInformation();
                        }

                        break;

                    case 1:                                  // 1. Display Member Profile

                        Console.WriteLine("===Display Member Profile===");
                        if (CheckisActive() == false) // if there is a member i will view the information 
                        {
                            ViewMemberInfo();
                        }

                        break;

                    case 2:                                 //2. Search Book by Title
                        Console.WriteLine("==== Search Book by Title ====");                 // here i used 2 function , 1. to return bool ( book registered or not ) 2. search book Void no need for any return just print
                        
                         Console.WriteLine("Enter search keyword:    ");
                         keyword = Console.ReadLine();    // whatever i press will be in lower case
                       
                        
                        if (SearchBook(keyword) == false)  // here if search book not contain keyword , will print not available
                        {
                            Console.WriteLine("There is no book available");
                        }
                        else
                        {
                            Console.WriteLine("The book is available");
                        }

                        break;


                    case 3:                            // 3. Borrow a Book

                    /*
                     * 
                     Reduce the available copy 
                    count of the registered book 
                    by 1. The function that 
                    performs the reduction must 
                    receive the copy count and 
                    modify the original variable 
                    in the caller — not a copy of 
                    it. 
                     * 
                     * 
                     * 
                     */

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
