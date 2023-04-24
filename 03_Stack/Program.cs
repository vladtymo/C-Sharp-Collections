using System.Collections;

namespace _03_Stack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var stack = new Stack();

            stack.Push("First");
            stack.Push("Second");
            stack.Push("Third");
            stack.Push("Fourth");

            // Peek() - get first
            if (stack.Peek() is string)
            {
                string str = (string)stack.Pop();
                Console.WriteLine(str);
            }

            while (stack.Count > 0)
            {
                Console.WriteLine(stack.Pop());
            }

            Console.WriteLine(stack.Pop());

            Console.ReadKey();
        }
    }
}