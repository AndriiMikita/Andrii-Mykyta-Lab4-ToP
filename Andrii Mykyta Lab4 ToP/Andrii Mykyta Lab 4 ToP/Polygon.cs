using Newtonsoft.Json;
using System.Collections;
using System.Text;

namespace Andrii_Mykyta_Lab_4_ToP
{
    [Serializable]
    public class Polygon : IEnumerable<Point>, IEquatable<Polygon>, IPolygon
    {
        /// <summary>
        /// Масив точок, що утворюють полігон.
        /// </summary>
        public Point[] points = new Point[1000000];

        /// <summary>
        /// Кількість точок у полігоні.
        /// </summary>
        public int count = 0;

        /// <summary>
        /// Ініціалізує новий екземпляр класу Polygon з випадковими координатами для трьох точок.
        /// </summary>
        public Polygon()
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

        /// <summary>
        /// Ініціалізує новий екземпляр класу Polygon з заданими точками.
        /// </summary>
        /// <param name="points">Масив точок, що утворюють полігон.</param>
        public Polygon(Point[] points)
        {
            this.points = points;
            count = points.Length;
        }

        /// <summary>
        /// Ініціалізує новий екземпляр класу Polygon з заданими координатами точок.
        /// </summary>
        /// <param name="xCoordinates">Масив значень координат X точок.</param>
        /// <param name="yCoordinates">Масив значень координат Y точок.</param>
        public Polygon(int[] xCoordinates, int[] yCoordinates)
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

        /// <summary>
        /// Кількість точок у полігоні.
        /// </summary>
        public int Count => this.count;

        /// <summary>
        /// Масив точок, що утворюють полігон.
        /// </summary>
        public Point[] Points
        {
            get
            {
                Point[] points = new Point[count];
                for (int i = 0; i < Count; i++)
                    points[i] = this.points[i];
                return points;
            }
        }

        /// <summary>
        /// Периметр полігону.
        /// </summary>
        public double Perimeter
        {
            get
            {
                double perimeter = 0;
                for (int i = 0; i < Count - 1; i++)
                {
                    perimeter += Distance(points[i], points[i + 1]);
                }
                perimeter += Distance(points[0], points[^1]);
                return perimeter;
            }
        }

