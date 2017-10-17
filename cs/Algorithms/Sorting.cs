using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class Sorting
    {
        public static void Bubble(int[] array)
        {
            int length = array.Length;
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    if (array[i] < array[j])
                    {
                        int tmp = array[i];
                        array[i] = array[j];
                        array[j] = tmp;
                    }
                }
            }
        }
        public static void MergeSort(int[] array, int low, int high)
        {
            int N = high - low;
            if (N <= 1)
                return;

            int mid = low + N / 2;

            MergeSort(array, low, mid);
            MergeSort(array, mid, high);

            int[] aux = new int[N];
            int i = low, j = mid;
            for (int k = 0; k < N; k++)
            {
                if (i == mid) aux[k] = array[j++];
                else if (j == high) aux[k] = array[i++];
                else if (array[j].CompareTo(array[i]) < 0) aux[k] = array[j++];
                else aux[k] = array[i++];
            }

            for (int k = 0; k < N; k++)
            {
                array[low + k] = aux[k];
            }
            //Console.Write($"\n {low}, {mid} , {high}\n");
            //for (int l = 0; l < array.Length; l++)
            //{
            //    Console.Write($"{array[l]} ");
            //}
        }
        public static int[] MergeArray(int[] a, int[] b)
        {
            int totalElements = a.Length + b.Length;
            int aIndex = 0;
            int bIndex = 0;
            int cIndex = 0;
            int[] newArray = new int[totalElements];
            while (aIndex < a.Length && bIndex < b.Length)
            {
                if (a[aIndex] < b[bIndex])
                {
                    newArray[cIndex++] = a[aIndex++];
                }
                else
                {
                    newArray[cIndex++] = b[bIndex++];
                }
            }
            while (aIndex < a.Length)
            {
                newArray[cIndex++] = a[aIndex++];
            }
            while (bIndex < b.Length)
            {
                newArray[cIndex++] = b[bIndex++];
            }
            return newArray;
        }
        public static void Quick_sort(int[] array, int start, int end)
        {
            if (start < end)
            {
                //stores the position of pivot element
                int piv_pos = Partition(array, start, end);
                Quick_sort(array, start, piv_pos - 1);    //sorts the left side of pivot.
                Quick_sort(array, piv_pos + 1, end); //sorts the right side of pivot.
            }
        }
        public static int Partition(int[] array, int start, int end)
        {
            int i = start + 1;
            int piv = array[start];            //make the first element as pivot element.
            for (int j = start + 1; j <= end; j++)
            {
                /*rearrange the array by putting elements which are less than pivot
                   on one side and which are greater that on other. */

                if (array[j] < piv)
                {
                    Swap(array, i, j);
                    i += 1;
                }
            }
            Swap(array, start, i - 1);  //put the pivot element in its proper place.
            return i - 1;                      //return the position of the pivot
        }
        private static void Swap(int[] array, int i, int j)
        {
            int tmp = array[i];
            array[i] = array[j];
            array[j] = tmp;
        }
    }
}
