using System;
using NUnit.Framework;
using System.Linq;
using Task2;

namespace Task2.Test
{
    class SortByMinValueToMax : IComparer 
    {
        public int Compare(int[] array1, int[] array2)
        {
            if (array1.Min() > array2.Min())
                return 1;
            if (array1.Min() < array2.Min())
                return -1;
            return 0;
        }
    }

    class SortByMinValueToMin : IComparer
    {
        public int Compare(int[] array1, int[] array2)
        {
            if (array1.Min() < array2.Min())
                return 1;
            if (array1.Min() > array2.Min())
                return -1;
            return 0;
        }
    }

    class SortByMaxValueToMin : IComparer
    {
        public int Compare(int[] array1, int[] array2)
        {
            if (array1.Max() < array2.Max())
                return 1;
            if (array1.Max() > array2.Max())
                return -1;
            return 0;
        }
    }

    class SortByMaxValueToMax : IComparer
    {
        public int Compare(int[] array1, int[] array2)
        {
            if (array1.Max() > array2.Max())
                return 1;
            if (array1.Max() < array2.Max())
                return -1;
            return 0;
        }
    }
    class SortBySumToMax : IComparer
    {
        public int Compare(int[] array1, int[] array2)
        {
            if (array1.Sum() > array2.Sum())
                return 1;
            if (array1.Sum() < array2.Sum())
                return -1;
            return 0;
        }
    }

    class SortBySumToMin : IComparer
    {
        public int Compare(int[] array1, int[] array2)
        {
            if (array1.Sum() < array2.Sum())
                return 1;
            if (array1.Sum() > array2.Sum())
                return -1;
            return 0;
        }
    }



    [TestFixture]
    public class SortTest
    {
       
