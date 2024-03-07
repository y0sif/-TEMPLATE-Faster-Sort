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
            Introsort(arr);
            
            return arr;
        }

        static private void Introsort(float[] arr)
        {
            int maxDepth = (int)Math.Floor(2 * Math.Log(arr.Length) / Math.Log(2));
            IntrosortRecursive(arr, 0, arr.Length - 1, maxDepth);
            InsertionSort(arr);
        }

        static private void IntrosortRecursive(float[] arr, int first, int last, int maxDepth)
        {
            while (last - first > 20)
            {
                if (maxDepth == 0)
                {
                    Heapsort(arr, first, last,20);
                    return;
                }

                int pivotIndex = Partition(arr, first, last);
                maxDepth--;

                if (pivotIndex - 1 > first)
                    IntrosortRecursive(arr, first, pivotIndex - 1, maxDepth);

                first = pivotIndex + 1;
            }
        }

        static private int Left(int n)
        {
            return 2 * n + 1;
        }

        static private int Right(int n)
        {
            return 2 * n + 2;
        }
        static private void MaxHeapify(float[] arr, int index, int heapSize)
        {
            int left = Left(index);
            int right = Right(index);
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
                (arr[index], arr[largest]) = (arr[largest], arr[index]);
                MaxHeapify(arr, largest, heapSize);
            }
        }

        static private int BuildMaxHeap(float[] arr, int first, int heapSize)
        {
            int hp = first + heapSize / 2 -1;
            int i = hp;
            for ( ; i >= first; i--)
            {
                MaxHeapify(arr, i, heapSize);
            }
            return hp;
        }


        static private void Heapsort(float[] arr, int first, int last, int heapSize)
        {
            BuildMaxHeap(arr, first, heapSize);
            for (int i = arr.Length - 1; i > 0; i--)
            {
                (arr[0], arr[i]) = (arr[i], arr[0]);
                heapSize--;
                MaxHeapify(arr, 0, heapSize);
            }
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
            Random r = new Random();
            int randStart = r.Next(first, last);
            float pivot = arr[randStart];
            arr[randStart] = arr[first];
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

            

            return rightMark;
        }

        static private void InsertionSort(float[] arr)
        {
            float temp;
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = i; j < arr.Length; j++)
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


        #endregion
    }
}
