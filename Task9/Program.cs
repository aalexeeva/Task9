using System;
using System.Net.NetworkInformation;
using static System.Console;

namespace Task9
{
    class Program
    {
        public static int Input(string Text, int minSize, int maxSize) // проверка соответствия ввода типу int
        {
            int number = 0;
            bool ok;
            string word = " ";
            string[] size = new string[2];
            size[0] = "большое";
            size[1] = "маленькое";
            do
            {
                try
                {
                    WriteLine(Text);
                    number = Convert.ToInt32(ReadLine());
                    if (number >= minSize && number <= maxSize) ok = true;
                    else
                    {
                        if (number >= maxSize) word = size[0];
                        if (number <= minSize) word = size[1];
                        WriteLine("Слишком {0} число. Число должно быть в диапазоне от {1} до {2}", word, minSize, maxSize);
                        ok = false;
                    }
                }
                catch (FormatException)
                {
                    WriteLine("Ошибка при вводе числа");
                    ok = false;
                }
                catch (OverflowException)
                {
                    WriteLine("Ошибка при вводе числа");
                    ok = false;
                }
            } while (!ok);
            return number;
        } // конец InputNumber

        static void Main(string[] args)
        {
            var n = Input("Введите количество элементов списка:", 0, 2147483647);
            Point beg = Point.MakeList(n);
            var userAnswer = Input("Выберите, что сделать со списком: \n1.Вывести список\n2.Удалить элемент\n3.Найти элемент", 0, 4);
            switch (userAnswer)
            {
                case 1: Point.ShowPoint(beg);
                    break;
                case 2:
                    var number = Input("Введите элемент, который необходимо удалить:", 0, 2147483647);
                    Point.DeleteElement(number, beg);
                    break;
                case 3:
                    var number2 = Input("Введите элемент, который необходимо найти:", 0, 2147483647);
                    Point.SearchElement(number2, beg);
                    break;
            }
            Read();
        }
    }
}
