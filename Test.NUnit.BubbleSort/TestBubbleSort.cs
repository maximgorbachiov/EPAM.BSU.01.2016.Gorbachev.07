using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using BubbleSortLib;


namespace Test.NUnit.BubbleSort
{
    [TestFixture]
    public class TestBubbleSort
    {
        class CustomComparator : IComparer<int[]>
        {
            public delegate bool CompareByWeights(int x, int y);

            private CompareByWeights CompareBy;

            public CustomComparator(CompareByWeights func)
            {
                CompareBy = func;
            }

            public int Compare(int[] a, int[] b)
            {
                int temp = CheckOnNullAndEmpty(a, b);

                if (temp != -1)
                {
                    return temp;
                }

                int sum1 = a.Sum();
                int sum2 = b.Sum();

                if (sum1 == sum2)
                {
                    return 0;
                }

                return (CompareBy(sum1, sum2)) ? 1 : -1;
            }

            private int CheckOnNullAndEmpty(int[] a, int[] b)
            {
                if (a == null)
                {
                    return 0;
                }

                if ((b == null) || (b.Length == 0))
                {
                    return 1;
                }

                if (a.Length == 0)
                {
                    return 0;
                }

                return -1;
            }
        }

        public int Compare(int[] arr1, int[] arr2)
        {
            IComparer<int[]> comparator = new CustomComparator((a, b) => a > b);
            return comparator.Compare(arr1, arr2);
        }

        [TestCase]
        public void Test_SortOfJaggedArray_ByAscendingOfSumElements_InterfaceOnDelegate()
        {
            int[][] expectedArray = { new[] { 2, 4, 6 }, new[] { 3, 5, 7 }, new[] { 4, 6, 8 } };
            int[][] sortedArray = { new[] { 4, 6, 8 }, new[] { 3, 5, 7 }, new[] { 2, 4, 6 } };

            IComparer<int[]> comparator = new CustomComparator((a, b) => a > b);

            BubbleSort<int[]>.Sort(sortedArray, comparator);

            Assert.AreEqual(expectedArray, sortedArray);
        }

        [TestCase]
        public void Test_SortOfJaggedArray_ByDiscendingOfMaxElements_InterfaceOnDelegate()
        {
            int[][] expectedArray = { new[] { 4, 6, 8 }, new[] { 3, 5, 7 }, new[] { 2, 4, 6 } };
            int[][] sortedArray = { new[] { 2, 4, 6 }, new[] { 3, 5, 7 }, new[] { 4, 6, 8 } };

            IComparer<int[]> comparator = new CustomComparator((a, b) => a < b);

            BubbleSort<int[]>.Sort(sortedArray, comparator);

            Assert.AreEqual(expectedArray, sortedArray);
        }

        [TestCase]
        public void Test_SortOfJaggedArray_WithNullElements_ByAscendingOfMaxElements_InterfaceOnDelegate()
        {
            int[][] expectedArray = { null, new[] { 2, 4, 6 }, new[] { 4, 6, 8 } };
            int[][] sortedArray = { new[] { 2, 4, 6 }, null, new[] { 4, 6, 8 } };

            IComparer<int[]> comparator = new CustomComparator((a, b) => a > b);

            BubbleSort<int[]>.Sort(sortedArray, comparator);

            Assert.AreEqual(expectedArray, sortedArray);
        }

        [TestCase]
        public void Test_SortOfJaggedArray_WithEmptyArrays_ByAscendingMaxElements_InterfaceOnDelegate()
        {
            int[][] expectedArray = { new int[0], new[] { 2, 4, 6 }, new[] { 4, 6, 8 } };
            int[][] sortedArray = { new[] { 2, 4, 6 }, new int[0], new[] { 4, 6, 8 } };

            IComparer<int[]> comparator = new CustomComparator((a, b) => a > b);

            BubbleSort<int[]>.Sort(sortedArray, comparator);

            Assert.AreEqual(expectedArray, sortedArray);
        }

        [TestCase]
        public void Test_SortOfJaggedArray_WithEmptyAndNullsArrays_ByAscendingMaxElements_InterfaceOnDelegate()
        {
            int[][] expectedArray = { null, null, new int[0], new int[0], new[] { 2, 4, 6 }, new[] { 4, 6, 8 } };
            int[][] sortedArray = { new[] { 2, 4, 6 }, null, new int[0], new int[0], new[] { 4, 6, 8 }, null };

            IComparer<int[]> comparator = new CustomComparator((a, b) => a > b);

            BubbleSort<int[]>.Sort(sortedArray, comparator);

            Assert.AreEqual(expectedArray, sortedArray);
        }

        [TestCase(ExpectedException = typeof(ArgumentNullException))]
        public void Test_SortOfNullJaggedArray_ByAscendingSum_InterfaceOnDelegate()
        {
            int[][] sortedArray = null;
            IComparer<int[]> comparator = new CustomComparator((a, b) => a > b);

            BubbleSort<int[]>.Sort(sortedArray, comparator);
        }

        [TestCase(ExpectedException = typeof(ArgumentNullException))]
        public void Test_SortOfJaggedArray_ComparatorIsNull_InterfaceOnDelegate()
        {
            int[][] sortedArray = { new[] { 2, 4, 6 }, null, new int[0], new int[0], new[] { 4, 6, 8 }, null };

            IComparer<int[]> comparator = null;

            BubbleSort<int[]>.Sort(sortedArray, comparator);
        }

        [TestCase]
        public void Test_SortOfJaggedArray_WithEmptyAndNullsArrays_ByAscendingSum_Delegate()
        {
            int[][] expectedArray = { null, null, new int[0], new int[0], new[] { 2, 4, 6 }, new[] { 4, 6, 8 } };
            int[][] sortedArray = { new[] { 2, 4, 6 }, null, new int[0], new int[0], new[] { 4, 6, 8 }, null };

            BubbleSort<int[]>.Sort(sortedArray, Compare);

            Assert.AreEqual(expectedArray, sortedArray);
        }

        [TestCase]
        public void Test_SortOfIntArray_ByStandartComparator_ByAscending_InterfaceOnDelegate()
        {
            int[] expectedArray = { 0, 2, 4, 4, 6, 6, 8 };
            int[] sortedArray = { 0, 2, 4, 6, 4, 6, 8 };

            BubbleSort<int>.Sort(sortedArray, (IComparer<int>)null);

            Assert.AreEqual(expectedArray, sortedArray);
        }
    }
}
