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
            if (size == 0) return null;
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
            if (elem == 1)//удаляем первый элемент
            {
                beg = beg.Next;
                return beg;
            }
            Point p = beg;
            //ищем элемент для удаления и встаем на предыдущий
            for (int i = 1; i < elem - 1 && p != null; i++)
                p = p.Next;
            if (p == null) // если элемент не найден
            {
                WriteLine("Элемент не найден");
                return beg;
            }
            //исключаем элемент из списка
            p.Next = p.Next.Next;
            return beg;
        }

        public static void SearchElement(int elem, Point beg)
        {
            if (beg == null)
            {
                WriteLine("Cписок пуст");
                return;
            }
            Point p = beg;
            if (p.Data != elem)
            {
                p = p.Next;
                if (p == null) WriteLine("Элемент не найден");
            }
            else WriteLine("Искомый элемент: " + p.Data);
        }
    } // конец Point
}
