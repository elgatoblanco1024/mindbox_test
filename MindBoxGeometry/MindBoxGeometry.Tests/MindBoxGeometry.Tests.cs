using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MindBoxGeometry.Tests
{
    [TestClass]
    public class MindBoxGeometryTests_Triangle
    {
        /// <summary>
        /// Треугольник с валидными сторонами создается
        /// </summary>
        [TestMethod]
        public void Triangle_sides5_3_4_notNull()
        {
            
            ShapeType shapeType = ShapeType.Triangle;
            double[] shapeParams = { 5, 3, 4 };

            var factory = new ShapeFactory();
            var triangle = factory.GetShape(shapeType, shapeParams);

            Assert.IsNotNull(triangle);
        }

        /// <summary>
        /// Треугольник с невалидными сторонами не создается
        /// </summary>
        [TestMethod]
        public void Triangle_sides10_3_4_Null()
        {

            ShapeType shapeType = ShapeType.Triangle;
            double[] shapeParams = { 10, 3, 4 };

            var factory = new ShapeFactory();
            var triangle = factory.GetShape(shapeType, shapeParams);

            Assert.IsNull(triangle);
        }

        /// <summary>
        /// Треугольник с невалидными сторонами не создается
        /// </summary>
        [TestMethod]
        public void Triangle_sides_n5_3_4_Null()
        {

            ShapeType shapeType = ShapeType.Triangle;
            double[] shapeParams = { -5, 0, 4 };

            var factory = new ShapeFactory();
            var triangle = factory.GetShape(shapeType, shapeParams);

            Assert.IsNull(triangle);
        }

        /// <summary>
        /// Прямоугольный треугольник
        /// </summary>
        [TestMethod]
        public void Triangle_sides5_3_4_Ortho_true()
        {

            ShapeType shapeType = ShapeType.Triangle;
            double[] shapeParams = { 5, 3, 4 };

            var factory = new ShapeFactory();
            var triangle = factory.GetShape(shapeType, shapeParams);

            Assert.IsTrue(((Triangle)triangle).IsOrthoTriangle);
        }

        /// <summary>
        /// Не прямоугольный треугольник
        /// </summary>
        [TestMethod]
        public void Triangle_sides5p1_3_4_Ortho_false()
        {

            ShapeType shapeType = ShapeType.Triangle;
            double[] shapeParams = { 5.1, 3, 4 };

            var factory = new ShapeFactory();
            var triangle = factory.GetShape(shapeType, shapeParams);

            Assert.IsFalse(((Triangle)triangle).IsOrthoTriangle);
        }

        /// <summary>
        /// Площадь
        /// </summary>
        [TestMethod]
        public void Triangle_sides5_3_4_Square_6()
        {

            ShapeType shapeType = ShapeType.Triangle;
            double[] shapeParams = { 5, 3, 4 };

            var factory = new ShapeFactory();
            var triangle = factory.GetShape(shapeType, shapeParams);
            double expected = 6;

            Assert.IsTrue(Math.Abs(triangle.GetSquare() - expected) < .000001);
        }


    }

    [TestClass]
    public class MindBoxGeometryTests_Circle
    {
        /// <summary>
        /// Круг с валидным радиусом создается
        /// </summary>
        [TestMethod]
        public void Circle_r5_notNull()
        {

            ShapeType shapeType = ShapeType.Circle;
            double shapeParams = 5;

            var factory = new ShapeFactory();
            var circle = factory.GetShape(shapeType, shapeParams);

            Assert.IsNotNull(circle);
        }

        /// <summary>
        /// Круг с невалидным радиусом несоздается
        /// </summary>
        [TestMethod]
        public void Circle_rn5_Null()
        {

            ShapeType shapeType = ShapeType.Circle;
            double shapeParams = -5;

            var factory = new ShapeFactory();
            var circle = factory.GetShape(shapeType, shapeParams);

            Assert.IsNull(circle);
        }

        /// <summary>
        /// Площадь круга
        /// </summary>
        [TestMethod]
        public void Circle_r5_Square_78d539()
        {

            ShapeType shapeType = ShapeType.Circle;
            double shapeParams = 5;

            var factory = new ShapeFactory();
            var circle = factory.GetShape(shapeType, shapeParams);
            double expected = 78.539815;

            Assert.IsTrue(Math.Abs(circle.GetSquare() - expected) < .00001);
        }

    }

}
