using System.Collections;

namespace _02_Queue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var queue = new Queue();

            queue.Enqueue("First");
            queue.Enqueue("Second");
            queue.Enqueue("Third");
            queue.Enqueue("Fourth");

            //get First 
            object element = queue.Peek();

            if (element is string)
                Console.WriteLine(element as string); // First

            Console.WriteLine(new string('-', 10));

            Console.WriteLine(queue.Dequeue());

            while (queue.Count > 0)
            {
                Console.WriteLine(queue.Dequeue()); // Second, Third, Fourth.
            }

            element = queue.Peek();
            Console.WriteLine(element as string);

            Console.ReadKey();
        }
    }
}