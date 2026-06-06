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

            Console.WriteLine("=========================================================");
            //Medium
            // Problem 3: Text Editor Undo System 

            Stack<string> undoStack = new Stack<string>();

            //// stores action descriptions in the order they were performed

            undoStack.Push("Type text");
            undoStack.Push("Delete text");
            undoStack.Push("Format text");
            undoStack.Push("Insert image");
            undoStack.Push("Copy text");
            undoStack.Push("Paste text");
            undoStack.Push("Save file");

            foreach (string undo in undoStack)
            {

                Console.WriteLine(undo);  //  display all

            }
            Console.WriteLine("-------------------------");
            Console.WriteLine("undone next:  " + undoStack.Peek());  // show which action would be undone next


            Console.WriteLine("Undo: " + undoStack.Pop());  // to remove and print
            Console.WriteLine("Undo: " + undoStack.Pop());
            Console.WriteLine("-------------------------");
            foreach (string undo in undoStack)
            {

                Console.WriteLine(undo);  //  display remaining undo history         // before also removing the middle one

            }

            Console.WriteLine("-------------------------");

            Stack<string> tempStack = new Stack<string>(); //Temporary stack 
           

            tempStack.Push(undoStack.Pop());     // delete ir from undoStack and store it in tempStack  // (remove "Copy text")
            tempStack.Push(undoStack.Pop());      // (remove "Insert image")
            undoStack.Pop(); //(remove "Format text") without saving it in any place

            undoStack.Push(tempStack.Pop());  // here now i add "Copy text" again in undoStack and remove it from tempStack
            undoStack.Push(tempStack.Pop());  // here now i add "Insert image" again in undoStack and remove it from tempStack

            foreach (string undo in undoStack)
            {

                Console.WriteLine(undo);  //  print after removing the middle one ("Format text")

            }
            Console.WriteLine("Final number of remaining actions: " + undoStack.Count);
            Console.WriteLine("======================================");
            // Problem 4: Hospital Emergency Room Triage 

            Queue<string> triageQueue = new Queue<string>();

            //  Enqueue 8 hardcoded patient names. 

            triageQueue.Enqueue("Sara");
            triageQueue.Enqueue("Ahmed");
            triageQueue.Enqueue("Asila");
            triageQueue.Enqueue("Budoor");
            triageQueue.Enqueue("Ammar");
            triageQueue.Enqueue("Emad");
            triageQueue.Enqueue("Asad");


            int position = 1;

            foreach (string patient in triageQueue)
            {
                Console.WriteLine("Position" +position +" : "+ patient);
                position++;
            }
            Console.WriteLine("---------------------------------------");

            Console.WriteLine("Next patient to be seen: " + triageQueue.Peek());   //  Peek to show who will be seen next.

            Console.WriteLine("---------------------------------------");

            for (int i = 0; i < 3; i++)  //  (dequeue) the first 3 patients and display each name as they are seen.
            {
                string patient = triageQueue.Dequeue();  // to remove
                Console.WriteLine("Patient seen:" +patient);
            }


            Console.WriteLine("---------------------------------------");
            Console.WriteLine("Remaining queue: " + triageQueue.Count);


        }
    }
}
