using System;

namespace Exercises
{
    public class Circumference
    {
        readonly float _radius;
        readonly Point _centre;

        public Circumference(float radius, Point centre)
        {
            if (radius <= 0)
                throw new ArgumentException("argument must be greater than zero", nameof(radius));
            if (centre == null)
                throw new ArgumentNullException(nameof(centre));

            _radius = radius;
            _centre = centre;
        }

        /// <summary>
        /// Check if this interstects other
        /// If the circumferences coincide (same centre and radius) intersect is false
        /// </summary>
        public bool Intersect(Circumference other)
        {
            if (other == null)
                throw new ArgumentNullException(nameof(other));

            var distanceBetweenCentres = Distance(other);

            var isCircumferencesCoincide = _centre.Equals(other._centre) && _radius == other._radius;
            var isOneInsideTheOther = distanceBetweenCentres < Math.Abs(_radius - other._radius);
            var isTooDistant = distanceBetweenCentres > _radius + other._radius;

            return !isCircumferencesCoincide && !isOneInsideTheOther && !isTooDistant;
        }

        /// <summary>
        /// Returns the distance between the centres of this circumference and the other one
        /// </summary>
        private double Distance(Circumference other) => _centre.Distance(other._centre);
    }
}
