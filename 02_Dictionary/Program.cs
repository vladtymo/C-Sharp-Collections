using System.Text;

namespace _02_Dictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            Dictionary<string, string> countries = new Dictionary<string, string>();

            countries.Add("UA", "Ukraine");
            countries.Add("GB", "Great Britain");
            countries.Add("USA", "United States");
            countries.Add("FR", "France");
            countries.Add("CH", "China");
            countries.Add("PL", "Poland");

            foreach (KeyValuePair<string, string> keyValue in countries)
            {
                Console.WriteLine(keyValue.Key + " - " + keyValue.Value);
            }
            Console.ReadKey();

            // get item by key
            string country = countries["USA"];
            Console.WriteLine(country);

            // change the item
            countries["USA"] = "America";
            // add the item if it's not exist
            countries["IN"] = "India";
            // remove by key
            countries.Remove("GB");

            foreach (KeyValuePair<string, string> keyValue in countries)
            {
                Console.WriteLine(keyValue.Key + " - " + keyValue.Value);
            }
            Console.ReadKey();

            ///////////////2
            Dictionary<char, Person> people = new Dictionary<char, Person>();

            people.Add('b', new Person() { Name = "Bill" });
            people.Add('t', new Person() { Name = "Tom" });
            people.Add('j', new Person() { Name = "John" });
            people.Add('r', new Person() { Name = "Rita" });

            foreach (KeyValuePair<char, Person> keyValue in people)
            {
                // keyValue.Value is an instance of Person class
                Console.WriteLine(keyValue.Key + " - " + keyValue.Value.Name);
            }
            Console.ReadKey();

            Console.WriteLine("\n\n changed value START");
            foreach (var keyValue in people)
            {
                Console.WriteLine(keyValue.Key + " - " + keyValue.Value.Name);
            }
            Console.WriteLine("original end");

            if (people.ContainsKey('r'))
            {
                people['r'].Name = "rat";
            }
            else
            {
                Console.WriteLine("Collection does not contain such key");
            }
            foreach (var keyValue in people)
            {
                Console.WriteLine(keyValue.Key + " - " + keyValue.Value.Name);
            }
            Console.WriteLine("changed value END");

            // get all keys
            foreach (char c in people.Keys)
            {
                Console.WriteLine(c);
            }

            // get all values
            foreach (Person p in people.Values)
            {
                Console.WriteLine(p.Name);
            }

            ////////adding
            Dictionary<char, Person> people2 = new Dictionary<char, Person>();
            people2.Add('b', new Person() { Name = "Bill" });
            people2['a'] = new Person() { Name = "Alice" };

            /////////init
            Dictionary<string, string> countries2 = new Dictionary<string, string>
            {
                {"Франція", "Париж"},
                {"Германия", "Берлін"},
                {"Великобританія", "Лондон"}
            };

            foreach (var pair in countries2)
                Console.WriteLine("{0} - {1}", pair.Key, pair.Value);

            ////// C# 6.0
            Dictionary<string, string> countries3 = new Dictionary<string, string>
            {
                ["Франція"] = "Париж",
                ["Германія"] = "Берлін",
                ["Великобританія"] = "Лондон"
            };

            foreach (var pair in countries3)
                Console.WriteLine("{0} - {1}", pair.Key, pair.Value);

            ///////////// with custom key
            Dictionary<Identity, string> staff = new Dictionary<Identity, string>();

            staff.Add(new Identity() { SerialNumber = 123, Authority = "6677" }, "Vova");

            if (staff.ContainsKey(new Identity() { SerialNumber = 123, Authority = "6677" }))
                Console.WriteLine("Exists!");
            else Console.WriteLine("Not exists!");

            staff[new Identity() { SerialNumber = 444 }] = "Vika";

            foreach (var item in staff)
            {
                Console.WriteLine(item.Key + " - " + item.Value);
            }
        }
    }

    class Identity
    {
        public long SerialNumber { get; set; }
        public string? Authority { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is Identity identity &&
                   SerialNumber == identity.SerialNumber;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(SerialNumber);
        }

        public override string ToString()
        {
            return $"{SerialNumber} {Authority}";
        }
    }

    internal class Person
    {
        public string Name { get; internal set; }
    }
}