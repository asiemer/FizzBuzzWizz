using System;
using System.Collections.Generic;
using FizzBuzzer;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            //print 1 - 15 to screen
            //div by 3 fizz
            //div by 5 buzz
            var result1 = new FizzBuzzerImpl().Start(1, 100, 3, 5);
            print(result1);

            //print 1 - 100 to screen
            //div by 3 fizz
            //div by 5 buzz
            var result2 = new FizzBuzzerImpl().Start(1, 100, new Dictionary<int, string>()
            {
                {3, "Fizz"},
                {5, "Buzz"}
            });
            print(result2);

            //print 1 - 100
            //div by 3 fizz
            //div by 5 buzz
            //div by 8 wizz
            var result3 = new FizzBuzzerImpl().Start(1, 130, new Dictionary<int, string>()
            {
                {3, "Fizz"},
                {5, "Buzz"},
                {8, "Wizz"}
            });
            print(result3);

            Console.ReadLine();
        }

        private static void print(IEnumerable<string> output)
        {
            foreach (string s in output)
            {
                Console.WriteLine(s);
            }
        }
    }
}
