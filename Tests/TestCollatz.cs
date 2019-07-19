using System;
using System.Collections.Generic;
using System.Text;
using Exercises;
using Xunit;

namespace Tests
{
    public class TestCollatz
    {
        [Theory]
        [InlineData(1, 1)]
        [InlineData(4, 3)]
        [InlineData(13, 9)]
        public void ComputeLongestCollatzSequence_ValidStartingNumber_ReturnsStartingNumberWithLongestSequence(int maxStartingNumber, int expectedResult)
        {
            //arrange
            var collatz = new Collatz();
            //act
            var actualResult = collatz.ComputeLongestCollatzSequence(maxStartingNumber);
            //assert
            Assert.Equal(expectedResult, actualResult);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        public void ComputeLongestCollatzSequence_NonPositiveStartingNumber_ThrowsException(int maxStartingNumber)
        {
            //arrange
            var collatz = new Collatz();
            //act (local function)
            object act() => collatz.ComputeLongestCollatzSequence(maxStartingNumber);
            //assert
            Assert.ThrowsAny<Exception>(act);
        }

        [Theory]
        [InlineData(1, 1)]
        [InlineData(4, 3)]
        [InlineData(13, 9)]
        public void ComputeLongestCollatzSequenceLinq_ValidStartingNumber_ReturnsStartingNumberWithLongestSequence(int maxStartingNumber, int expectedResult)
        {
            //arrange
            var collatz = new Collatz();
            //act
            var actualResult = collatz.ComputeLongestCollatzSequenceLinq(maxStartingNumber);
            //assert
            Assert.Equal(expectedResult, actualResult);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        public void ComputeLongestCollatzSequenceLinq_NonPositiveStartingNumber_ThrowsException(int maxStartingNumber)
        {
            //arrange
            var collatz = new Collatz();
            //act (local function)
            object act() => collatz.ComputeLongestCollatzSequenceLinq(maxStartingNumber);
            //assert
            Assert.ThrowsAny<Exception>(act);
        }

        [Theory]
        [InlineData(1, 1)]
        [InlineData(3, 8)]
        [InlineData(9, 20)]
        public void ComputeCollatzSequenceLength_ReturnsCollatzSequenceLength(int startingNumber, int expectedResult)
        {
            //arrange
            var collatz = new Collatz();
            //act (local function)
            var actualResult = collatz.ComputeCollatzSequenceLength(startingNumber);
            //assert
            Assert.Equal(expectedResult, actualResult);
        }
    }
}
