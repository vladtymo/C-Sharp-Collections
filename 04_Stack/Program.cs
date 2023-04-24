using System.Text;

namespace _04_Stack
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            // LIFO
            Stack<int> numbers = new Stack<int>();

            numbers.Push(3); // stack: 3
            numbers.Push(5); // stack: 5, 3
            numbers.Push(8); // stack: 8, 5, 3

            // get the top element/last (8)
            int stackElement = numbers.Pop(); // stack: 5, 3
            Console.WriteLine(stackElement);

            Stack<Person> persons = new Stack<Person>();
            persons.Push(new Person() { Name = "Tom" });
            persons.Push(new Person() { Name = "Bill" });
            persons.Push(new Person() { Name = "John" });

            foreach (Person p in persons)
            {
                Console.WriteLine(p.Name);
            }

            // inspect the top/last element
            Person person = persons.Pop(); // stack: Bill, Tom
            Console.WriteLine(person.Name);

            Console.ReadLine();
        }
    }

    class Person
    {
        public string Name { get; set; }
    }
}