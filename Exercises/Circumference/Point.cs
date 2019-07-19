using System;

namespace Exercises
{
    public class Point
    {
        readonly float _x;
        readonly float _y;

        public Point(float x, float y)
        {
            _x = x;
            _y = y;
        }

        public double Distance(Point other) => Math.Sqrt(Math.Pow(_x - other._x, 2) + Math.Pow(_y - other._y, 2));

        /// <summary>
        /// Checks if two points are equal
        /// Return false if obj is null or is not an instance of Point otherwise check coordinates equality
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (obj.GetType() != this.GetType())
                return false;

            var other = obj as Point;
            return _x == other._x && _y == other._y;
        }

        public override int GetHashCode() => (int)(_x + _y);
    }
}