        [TestCase(new int[] { 3, 5, 6, }, new int[] { 1, 2, 3, }, new int[] { -1, 2, 63, 12, 3 }, new int[] { -10, 14, 3, 54, 100, 0 }, new int[] { 1, 2, 3, 3 },  "-10-1113")]
        [TestCase(new int[] { 33, 1, 5, }, new int[] { 1, 1, 1, }, new int[] { -1, -2, -63, -12, 3 }, new int[] { -10, 14, 3, 54, 100, 0, 0 }, new int[] { 1, 2, 3, 3 }, "-63-10111")]
        [TestCase(new int[] { -30, 14, 7, }, new int[] { 0, 12, -3, 27 }, new int[] { -1 }, new int[] { -110, 14, 43, 534, 100, 0 }, new int[] { 1, 342, 3, 3 }, "-110-30-3-11")]
        [Test]
        public void Sort_By_Min_Vl_To_Max_PositiveTest(int[] list0, int[] list1, int[] list2, int[] list3, int[] list4, string expectedResult)
        {
            var comparer = new SortByMinValueToMax();
            int[][] array = new int[5][];
            array[0] = list0;
            array[1] = list1;
            array[2] = list2;
            array[3] = list3;
            array[4] = list4;
            array.BubbleSort(comparer);          
            string str = array[0].Min().ToString() + array[1].Min().ToString() + array[2].Min().ToString() + array[3].Min().ToString() + array[4].Min().ToString();
            Assert.AreEqual(expectedResult, str);
        }
        [TestCase(new int[] { 3, 5, 6, }, new int[] { 1, 2, 3, }, new int[] { -1, 2, 63, 12, 3 }, new int[] { -10, 14, 3, 54, 100, 0 }, new int[] { 1, 2, 3, 3 }, "311-1-10")]
        [TestCase(new int[] { 33, 1, 5, }, new int[] { 1, 1, 1, }, new int[] { -1, -2, -63, -12, 3 }, new int[] { -10, 14, 3, 54, 100, 0, 0 }, new int[] { 1, 2, 3, 3 }, "111-10-63")]
        [TestCase(new int[] { -30, 14, 7, }, new int[] { 0, 12, -3, 27 }, new int[] { -1 }, new int[] { -110, 14, 43, 534, 100, 0 }, new int[] { 1, 342, 3, 3 }, "1-1-3-30-110")]
        [Test]
        public void Sort_By_Min_Vl_To_Min_PositiveTest(int[] list0, int[] list1, int[] list2, int[] list3, int[] list4, string expectedResult)
        {
            var comparer = new SortByMinValueToMin();
            int[][] array = new int[5][];
            array[0] = list0;
            array[1] = list1;
            array[2] = list2;
            array[3] = list3;
            array[4] = list4;
            array.BubbleSort(comparer);
            string str = array[0].Min().ToString() + array[1].Min().ToString() + array[2].Min().ToString() + array[3].Min().ToString() + array[4].Min().ToString();
            Assert.AreEqual(expectedResult, str);
        }
        [TestCase(new int[] { 3, 5, 6, }, new int[] { 1, 2, 3, }, new int[] { -1, 2, 63, 12, 3 }, new int[] { -10, 14, 3, 54, 100, 0 }, new int[] { 1, 2, 3, 3 }, "-10-1311")]
        [TestCase(new int[] { 33, 1, 5, }, new int[] { 1, 1, 1, }, new int[] { -1, -2, -63, -12, 3 }, new int[] { -10, 14, 3, 54, 100, 0, 0 }, new int[] { 1, 2, 3, 3 }, "-1033-111")]
        [TestCase(new int[] { -30, 14, 7, }, new int[] { 0, 12, -3, 27 }, new int[] { -1 }, new int[] { -110, 14, 43, 534, 100, 0 }, new int[] { 1, 342, 3, 3 }, "-11010-30-1")]
        [Test]
        public void Sort_By_Max_Vl_To_Min_PositiveTest(int[] list0, int[] list1, int[] list2, int[] list3, int[] list4, string expectedResult)
        {
            var comparer = new SortByMaxValueToMin();
            int[][] array = new int[5][];
            array[0] = list0;
            array[1] = list1;
            array[2] = list2;
            array[3] = list3;
            array[4] = list4;
            array.BubbleSort(comparer);            
            string str = array[0][0].ToString() + array[1][0].ToString() + array[2][0].ToString() + array[3][0].ToString() + array[4][0].ToString();
            Assert.AreEqual(expectedResult, str);
        }
        [TestCase(new int[] { 3, 5, 6, }, new int[] { 1, 2, 3, }, new int[] { -1, 2, 63, 12, 3 }, new int[] { -10, 14, 3, 54, 100, 0 }, new int[] { 1, 2, 3, 3 }, "113-1-10")]
        [TestCase(new int[] { 33, 1, 5, }, new int[] { 1, 1, 1, }, new int[] { -1, -2, -63, -12, 3 }, new int[] { -10, 14, 3, 54, 100, 0, 0 }, new int[] { 1, 2, 3, 3 }, "1-1133-10")]
        [TestCase(new int[] { -30, 14, 7, }, new int[] { 0, 12, -3, 27 }, new int[] { -1 }, new int[] { -110, 14, 43, 534, 100, 0 }, new int[] { 1, 342, 3, 3 }, "-1-3001-110")]
        [Test]
        public void Sort_By_Max_Vl_To_Max_PositiveTest(int[] list0, int[] list1, int[] list2, int[] list3, int[] list4, string expectedResult)
        {
            var comparer = new SortByMaxValueToMax();
            int[][] array = new int[5][];
            array[0] = list0;
            array[1] = list1;
            array[2] = list2;
            array[3] = list3;
            array[4] = list4;
            array.BubbleSort(comparer);
            string str = array[0][0].ToString() + array[1][0].ToString() + array[2][0].ToString() + array[3][0].ToString() + array[4][0].ToString();
            Assert.AreEqual(expectedResult, str);
        }
        [TestCase(new int[] { 3, 5, 6, }, new int[] { 1, 2, 3, }, new int[] { -1, 2, 63, 12, 3 }, new int[] { -10, 14, 3, 54, 100, 0 }, new int[] { 1, 2, 3, 3 }, "-10-1311")]
        [TestCase(new int[] { 33, 1, 5, }, new int[] { 1, 1, 1, }, new int[] { -1, -2, -63, -12, 3 }, new int[] { -10, 14, 3, 54, 100, 0, 0 }, new int[] { 1, 2, 3, 3 }, "-103311-1")]
        [TestCase(new int[] { -30, 14, 7, }, new int[] { 0, 12, -3, 27 }, new int[] { -1 }, new int[] { -110, 14, 43, 534, 100, 0 }, new int[] { 1, 342, 3, 3 }, "-11010-1-30")]
        [Test]
        public void Sort_By_Sum_To_Min_PositiveTest(int[] list0, int[] list1, int[] list2, int[] list3, int[] list4, string expectedResult)
        {
            var comparer = new SortBySumToMin();
            int[][] array = new int[5][];
            array[0] = list0;
            array[1] = list1;
            array[2] = list2;
            array[3] = list3;
            array[4] = list4;
            array.BubbleSort(comparer);           
            string str = array[0][0].ToString() + array[1][0].ToString() + array[2][0].ToString() + array[3][0].ToString() + array[4][0].ToString();
            Assert.AreEqual(expectedResult, str);
        }

        [TestCase(new int[] { 3, 5, 6, }, new int[] { 1, 2, 3, }, new int[] { -1, 2, 63, 12, 3 }, new int[] { -10, 14, 3, 54, 100, 0 }, new int[] { 1, 2, 3, 3 }, "113-1-10")]
        [TestCase(new int[] { 33, 1, 5, }, new int[] { 1, 1, 1, }, new int[] { -1, -2, -63, -12, 3 }, new int[] { -10, 14, 3, 54, 100, 0, 0 }, new int[] { 1, 2, 3, 3 }, "-11133-10")]
        [TestCase(new int[] { -30, 14, 7, }, new int[] { 0, 12, -3, 27 }, new int[] { -1 }, new int[] { -110, 14, 43, 534, 100, 0 }, new int[] { 1, 342, 3, 3 }, "-30-101-110")]
        [Test]
        public void Sort_By_Sum_To_Max_PositiveTest(int[] list0, int[] list1, int[] list2, int[] list3, int[] list4, string expectedResult)
        {
            var comparer = new SortBySumToMax();
            int[][] array = new int[5][];
            array[0] = list0;
            array[1] = list1;
            array[2] = list2;
            array[3] = list3;
            array[4] = list4;
            array.BubbleSort(comparer);
            string str = array[0][0].ToString() + array[1][0].ToString() + array[2][0].ToString() + array[3][0].ToString() + array[4][0].ToString();
            Assert.AreEqual(expectedResult, str);
        }

    }
}