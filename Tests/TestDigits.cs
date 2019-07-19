using System;
using System.Collections.Generic;
using System.Text;
using Exercises;
using Xunit;

namespace Tests
{
    public class TestDigits
    {
        [Theory]
        [MemberData(nameof(EnglishData))]
        public void OrderAlphabetically_EnglishAlphabeticalOrder(List<int> unorderedDigits, List<int> expectedOrderedDigits)
        {
            //arrange
            var orderer = new Digits<EnglishSpelledDigit>();
            //act
            var actualOrderedDigits = orderer.OrderAlphabetically(unorderedDigits);
            //assert
            Assert.Equal<int>(actualOrderedDigits, expectedOrderedDigits);
        }

        [Theory]
        [MemberData(nameof(ItalianData))]
        public void OrderAlphabetically_ItalianAlphabeticalOrder(List<int> unorderedDigits, List<int> expectedOrderedDigits)
        {
            //arrange
            var orderer = new Digits<ItalianSpelledDigit>();
            //act
            var actualOrderedDigits = orderer.OrderAlphabetically(unorderedDigits);
            //assert
            Assert.Equal<int>(actualOrderedDigits, expectedOrderedDigits);
        }

        [Theory]
        [MemberData(nameof(PartialNumeralData))]
        public void OrderAlphabetically_PartialNumerals_SortsMissingValueAccordingToNumberCharacter(List<int> unorderedDigits, List<int> expectedOrderedDigits)
        {
            //arrange
            var orderer = new Digits<PartialNumeral>();
            //act
            var actualOrderedDigits = orderer.OrderAlphabetically(unorderedDigits);
            //assert
            Assert.Equal<int>(actualOrderedDigits, expectedOrderedDigits);
        }

        [Theory]
        [MemberData(nameof(BadData))]
        public void OrderAlphabetically_BadInput_ThrowsException(List<int> unorderedDigits)
        {
            //arrange
            var orderer = new Digits<ItalianSpelledDigit>();
            //act
            object act() => orderer.OrderAlphabetically(unorderedDigits);
            //assert
            Assert.ThrowsAny<Exception>(act);
        }

        public static IEnumerable<object[]> EnglishData =>
            new List<object[]>
            {
                new object[] { new List<int> { 1, 1, 2, 3, 4, 5, 6, 7, 8, 9, 2, 0 }, new List<int> { 8, 5, 4, 9, 1, 1, 7, 6, 3, 2, 2, 0 } },
                new object[] { new List<int> { 1, 2 }, new List<int> { 1, 2 } },
                new object[] { new List<int> { 1, 9, 0, 5 }, new List<int> { 5, 9, 1, 0 } },
                new object[] { new List<int> { 9, 4, 7, 1, 3 }, new List<int> { 4,9,1,7,3 } }
            };

        public static IEnumerable<object[]> ItalianData =>
            new List<object[]>
            {
                new object[] { new List<int> { 1, 1, 2, 3, 4, 5, 6, 7, 8, 9, 2, 0 }, new List<int> { 5, 2, 2, 9, 8, 4, 6, 7, 3, 1, 1, 0 } },
                new object[] { new List<int> { 1, 2 }, new List<int> { 2, 1 } },
                new object[] { new List<int> { 1, 9, 0, 5 }, new List<int> { 5, 9, 1, 0 } },
                new object[] { new List<int> { 9, 4, 7, 1, 3 }, new List<int> { 9, 4, 7, 3, 1 } }
            };

        public static IEnumerable<object[]> PartialNumeralData =>
            new List<object[]>
            {
                new object[] { new List<int> { 1, 9, 0, 5 }, new List<int> { 5, 9, 1, 0 } },
                new object[] { new List<int> { 9, 4, 7, 1, 3 }, new List<int> { 3, 4, 7, 9, 1 } }
            };
        public enum PartialNumeral { Zero, One }

        public static IEnumerable<object[]> BadData =>
            new List<object[]>
            {
                new object[] { null },
                new object[] { new List<int> { 10, 4, 7, 1, 3 } },
                new object[] { new List<int> { 9, 4, 7, 1, -1 } }
            };
    }
}
