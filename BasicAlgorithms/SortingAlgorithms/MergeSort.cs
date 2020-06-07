using System;

namespace SortingAlgorithms
{
    public static class MergeSort<T> where T : IComparable<T>
    {
        // Array 'T[] arr' has the items to sort; array 'T[] aux' is a help array.
        public static void Sort(T[] arr)
        {
            T[] aux = new T[arr.Length];
            arr.CopyTo(aux, 0);// one time copy of arr to aux
            Sort(aux, 0, arr.Length, arr);// sort data from aux into arr
        }

        // Sort the given array arr using array aux as a source.
        // iStart is inclusive; iEnd is exclusive (arr[iEnd] is not in the set).
        private static void Sort(T[] source, int iStart, int iEnd, T[] destination)
        {
            // size == 0 || size == 1 consider it sorted by definition
            if (iEnd - iStart <= 1)
            { 
                return;
            }   
            
            // split the array longer than 1 item into halves
            int iMiddle = (iEnd + iStart) / 2;  // mid point

            // recursively sort both arrays
            Sort(destination, iStart, iMiddle, source); // sort the left one
            Sort(destination, iMiddle, iEnd, source);   // sort the right one

            // merge the resulting arrays
            Merge(source, iStart, iMiddle, iEnd, destination);
        }

        // Left source half is aux[from iBegin to iMiddle - 1]
        // Right source half is aux[from iMiddle to iEnd - 1]
        // Result is arr[from iBegin to iEnd - 1]
        private static void Merge(T[] source, int iBegin, int iMiddle,int iEnd, T[] destination)
        {
            int i = iBegin;
            int j = iMiddle;

            // While there are elements in the left or right
            for (int k = iBegin; k < iEnd; k++)
            {
                // If left element exists and is <= existing right element
                if (i < iMiddle && (j >= iEnd || source[i].CompareTo(source[j]) <= 0))
                {
                    destination[k] = source[i];
                    i++;
                }
                else
                {
                    destination[k] = source[j];
                    j++;
                }
            }
        }
    }
}
