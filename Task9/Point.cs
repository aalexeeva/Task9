using static System.Console;

namespace Task9
{
    public class Point // однонаправленный список
    {
        public int Data;
        public Point Next;
        public Point(int d)
        {
            Data = d;
            Next = null;
        }
        public override string ToString()
        {
            return Data + " ";
        }

        public static Point MakePoint(int d) // добавление элемента в список
        {
            Point p = new Point(d);
            return p;
        } // конец MakePoint

        public static Point MakeList(int size) // создание элементов списка
        {
            if (size == 0)
                return null;
            var info = 1;
            Point beg = MakePoint(info);
            Point r = beg;
            for (var i = 1; i < size; i++)
            {
                info++;
                Point p = MakePoint(info);
                r.Next = p;
                r = p;
            }
            return beg;
        } // конец MakeList

        public static void ShowPoint(Point beg) // печать списка
        {
            if (beg == null)
            {
                WriteLine("Cписок пуст");
                return;
            }
            Point p = beg;
            Write("Элементы списка: ");
            while (p != null)
            {
                Write(p);
                p = p.Next;
            }
            WriteLine();
        } // конец ShowList

        public static Point DeleteElement(int elem, Point beg)
        {
            if (beg == null)
            {
                WriteLine("Cписок пуст");
                return null;
            }
            if (elem == 1)  // удаляем первый элемент
            {
                beg = beg.Next;
                return beg;
            }
            Point p = beg;
            // ищем элемент для удаления и встаем на предыдущий
            for (int i = 0; i < elem - 2; i++)
                if (p != null)
                    p = p.Next;
            if (p == null) // если элемент не найден
            {
                WriteLine("Элемент не найден");
                return beg;
            }
            // исключаем элемент из списка
            if (p.Next.Next != null)
                p.Next = p.Next.Next;
            else
                p.Next = null; // Удаление последнего элемента
            return beg;
        }

        public static int SearchElement(int elem, Point beg)
        {
            if (beg == null)
            {
                WriteLine("Cписок пуст");
                return -1;
            }
            Point p = beg;

            int i = 0;
            while (p != null)
            {
                if (p.Data == elem)
                    return i + 1;
                p = p.Next;
                ++i;
            }
            return -1;
        }

        public static string GetElementsString(Point beg)
        {
            Point p = beg;
            string data = "";
            while (p != null)
            {
                data += p.Data.ToString() + " ";
                p = p.Next;
            }
            return data;
        }
    } // конец Point
}
