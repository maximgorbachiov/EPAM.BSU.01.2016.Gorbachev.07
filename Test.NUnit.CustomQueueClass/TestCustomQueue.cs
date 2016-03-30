using System;
using System.Collections.Generic;
using NUnit.Framework;
using CustomQueue;

namespace Test.NUnit.CustomQueueClass
{
    [TestFixture]
    public class TestCustomQueue
    {
        [TestCase]
        public void Test_EnqueueToCustomQueue_WithIterations()
        {
            int[] expectedArray = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int[] resultArray = new int[10];
            int j = 0;

            CustomQueueClass<int> queue = new CustomQueueClass<int>();

            for (int i = 0; i < 10; i++)
            {
                queue.Enqueue(i);
            }

            foreach (var value in queue)
            {
                resultArray[j++] = value;
            }

            Assert.AreEqual(expectedArray, resultArray);
        }

        [TestCase]
        public void Test_DequeueCustomQueue_WithoutIterations()
        {
            int[] expectedArray = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int[] resultArray = new int[10];

            CustomQueueClass<int> queue = new CustomQueueClass<int>();

            for (int i = 0; i < 10; i++)
            {
                queue.Enqueue(i);
            }

            for (int i = 0; i < 10; i++)
            {
                resultArray[i] = queue.Dequeue();
            }

            Assert.AreEqual(expectedArray, resultArray);
        }

        [TestCase]
        public void Test_EnqueueDequeueEnqueueToCustomQueue_WithIterations()
        {
            int[] expectedArray = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int[] resultArray = new int[10];
            int j = 0;

            CustomQueueClass<int> queue = new CustomQueueClass<int>();

            for (int i = 0; i < 10; i++)
            {
                queue.Enqueue(i);
            }

            for (int i = 0; i < 10; i++)
            {
                resultArray[i] = queue.Dequeue();
            }

            for (int i = 0; i < 10; i++)
            {
                queue.Enqueue(i);
            }

            foreach (var value in queue)
            {
                resultArray[j++] = value;
            }

            Assert.AreEqual(expectedArray, resultArray);
        }

        [TestCase(ExpectedException = typeof(InvalidOperationException))]
        public void Test_IterationsExcception_AfterQueueModified()
        {
            int[] resultArray = new int[10];
            int j = 0;

            CustomQueueClass<int> queue = new CustomQueueClass<int>();

            for (int i = 0; i < 10; i++)
            {
                queue.Enqueue(i);
            }

            foreach (var value in queue)
            {
                resultArray[j++] = value;
                queue.Dequeue();
            }
        }

        [TestCase]
        public void Test_Iterations_ByHand()
        {
            int[] expectedArray = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int[] resultArray = new int[10];
            int j = 0;

            CustomQueueClass<int> queue = new CustomQueueClass<int>();

            for (int i = 0; i < 10; i++)
            {
                queue.Enqueue(i);
            }

            IEnumerator<int> iterater = queue.GetEnumerator();

            while (iterater.MoveNext())
            {
                resultArray[j++] = iterater.Current;
            }

            Assert.AreEqual(expectedArray, resultArray);
        }

        [TestCase(ExpectedException = typeof(InvalidOperationException))]
        public void Test_IterationsExcception_AfterQueueModified_ByHand()
        {
            CustomQueueClass<int> queue = new CustomQueueClass<int>();

            for (int i = 0; i < 10; i++)
            {
                queue.Enqueue(i);
            }

            IEnumerator<int> iterater = queue.GetEnumerator();

            while (iterater.MoveNext())
            {
                queue.Enqueue(9);            
            }
        }
    }
}
