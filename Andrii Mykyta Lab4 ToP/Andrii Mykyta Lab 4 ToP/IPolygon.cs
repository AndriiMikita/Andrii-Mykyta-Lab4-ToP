namespace Andrii_Mykyta_Lab_4_ToP
{
    public interface IPolygon
    {
        int Count { get; }
        Point[] Points { get; }
        double Perimeter { get; }

        void Insert(int index, Point point);
        void Remove(int index);
    }

}
