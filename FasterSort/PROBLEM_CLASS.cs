using System;
using System.Collections;
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
            MergeSort(arr, 0, N);
            return arr;
        }
        #endregion

        static private void MergeSort(float[] arr, int start, int end)
        {
            if (start < end)
            {
                int mid = (start + end) / 2;
                MergeSort(arr, start, mid);
                MergeSort(arr, mid, end);
                Merge(arr, start, mid, end);
            }
        }

        static private void Merge(float[] arr, int start, int mid, int end)
        {
            //Console.WriteLine("in merge");
            int n1 = mid - start+1;
            int n2 = end - mid;

            float[] arr1 = new float[n1 + 1];
            float[] arr2 = new float[n2 + 1];

            //Console.WriteLine("in first arr");
            for (int k = 0; k < n1; k++)
            {
                //Console.WriteLine(arr[start + k]);
                arr1[k] = arr[start + k];
            }

            //Console.WriteLine("in second arr");
            for (int k = 0; k < n2; k++)
            {
                //Console.WriteLine(arr[k + mid]);
                arr2[k] = arr[k + mid];
            }

            arr1[n1] = arr2[n2] = float.PositiveInfinity;
            int i = 0;
            int j = 0;
            for (int k = start; k < end; k++)
            {
                //Console.WriteLine("arr1: "+arr1[i]);
                //Console.WriteLine("arr2: "+ arr2[j]);
                if (arr1[i] <= arr2[j])
                {
                    arr[k] = arr1[i];
                    i++;
                }
                else
                {
                    arr[k] = arr2[j];
                    j++;
                }
            }
        }
    }
}
