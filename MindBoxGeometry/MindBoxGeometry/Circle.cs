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
        /// Создает круг с указанным радиусом. Нет проверки корректности, используйте на свой страх и риск или пользуйтесь фабрикой!
        /// </summary>
        /// <param name="radius"></param>
        public Circle(double radius)
        {
            // проверяем значения
            if(radius > 0)
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
    }
}
