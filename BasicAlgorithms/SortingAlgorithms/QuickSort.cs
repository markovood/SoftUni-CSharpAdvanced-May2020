using System;

namespace SortingAlgorithms
{
    public static class QuickSort<T> where T : IComparable<T>
    {
        public static void Sort(T[] arr)
        {
            Sort(arr, 0, arr.Length - 1);
        }

        // Algorithm explained at https://en.wikipedia.org/wiki/Quicksort Hoare partition scheme
        private static void Sort(T[] arr, int lo, int hi)
        {
            // Pick an element, called a pivot, from the array.
            T pivot = GetPivot(arr, lo, hi);

            if (lo < hi)// has more than one elements 
            {
                // Partitioning: reorder the array so that all elements with values less than the pivot come before
                //               the pivot, while all elements with values greater than the pivot come after it
                //               (equal values can go either way). After this partitioning, the pivot is in its
                //               final position. This is called the partition operation.
                int partitionBorder = Partition(arr, lo, hi, pivot);

                // Recursively apply the above steps to the sub-array of elements with smaller values and
                // separately to the sub-array of elements with greater values.
                Sort(arr, lo, partitionBorder);
                Sort(arr, partitionBorder + 1, hi);
            }
        }

        private static T GetPivot(T[] arr, int lo, int hi)
        {
            // see Choice of pivot at https://en.wikipedia.org/wiki/Quicksort
            
            // If the boundary indices of the subarray being sorted are sufficiently large (let's say we need
            // the middle of sub-array starting with index 2_000_000_000 and ending at 2_100_000_000), the
            // naive expression for the middle index, (lo + hi)/2, will cause overflow and provide an invalid
            // pivot index. This can be overcome by using the below formula to index the middle element
            int mid = lo + ((hi - lo) / 2);

            if (arr[mid].CompareTo(arr[lo]) < 0)
            {
                Swap(arr, lo, mid);
            }

            if (arr[hi].CompareTo(arr[lo]) < 0)
            {
                Swap(arr, lo, hi);
            }

            if (arr[mid].CompareTo(arr[hi]) < 0)
            {
                Swap(arr, mid, hi);
            }

            return arr[hi];
        }

        private static int Partition(T[] arr, int lo, int hi, T pivot)
        {
            int i = lo;
            int j = hi;
            while (true)
            {
                while (arr[i].CompareTo(pivot) < 0)
                {
                    i++;
                }

                while (arr[j].CompareTo(pivot) > 0)
                {
                    j--;
                }

                if (i >= j)
                {
                    return j;
                }

                Swap(arr, i, j);
                i++;
                j--;
            }
        }

        private static void Swap(T[] arr, int i, int j)
        {
            T temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }
    }
}
