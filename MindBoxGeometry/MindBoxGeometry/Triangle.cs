using System;

namespace MindBoxGeometry
{
    public class Triangle : I2dShape
    {
        /// <summary>
        /// Стороны треугольника
        /// </summary>
        private double[] Sides;

        /// <summary>
        /// Возвращает длину стороны. При некорректном индексе вернет 0.
        /// </summary>
        /// <param name="n">Индекс стороны, от 0 до 2</param>
        /// <returns>Длина стороны</returns>
        public double GetSide(int n)
        {
            if (n >= 0 && n <= 2) return Sides[n];
            else return 0;
        }

        /// <summary>
        /// Создает треугольник с указанными длинами сторонами. Проверки на корректность нет, пользуйтесь фабрикой!
        /// </summary>
        /// <param name="shapeParams">Массив длин сторон</param>
        public Triangle(double[] shapeParams)
        {

            Sides = new double[3];
            // копируем значения
            for (int i = 0; i < 3; i++)
            {
                Sides[i] = shapeParams[i];
            }

            // Сразу же проверим, является ли он прямоугольным - не вычислять же это каждый раз!
            if (Math.Abs(Sides[0] * Sides[0] + Sides[1] * Sides[1] - Sides[2] * Sides[2]) < .0000001)
            {
                IsOrthoTriangle = true;
            }
            else
            {
                IsOrthoTriangle = false;
            }
            
        }

        /// <summary>
        /// Площадь треугольника
        /// </summary>
        /// <returns></returns>
        public double GetSquare()
        {
            // Вычисляем по формуле Герона
            var p = (Sides[0] + Sides[1] + Sides[2]) / 2;
            return Math.Sqrt(p * (p - Sides[0]) * (p - Sides[1]) * (p - Sides[2]));
        }

        /// <summary>
        /// Признак прямоугольного треугольника
        /// </summary>
        public bool IsOrthoTriangle { get; }
    }

}
