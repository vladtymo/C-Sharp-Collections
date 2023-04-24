﻿using System.Text;
using System.Collections.Generic; // C# 2.0

namespace _01_List
{
    class Program
    {
        static void Main(string[] args)
        {
            //void Add(T item): добавление нового элемента в список
            //
            //void AddRange(ICollection collection): добавление с список коллекции или массива
            //
            //int BinarySearch(T item): бинарный поиск элемента в списке.Если элемент найден, то метод возвращает индекс этого элемента в коллекции. При этом список должен быть отсортирован.
            //
            //int IndexOf(T item): возвращает индекс первого вхождения элемента в списке
            //
            //void Insert(int index, T item): вставляет элемент item в списке на позицию index
            //
            //bool Remove(T item): удаляет элемент item из списка, и если удаление прошло успешно, то возвращает true
            //
            //void RemoveAt(int index): удаление элемента по указанному индексу index
            //
            //void Sort(): сортировка списка

            Console.OutputEncoding = Encoding.UTF8;

            List<int> numbers = new List<int>() { 1, 2, 3, 45 };

            numbers.Add(6); // добавление элемента
            numbers.AddRange(new int[] { 7, 8, 9 });
            numbers.Insert(0, 666); // вставляем на первое место в списке число 666
            numbers.RemoveAt(1); //  удаляем второй элемент

            foreach (int i in numbers)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine("Index of 7: " + numbers.IndexOf(7));

            Console.ReadKey();

            //numbers.Exists((x) => x % 2 == 0);

            List<Person> people = new List<Person>(3);
            Person person = new Person() { Name = "Billy" };
            people.Add(person);
            people.Add(new Person() { Name = "Antony" });
            people.Add(new Person() { Name = "Julia" });
            people.Sort();

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