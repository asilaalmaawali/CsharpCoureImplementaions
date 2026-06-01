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


        }
    }
}
