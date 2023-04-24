using System.Collections;

namespace _01_ArrayList
{
    internal class Program
    {
        static void Main()
        {
            var list = new ArrayList();

            // add a single element
            string s = "Hello";
            list.Add(s);
            list.Add("hi");
            list.Add(50);
            list.Add(new object());

            // add a collection of the elements
            var anArray = new[] { "more", "or", "less" };
            list.AddRange(anArray);

            var anotherArray = new[] { new object(), new ArrayList() };
            list.AddRange(anotherArray);

            foreach (var item in list)
            {
                System.Console.WriteLine(item);
            }
            Console.ReadKey();

            list.Add("Hello");              // add to end
            list.Remove("Hello");           // remove from begin
            list.RemoveAt(list.Count - 1);  // remove from end

            list.Insert(3, "Hey All");

            var moreString = new[] { "goodnight", "see ya" };
            list.InsertRange(4, moreString);

            foreach (var item in list)
            {
                System.Console.WriteLine(item);
            }
            Console.ReadKey();

            //-----------------------------------------
            var listFixed = ArrayList.FixedSize(list);
            System.Console.WriteLine(list.IsFixedSize);
            System.Console.WriteLine(listFixed.IsFixedSize);
            //listFixed.Add(12);
            //listFixed.Add(10);

            list.RemoveRange(0, 4);

            string myString = "see ya";

            if (list.Contains(myString))
            {
                int index = list.IndexOf(myString);
                Console.WriteLine("Remove element!");
                list.RemoveAt(index);
            }
            else
            {
                Console.WriteLine("Clear list!");
                list.Clear();
            }
        }
    }
}