using System;

namespace DellChallenge.A
{
    class Program
    {
        static void Main(string[] args)
        {
            // State and explain console output order.
            /*
             * A.A() is written first, because in an inheritance chain the constructors are called in order, from the base class to the derived class
             * B.B() is written second, because B derives from A 
             * A .Age() is written last, because the set method is called at the end of B's constructor
             */

            new B();
            Console.ReadKey();
        }
    }

    class A
    {
        private int _age;
        public int Age
        {
            get { return _age; }
            set
            {
                _age = value;
                Console.WriteLine("A .Age");
            }
        }

        public A()
        {
            Console.WriteLine("A.A()");
        }
    }

    class B : A
    {
        public B()
        {
            Console.WriteLine("B.B()");
            Age = 0;
        }
    }
}