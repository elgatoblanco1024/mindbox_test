using System;

namespace MindBoxGeometry
{
    public class Circle : I2dShape
    {
        /// <summary>
        /// Радиус круга
        /// </summary>
        public double Radius { get; }

        /// <summary>
        /// Создает круг с указанным радиусом.
        /// </summary>
        /// <param name="radius">Радиус</param>
        public Circle(double radius)
        {
            // проверяем значения
            Validate(radius);
            Radius = radius;
        }

        /// <summary>
        /// Площадь круга
        /// </summary>
        /// <returns></returns>
        public double GetSquare()
        {
            return Math.PI * Radius * Radius;
        }


        static private void Validate(double radius)
        {
            if (radius <= 0)
            {
                throw new ArgumentException("Radius must be greater than 0.");
            }
        }


    }
}
