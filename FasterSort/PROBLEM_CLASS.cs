﻿using System;
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


        //FINAL EVALUATION(%) = 100
        //MAX TIME (ms) = 2223, AVG TIME (ms) = 884.6
        //at Test Case 10: timeOutInMillisec = 4633 and threshold of 170

        //tried all values between 16 and 120, best average is between 110 and 130 but sometimes Test case 7 fails
        //above 130 gets better average score but a lil bit worse max
        //above 190 is working well but the score gets worse bit by bit
        //no diff in performance in using more readable constant
        private const int ParallelThreshold = 170;

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
                    //using this is better than Parallel.Invoke for some reason 
                    var leftBranch = Task.Run(() => QuickSort(arr, first, split - 1));
                    var rightBranch = Task.Run(() => QuickSort(arr, split + 1, last));
                    Task.WaitAll(leftBranch, rightBranch);

                }
                // insertion sort for smaller subarrays
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
            // made the swapping without using conditions to make it some what random, also helped a lot in performance due to less array accessing
            // making the swaps using tuples is faster than traditional swapping for some reason, C# moment
            int middle = (first + last) / 2;
            
            (arr[middle], arr[first]) = (arr[first], arr[middle]);
 
            (arr[first], arr[last]) = (arr[last], arr[first]);
            
            (arr[middle], arr[last]) = (arr[last], arr[middle]);

            float pivot = arr[middle];
            arr[middle] = arr[first];
            arr[first] = pivot;
            int leftMark = first + 1;
            int rightMark = last;

            //using this as the while condition is better than using while true
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

            (arr[first], arr[rightMark]) = (arr[rightMark], arr[first]);

            return rightMark;
        }


        #endregion
    }
}
