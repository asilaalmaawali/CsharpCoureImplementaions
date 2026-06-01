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






        }
    }
}
