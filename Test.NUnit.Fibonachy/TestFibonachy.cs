using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using FibonachyLib;

namespace Test.NUnit.Fibonachy
{
    [TestFixture]
    public class TestFibonachy
    {
        [TestCase]
        public void Test_Fibonachy_WithNormParams()
        {
            IEnumerable<int> expectedResult = new List<int> { 1, 1, 2, 3, 5, 8, 13, 21, 34, 55 };
            IEnumerable<int> realResult;

            realResult = FibonachyLib.Fibonachy.GetSequenceOfFibonachy(10);

            Assert.AreEqual(expectedResult, realResult);
        }

        [TestCase]
        public void Test_Fibonachy_ForNullElement()
        {
            IEnumerable<int> expectedResult = new List<int> { 0 };
            IEnumerable<int> realResult;

            realResult = FibonachyLib.Fibonachy.GetSequenceOfFibonachy(0);

            Assert.AreEqual(expectedResult, realResult);
        }
    }
}
