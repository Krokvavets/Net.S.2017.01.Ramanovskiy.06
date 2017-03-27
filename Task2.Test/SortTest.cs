using System;
using NUnit.Framework;

namespace Task2.Test
{
    [TestFixture]
    public class SortTest
    {
        [TestCase(new int[] { 3, 5, 6,}, new int[] { 1, 2, 3,}, new int[] { -1, 2, 63, 12, 3}, new int[] { -10, 14, 3, 54, 100,0 }, new int[] { 1, 2, 3,3}, "311-1-10")]
        [TestCase(new int[] { 33, 1, 5,}, new int[] { 1, 1, 1,}, new int[] { -1, -2, -63, -12, 3}, new int[] { -10, 14, 3, 54, 100,0,0 }, new int[] { 1, 2, 3,3}, "1133-10-1")]
        [TestCase(new int[] { -30, 14, 7,}, new int[] { 0, 12, -3, 27}, new int[] { -1}, new int[] { -110, 14, 43, 534, 100,0 }, new int[] { 1, 342, 3,3}, "1-10-30-110")]
        [Test]
        public void SortMinVlToMin_PositiveTest(int[] list0, int[] list1, int[] list2, int[] list3, int[] list4, string expectedResult)
        {
            int[][] array = new int[5][];
            array[0] = list0;
            array[1] = list1;
            array[2] = list2;
            array[3] = list3;
            array[4] = list4;
            array.SortMinVlToMin();
            string str = array[0][0].ToString() + array[1][0].ToString() + array[2][0].ToString()+ array[3][0].ToString()+ array[4][0].ToString();
            Assert.AreEqual(expectedResult, str);
        }

