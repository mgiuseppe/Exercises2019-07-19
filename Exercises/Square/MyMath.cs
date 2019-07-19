using System;

namespace Exercises
{
    /// <summary>
    /// This class is really simple and has no dependencies so it's ok to implement it as an helper (see Math). You can also use this as extension methods
    /// </summary>
    public static class MyMath
    {
        public static int Square(this int x)
        {
            var result = 0;

            checked
            {
                var absX = Math.Abs(x);

                //calculates absX times absX
                for (var i = 0; i < absX; i++)
                    result += absX;
            }

            return result;
        }

        public static int FunnySquare(this int x)
        {
            checked
            {
                return x == 0 ? 0 : (int)(x / (1.0 / x));
            }
        }
    }
}
