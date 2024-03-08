using System;
using System.Collections.Generic;
using System.Linq;
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
            QuickSort(arr, 0, N - 1);
            return arr;
        }
        //28 is best with 5 out of 10
        //30 is best with 6 out of 10
        //46 is best with 7 out of 10
        private const int ParallelThreshold = 46;
        static private void QuickSort(float[] arr, int first, int last)
        {
            if (first < last)
            {
                int split = Partition(arr, first, last);
                if(last - first > ParallelThreshold)
                {
                    Parallel.Invoke(
                    () => QuickSort(arr, first, split - 1),
                    () => QuickSort(arr, split + 1, last)
                    );

                }
                else
                {
                    float key;
                    int j;
                    for (int i = first + 1; i <= last; i++)
                    {
                        key = arr[i];
                        j = i - 1;

                        while (j >= first && arr[j] > key)
                        {
                            arr[j + 1] = arr[j];
                            j--;
                        }

                        arr[j + 1] = key;
                    }
                }
                

            }
        }

        static private int Partition(float[] arr, int first, int last)
        {
            // the use of median of three is better than the randomized and the fixed pivot at first element
            int middle = (first + last) / 2;

            //use these floats for less array access time
            float f = arr[first];
            float l = arr[last];
            float m = arr[middle];

            // use pivot for swapping rather than making temp floats
            float pivot;
            if (f > m)
            {
                pivot = arr[first];
                arr[first] = arr[middle];
                arr[middle] = pivot;
            }

            if (f > l)
            {
                pivot = arr[first];
                arr[first] = arr[last];
                arr[last] = pivot;
            }

            if (m > l)
            {
                pivot = arr[middle];
                arr[middle] = arr[last];
                arr[last] = pivot;
            }

            pivot = arr[middle];
            arr[middle] = arr[first];
            arr[first] = pivot;
            int leftMark = first + 1;
            int rightMark = last;

            while (true)
            {

                while (leftMark <= rightMark && arr[leftMark] <= pivot)
                {
                    leftMark++;
                }

                while (rightMark >= leftMark && arr[rightMark] >= pivot)
                {
                    rightMark--;
                }

                if (rightMark < leftMark) 
                {
                    break;
                }
                else
                {
                    float temp1 = arr[leftMark];
                    arr[leftMark] = arr[rightMark];
                    arr[rightMark] = temp1;
                }
            }

            // use pivot for swapping rather than making temp floats
            pivot = arr[first];
            arr[first] = arr[rightMark];
            arr[rightMark] = pivot;

            return rightMark;
        }


        #endregion
    }
}
