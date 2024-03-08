using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Problem
{
    // *****************************************
    // DON'T CHANGE CLASS OR FUNCTION NAME
    // YOU CAN ADD FUNCTIONS IF YOU NEED TO
    // *****************************************
    public static class PROBLEM_CLASS
    {
        #region YOUR CODE IS HERE 

               //Your Code is Here:
        //==================
        /// <summary>
        /// Sort the given array in ascending order
        /// At least, should beat the default sorting algorithm of the C# (Array.Sort())
        /// </summary>
        /// <param name="arr"> array to be sorted in ascending order </param>
        /// <param name="N"> array size </param>
        /// <returns> sorted array </returns>
        static public float[] RequiredFuntion(float[] arr, int N)
        {
            //REMOVE THIS LINE BEFORE START CODING
            //throw new NotImplementedException();
            Heapsort(arr);
            
            return arr;
        }

        static private void MaxHeapify(float[] arr, int index, int heapSize)
        {
            int left = 2 * index + 1;
            int right = 2 * index + 2;
            int largest;
            if (left < heapSize && arr[left] > arr[index])
            {
                largest = left;
            }
            else
            {
                largest = index;
            }
            if (right < heapSize && arr[right] > arr[largest])
            {
                largest = right;
            }
            if (largest != index)
            {
                float temp = arr[index];
                arr[index] = arr[largest];
                arr[largest] = temp;
                MaxHeapify(arr, largest, heapSize);
            }
        }

        static private int BuildMaxHeap(float[] arr)
        {
            int heapSize = arr.Length;
            int i = arr.Length / 2 - 1;
            for ( ; i >= 0; i--)
            {
                MaxHeapify(arr, i, heapSize);
            }
            return heapSize;
        }


        static private void Heapsort(float[] arr)
        {
            int heapSize = BuildMaxHeap(arr);
            float temp;
            for (int i = arr.Length - 1; i > 0; i--)
            {
                temp = arr[i];
                arr[i] = arr[0];
                arr[0] = temp;
                heapSize--;
                MaxHeapify(arr, 0, heapSize);
            }
        }
        #endregion
    }
}
