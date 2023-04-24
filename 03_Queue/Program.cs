using System.Text;

namespace _03_Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            // FIFO
            Queue<int> numbers = new Queue<int>();

            numbers.Enqueue(3); // queue: 3
            numbers.Enqueue(5); // queue: 3, 5
            numbers.Enqueue(8); // queue: 3, 5, 8

            // get and remove the first element
            int queueElement = numbers.Dequeue(); // queue: 5, 8
            Console.WriteLine(queueElement);
            Console.ReadKey();

            Queue<Person> persons = new Queue<Person>();
            persons.Enqueue(new Person() { Name = "Tom" });
            persons.Enqueue(new Person() { Name = "Bill" });
            persons.Enqueue(new Person() { Name = "John" });

            // inspect the first item
            Person pp = persons.Peek();
            Console.WriteLine(pp.Name);

            Console.WriteLine("Сейчас в очереди {0} человек", persons.Count);

            // queue: Tom, Bill, John
            foreach (Person p in persons)
            {
                Console.WriteLine(p.Name);
            }

            // get and remove the first element - Tom
            Person person = persons.Dequeue(); // queue: Bill, John
            Console.WriteLine(person.Name);

            Console.ReadLine();
        }
    }

    class Person
    {
        public string Name { get; set; }
    }
}