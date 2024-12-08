using System;

namespace SortingLib
{
    public static class SelectionSort
    {
        public static int[] SortAsc(int[] array) // ascending order
        {
            // error handler if array null or empty
            if (array == null || array.Length == 0) throw new ArgumentNullException(nameof(array), "Input array can't be null or empty");
            // return sorted array - 1 data
            else if (array.Length == 1) return array;

            int n = array.Length;
            for (int i = 0; i < (n - 1); i++)
            {
                int minimumIndex = i; // smallest element index
                for (int j = (i + 1); j < n; j++)
                {
                    // find smallest element position
                    if (array[j] < array[minimumIndex])
                    {
                        minimumIndex = j;
                    }
                }
                // swap elements to respective position
                int temp = array[minimumIndex];
                array[minimumIndex] = array[i];
                array[i] = temp;
            }
            // return sorted array
            return array;
        }

        public static int[] SortDesc(int[] array) // descending order
        {
            // error handler if array null or empty
            if (array == null || array.Length == 0) throw new ArgumentNullException(nameof(array), "Input array can't be null or empty");
            // return sorted array - 1 data
            else if (array.Length == 1) return array;

            int n = array.Length;
            for (int i = 0; i < (n - 1); i++)
            {
                int maximumIndex = i; // largest element index
                for (int j = (i + 1); j < n; j++)
                {
                    // find largest element position
                    if (array[j] > array[maximumIndex])
                    {
                        maximumIndex = j;
                    }
                }
                // swap elements to respective position
                int temp = array[maximumIndex];
                array[maximumIndex] = array[i];
                array[i] = temp;
            }
            // return sorted array
            return array;
        }
    }
}
