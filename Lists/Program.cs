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







        }
    }
}
