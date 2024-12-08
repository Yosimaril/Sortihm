using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingLib
{
    public static class MergeSort
    {
        #region ASCENDING ORDER
        public static int[] SortAsc(int[] array) // ascending order
        {
            // error handler if array null or empty
            if (array == null || array.Length == 0) throw new ArgumentNullException(nameof(array), "Input array can't be null or empty");
            // return sorted array - 1 data
            else if (array.Length == 1) return array;

            // merge sort asc - return sorted array
            MergeSortAsc(array);
            return array;
        }

        private static void MergeSortAsc(int[] array) // merge sort ascending
        {
            int length = array.Length;
            if (length <= 1) return;

            int middle = length / 2; // middle index
            // seperate array to 2 parts
            int[] leftArray = new int[middle];
            int[] rightArray = new int[length - middle];

            for (int i = 0, j = 0; i < length; i++)
            {
                // assign elements to respective array
                if (i < middle)
                {
                    leftArray[i] = array[i];
                }
                else
                {
                    rightArray[j] = array[i];
                    j++;
                }
            }

            MergeSortAsc(leftArray); // recursive merge sort asc left array
            MergeSortAsc(rightArray); // recursive merge sort asc right array
            MergeAsc(leftArray, rightArray, array); // merge asc left-right array to original array
        }

        private static void MergeAsc(int[] leftArray, int[] rightArray, int[] array) // merge ascending
        {
            // find array size
            int leftSize = leftArray.Length;
            int rightSize = rightArray.Length;

            int i = 0, left = 0, right = 0; // array index
            while (left < leftSize && right < rightSize)
            {
                if (leftArray[left] < rightArray[right]) // if left element less than right element - insert left element
                {
                    array[i] = leftArray[left];
                    i++;
                    left++;
                }
                else // otherwise - insert right element 
                {
                    array[i] = rightArray[right];
                    i++;
                    right++;
                }
            }

            // insert remaining left elements
            while (left < leftSize)
            {
                array[i] = leftArray[left];
                i++;
                left++;
            }
            // insert remaining right elements
            while (right < rightSize)
            {
                array[i] = rightArray[right];
                i++;
                right++;
            }
        }
        #endregion

        #region DESCENDING ORDER
        public static int[] SortDesc(int[] array) // descending order
        {
            // error handler if array null or empty
            if (array == null || array.Length == 0) throw new ArgumentNullException(nameof(array), "Input array can't be null or empty");
            // return sorted array - 1 data
            else if (array.Length == 1) return array;

            // merge sort desc - return sorted array
            MergeSortDesc(array);
            return array;
        }

        private static void MergeSortDesc(int[] array) // merge sort descending
        {
            int length = array.Length;
            if (length <= 1) return;

            int middle = length / 2; // middle index
            // seperate array to 2 parts
            int[] leftArray = new int[middle];
            int[] rightArray = new int[length - middle];

            for (int i = 0, j = 0; i < length; i++)
            {
                // assign elements to respective array
                if (i < middle)
                {
                    leftArray[i] = array[i];
                }
                else
                {
                    rightArray[j] = array[i];
                    j++;
                }
            }

            MergeSortDesc(leftArray); // recursive merge sort desc left array
            MergeSortDesc(rightArray); // recursive merge sort desc right array
            MergeDesc(leftArray, rightArray, array); // merge desc left-right array to original array
        }

        private static void MergeDesc(int[] leftArray, int[] rightArray, int[] array) // merge descending
        {
            // find array size
            int leftSize = leftArray.Length;
            int rightSize = rightArray.Length;

            int i = 0, left = 0, right = 0; // array index
            while (left < leftSize && right < rightSize)
            {
                if (leftArray[left] > rightArray[right]) // if left element greater than right element - insert left element
                {
                    array[i] = leftArray[left];
                    i++;
                    left++;
                }
                else // otherwise - insert right element 
                {
                    array[i] = rightArray[right];
                    i++;
                    right++;
                }
            }

            // insert remaining left elements
            while (left < leftSize)
            {
                array[i] = leftArray[left];
                i++;
                left++;
            }
            // insert remaining right elements
            while (right < rightSize)
            {
                array[i] = rightArray[right];
                i++;
                right++;
            }
        }
        #endregion
    }
}
