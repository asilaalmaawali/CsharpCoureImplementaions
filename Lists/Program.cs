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











        }
    }
}
