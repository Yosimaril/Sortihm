using System;

namespace SortingLib
{
    public static class InsertionSort
    {
        public static int[] SortAsc(int[] data) // ascending order
        {
            // error handler if array null or empty
            if (data == null || data.Length == 0) throw new ArgumentNullException(nameof(data), "Input array can't be null or empty");
            // return sorted array - 1 data
            else if (data.Length == 1) return data;

            int n = data.Length;
            for (int j = 1; j < n; j++)
            {
                int key = data[j]; // element to be inserted
                int i = j - 1; // element before

                while (i >= 0 && data[i] > key) // find position
                {
                    // move element to next index if greater than current element
                    data[i + 1] = data[i];
                    i = i - 1;
                }
                // insert current element
                data[i + 1] = key;
            }
            // return sorted array
            return data;
        }

        public static int[] SortDesc(int[] data) // descending order
        {
            // error handler if array null or empty
            if (data == null || data.Length == 0) throw new ArgumentNullException(nameof(data), "Input array can't be null or empty");
            // return sorted array - 1 data
            else if (data.Length == 1) return data;

            int n = data.Length;
            for (int j = 1; j < n; j++)
            {
                int key = data[j]; // element to be inserted
                int i = j - 1; // element before

                while (i >= 0 && data[i] < key) // find position
                {
                    // move element to next index if less than current element
                    data[i + 1] = data[i];
                    i = i - 1;
                }
                // insert current element
                data[i + 1] = key;
            }
            // return sorted array
            return data;
        }
    }
}