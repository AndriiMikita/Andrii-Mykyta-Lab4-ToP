using Andrii_Mykyta_Lab_4_ToP;
using System.Drawing;
using Point = Andrii_Mykyta_Lab_4_ToP.Point;
using Rectangle = Andrii_Mykyta_Lab_4_ToP.Rectangle;

namespace Andrii_Mikita_Lab4_ToP_Tests
{
    [TestFixture]
    public class PolygonTests
    {
        [Test]
        public void Polygon_ConstructorWithNoArguments_CreatesPolygonWithThreeRandomPoints()
        {
            Polygon polygon = new Polygon();
            Assert.AreEqual(3, polygon.Count);
        }

        [Test]
        public void Polygon_ConstructorWithPointsArray_CreatesPolygonWithGivenPoints()
        {
            Point[] points = new Point[]
            {
                new Point(0, 0),
                new Point(1, 1),
                new Point(2, 2)
            };

            Polygon polygon = new Polygon(points);
            Assert.AreEqual(3, polygon.Count);
            CollectionAssert.AreEqual(points, polygon.Points);
        }

        [Test]
        public void Polygon_ConstructorWithXCoordinatesAndYCoordinatesArrays_CreatesPolygonWithGivenPoints()
        {
            int[] xCoordinates = new int[] { 0, 1, 2 };
            int[] yCoordinates = new int[] { 0, 1, 2 };

            Polygon polygon = new Polygon(xCoordinates, yCoordinates);
            Assert.AreEqual(3, polygon.Count);

            Point[] expectedPoints = new Point[]
            {
                new Point(0, 0),
                new Point(1, 1),
                new Point(2, 2)
            };

            CollectionAssert.AreEqual(expectedPoints, polygon.Points);
        }

        [Test]
        public void Polygon_Insert_AddsPointAtGivenIndex()
        {
            Polygon polygon = new Polygon();
            Point point = new Point(3, 3);

            polygon.Insert(1, point);

            Assert.AreEqual(4, polygon.Count);
            Assert.AreEqual(point, polygon.Points[0]);
        }

        [Test]
        public void Polygon_Remove_RemovesPointAtGivenIndex()
        {
            Point[] points = new Point[]
            {
                new Point(0, 0),
                new Point(1, 1),
                new Point(2, 2)
            };

            Polygon polygon = new Polygon(points);

            polygon.Remove(2);

            Assert.AreEqual(2, polygon.Count);
            Assert.AreEqual(points[2], polygon.Points[1]);
        }

        [Test]
        public void Polygon_Perimeter_CalculatesPerimeterCorrectly()
        {
            Point[] points = new Point[]
            {
                new Point(0, 0),
                new Point(3, 0),
                new Point(0, 4)
            };

            Polygon polygon = new Polygon(points);

            double expectedPerimeter = 12.0;
            Assert.AreEqual(expectedPerimeter, polygon.Perimeter);
        }

        [Test]
        public void Polygon_Equals_ReturnsTrueForEqualPolygons()
        {
            Point[] points1 = new Point[]
            {
                new Point(1, -3),
                new Point(2, -2),
                new Point(3, -1)
            };

            Point[] points2 = new Point[]
            {
                new Point(0, 0),
                new Point(1, 1),
                new Point(2, 2)
            };

            Polygon polygon1 = new Polygon(points1);
            Polygon polygon2 = new Polygon(points2);
            
            Assert.IsTrue(polygon1.Equals(polygon2));
        }

        [Test]
        public void Polygon_Equals_ReturnsFalseForDifferentPolygons()
        {
            Point[] points1 = new Point[]
            {
                new Point(0, 0),
                new Point(1, 1),
                new Point(2, 2)
            };

            Point[] points2 = new Point[]
            {
                new Point(0, 0),
                new Point(2, 2),
                new Point(1, 1)
            };

            Polygon polygon1 = new Polygon(points1);
            Polygon polygon2 = new Polygon(points2);

            Assert.IsFalse(polygon1.Equals(polygon2));
            Assert.IsTrue(polygon1 != polygon2);
        }

        [Test]
        public void Polygon_GetEnumerator_EnumeratesPointsInOrder()
        {
            Point[] points = new Point[]
            {
                new Point(0, 0),
                new Point(1, 1),
                new Point(2, 2)
            };

            Polygon polygon = new Polygon(points);

            int i = 0;
            foreach (Point point in polygon)
            {
                Assert.AreEqual(points[i], point);
                i++;
            }
        }

        public void Polygon_SerializePolygon_SerializesAndDeserializesPolygonCorrectly()
        {
            Point[] points = new Point[]
            {
                new Point(0, 0),
                new Point(1, 1),
                new Point(2, 2)
            };

            Polygon polygon = new Polygon(points);

            polygon.SerializePolygon();

        }

        [Test]
        public void Rectangle_ConstructorWithNoArguments_CreatesRectangleWithThreeRandomPoints()
        {
            Rectangle rectangle = new Rectangle();
            Assert.AreEqual(3, rectangle.Count);
        }

        [Test]
        public void Rectangle_ConstructorWithPointsArray_CreatesRectangleWithGivenPoints()
        {
            Point[] points = new Point[]
            {
                new Point(0, 0),
                new Point(1, 1),
                new Point(2, 2)
            };

            Rectangle rectangle = new Rectangle(points);
            Assert.AreEqual(3, rectangle.Count);
            CollectionAssert.AreEqual(points, rectangle.Points);
        }

        [Test]
        public void Rectangle_ConstructorWithXCoordinatesAndYCoordinatesArrays_CreatesRectangleWithGivenPoints()
        {
            int[] xCoordinates = new int[] { 0, 1, 2 };
            int[] yCoordinates = new int[] { 0, 1, 2 };

            Rectangle rectangle = new Rectangle(xCoordinates, yCoordinates);
            Assert.AreEqual(3, rectangle.Count);

            Point[] expectedPoints = new Point[]
            {
                new Point(0, 0),
                new Point(1, 1),
                new Point(2, 2)
            };

            CollectionAssert.AreEqual(expectedPoints, rectangle.Points);
        }

        [Test]
        public void Rectangle_Square_CalculatesSquareCorrectly()
        {
            Point[] points = new Point[]
            {
                new Point(0, 0),
                new Point(3, 0),
                new Point(3, 4)
            };

            Rectangle rectangle = new Rectangle(points);

            double expectedSquare = 12.0;
            Assert.AreEqual(expectedSquare, rectangle.Square);
        }

        [Test]
        public void Rectangle_Perimeter_CalculatesPerimeterCorrectly()
        {
            Point[] points = new Point[]
            {
                new Point(0, 0),
                new Point(3, 0),
                new Point(3, 4)
            };

            Rectangle rectangle = new Rectangle(points);

            double expectedPerimeter = 14.0;
            Assert.AreEqual(expectedPerimeter, rectangle.Perimeter);
        }
    }
}