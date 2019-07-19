using System;
using System.Collections.Generic;
using Exercises;
using Xunit;

namespace Tests
{
    /// <summary>
    /// I'm not testing the methods exposed by Point but in a real context I should
    /// </summary>
    public class TestCircumference
    {
        [Theory]
        [MemberData(nameof(Data))]
        public void TestIntersect(Circumference c1, Circumference c2, bool expectedResult)
        {
            //arrange
            //act
            var actualResult = c1.Intersect(c2);
            //assert
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void Intersect_OtherNull_ThrowsArgumentNullException()
        {
            //arrange
            var c1 = new Circumference(1, new Point(1, 2));
            //act
            object act() => c1.Intersect(null);
            //assert
            Assert.Throws<ArgumentNullException>(act);
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] { new Circumference(5, new Point(0, 0)), new Circumference(5, new Point(0, 0)), false }, //coincide
                new object[] { new Circumference(5, new Point(0, 0)), new Circumference(1, new Point(0, 0)), false }, //inside
                new object[] { new Circumference(5, new Point(0, 0)), new Circumference(1, new Point(6, 6)), false }, //too distant
                new object[] { new Circumference(5, new Point(0, 0)), new Circumference(1, new Point(0, 6)), true },  //one point intersection
                new object[] { new Circumference(5, new Point(0, 0)), new Circumference(2, new Point(0, 5)), true }   //two points intersection
            };
    }
}
