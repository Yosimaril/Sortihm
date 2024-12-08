using System;
using System.Globalization;

namespace SortingLib
{
    public class RadixSort
    {
        public static int[] SortAsc(int[] arr) // ascending order
        {
            // error handler if array null or empty
            if (arr == null || arr.Length == 0) throw new ArgumentNullException(nameof(arr), "Input array can't be null or empty");
            // return sorted array - 1 data
            else if (arr.Length == 1) return arr;

            int n = arr.Length;

            // find greatest element
            int max = arr[0];
            for (int i = 1; i < n; i++)
            {
                if (arr[i] > max)
                {
                    max = arr[i];
                }
            }

            for (int exp = 1; max / exp > 0; exp *= 10) // loop from LSD
            {
                int[] sorted = new int[n]; // temporary sorted array
                int[] count = new int[10]; // 0 - 9

                for (int i = 0; i < n; i++)
                { 
                    // find digit from element - update count for the certain digit
                    int digit = (arr[i] / exp) % 10;
                    count[digit]++;
                }
                
                for (int i = 1; i < 10; i++) 
                {
                    // determine count start position for every digit - cumulative count
                    count[i] += count[i - 1];
                }

                for (int i = n - 1; i >= 0; i--)
                {
                    // find digit - insert element to respective position
                    int digit = (arr[i] / exp) % 10;
                    count[digit]--;
                    sorted[count[digit]] = arr[i];
                }

                for (int i = 0; i < n; i++)
                {
                    // copy sorted array to original array
                    arr[i] = sorted[i];
                }
            }

            // return sorted array
            return arr;
        }

        public static int[] SortDesc(int[] arr) // descending order
        {
            // error handler if array null or empty
            if (arr == null || arr.Length == 0) throw new ArgumentNullException(nameof(arr), "Input array can't be null or empty");
            // return sorted array - 1 data
            else if (arr.Length == 1) return arr;

            int n = arr.Length;

            // find greatest element
            int max = arr[0];
            for (int i = 1; i < n; i++)
            {
                if (arr[i] > max)
                {
                    max = arr[i];
                }
            }

            for (int exp = 1; max / exp > 0; exp *= 10) // loop from LSD
            {
                int[] sorted = new int[n]; // temporary sorted array
                int[] count = new int[10]; // 0 - 9

                for (int i = 0; i < n; i++)
                {
                    // find digit from element - update count for the certain digit
                    int digit = (arr[i] / exp) % 10;
                    count[digit]++;
                }

                for (int i = 8; i >= 0; i--)
                {
                    // determine count start position for every digit - cumulative count
                    count[i] += count[i + 1];
                }

                for (int i = n - 1; i >= 0; i--)
                {
                    // find digit - insert element to respective position
                    int digit = (arr[i] / exp) % 10;
                    count[digit]--;
                    sorted[count[digit]] = arr[i];
                }

                for (int i = 0; i < n; i++)
                {
                    // copy sorted array to original array
                    arr[i] = sorted[i];
                }
            }

            // return sorted array
            return arr;
        }
    }
}
