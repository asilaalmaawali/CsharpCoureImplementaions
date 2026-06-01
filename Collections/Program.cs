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

    
        }
    }
}
