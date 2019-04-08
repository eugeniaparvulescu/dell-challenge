using System;

namespace DellChallenge.C
{
    class Program
    {
        static void Main(string[] args)
        {
            // Please refactor the code below whilst taking into consideration the following aspects:
            //      1. clean coding
            //      2. naming standards
            //      3. code reusability, hence maintainability

            var operations = new Operations();
            var results = Calculate(operations);
            Print(results);

            Console.ReadKey();
        }

        private static int[] Calculate(Operations operations)
        {
            int sumOfTwo = operations.Add(1, 3);
            int sumOfThree = operations.Add(1, 3, 5);

            return new int[] { sumOfTwo, sumOfThree };
        }

        private static void Print(int[] values)
        {
            foreach (int value in values)
            {
                Console.WriteLine(value);
            }
        }
    }
}