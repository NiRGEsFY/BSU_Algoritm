using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Algoritm
    {
        Sorting sorter = new Sorting();

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
                int.TryParse(readingField, out input);
                Array.Resize(ref array, lenght);
                array[lenght - 1] = input;
            }
            Console.Write("Массив заполнен, введите число которое надо найти\n" +
                          "Ввод: ");
            int.TryParse(Console.ReadLine(), out input);
            Array.Sort(array);
            var searchDigit = Sorting.BinarySearch(array, input, 0, array.Length);
            if (searchDigit < 0)
            {
                Console.WriteLine("Элемент со значение {0} не найден", input);
            }
            else
            {
                Console.WriteLine("Элемент со значение {0} найден, с индексом {1}", input, searchDigit);
            }
        }
        public void ThirdyEx()
        {
            Console.WriteLine("Разработать следующие алгоритмы и программы с \r\nиспользованием рекурсии\n" +
                              "7.Перевода целого числа, введенного с клавиатуры, в двоичную \r\nсистему счисления.\r\n");
            Console.Write("Введите число: ");
            int input = 0;
            if (!int.TryParse(Console.ReadLine(), out input))
            {
                Console.WriteLine("Введенно не корректное число");
                return;
            }
            Console.WriteLine($"Число в бинарной системе исчисления: {sorter.BinaryParse(input)}");

        }
        public void ForthyEx()
        {
            Random rand = new Random();
            for (int i = 1000; i < 11000; i += 1000)
            {
                int[] array = new int[i];
                for (int j = 0; j < i; j++)
                {
                    array[j] = rand.Next(1000);
                }
                double totalTime = 0;
                for (int j = 0; j < 3; j++)
                {
                    var startTime = System.Diagnostics.Stopwatch.StartNew();
                    sorter.QuickSort(array);
                    startTime.Stop();
                    totalTime += startTime.Elapsed.TotalMilliseconds;
                }
                Console.WriteLine($"Быстрая сортировка\n" +
                                  $"Количество элементов: {i}\n" +
                                  $"Время выполнения: {totalTime / 3} мс");
                totalTime = 0;
                for (int j = 0; j < 3; j++)
                {
                    var startTime = System.Diagnostics.Stopwatch.StartNew();
                    sorter.BubbleSort(array);
                    startTime.Stop();
                    totalTime += startTime.Elapsed.TotalMilliseconds;
                }
                Console.WriteLine($"Пузырьковая сортировка\n" +
                                  $"Количество элементов: {i}\n" +
                                  $"Время выполнения: {totalTime / 3} мс");
            }

        }
        public void FivethyEx()
        {
            BinaryTree<int> tree = new BinaryTree<int>(90);
            Random rand = new Random();
            for (int i = 0; i < 20; i++)
            {
                tree.Insert(rand.Next(0,181));
            }
            BinaryTree<int> treeB = new BinaryTree<int>(90);
            for (int i = 0; i < 20; i++)
            {
                treeB.Insert(rand.Next(0, 181));
            }
        }
    }
}
