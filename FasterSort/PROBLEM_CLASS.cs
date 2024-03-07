﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
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
            Stopwatch sw = null;
            sw = Stopwatch.StartNew();
            MergeSort(arr, 0, N-1);
            sw.Stop();
            Console.WriteLine("time of merge: " + sw.ElapsedMilliseconds);
            return arr;
        }
        #endregion

        static private void MergeSort(float[] arr, int start, int end)
        {
            
            if (start < end)
            {
                int mid = (start + end) / 2;
                Parallel.Invoke(
                () =>
                {
                    MergeSort(arr, start, mid);
                },
                () =>
                {
                    MergeSort(arr, mid + 1, end);
                });
                if (end - start < 50)
                {
                    float temp;
                    for (int i = start; i <= end; i++)
                    {
                        for (int j = i; j <= end; j++)
                        {
                            if (arr[i] > arr[j])
                            {
                                temp = arr[j];
                                arr[j] = arr[i];
                                arr[i] = temp;
                            }
                        }
                    }
                }
                else
                {
                    Merge(arr, start, mid, end);
                }
                
            }
            
        }

        static private void Merge(float[] arr, int start, int mid, int end)
        {
            int n1 = mid - start + 1;
            int n2 = end - mid;

            float[] arr1 = new float[n1];

            for (int e = 0; e < n1; e++)
                arr1[e] = arr[start + e];

            int i = 0;
            int j = 0;
            int k = start;
            for ( ; k < end; k++) 
            {
                if (i < n1 && j < n2)
                {
                    if (arr1[i] <= arr[j + mid + 1])
                    {
                        arr[k] = arr1[i];
                        i++;
                    }
                    else
                    {
                        arr[k] = arr[j + mid + 1];
                        j++;
                    }
                }
                else
                {
                    break;
                }
            }

            while (i < n1)
            {
                arr[k] = arr1[i];
                k++;
                i++;
            }

            while (j < n2)
            {
                arr[k] = arr[j + mid + 1];
                k++;
                j++;
            }

        }
    }
}
