using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MindBoxGeometry;

namespace MindboxGeometryDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var factory = new ShapeFactory();
            
            // треугольник
            I2dShape triangle = factory.GetShape(ShapeType.Triangle, 3, 4, 5);
            Console.WriteLine("Triangle has square {0}, it's {1}a right angle triangle.",
                triangle.GetSquare(), ((Triangle)triangle).IsRightAngle == true ? "" : "not ");
            
            // круг
            I2dShape circle = factory.GetShape(ShapeType.Circle, 5.5 );
            Console.WriteLine("Circle has square {0}", circle.GetSquare());
            Console.ReadKey();
        }
    }
}
