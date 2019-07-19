using System;
using System.Linq;
using System.Threading.Tasks;

namespace Exercises
{
    /// <summary>
    /// This class is robust enough to achieve the results asked in the exercise
    /// But this is not rock solid and it's a naive implementation so don't try to call this method passing int32.Max as maxStartingNumber because for simplicity's sake i'm not catching outofmemoryexpections and i'm not managing
    /// I assume that for each input you can pass to the function it will converge because wikipedia says that it has already been test for each starting number below 10^20
    /// </summary>
    public class Collatz
    {
        public int ComputeLongestCollatzSequenceLinq(int maxStartingNumber) => Enumerable.Range(1, maxStartingNumber)
                                                                                         .AsParallel()
                                                                                         .OrderByDescending(n => ComputeCollatzSequenceLength(n))
                                                                                         .First();

        public int ComputeLongestCollatzSequence(int maxStartingNumber)
        {
            if (maxStartingNumber <= 0)
                throw new ArgumentException("The max starting number must be a positive integer", nameof(maxStartingNumber));

            var lengths = new int[maxStartingNumber];
            Parallel.For(1, maxStartingNumber + 1, n =>
            {
                lengths[n - 1] = ComputeCollatzSequenceLength(n);
            });
            return Array.IndexOf(lengths, lengths.Max()) + 1;
        }

        public int ComputeCollatzSequenceLength(int startingNumber)
        {
            checked
            {
                var length = 1;
                long next = startingNumber;
                while (next != 1)
                {
                    next = next % 2 == 0 ? (next / 2) : (3 * next + 1);
                    length++;
                }
                return length;
            }
        }
    }
}