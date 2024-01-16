using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Sorting
    {
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

        public void Swap(ref int e1, ref int e2)
        {
            var temp = e1;
            e1 = e2;
            e2 = temp;
        }

        public int Partition(int[] array, int minIndex, int maxIndex)
        {
            var pivot = minIndex - 1;
            for (var i = minIndex; i < maxIndex; i++)
            {
                if (array[i] < array[maxIndex])
                {
                    pivot++;
                    Swap(ref array[pivot], ref array[i]);
                }
            }

            pivot++;
            Swap(ref array[pivot], ref array[maxIndex]);
            return pivot;
        }

        public int[] QuickSort(int[] array, int minIndex, int maxIndex)
        {
            if (minIndex >= maxIndex)
            {
                return array;
            }

            var pivotIndex = Partition(array, minIndex, maxIndex);
            QuickSort(array, minIndex, pivotIndex - 1);
            QuickSort(array, pivotIndex + 1, maxIndex);

            return array;
        }
        public int[] QuickSort(int[] array)
        {
            return QuickSort(array, 0, array.Length - 1);
        }

        public int[] BubbleSort(int[] array)
        {
            var len = array.Length;
            for (var i = 1; i < len; i++)
            {
                for (var j = 0; j < len - i; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        Swap(ref array[j], ref array[j + 1]);
                    }
                }
            }

            return array;
        }
        public static int BinarySearch(int[] array, int searchedValue, int first, int last)
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
    }
}
