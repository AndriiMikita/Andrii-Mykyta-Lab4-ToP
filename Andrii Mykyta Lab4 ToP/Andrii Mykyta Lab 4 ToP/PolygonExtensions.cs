namespace Andrii_Mykyta_Lab_4_ToP
{
    public static class PolygonExtensions
    {
        public static void PrintPoints(this Polygon polygon)
        {
            Console.WriteLine("Polygon Points:");
            foreach (var point in polygon)
            {
                Console.WriteLine(point);
            }
        }
    }
}
