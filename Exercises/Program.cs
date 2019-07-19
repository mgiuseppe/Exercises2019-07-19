using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Exercises
{
    class Program
    {
        static void Main(string[] args)
        {
            TestBracketsBalancing();
            TestCircumferencesIntersection();
            TestDigitsOrdering();
            TestSquare();
            TestCollatz();
        }
        
        private static void TestBracketsBalancing()
        {
            Console.WriteLine("Check brackets balancing");
            Console.WriteLine($"Expected True: {"()".AreBracketsBalanced()}");
            Console.WriteLine($"Expected False: {")(".AreBracketsBalanced()}");
            Console.WriteLine($"Expected True: {"([])".AreBracketsBalanced()}");
            Console.WriteLine($"Expected False: {"([)]".AreBracketsBalanced()}");
            Console.WriteLine($"Expected False: {"[()".AreBracketsBalanced()}");
            Console.WriteLine($"Expected True: {"()[]".AreBracketsBalanced()}");
            Console.WriteLine($"Expected True: {"(az+(r-=%[]([a])))".AreBracketsBalanced()}");
        }

        private static void TestCircumferencesIntersection()
        {
            Console.WriteLine();
            Console.WriteLine("Check intersection");
            var c = new Circumference(5, new Point(0, 0));
            var cCoincide = new Circumference(5, new Point(0, 0));
            var cInside = new Circumference(1, new Point(0, 0));
            var cTooDistant = new Circumference(1, new Point(6, 6));
            var cOnePoint = new Circumference(1, new Point(0, 6));
            var cTwoPoint = new Circumference(2, new Point(0, 5));
            Console.WriteLine($"Case Same Object - Expected False: {c.Intersect(c)}");
            Console.WriteLine($"Case Coincide    - Expected False: {c.Intersect(cCoincide)}");
            Console.WriteLine($"Case Inside      - Expected False: {c.Intersect(cInside)}");
            Console.WriteLine($"Case Too Distant - Expected False: {c.Intersect(cTooDistant)}");
            Console.WriteLine($"Case One Point   - Expected True: {c.Intersect(cOnePoint)}");
            Console.WriteLine($"Case Two Points  - Expected True: {c.Intersect(cTwoPoint)}");
        }

        private static void TestDigitsOrdering()
        {
            Console.WriteLine();
            Console.WriteLine("Order Digits in english alphabetical order");
            var digits = new Digits<EnglishSpelledDigit>();
            Console.WriteLine($"Ordered ints: {string.Join(',', digits.OrderAlphabetically(new List<int> { 1, 1, 2, 3, 4, 5, 6, 7, 8, 9, 2, 0 }))}");
            Console.WriteLine($"Ordered ints: {string.Join(',', digits.OrderAlphabetically(new List<int> { 1, 2 }))}");
            Console.WriteLine($"Ordered ints: {string.Join(',', digits.OrderAlphabetically(new List<int> { 1, 9, 0, 5 }))}");
            Console.WriteLine($"Ordered ints: {string.Join(',', digits.OrderAlphabetically(new List<int> { 9, 4, 7, 1, 3 }))}");
        }

        private static void TestSquare()
        {
            Console.WriteLine();
            Console.WriteLine("Compute Square");
            Console.WriteLine($"Case 0 Square: {MyMath.Square(0)}");
            Console.WriteLine($"Case -5 Square: {MyMath.Square(-5)}");
            Console.WriteLine($"Case 10 Square: {MyMath.Square(10)}");
            Console.WriteLine($"Case 0 FunnySquare: {MyMath.FunnySquare(0)}");
            Console.WriteLine($"Case -5 FunnySquare: {MyMath.FunnySquare(-5)}");
            Console.WriteLine($"Case 10 FunnySquare: {MyMath.FunnySquare(10)}");
        }

        private static void TestCollatz()
        {
            Console.WriteLine();
            Console.WriteLine("Collatz");
            var collatz = new Collatz();
            var sw = new Stopwatch();
            var n = 1000000;
            
            sw.Start();
            var startingNumberWithMaxSequenceLength = collatz.ComputeLongestCollatzSequence(n);
            sw.Stop();
            Console.WriteLine($"Starting number {startingNumberWithMaxSequenceLength} found in {sw.Elapsed}");
            Console.WriteLine($"Starting number {startingNumberWithMaxSequenceLength} length: {collatz.ComputeCollatzSequenceLength(startingNumberWithMaxSequenceLength)}");

            sw.Restart();
            startingNumberWithMaxSequenceLength = collatz.ComputeLongestCollatzSequenceLinq(n);
            sw.Stop();
            Console.WriteLine($"Starting number {startingNumberWithMaxSequenceLength} found in {sw.Elapsed}");
        }
    }
}
