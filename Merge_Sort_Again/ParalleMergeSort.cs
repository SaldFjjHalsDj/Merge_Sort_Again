using System;
using System.Threading.Tasks;

namespace Merge_Sort_Again
{
    public class ParalleMergeSort<T> where T : IComparable
    {
        public static T[] ParallelSort(T[] arr, int streams)
        {
            var length = arr.Length;
            if (length < 2)
                return arr;

            var arrLeft = arr.AsSpan(0..(length / 2)).ToArray();
            var arrRight = arr.AsSpan((length / 2)..length).ToArray();

            if (streams > 0)
            {
                var arrLeftTask = Task.Run(() => ParallelSort(arrLeft, streams - 1));
                var arrRightTask = Task.Run(() => ParallelSort(arrRight, streams - 1));
                Task.WaitAll(arrLeftTask, arrRightTask);
            }
            else
            {
                arrLeft = ParallelSort(arrLeft, 0);
                arrRight = ParallelSort(arrRight, 0);
            }

            return ParallelMerge(arrLeft, arrRight);
        }

        private static T[] ParallelMerge(T[] arrLeft, T[] arrRight)
        {
            var result = new T[arrLeft.Length + arrRight.Length];
            int indexMiddle = 0, indexLeft = 0, indexRight = 0;

            while (indexLeft < arrLeft.Length || indexRight < arrRight.Length)
            {
                result[indexMiddle++] = indexLeft < arrLeft.Length && (indexRight > arrRight.Length - 1 || arrLeft[indexLeft].CompareTo(arrRight[indexRight]) < 0)
                                    ? arrLeft[indexLeft++] : arrRight[indexRight++];
            }
            return result;
        }
    }
}
