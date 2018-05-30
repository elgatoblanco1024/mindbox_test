using System;

namespace MindBoxGeometry
{
    public class ShapeFactory
    {
        public string ErrorMessage { get; private set; }

        /// <summary>
        /// Предоставляет экземпляр фигуры с указанными параметрами. Проводит проверку входных данных.
        /// </summary>
        /// <param name="shapeType">Тип фигуры</param>
        /// <param name="shapeParams">Массив параметров фигуры.
        /// Треугольниrк - длины трех сторон, 
        /// Круг - радиус
        /// </param>
        /// <returns></returns>
        public I2dShape GetShape(ShapeType shapeType, params double[] shapeParams)
        {
            I2dShape result = null;
            switch(shapeType)
            {
                case ShapeType.Triangle:
                    result = GetTriangle(shapeParams);
                    break;
                case ShapeType.Circle:
                    result = GetCircle(shapeParams);
                    break;
            }
            return result;
        }

        private Triangle GetTriangle(double[] shapeParams)
        {
            Triangle result = null;
            // проверяем входные данные
            bool isOk = true;
            if (shapeParams.Length == 3) // работаем, если есть три параметра
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
                    // также сортировка - подготовка к проверке на прямоугольный треукольник
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
            if(isOk)
            {
                result = new Triangle(shapeParams);
            }
            return result;
       }

        /// <summary>
        /// Создает круг с указанным радиусом
        /// </summary>
        /// <param name="radius"></param>
        /// <returns></returns>
        private Circle GetCircle(double[] radius)
        {
            Circle result = null;
            if (radius != null && radius.Length == 1)
            {
                if (radius[0] > 0)
                {
                    result = new Circle(radius[0]);
                }
                else
                {
                    ErrorMessage = "Radius must be greater than 0.";
                }
            }
            else
            {
                ErrorMessage = "Incorrect circle params array.";
            }
            return result;
        }

    }

}
