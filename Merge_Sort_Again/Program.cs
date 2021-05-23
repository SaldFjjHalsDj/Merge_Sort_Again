using System;

namespace Merge_Sort_Again
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите колличество элементов для сортировки: ");

            long n = int.Parse(Console.ReadLine());
            long[] arr = new long[n];
            long[] arrParallel = new long[n];

            Console.WriteLine();

            Random rd = new Random();

            for (int i = 0; i < n; i++)
            {
                arr[i] += rd.Next(-100, 100);
                arrParallel[i] = arr[i];
            }

            DateTime start = DateTime.Now;
            var sortedIntAr = MergeSort<long>.Sort(arr);
            DateTime finish = DateTime.Now;
            Console.WriteLine($"Время выполнения сортировки стандартным способом: {finish - start}");

            start = DateTime.Now;
            sortedIntAr = ParalleMergeSort<long>.ParallelSort(arrParallel, (int)Math.Log(Environment.ProcessorCount, 2) + 4);
            finish = DateTime.Now;
            Console.WriteLine($"Время выполнения сортировки параллельным  способом: {finish - start}");
        }
    }
}