        [TestCase(new int[] { 3, 5, 6, }, new int[] { 1, 2, 3, }, new int[] { -1, 2, 63, 12, 3 }, new int[] { -10, 14, 3, 54, 100, 0 }, new int[] { 1, 2, 3, 3 }, "-10-1113")]
        [TestCase(new int[] { 33, 1, 5, }, new int[] { 1, 1, 1, }, new int[] { -1, -2, -63, -12, 3 }, new int[] { -10, 14, 3, 54, 100, 0, 0 }, new int[] { 1, 2, 3, 3 }, "-1-103311")]
        [TestCase(new int[] { -30, 14, 7, }, new int[] { 0, 12, -3, 27 }, new int[] { -1 }, new int[] { -110, 14, 43, 534, 100, 0 }, new int[] { 1, 342, 3, 3 }, "-110-300-11")]
        [Test]
        public void SortMinVlToMax_PositiveTest(int[] list0, int[] list1, int[] list2, int[] list3, int[] list4, string expectedResult)
        {
            int[][] array = new int[5][];
            array[0] = list0;
            array[1] = list1;
            array[2] = list2;
            array[3] = list3;
            array[4] = list4;
            array.SortMinVlToMax();
            string str = array[0][0].ToString() + array[1][0].ToString() + array[2][0].ToString() + array[3][0].ToString() + array[4][0].ToString();
            Assert.AreEqual(expectedResult, str);
        }
        [TestCase(new int[] { 3, 5, 6, }, new int[] { 1, 2, 3, }, new int[] { -1, 2, 63, 12, 3 }, new int[] { -10, 14, 3, 54, 100, 0 }, new int[] { 1, 2, 3, 3 }, "-10-1311")]
        [TestCase(new int[] { 33, 1, 5, }, new int[] { 1, 1, 1, }, new int[] { -1, -2, -63, -12, 3 }, new int[] { -10, 14, 3, 54, 100, 0, 0 }, new int[] { 1, 2, 3, 3 }, "-10331-11")]
        [TestCase(new int[] { -30, 14, 7, }, new int[] { 0, 12, -3, 27 }, new int[] { -1 }, new int[] { -110, 14, 43, 534, 100, 0 }, new int[] { 1, 342, 3, 3 }, "-11010-30-1")]
        [Test]
        public void SortMaxVlToMin_PositiveTest(int[] list0, int[] list1, int[] list2, int[] list3, int[] list4, string expectedResult)
        {
            int[][] array = new int[5][];
            array[0] = list0;
            array[1] = list1;
            array[2] = list2;
            array[3] = list3;
            array[4] = list4;
            array = array.SortMaxVlToMin();
            string str = array[0][0].ToString() + array[1][0].ToString() + array[2][0].ToString() + array[3][0].ToString() + array[4][0].ToString();
            Assert.AreEqual(expectedResult, str);
        }
        [TestCase(new int[] { 3, 5, 6, }, new int[] { 1, 2, 3, }, new int[] { -1, 2, 63, 12, 3 }, new int[] { -10, 14, 3, 54, 100, 0 }, new int[] { 1, 2, 3, 3 }, "113-1-10")]
        [TestCase(new int[] { 33, 1, 5, }, new int[] { 1, 1, 1, }, new int[] { -1, -2, -63, -12, 3 }, new int[] { -10, 14, 3, 54, 100, 0, 0 }, new int[] { 1, 2, 3, 3 }, "1-1133-10")]
        [TestCase(new int[] { -30, 14, 7, }, new int[] { 0, 12, -3, 27 }, new int[] { -1 }, new int[] { -110, 14, 43, 534, 100, 0 }, new int[] { 1, 342, 3, 3 }, "-1-3001-110")]
        [Test]
        public void SortMaxVlToMax_PositiveTest(int[] list0, int[] list1, int[] list2, int[] list3, int[] list4, string expectedResult)
        {
            int[][] array = new int[5][];
            array[0] = list0;
            array[1] = list1;
            array[2] = list2;
            array[3] = list3;
            array[4] = list4;
            array = array.SortMaxVlToMax();
            string str = array[0][0].ToString() + array[1][0].ToString() + array[2][0].ToString() + array[3][0].ToString() + array[4][0].ToString();
            Assert.AreEqual(expectedResult, str);
        }
        [TestCase(new int[] { 3, 5, 6, }, new int[] { 1, 2, 3, }, new int[] { -1, 2, 63, 12, 3 }, new int[] { -10, 14, 3, 54, 100, 0 }, new int[] { 1, 2, 3, 3 }, "-10-1311")]
        [TestCase(new int[] { 33, 1, 5, }, new int[] { 1, 1, 1, }, new int[] { -1, -2, -63, -12, 3 }, new int[] { -10, 14, 3, 54, 100, 0, 0 }, new int[] { 1, 2, 3, 3 }, "-103311-1")]
        [TestCase(new int[] { -30, 14, 7, }, new int[] { 0, 12, -3, 27 }, new int[] { -1 }, new int[] { -110, 14, 43, 534, 100, 0 }, new int[] { 1, 342, 3, 3 }, "-11010-1-30")]
        [Test]
        public void SortSumToMin_PositiveTest(int[] list0, int[] list1, int[] list2, int[] list3, int[] list4, string expectedResult)
        {
            int[][] array = new int[5][];
            array[0] = list0;
            array[1] = list1;
            array[2] = list2;
            array[3] = list3;
            array[4] = list4;
            array = array.SortSumToMin();
            string str = array[0][0].ToString() + array[1][0].ToString() + array[2][0].ToString() + array[3][0].ToString() + array[4][0].ToString();
            Assert.AreEqual(expectedResult, str);
        }

        [TestCase(new int[] { 3, 5, 6, }, new int[] { 1, 2, 3, }, new int[] { -1, 2, 63, 12, 3 }, new int[] { -10, 14, 3, 54, 100, 0 }, new int[] { 1, 2, 3, 3 }, "113-1-10")]
        [TestCase(new int[] { 33, 1, 5, }, new int[] { 1, 1, 1, }, new int[] { -1, -2, -63, -12, 3 }, new int[] { -10, 14, 3, 54, 100, 0, 0 }, new int[] { 1, 2, 3, 3 }, "-11133-10")]
        [TestCase(new int[] { -30, 14, 7, }, new int[] { 0, 12, -3, 27 }, new int[] { -1 }, new int[] { -110, 14, 43, 534, 100, 0 }, new int[] { 1, 342, 3, 3 }, "-30-101-110")]
        [Test]
        public void SortSumToMax_PositiveTest(int[] list0, int[] list1, int[] list2, int[] list3, int[] list4, string expectedResult)
        {
            int[][] array = new int[5][];
            array[0] = list0;
            array[1] = list1;
            array[2] = list2;
            array[3] = list3;
            array[4] = list4;
            array = array.SortSumToMax();
            string str = array[0][0].ToString() + array[1][0].ToString() + array[2][0].ToString() + array[3][0].ToString() + array[4][0].ToString();
            Assert.AreEqual(expectedResult, str);
        }

    }
}