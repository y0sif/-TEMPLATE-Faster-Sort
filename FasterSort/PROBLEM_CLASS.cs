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
        //70 is best with 8 out of 10
        //80 is best with 9 out of 10
        private const int ParallelThreshold = 80;

        /// <summary>
        /// A quicksort algorithm with parallelism and insertion sort
        /// </summary>
        /// <param name="arr"> array to be sorted in ascending order </param>
        /// <param name="first"> index of first element </param>
        /// <param name="last"> index of last element </param>
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
        /// <summary>
        /// The divide side of the quicksort algorithm
        /// </summary>
        /// <param name="arr"> array to be sorted in ascending order </param>
        /// <param name="first"> index of first element </param>
        /// <param name="last"> index of last element </param>
        /// <returns> next splitting index </returns> 
        
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
                (arr[middle], arr[first]) = (arr[first], arr[middle]);
            }

            if (f > l)
            {
                (arr[first], arr[last]) = (arr[last], arr[first]);
            }

            if (m > l)
            {
                (arr[middle], arr[last]) = (arr[last], arr[middle]);
            }

            pivot = arr[middle];
            arr[middle] = arr[first];
            arr[first] = pivot;
            int leftMark = first + 1;
            int rightMark = last;

            while (leftMark <= rightMark)
            {

                while (leftMark <= rightMark && arr[leftMark] <= pivot)
                {
                    leftMark++;
                }

                while (rightMark >= leftMark && arr[rightMark] >= pivot)
                {
                    rightMark--;
                }

                if (leftMark <= rightMark) 
                {
                    (arr[rightMark], arr[leftMark]) = (arr[leftMark], arr[rightMark]);
                }
            }

            // use pivot for swapping rather than making temp floats
            (arr[first], arr[rightMark]) = (arr[rightMark], arr[first]);

            return rightMark;
        }


        #endregion
    }
}
