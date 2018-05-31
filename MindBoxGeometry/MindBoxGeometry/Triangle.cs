using System;

namespace MindBoxGeometry
{
    public class Triangle : I2dShape
    {
        /// <summary>
        /// Длины сторон треугольника
        /// </summary>
        private double[] Sides;

        /// <summary>
        /// Создает треугольник с указанными длинами сторонами. Стороны упорядочиваются по возрастанию длины.
        /// </summary>
        /// <param name="shapeParams">Массив длин сторон</param>
        public Triangle(double[] shapeParams)
        {
            // начинаем с проверки
            Validate(shapeParams);
            Sides = new double[3];
            // копируем значения, а не присваиваем ссылку
            for (int i = 0; i < 3; i++)
            {
                Sides[i] = shapeParams[i];
            }

            // Сразу же проверим, является ли он прямоугольным - не вычислять же это каждый раз!
            // используем обратную теорему Пифагора - это экономичнее, чем считать углы. 
            // стороны уже упорядочены в вызове Validate, 0 и 1 это катеты
            if (Math.Abs(Sides[0] * Sides[0] + Sides[1] * Sides[1] - Sides[2] * Sides[2]) < .0000001)
            {
                IsRightAngle = true;
            }
            else
            {
                IsRightAngle = false;
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
        public bool IsRightAngle { get; }

        /// <summary>
        /// Проверка параметров треугольника.
        /// </summary>
        /// <param name="shapeParams">Длины сторон.</param>
        static private void Validate(double[] shapeParams)
        {
            bool isOk = true;
            string ErrorMessage = "";
            if (shapeParams!= null && shapeParams.Length == 3) // работаем, если есть три параметра
            {
                // во-первых, все ли они больше нуля?
                for (int i = 0; i < 3; i++)
                {
                    if (shapeParams[i] <= 0)
                    {
                        isOk = false;
                        ErrorMessage = "Params must be greater than 0.";
                        break;
                    }
                }
                if (isOk) // если есть смысл продолжать, проверим, треугольник ли это вообще
                {

                    // сумма меньших сторон должна превосходить третью
                    Array.Sort(shapeParams);
                    if (shapeParams[0] + shapeParams[1] <= shapeParams[2])
                    {
                        isOk = false;
                        ErrorMessage = "Triange with those sides doesn't exist.";
                    }
                }
            }
            else
            {
                isOk = false;
                ErrorMessage = "Incorrect triangle params array.";
            }
            if (!isOk)
            {
                throw new ArgumentException(ErrorMessage);
            }
        }

    }

}
