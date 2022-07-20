using System;

namespace CnbParens
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //ValidateTest("()()[]");
            //ValidateTest("()[]{}");
            ValidateTest("([])");
        }

        public static void ValidateTest(string s)
        {
            var p = new BracketTester("()[]{}");

            bool valid = p.IsValid(s);

            Console.Write($"\"{s}\" ==> ");
            Console.WriteLine(valid ? "Valid" : "Invalid");
        }
    }
}
