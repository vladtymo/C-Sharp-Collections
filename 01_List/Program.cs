using System.Text;
using System.Collections.Generic; // C# 2.0

namespace _01_List
{
    class Program
    {
        static void Main(string[] args)
        {
            //void Add(T item): додавання нового елемента до списку
            //
            //void AddRange(ICollection collection): додавання до списку колекції або масиву
            //
            //int BinarySearch(T item): бінарний пошук елемента у списку.Якщо елемент знайдено, то метод повертає індекс цього елемента в колекції. При цьому список має бути відсортований.
            //
            //int IndexOf(T item): повертає індекс першого входження елемента у списку
            //
            //void Insert(int index, T item): вставляє елемент item у списку на позицію index
            //
            //bool Remove(T item): видаляє елемент item зі списку і якщо видалення пройшло успішно, то повертає true
            //
            //void RemoveAt(int index): видалення елемента за вказаним індексом index
            //
            //void Sort(): сортування списку

            Console.OutputEncoding = Encoding.UTF8;

            // generic collections store specific data type
            // introduced in C# 2.0

            List<int> numbers = new List<int>() { 1, 2, 3, 45 };
            
            numbers.Add(6);         // add item to the end
            numbers.AddRange(new int[] { 7, 8, 9 });
            numbers.Insert(0, 666); // insert value {666} to index [0]
            numbers.RemoveAt(1);    // remove item from idenx [1]

            numbers[3] = 555;
            Console.WriteLine("Element[3]: " + numbers[3]);

            foreach (int i in numbers)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine("\nIndex of 7: " + numbers.IndexOf(7)); // if not found: -1

            Console.ReadKey();

            //numbers.Exists((x) => x % 2 == 0);

            List<Person> people = new List<Person>(3);

            Person person = new Person() { Name = "Billy" };
            people.Add(person);
            people.Add(new Person() { Name = "Antony" });
            people.Add(new Person() { Name = "Julia" });

            people.Sort(); // by name

            foreach (Person p in people)
            {
                Console.WriteLine(p.Name);
            }

            Console.ReadLine();
        }
    }

    public class Person : IComparable<Person>
    {
        public string Name { get; set; }

        public int CompareTo(Person other)
        {
            return Name.CompareTo(other.Name);
        }
    }
}
