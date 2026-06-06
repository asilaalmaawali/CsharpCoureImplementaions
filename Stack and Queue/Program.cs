namespace Stack_and_Queue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Problem 1: Browser History Tracker ( stack)

            Stack <string> browserHistory = new Stack<string>();

            // i push 5 hardcoded page URL one by one
            browserHistory.Push("https://www.google.com");  // this will the last one in stack , this will remove first if we want to remove from the stack
            browserHistory.Push("https://www.linkedin.com");
            browserHistory.Push("https://www.github.com");
            browserHistory.Push("https://www.youtube.com");
            browserHistory.Push("https://www.microsoft.com");  // this in the top of stack

            foreach (string browser in browserHistory)
            {

                Console.WriteLine(browser);       // to print the URL
            }

            Console.WriteLine("Current Page:  " + browserHistory.Peek());  // to display the current page 


            Console.WriteLine("Back 1: " +browserHistory.Pop());  // to remove and print
            Console.WriteLine("Back 2: " +browserHistory.Pop());

            foreach (string browser in browserHistory)
            {

                Console.WriteLine(browser);       // to print the URLs after pop (remove)
            }

            // Check whether a specific hardcoded URL is still in the history and print the result , here i can use contain to check

            bool is_found = browserHistory.Contains("https://www.github.com");    // contains here output true or false

            if (is_found)    // if it true
            {
                Console.WriteLine("https://www.github.com is in the browser history");  
            }
            else
            {
                Console.WriteLine("https://www.github.com is not in the browser history");  // if it false
            }

            Console.WriteLine("Total pages in browser history: " + browserHistory.Count);  // to count the pages


            Console.WriteLine("=========================================================");

            // Problem 2: Hotel Check-In Queue


            Queue <string> checkInQueue = new Queue<string>();

            // 5 hardcoded guest names

            checkInQueue.Enqueue("Asila");     // first
            checkInQueue.Enqueue("Noor");
            checkInQueue.Enqueue("Suad");
            checkInQueue.Enqueue("Hilal");
            checkInQueue.Enqueue("Hamed");    // last

            foreach (string name in checkInQueue)
            {


                Console.WriteLine(name);  //  Display all waiting guests in order

            }

            Console.WriteLine("next guest in check-in queue: " + checkInQueue.Peek()); // use Peek to display who is next without removing them from the queue

            Console.WriteLine("Served: " + checkInQueue.Dequeue());    // remove and print
            Console.WriteLine("Served: " + checkInQueue.Dequeue());


            Console.WriteLine("After serving :  ");

            foreach (string name in checkInQueue)
            {

                Console.WriteLine(name);  //  display after serving.

            }

            bool isWaiting = checkInQueue.Contains("omar");    // here i want to try if the name not their

            if (isWaiting)
            {
                Console.WriteLine("Omar is still waiting in the check-in queue");
            }
            else
            {
                Console.WriteLine("Omar is not in the check-in queue");
            }

            Console.WriteLine("Total guests still in queue: " + checkInQueue.Count);   



        }
    }
}
