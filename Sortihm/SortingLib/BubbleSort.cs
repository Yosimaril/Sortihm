using System;
using System.Runtime.InteropServices;

namespace SortingLib
{
    public static class BubbleSort
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
                for (int j = 0; j < (n - i - 1); j++) // check unsorted
                {
                    if (array[j] > array[j + 1]) // current element greater than next element
                    {
                        // move current element to next element
                        int temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
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
                for (int j = 0; j < (n - i - 1); j++) // check unsorted
                {
                    if (array[j] < array[j + 1]) // current element less than next element
                    {
                        // move current element to next element
                        int temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }
            // return sorted array
            return array; 
        }
    }
}
