using System;
using Xunit;
using Exercises;

namespace Tests
{
    public class TestBracketsExtensions
    {
        [Theory]
        [InlineData("()", true)]
        [InlineData(")(", false)]
        [InlineData("([])", true)]
        [InlineData("([)]", false)]
        [InlineData("[()", false)]
        [InlineData("()[]", true)]
        [InlineData("(az+(r-=%[]([a])))", true)]
        [InlineData(null, true)]
        [InlineData("", true)]
        public void TestAreBracketsBalanced(string bracketsExpression, bool expectedResult)
        {
            //arrange
            //act
            var actualResult = bracketsExpression.AreBracketsBalanced();
            //assert
            Assert.Equal(expectedResult, actualResult);
        }
    }
}
