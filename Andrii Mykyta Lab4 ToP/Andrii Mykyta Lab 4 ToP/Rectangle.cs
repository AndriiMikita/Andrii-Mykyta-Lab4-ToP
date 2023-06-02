namespace Andrii_Mykyta_Lab_4_ToP
{
    public class Rectangle : Polygon
    {
        private double square;

        public Rectangle()
        {
            Random random = new Random();
            count = 3;
            for (int i = 0; i < 3; i++)
            {
                int x = random.Next(points.Length);
                int y = random.Next(points.Length);
                points[i] = new Point(x, y);
            }
        }

        public Rectangle(Point[] points)
        {
            this.points = points;
            count = points.Length;
        }

        public Rectangle(int[] xCoordinates, int[] yCoordinates)
        {
            if (xCoordinates.Length != yCoordinates.Length)
            {
                throw new ArgumentException("Масиви координат повинні мати однакову довжину.");
            }

            if (xCoordinates.Length < 3)
            {
                throw new ArgumentException("Масиви координат повинні мати хоча б 3 елементи.");
            }

            count = xCoordinates.Length;
            points = new Point[count];
            for (int i = 0; i < count; i++)
            {
                points[i] = new Point(xCoordinates[i], yCoordinates[i]);
            }
        }

        public double Square
        {
            get 
            {
                square = Distance(Points[0], Points[1]) * Distance(Points[2], Points[1]);
                return square;
            }
        }

        public double Perimeter =>  (Distance(Points[0], Points[1]) + Distance(Points[2], Points[1])) * 2;
    }
}
