using Microsoft.Win32;
using System.Diagnostics.Metrics;
using System.Net.NetworkInformation;
using System.Reflection.Metadata;
using System.Reflection.PortableExecutable;
using System.Runtime;
using System.Security.Cryptography;
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
        static string book_genre = "";    // Advanture , Historical , fantasy , science
        static int available_copies=0;   // number of available copies
        static bool Bookisregistered = false;  // whether a book is registered
        static int total_books_borrowed = 0; //  total books borrowed this session
        static int TotalFinesPaid = 0; // total fines paid this session
        //static bool checkResult = CheckisActive();   // inside it checking Memisregistered   , for if condition inside cases ( checkResult) , i declare it here to use it everywhere in cases  || IT CAUSED A CONFUSING ERROR
        static DateTime Today = DateTime.Now;  // for today date
        //static bool checkResultB = CheckBisReg();  // inside it checking Bookisregistered ,  for if condition inside cases ( checkResultB) 
        static int suscription_amount =0;
        static string keyword = "";
        static int Overduedays = 0;
        static double fineRate = 0;

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
            MemName = Console.ReadLine().Substring(0);   // i dont delete any character in the name
            Console.WriteLine("enter Member email:");
            MemEmail = Console.ReadLine();
            Console.WriteLine("enter Member Tier:");
            Memtier = Console.ReadLine();
            if (Memtier == "standard")
            {
               suscription_amount = 10;
               Console.WriteLine(" standard suscription added successfully");
            
        }
            else if (Memtier == "perimum")
            {

                suscription_amount = 30;
                Console.WriteLine(" perimum suscription added successfully");
            }

            Today = DateTime.Now;
            membership_expiry_date = Today.AddDays(183); // 183 days in sex month , from today date after sex month will expired

            Memisregistered = true;
            Console.WriteLine("account information added successfully.");
        }


        public static void ViewMemberInfo()           // here to display member info
        {
            
            Console.WriteLine("Member name:    " + MemName); 
            Console.WriteLine("Member email:     " +MemEmail.PadLeft(5));                // PadLeft it adds spaces to the left side of the text, i do 5 spaces in begining for all.
            Console.WriteLine("Member Tier :      " + Memtier.PadLeft(5));
            Today = DateTime.Now;
            Console.WriteLine("registered Date :      " + Today.ToString().PadLeft(5));
            Console.WriteLine("membership expiry date :     "+ Today.AddDays(183).ToString().PadLeft(5));


        }

        //public static bool CheckBisReg()      // here i want a return ( true or false)  , check if the book registered
        //{
        //    if (Bookisregistered == true)   // if there is a book registered
        //    {
        //        Console.WriteLine("book already exists ");
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }

        //}


        public static bool SearchBook(string keyword)            // i want to return if there a book or not
        {
            keyword = keyword.ToLower();
            BookTitle = BookTitle.ToLower();
            
            return BookTitle.Contains(keyword);                 // containing function , whether a BookTitle contains a keyword.
        }
        public static int Reduce(ref int x)       // return (Reduce) the available copy count of the registered book by 1.  // ref mean we use orginal (available copy) and reduce it and save
        {


            return Math.Max(0, x - 1);          // to start from zero and above 
           
        }
        public static int Restore(ref int available_copies)       // return ( restore)  the available copy count of the registered book by 1.  // ref mean we use orginal (available copy) and restore it and save
        {
            return available_copies + 1;         //  it not go more than available copy
        }


        public static void RegBook()           // to Register book  // optional parameter  , i set book generation as default to science
        {        //string BookTitle, string BookAuthor,int available_copies, string book_genre = "science"
            Console.WriteLine("Enter a Book Title:");
            BookTitle = Console.ReadLine().Trim();                  // read it without spaces
            Console.WriteLine("Enter a Author Book:");
            BookAuthor = Console.ReadLine().Trim();
            Console.WriteLine("Enter a number of copies:");
            available_copies = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the Generation of a book:");
            book_genre = Console.ReadLine();

            Bookisregistered = true;
            Console.WriteLine("Book added successfully.");



        }


        public static void BookDetails()    // named parameters at call site
        {                 //string BookTitle, string BookAuthor, int available_copies, string book_genre


            Console.WriteLine("Book Title:   " +BookTitle);
            Console.WriteLine("Author Book:  " +BookAuthor.PadRight(10));
            Console.WriteLine("Number of copies:       " +available_copies.ToString().PadRight(10));
            Console.WriteLine("the Generation of a book:" +book_genre.PadRight(10));
            
        }

        public static double LateFine(int OverdueDays)
        {
            
            fineRate = Math.Sqrt(OverdueDays) * 2.5;  // 2.5 = fine rate

            return Math.Round(fineRate, 2);
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
                        if (CheckisActive() == true) // if there is a member i will view the information 
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

                        Console.WriteLine("==== Borrow a Book ====");
                       
                        if (Bookisregistered == true)   // if there is a book registered
                        {


                            Console.WriteLine("Number of available copies in library :   " + available_copies);
                            if (available_copies > 0)

                            {
                                Reduce(ref available_copies);
                                Console.WriteLine("available_copies after borrow :   " + Reduce(ref available_copies));
                            }
                            else
                            {

                                Console.WriteLine("The book is out the stock");
                            }

                        }
                        else
                        {

                            Console.WriteLine("The book is not registered");
                        }

              

                        break;

                    case 4:                            // 4. Return a Book 

                        if (Bookisregistered == true)   // if there is a book registered
                        {


                            Console.WriteLine("Number of available copies in library :   " + available_copies);

                            if (available_copies >= 0)

                            {

                                Restore(ref available_copies);
                                //Console.WriteLine("available_copies after borrow :   " + Math.Min(available_copies, Restore(ref available_copies)));   // i mean if the available_copies =0 so i dont need to restore because it already sold out or out of the stock
                                Console.WriteLine("available_copies after borrow :   " + Restore(ref available_copies));
                            }
                        
                        }
                        else
                        {

                            Console.WriteLine("The book is not registered");
                        }

                        break;
                    case 5:                         //5. Calculate Late Fine 

                        Console.WriteLine("Enter overdue days:");
                        int Overduedays = int.Parse(Console.ReadLine());

                        Console.WriteLine("Late Fine = " + LateFine(Overduedays));

                        break;


                    case 6:                                  // 6. Apply Member Discount


                        break;

                    case 7:                                  // 7. Check Borrowing Eligibility


                        break;

                    case 8:                                  // 8. Register Book



                        if (Bookisregistered == false) //there is no Book stored
                        {
                            RegBook();       // BookTitle,BookAuthor,available_copies,book_genre = " science"
                        }
                        else
                        {
                            Console.WriteLine("The book is already exists");
                        }

                        break;



                      

                    case 9:                                  // 9. Generate Member ID 


                        break;

                    case 10:                                  // 10. Display Book Details
                        Console.WriteLine("==== Display Book Details ====");

                        if (Bookisregistered== true)
                        {
                            BookDetails();
                           // BookTitle,BookAuthor,available_copies,book_genre


                        }
                        else
                        {

                            Console.WriteLine("The book is not registered");
                        }

                        break;

                    case 11:                                  // 11. Calculate Renewal Fee


                        break;

                    case 12:                                // 12. Update Member Email 

                        //if (Bookisregistered == true)
                        //{




                        //}




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
