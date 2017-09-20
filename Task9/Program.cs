using System;
using static System.Console;

namespace Task9
{
    class Program
    {
        public static int Input(string text, int minSize, int maxSize) // проверка соответствия ввода типу int
        {
            var number = 0; // переменная для числа
            bool ok;
            var word = " ";
            var size = new string[2];
            size[0] = "большое";
            size[1] = "маленькое";
            do
            {
                try
                {
                    WriteLine(text); // вывод сообщения
                    number = Convert.ToInt32(ReadLine());
                    if (number >= 1 && number <= maxSize) ok = true; // проверка вхождения числа в допустимый диапазон
                    else
                    {
                        if (number >= maxSize) word = size[0];
                        if (number < 1) word = size[1];
                        WriteLine("Слишком {0} число. Число должно быть в диапазоне от {1} до {2}", word, 1, maxSize);
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
            bool okay = false;
            var n = Input("Введите количество элементов списка:", 0, 10000);
            Point beg = Point.MakeList(n); // создание списка
            do
            {
                // вывод меню
                var userAnswer = Input("Выберите, что сделать со списком: \n1.Вывести список\n2.Удалить элемент\n3.Найти элемент\n4.Начать заново\n5.Выход", 0, 5);
                switch (userAnswer)
                {
                    case 1: // вывод списка
                        Point.ShowPoint(beg);
                        break;
                    case 2: // удаление элемента
                        var number = Input("Введите значение элемента, который необходимо удалить:", 0, n);
                        beg = Point.DeleteElement(number, beg);
                        n--;
                        Write("Полученный список: " + Point.GetElementsString(beg) + "\n");
                        break;
                    case 3: // поиск элемента
                        var number2 = Input("Введите значение элемента, который необходимо найти:", 0, n);
                        var result = Point.SearchElement(number2, beg);
                        if (result == -1)
                            WriteLine("Элемент не найден");
                        else
                            WriteLine("Порядковый номер элемента: " + result);
                        break;
                    case 4:
                        Clear();
                        n = Input("Введите количество элементов списка:", 0, 10000);
                        beg = Point.MakeList(n);
                        break;
                    case 5: // выход
                        Environment.Exit(0);
                        break;
                }
                WriteLine("\n");
            } while (!okay);
        }
    }
}
