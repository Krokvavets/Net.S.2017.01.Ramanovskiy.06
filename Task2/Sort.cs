namespace Task2
{
    public static class Sort
    {
        ///<summary>
        /// The method is Algorithm Bubble Sort
        ///</summary>
        /// <param name="array">Input array</param>
        /// <param name="comparer">Input comparer</param>
        ///<returns>sorted array</returns>
        static public void BubbleSort(this int[][] array, IComparer comparer)
        {
            int[] temp;
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (comparer.Compare(array[i], array[j]) == 1)
                    {
                        temp = (int[])array[i].Clone();
                        array[i] = (int[])array[j].Clone();
                        array[j] = (int[])temp.Clone();
                    }
                }
            }
        }
    }
}
