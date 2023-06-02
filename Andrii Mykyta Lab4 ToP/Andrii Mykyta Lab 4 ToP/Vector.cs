namespace Andrii_Mykyta_Lab_4_ToP
{
    public class Vector
    {
        public int X { get; }
        public int Y { get; }

        public Vector(int x, int y)
        {
            X = x;
            Y = y;
        }

        public static double operator *(Vector v1, Vector v2)
        {
            return v1.X * v2.X + v1.Y * v2.Y;
        }
    }
}
