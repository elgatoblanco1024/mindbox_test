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
            I2dShape triangle = factory.GetShape(ShapeType.Triangle, 5, 3, 4);
            Console.WriteLine("Triangle with sides 5,3,4 has square {0}", triangle.GetSquare());
            I2dShape circle = factory.GetShape(ShapeType.Circle, 5.5 );
            Console.WriteLine("Circle with radius 5.5 has square {0}", circle.GetSquare());
            Console.ReadKey();
        }
    }
}
