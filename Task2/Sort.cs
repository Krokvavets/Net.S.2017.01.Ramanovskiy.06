using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    struct Date
    {
        public int Numer { get; internal set; }
        public int Value { get; internal set; }
    }

    public static class Sort
    {
        ///<summary>
        /// The method is Algorithm Bubble Sort
        ///</summary>
        /// <param name="array">Input array</param>
        ///<returns>sorted array</returns>
        static private Date[] BubbleSort(Date[] array)
        {
            Date temp;
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[i].Value > array[j].Value)
                    {
                        temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                    }
                }
            }
            return array;
        }
        ///<summary>
        /// The method is Algorithm Bubble Sort for matrix from largest to the smallest min. value in matrix
        ///</summary>
        /// <param name="array">Input matrix</param>
        ///<returns>sorted array</returns>
        public static int[][] SortMinVlToMin(this int[][] array)
        {
            int[][] sortedArray = SortMinVlToMax(array);
            Array.Reverse(sortedArray);
            return sortedArray;
        }

        ///<summary>
        /// The method is Algorithm Bubble Sort for matrix from the smallest to the largest min. value in matrix
        ///</summary>From the smallest to the largest
        /// <param name="array">Input matrix</param>
        ///<returns>sorted array</returns>

        public static int[][] SortMinVlToMax(this int[][] array)
        {
            Date[] arrayForSort = new Date[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                arrayForSort[i].Value = array[i].Min();
                arrayForSort[i].Numer = i;
            }
            return Enum(array, BubbleSort(arrayForSort));
        }
        ///<summary>
        /// The method is Algorithm Bubble Sort for matrix from largest to the smallest max. value in matrix
        ///</summary>
        /// <param name="array">Input matrix</param>
        ///<returns>sorted array</returns>

        public static int[][] SortMaxVlToMin(this int[][] array)
        {
            int[][] sortedArray = SortMaxVlToMax(array);
            Array.Reverse(sortedArray);
            return sortedArray;
        }
        ///<summary>
        /// The method is Algorithm Bubble Sort for matrix from the smallest to the largest max. value in matrix
        ///</summary>From the smallest to the largest
        /// <param name="array">Input matrix</param>
        ///<returns>sorted array</returns>
        public static int[][] SortMaxVlToMax(this int[][] array)
        {
            Date[] arrayForSort = new Date[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                arrayForSort[i].Value = array[i].Max();
                arrayForSort[i].Numer = i;
            }
            return Enum(array, BubbleSort(arrayForSort));
        }
        ///<summary>
        /// The method is Algorithm Bubble Sort for matrix from largest to the smallest string amount of matrix
        ///</summary>
        /// <param name="array">Input matrix</param>
        ///<returns>sorted array</returns>
        public static int[][] SortSumToMin(this int[][] array)
        {
            int[][] sortedArray = SortSumToMax(array);
            Array.Reverse(sortedArray);
            return sortedArray;
        }
        ///<summary>
        /// The method is Algorithm Bubble Sort for matrix from largest to the smallest string amount of matrix
        ///</summary>
        /// <param name="array">Input matrix</param>
        ///<returns>sorted array</returns>
        public static int[][] SortSumToMax(int[][] array)
        {
            Date[] arrayForSort = new Date[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                arrayForSort[i].Value = array[i].Sum();
                arrayForSort[i].Numer = i;
            }
            return Enum(array, BubbleSort(arrayForSort));
        }

        private static int[][] Enum(int[][] inputArray, Date[] sortedArray)
        {
            int[][] outputArray = new int[inputArray.Length][];
            for (int i = 0; i < inputArray.Length; i++)
                outputArray[i] = inputArray[sortedArray[i].Numer];
            return outputArray;
        }
    }
}
