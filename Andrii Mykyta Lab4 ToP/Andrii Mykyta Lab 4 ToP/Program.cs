using Andrii_Mykyta_Lab_4_ToP;

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
polygon1.Equals(polygon2);