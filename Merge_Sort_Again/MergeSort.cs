using System;


namespace Merge_Sort_Again
{
    public class MergeSort<T> where T : IComparable
    {
        public static T[] Sort(T[] arr)
        {
            var length = arr.Length;
            if (length < 2)
                return arr;

            var arrLeft = arr.AsSpan(0..(length / 2)).ToArray();
            var arrRight = arr.AsSpan((length / 2)..length).ToArray();

            arrLeft = Sort(arrLeft);
            arrRight = Sort(arrRight);

            return Merge(arrLeft, arrRight);
        }

        private static T[] Merge(T[] arrLeft, T[] arrRight)
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
