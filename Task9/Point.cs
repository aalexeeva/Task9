using System;

namespace Task9
{
    public class Point // однонаправленный список
    {
        public string data;
        public Point next;
        public Point(string d)
        {
            data = d;
            next = null;
        }
        public override string ToString()
        {
            return data + " ";
        }

        public static Point MakePoint(string d) // добавление элемента в список
        {
            Point p = new Point(d);
            return p;
        } // конец MakePoint

        public static Point MakeList(int size) // создание элементов списка
        {
            if (size == 0) return null;
            Console.WriteLine("Введите элемент");
            string info = Console.ReadLine();
            Point beg = MakePoint(info);
            Point r = beg;
            for (int i = 1; i < size; i++)
            {
                Console.WriteLine("Введите элемент");
                info = Console.ReadLine();
                Point p = MakePoint(info);
                r.next = p;
                r = p;
            }
            return beg;
        } // конец MakeList

        public static void ShowPoint(Point beg) // печать списка
        {
            if (beg == null)
            {
                Console.WriteLine("Cписок пуст");
                return;
            }
            Point p = beg;
            Console.Write("Элементы списка: ");
            while (p != null)
            {
                Console.Write(p);
                p = p.next;
            }
            Console.WriteLine();
        } // конец ShowList

        public static void DeleteElement()
        {
            
        }

        public static void SearchElement()
        {
            
        }
    } // конец Point
}
