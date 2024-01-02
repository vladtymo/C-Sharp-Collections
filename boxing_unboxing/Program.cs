using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _00_boxing_unboxing
{
    class Program
    {
        static void Main(string[] args)
        {
            // reference types  - stores in HEAP  (slower)
            // value types      - stores in STACK (faster)

            // boxing   - from value-type to reference-type
            // unboxing - wise-wersa

            string str = "hello heap";  // heap
            int number = 445;           // stack

            // boxing
            object obj = (object)number;// stack -> heap (boxing)

            // unboxing
            number = (int)obj;          // heap -> stack (unboxing)

            // nullable
            int? nullableInt = 55;      // heap

            // boxing
            MyClass my = new MyClass(number);

            // unboxing
            int res = (int)my;
        }
    }
    class MyClass
    {
        public int Number { get; set; }

        public MyClass(int num = 0)
        {
            Number = num;
        }

        public static explicit operator int(MyClass @class)
        {
            return @class.Number;
        }
    }
}