using System;

namespace SortingAlgorithms
{
    public static class MergeSort<T> where T : IComparable<T>
    {
        private static T[] aux;

        public static void Sort(T[] arr)
        {
            aux = new T[arr.Length];
            Sort(arr, 0, arr.Length - 1);
        }

        private static void Sort(T[] arr, int lo, int hi)
        {
            // only one element -> already sorted
            if (lo >= hi)
            {
                return;
            }

            int mid = (lo + hi) / 2;

            // split it into two 'sub-arrays', sort them recursively and then merge them on the way up 
            Sort(arr, lo, mid);
            Sort(arr, mid + 1, hi);
            Merge(arr, lo, mid, hi);
        }

        private static void Merge(T[] arr, int lo, int mid, int hi)
        {
            if (IsLess(arr[mid], arr[mid + 1]))
            {
                // if the largest element in the left is smaller than the smallest in the right, the two
                // subarrays are already merged
                return;
            }

            // transfer all elements to the auxiliary array
            for (int index = lo; index < hi + 1; index++)
            {
                aux[index] = arr[index];
            }

            // merge them back in the main array
            int i = lo;
            int j = mid + 1;
            for (int k = lo; k <= hi; k++)
            {
                if (i > mid)
                {
                    arr[k] = aux[j++];
                }
                else if (j > hi)
                {
                    arr[k] = aux[i++];
                }
                else if (IsLess(aux[i], aux[j]))
                {
                    arr[k] = aux[i++];
                }
                else
                {
                    arr[k] = aux[j++];
                }
            }
        }

        private static bool IsLess(T value1, T value2)
        {
            return value1.CompareTo(value2) < 0;
        }
    }
}