        /// <summary>
        /// Вставляє нову точку у задане місце у полігоні.
        /// </summary>
        /// <param name="index">Індекс, на якому потрібно вставити точку.</param>
        /// <param name="point">Точка, яку потрібно вставити.</param>
        public void Insert(int index, Point point)
        {
            try
            {
                for (int i = Count; i > index; i--)
                {
                    points[i] = points[i - 1];
                }
                points[index - 1] = point;
                count++;
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine("Забагато точок для многокутника.");
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Видаляє точку з заданого індексу у полігоні.
        /// </summary>
        /// <param name="index">Індекс точки, яку потрібно видалити.</param>
        public void Remove(int index)
        {
            for (int i = index; i < Count; i++)
            {
                points[i - 1] = points[i];
            }
            count--;
        }

        /// <summary>
        /// Перетворює полігон, масштабуючи його координати на заданий множник.
        /// </summary>
        /// <param name="polygon">Початковий полігон.</param>
        /// <param name="factor">Множник масштабування.</param>
        /// <returns>Масштабований полігон.</returns>
        public static Polygon operator *(Polygon polygon, int factor)
        {
            Point[] points = polygon.Points;
            for (int i = 0; i < polygon.Count; i++)
            {
                points[i] = new Point(points[i].X * factor, points[i].Y * factor);
            }
            return new Polygon(points);
        }

        /// <summary>
        /// Зсуває полігон на заданий вектор.
        /// </summary>
        /// <param name="polygon">Початковий полігон.</param>
        /// <param name="vector">Вектор зсуву.</param>
        /// <returns>Полігон після зсуву.</returns>
        public static Polygon operator +(Polygon polygon, Vector vector)
        {
            Point[] points = polygon.Points;
            for (int i = 0; i < polygon.Count; i++)
            {
                points[i] = new Point(points[i].X + vector.X, points[i].Y * vector.Y);
            }
            return new Polygon(points);
        }

        /// <summary>
        /// Порівнює два полігона на рівність.
        /// </summary>
        /// <param name="polygon1">Перший полігон.</param>
        /// <param name="polygon2">Другий полігон.</param>
        /// <returns>Значення true, якщо полігони рівні; в іншому випадку — значення false.</returns>
        public static bool operator ==(Polygon polygon1, Polygon polygon2)
        {
            if (ReferenceEquals(polygon1, polygon2))
            {
                return true;
            }

            if (ReferenceEquals(polygon1, null) || ReferenceEquals(polygon2, null))
            {
                return false;
            }

            if (polygon1.Count != polygon2.Count)
            {
                return false;
            }

            for (int i = 0; i < polygon1.Count; i++)
            {
                if (polygon1.Points[i] != polygon2.Points[i])
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Порівнює два полігона на нерівність.
        /// </summary>
        /// <param name="polygon1">Перший полігон.</param>
        /// <param name="polygon2">Другий полігон.</param>
        /// <returns>Значення true, якщо полігони нерівні; в іншому випадку — значення false.</returns>
        public static bool operator !=(Polygon polygon1, Polygon polygon2)
        {
            return !(polygon1 == polygon2);
        }

        /// <summary>
        /// Обчислює відстань між двома точками.
        /// </summary>
        /// <param name="p1">Перша точка.</param>
        /// <param name="p2">Друга точка.</param>
        /// <returns>Відстань між точками.</returns>
        public static double Distance(Point p1, Point p2)
        {
            double dx = p2.X - p1.X;
            double dy = p2.Y - p1.Y;
            return Math.Sqrt(dx * dx + dy * dy);
        }

        /// <summary>
        /// Повертає перебірник для точок полігону.
        /// </summary>
        /// <returns>Перебірник для точок полігону.</returns>
        public IEnumerator<Point> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return points[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// Порівнює поточний полігон з іншим полігоном на рівність.
        /// </summary>
        /// <param name="other">Полігон, з яким потрібно порівняти поточний полігон.</param>
        /// <returns>Значення true, якщо полігони рівні; в іншому випадку — значення false.</returns>
        public bool Equals(Polygon other)
        {
            Console.WriteLine(1);
            if (ReferenceEquals(this, other))
            {
                return true;
            }
            Console.WriteLine(2);
            if (ReferenceEquals(other, null))
            {
                return false;
            }
            Console.WriteLine(3);
            if (Count != other.Count)
            {
                return false;
            }
            Console.WriteLine(4);
            Vector shift = new Vector(other.Points[0].X - points[0].X, other.Points[0].Y - points[0].Y);
            for (int i = 1; i < Count; i++)
            {
                Vector temp = new Vector(other.Points[i].X - points[i].X, other.Points[i].Y - points[i].Y);
                if (temp.Equals(shift))
                {
                    return false;
                }
            }
            Console.WriteLine(6);
            return true;
        }

        /// <summary>
        /// Порівнює поточний полігон з іншим об'єктом на рівність.
        /// </summary>
        /// <param name="obj">Об'єкт, з яким потрібно порівняти поточний полігон.</param>
        /// <returns>Значення true, якщо об'єкти рівні; в іншому випадку — значення false.</returns>
        public override bool Equals(object obj)
        {
            return Equals(obj as Polygon);
        }

        /// <summary>
        /// Повертає хеш-код для поточного полігону.
        /// </summary>
        /// <returns>Хеш-код для поточного полігону.</returns>
        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 3;
                for (int i = 0; i < Count; i++)
                {
                    hash = hash * 17 + points[i].GetHashCode();
                }
                return hash;
            }
        }

        /// <summary>
        /// Повертає рядкове представлення поточного полігону.
        /// </summary>
        /// <returns>Рядкове представлення полігону.</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Polygon:");
            for (int i = 0; i < Count; i++)
            {
                sb.AppendLine($"Point {i + 1}: {points[i]}");
            }
            sb.AppendLine($"Perimeter: {Perimeter}");
            return sb.ToString();
        }

        /// <summary>
        /// Серіалізує поточний полігон у файл з розширенням .json.
        /// </summary>
        public void SerializePolygon()
        {
            Polygon polygon = this;
            string json = JsonConvert.SerializeObject(polygon, Formatting.Indented);

            File.WriteAllText("polygon.json", json);

            string jsonFromFile = File.ReadAllText("polygon.json");

            Polygon deserializedPolygon = JsonConvert.DeserializeObject<Polygon>(jsonFromFile);

            Console.WriteLine(deserializedPolygon.ToString());
        }

        /// <summary>
        /// Отримує прямокутник, який описує межі полігону.
        /// </summary>
        /// <returns>Прямокутник, що описує межі полігону.</returns>
        public Rectangle GetRect()
        {
            int minX = points[0].X;
            int minY = points[0].Y;
            int maxX = points[0].X;
            int maxY = points[0].Y;

            for (int i = 1; i < Count; i++)
            {
                int x = points[i].X;
                int y = points[i].Y;

                if (x < minX)
                {
                    minX = x;
                }
                if (x > maxX)
                {
                    maxX = x;
                }
                if (y < minY)
                {
                    minY = y;
                }
                if (y > maxY)
                {
                    maxY = y;
                }
            }

            int width = maxX - minX;
            int height = maxY - minY;

            Point[] rectPoints = new Point[4];
            rectPoints[0] = new Point(minX, minY);
            rectPoints[1] = new Point(minX, minY + height);
            rectPoints[2] = new Point(minX + width, minY + height);
            rectPoints[3] = new Point(minX + width, minY);

            return new Rectangle(rectPoints);
        }
    }
}
