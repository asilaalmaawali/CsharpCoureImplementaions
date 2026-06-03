using System.Timers;

namespace Collections
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ////////////// Problem 1: Temperature Log 

             double[] temperatures = new double [7] {25,30,35,40,45,50,55};   // declare and initialize for temperatures array + 

            for (int i = 0; i < temperatures.Length; i++)       // for loop and indexing
            {

                Console.WriteLine("Day " + (i + 1) +": "+ temperatures[i] +" C");   // indexing


            }
            Console.WriteLine("Total number of readings: " + temperatures.Length);    // length of temperatures 

            Console.WriteLine("=============================");   // to order the output
            ////////////// Problem 2: Student Score Board  

            int[] scores = new int[6] { 0, 30, 50, 70, 90, 100};          // Array initialization 

            Console.WriteLine("scores: ");
            foreach (int score in scores)  // goes through each value in scores array , regarding to index i use another name (score)
            {

                Console.WriteLine(score);
            }

            Console.WriteLine("--Reversed--");

            Array.Reverse(scores);     // to reverse the scores , not be in order

            foreach (int score in scores)              // to print the reverse 
            {
                Console.WriteLine(score);
            }
            Console.WriteLine("=============================");   // to order the output
            ////////// Problem 3: Product Price Finder 


            double[] Prices = new double[5] {1.5 , 2 , 3.5 , 4.4 , 5};  // declare and initialize for prices array 

            for (int i = 0; i < Prices.Length; i++)       // for loop and indexing
            {

                Console.WriteLine("Product " + (i + 1) + ": " + Prices[i] );   // indexing

            }


            int index = Array.IndexOf(Prices, 2);      // search for position of a value
            if (index == -1)             // if not their will print its not found
            {
                Console.WriteLine("Item not found in the array");
            }
            else
            {
                Console.WriteLine("Item found at index: " + index); // 2 will find it in index 2 
            }
            // Medium
            Console.WriteLine("=============================");   // to order the output
            //////////////// Problem 4: Race Finish Times 

            int [] finishTimes = new int[8] { 45, 32, 58, 27, 41, 63, 36, 50 }; // Declare and initialize


            Console.WriteLine("finish Times in unsorted times :");
            foreach (int time in finishTimes)              // to print unsorted times 
            {
                Console.WriteLine(time);
            }

            finishTimes.Sort();
            Console.WriteLine("finish Times in sorted time:");
            foreach (int time in finishTimes)              // to print sorted time
            {
                Console.WriteLine(time);
            }

            Console.WriteLine("Number of participants: " + finishTimes.Length);

            Console.WriteLine("=============================");   // to order the output
            /////  Problem 5: Classroom Grade Report 

            int[] grades = new int[10] { 85, 92, 78, 64, 88, 95, 73, 81, 69, 90 }; // Declare and initialize

            grades.Sort();
            Console.WriteLine("Sorted grades: ");
            foreach (int grade in grades)              // to print sorted grades
            {
                Console.WriteLine(grade);
            }

            grades.Reverse();

            Console.WriteLine("Reverse grades: ");
            foreach (int grade in grades)              // to print sorted grades
            {
                Console.WriteLine(grade);
            }

            for (int i = 0; i < grades.Length; i++)       // for loop and indexing
            {

                Console.WriteLine("Rank " + (i + 1) + ": " + grades[i]);   // indexing

            }
            Console.WriteLine("=============================");   // to order the output
            /// Problem 6: Warehouse Inventory Check 

            int[] quantities = new int[8] { 42, 17, 9, 55, 28, 36, 14, 61 };  // Declare and initialize an array with 8 integer quantity values.

            int totalStock = 0;    // start the sum at zero

            for (int i = 0; i < quantities.Length; i++)
            {
                totalStock = totalStock + quantities[i];                // Calculate total stock
            }

            Console.WriteLine("Total stock: " + totalStock);

            double averageStock = (double)totalStock / quantities.Length;   // converts totalStock from int to decimal number (double).  //Calculate average using .Length
            Console.WriteLine("Average stock per slot: " + averageStock);


            int ii = Array.IndexOf(quantities, 36);   // search index for (36) quantity  

            Console.WriteLine("==Result of quantity Search==");
            if (ii != -1)                                     // if there is or not
            {
                Console.WriteLine("Quantity found at index: " + ii);  // ii mean index to not conflict with others index
            }
            else
            {
                Console.WriteLine("Quantity not found");
            }




        }
    }
}
