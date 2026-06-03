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
        }
    }
}
