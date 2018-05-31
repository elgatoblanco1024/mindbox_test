using System;

namespace MindBoxGeometry
{
    public class ShapeFactory
    {
        public string ErrorMessage { get; private set; }

        /// <summary>
        /// Предоставляет экземпляр фигуры с указанными параметрами. Обрабатывает исключения, записывает сообщение в ErrorMessage и возвращает null.
        /// </summary>
        /// <param name="shapeType">Тип фигуры</param>
        /// <param name="shapeParams">Массив параметров фигуры.
        /// Треугольниrк - длины трех сторон, 
        /// Круг - радиус
        /// </param>
        /// <returns>Объект фигуры</returns>
        public I2dShape GetShape(ShapeType shapeType, params double[] shapeParams)
        {
            I2dShape result = null;
            try
            {
                switch (shapeType)
                {
                    case ShapeType.Triangle:
                        result = new Triangle(shapeParams);
                        break;
                    case ShapeType.Circle:
                        result = new Circle(shapeParams[0]);
                        break;
                }
            }
            catch (ArgumentException e)
            {
                ErrorMessage = e.Message;
            }
            return result;
        }
    }

}
