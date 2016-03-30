using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using BinarySeacherLib;

namespace Test.NUnit.BinarySearcher
{
    [TestFixture]
    public class TestBinarySearcher
    {
        private class CustomComparer : IComparer<int>
        {
            public int Compare(int x, int y)
            {
                if (x == y)
                {
                    return 0;
                }

                if (x < y)
                {
                    return 1;
                }

                return -1;
            }
        }

        [TestCase]
        public void Test_SortOfJaggedArray_ByAscendingOfSumElements_InterfaceOnDelegate()
        {
            int expectedIndex = 0;
            int realIndex;

            List<int> sortedArray = new List<int>{ 0, 10};

            IComparer<int> comparer = new CustomComparer();

            realIndex = BinarySearcher<int>.Search(sortedArray, 0, comparer);

            Assert.AreEqual(expectedIndex, realIndex);
        }
    }
}
