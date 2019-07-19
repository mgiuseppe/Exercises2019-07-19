using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercises
{
    /// <summary>
    /// Provides methods for operations on digits
    /// </summary>
    /// <typeparam name="TEnumSpelledDigits">Enum containing the numerals of each digit in a particular language</typeparam>
    public class Digits<TEnumSpelledDigits> where TEnumSpelledDigits : Enum
    {
        /// <summary>
        /// Returns the list of ints ordered according to the numerals contained in TEnumSpelledDigits.
        /// If TEnumSpelledDigits misses some numerals that numeral will be sorted with as the corresponding number character
        /// </summary>
        public IEnumerable<int> OrderAlphabetically(List<int> unorderedInts)
        {
            if (unorderedInts == null)
                throw new ArgumentNullException("list cannot be null", nameof(unorderedInts));
            if (unorderedInts.Any(x => x > 9 || x < 0))
                throw new ArgumentException("every x in unorderedInts must be 0 <= x <= 9");

            return unorderedInts.OrderBy(x => ((TEnumSpelledDigits)(object)x).ToString());
        }
    }
}
