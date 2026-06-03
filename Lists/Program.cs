namespace Lists
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ////////////// Problem 1: Temperature Log 

            
            List < double> temperatures = new List<double> () { 25, 30, 35, 40, 45, 50, 55 }; // declare and initialize for temperatures list
            for (int i = 0; i < temperatures.Count; i++)       // for loop and indexing  // instead using length in array , i use (count)for list
            {

                Console.WriteLine("Day " + (i + 1) + ": " + temperatures[i] + " C");   // indexing


            }
            Console.WriteLine("Total number of readings: " + temperatures.Count);    // length of temperatures 

            Console.WriteLine("=============================");   // to order the output

            ////////////// Problem 2: Student Score Board  

                
            List <int> scores = new List<int> () { 0, 30, 50, 70, 90, 100 }; // list declare and initialization 
            Console.WriteLine("scores: ");
            foreach (int score in scores)  // goes through each value in scores list , regarding to index i use another name (score)
            {

                Console.WriteLine(score);
            }

            Console.WriteLine("--Reversed--");

            scores.Reverse();     // to reverse the scores , not be in order   , reverse in list

            foreach (int score in scores)              // to print the reverse 
            {
                Console.WriteLine(score);
            }
            Console.WriteLine("=============================");   // to order the output


            ////////// Problem 3: Product Price Finder 


            List <double> Prices = new List<double> () { 1.5, 2, 3.5, 4.4, 5 }; // declare and initialize for prices list 
            for (int i = 0; i < Prices.Count; i++)       // for loop and indexing
            {

                Console.WriteLine("Product " + (i + 1) + ": " + Prices[i]);   // indexing

            }


            int index = Prices.IndexOf(2);     // search for position of a value  , instead of using array.indexOf in array , here i use indexof function   prices.indexOf()
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

           
            List<int> finishTimes = new List<int>() { 45, 32, 58, 27, 41, 63, 36, 50 }; // declare and initialize

            Console.WriteLine("finish Times in unsorted times :");
            foreach (int time in finishTimes)              // to print unsorted times 
            {
                Console.WriteLine(time);
            }
           
            finishTimes.Sort(); // sorting in list

            Console.WriteLine("finish Times in sorted time:");
            foreach (int time in finishTimes)              // to print sorted time
            {
                Console.WriteLine(time);
            }

            Console.WriteLine("Number of participants: " + finishTimes.Count);

            Console.WriteLine("=============================");   // to order the output

            /////  Problem 5: Classroom Grade Report 

            
            List<int> grades = new List<int>() { 85, 92, 78, 64, 88, 95, 73, 81, 69, 90 }; // declare and initialize
            grades.Sort(); // sorting in list
          
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

            for (int i = 0; i < grades.Count; i++)       // for loop and indexing
            {

                Console.WriteLine("Rank " + (i + 1) + ": " + grades[i]);   // indexing

            }
            Console.WriteLine("=============================");   // to order the output


            /// Problem 6: Warehouse Inventory Check 

 
            List<int> quantities = new List<int>() { 42, 17, 9, 55, 28, 36, 14, 61 }; // Declare and initialize an list with 8 integer quantity values.

            int totalStock = 0;    // start the sum at zero

            for (int i = 0; i < quantities.Count; i++)
            {
                totalStock = totalStock + quantities[i];                // Calculate total stock
            }

            Console.WriteLine("Total stock: " + totalStock);

            double averageStock = (double)totalStock / quantities.Count;   // converts totalStock from int to decimal number (double).  //Calculate average using .Length
            Console.WriteLine("Average stock per slot: " + averageStock);


            int ii = quantities.IndexOf(36);   // search index for (36) quantity  

            Console.WriteLine("==Result of quantity Search==");
            if (ii != -1)                                     // if there is or not
            {
                Console.WriteLine("Quantity found at index: " + ii);  // ii mean index to not conflict with others index
            }
            else
            {
                Console.WriteLine("Quantity not found");
            }

            Console.WriteLine("=============================");   // to order the output

            // Problem 7: Library Book Shelf Scanner 

            List<int> copies = new List<int>() { 4, 5, 6, 7, 8, 9, 10, 2, 1 };  // Declare and initialize 
            Console.WriteLine("copy counts in original order");

            foreach (int copycount in copies)
            {
                Console.WriteLine(copycount);              // to print in original order
            }

            copies.Sort();
            Console.WriteLine("copy counts in sorted order");
            foreach (int copycount in copies)
            {
                Console.WriteLine(copycount);                    // to print in sorted order
            }

            int maxCopies = copies[8];  // the biggest number is 10 after sorting , so when i want the last number for index (size 9-1 =8) so last index 8
            Console.WriteLine("max copies is :  " + maxCopies);


            for (int i = 0; i < copies.Count; i++)          // for loop to go through every copyies one by one
            {
                if (copies[i] == 0)            // if there is copyies list = 0 they will print zero exists in the array
                {
                    Console.WriteLine("A zero exists in the array");
                    break;
                }

                if (i == copies.Count - 1)      // if it reach to last copyies list without finding 0 so will print not found
                {
                    Console.WriteLine("No zero found in the array");
                }
            }

        }
    }
}
