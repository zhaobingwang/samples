using System;
using System.Collections.Generic;
using System.Text;

namespace CodeSnippets.DataStructuresAndAlgorithms
{
    public class SortAlgorithm
    {
        private static List<int> list = new List<int> { 98, 1, 45, 23, 87, 3, 20, 13, 47, 9 };

        public static void Run()
        {
            //BubbleSort();
            QuickSort(list, 0, list.Count-1);

            PrintList(list, "Quick sort array.");
        }
        public static void BubbleSort()
        {
            Console.WriteLine("Bubble sort start ...");
            PrintList(list, "Messy array.");
            for (int i = 0; i < list.Count; i++)
            {
                for (int j = 0; j < list.Count - 1 - i; j++)
                {
                    if (list[j] > list[j + 1])
                    {
                        var tmp = list[j + 1];
                        list[j + 1] = list[j];
                        list[j] = tmp;
                    }
                }
            }
            PrintList(list, "Sorted array.");
            ResetList();
            Console.WriteLine("Bubble sort end ...");
        }

        public static void QuickSort(List<int> list, int left, int right)
        {
            var len = list.Count;
            var partitionIndex = 1;
            if (left < right)
            {
                partitionIndex = Partition(list, left, right);
                QuickSort(list, left, partitionIndex - 1);
                QuickSort(list, partitionIndex + 1, right);
            }
        }
        private static int Partition(List<int> list, int left, int right)
        {
            int pivot = left;
            var idx = pivot + 1;
            for (int i = idx; i <= right; i++)
            {
                if (list[i] < list[pivot])
                {
                    Swap(list, i, idx);
                    idx++;
                }
            }
            Swap(list, pivot, idx - 1);
            return idx - 1;
        }

        private static void Swap(List<int> list, int i, int j)
        {
            var tmp = list[i];
            list[i] = list[j];
            list[j] = tmp;
        }

        private static void PrintList(List<int> list, string title)
        {
            Console.WriteLine(title);
            for (int i = 0; i < list.Count; i++)
            {
                Console.Write($"{list[i]}\t");
            }
            Console.WriteLine();
        }
        private static void ResetList()
        {
            list = new List<int> { 98, 1, 45, 23, 87, 3, 20, 13, 47, 9 };
        }
    }
}
