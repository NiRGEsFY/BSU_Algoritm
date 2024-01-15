using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Algoritm
    {
        public void FirstEx()
        {
            Console.WriteLine("8.Составить программу, которая формирует матрицу из\r\n" +
                              "n*nслучайных чисел. Определить сумму чисел, лежащих выше\r\n" +
                              "главной диагонали матрицы. Значение n меняется в пределах от 5 до\r\n" +
                              "10 тысяч.");
            var startTime = System.Diagnostics.Stopwatch.StartNew();
            Random rand = new Random();
            int n = rand.Next(5, 10000);
            int[,] array = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    array[i, j] = rand.Next(0, 10);
                }
            }
            int sum = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = n - i - 1; j >= 0; j--)
                {
                    sum += array[i, j];

                }
            }
            startTime.Stop();
            Console.WriteLine($"n = {n}\n" +
                              $"Сумма чисел = {sum}\n" +
                              $"Время выполнения: {startTime.Elapsed.TotalMilliseconds} мс");
        }

        public void SecondEx()
        {
            Console.WriteLine("3.Разработать алгоритм и программу дихотомического поиска. В\r\n" +
                              "качестве исходных данных использовать массив целых чисел,\r\n" +
                              "который вводится с клавиатуры. Аргумент поиска – число.");
            int lenght = 0;
            int[] array = new int[lenght];
            int input = 0;
            while (true)
            {
                Console.Write("Для выхода из ввода введите пустую строку\n" +
                              "Введите число в массив: ");
                string readingField = Console.ReadLine();
                if (String.IsNullOrEmpty(readingField))
                {
                    break;
                }
                lenght++;
                int.TryParse(readingField,out input);
                Array.Resize(ref array, lenght);
                array[lenght - 1] = input;
            }
            Console.Write("Массив заполнен, введите число которое надо найти\n" +
                          "Ввод: ");
            int.TryParse(Console.ReadLine(), out input);
            Array.Sort(array);
            var searchDigit = Algoritm.BinarySearch(array, input, 0, array.Length);
            if (searchDigit < 0)
            {
                Console.WriteLine("Элемент со значение {0} не найден",input);
            }
            else
            {
                Console.WriteLine("Элемент со значение {0} найден, с индексом {1}",input,searchDigit);
            }
        }
        static int BinarySearch(int[] array, int searchedValue, int first, int last)
        {
            if (first > last)
            {
                return -1;
            }
            var middle = (first + last) / 2;
            var middleValue = array[middle];

            if (middleValue == searchedValue)
            {
                return middle;
            }
            else
            {
                if (middleValue > searchedValue)
                {
                    return BinarySearch(array, searchedValue, first, middle - 1);
                }
                else
                {
                    return BinarySearch(array, searchedValue, middle + 1, last);
                }
            }
        }

        public void ThirdyEx()
        {
            Console.WriteLine("Разработать следующие алгоритмы и программы с \r\nиспользованием рекурсии\n" +
                              "7.Перевода целого числа, введенного с клавиатуры, в двоичную \r\nсистему счисления.\r\n");
            Console.Write("Введите число: ");
            int input = 0;
            if (!int.TryParse(Console.ReadLine(),out input))
            {
                Console.WriteLine("Введенно не корректное число");
                return;
            }
            Console.WriteLine($"Число в бинарной системе исчисления: {BinaryParse(input)}");
            
        }
        public int BinaryParse(int input)
        {
            int mult = 0;
            int divider = 1;
            while (divider < input)
            {
                divider *= 2;
                mult++;
                if (input == divider)
                {
                    divider = 1;
                    for (int i = 0; i < mult; i++)
                    {
                        divider *= 10;
                    }
                    return divider;
                }
            }
            divider /= 2;
            mult--;
            int output = 0;
            if (input > 1)
            {
                output += BinaryParse(input - divider);
                divider = 1;
                for (int i = 0; i < mult; i++)
                {
                    divider *= 10;
                }
                return divider + output;
            }
            return input;
        }
    }
}
