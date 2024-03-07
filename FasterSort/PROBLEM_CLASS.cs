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

        static private void QuickSort(float[] arr, int first, int last)
        {
            if (first < last)
            {
                int split = Partition(arr, first, last);

                QuickSort(arr, first, split - 1);
                QuickSort(arr, split + 1, last);

            }
        }

        static private int Partition(float[] arr, int first, int last)
        {
            float pivot = arr[first];
            int leftMark = first + 1;
            int rightMark = last;
            bool done = false;

            while (!done)
            {
                while (leftMark <= rightMark && arr[leftMark] <= pivot)
                {
                    leftMark++;
                }

                while (arr[rightMark] >= pivot && rightMark >= leftMark)
                {
                    rightMark--;
                }

                if (rightMark < leftMark) 
                { 
                    done = true;
                }
                else
                {
                    float temp1 = arr[leftMark];
                    arr[leftMark] = arr[rightMark];
                    arr[rightMark] = temp1;
                }
            }
            float temp = arr[first];
            arr[first] = arr[rightMark];
            arr[rightMark] = temp;

            return rightMark;
        }
        #endregion
    }
}
