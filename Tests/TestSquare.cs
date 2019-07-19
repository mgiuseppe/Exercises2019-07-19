using System;
using System.Collections.Generic;
using System.Text;
using Exercises;
using Xunit;

namespace Tests
{
    public class TestSquare
    {
        [Theory]
        [InlineData(0, 0)]
        [InlineData(-5, 25)]
        [InlineData(10, 100)]
        public void TestSimpleSquare(int input, int expectedResult)
        {
            //arrange
            //act
            var actualResult = input.Square();
            //assert
            Assert.Equal(expectedResult, actualResult);
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(-5, 25)]
        [InlineData(10, 100)]
        public void TestFunnySquare(int input, int expectedResult)
        {
            //arrange
            //act
            var actualResult = input.Square();
            //assert
            Assert.Equal(expectedResult, actualResult);
        }
    }
}
