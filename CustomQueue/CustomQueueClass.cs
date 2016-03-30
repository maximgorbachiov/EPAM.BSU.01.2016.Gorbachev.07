using System;
using System.Collections;
using System.Collections.Generic;

namespace CustomQueue
{
    public class CustomQueueClass<T>: IEnumerable<T>
    {
        private T[] queueElements;
        private int count;
        private int capacity = 4;
        private int head;
        private int tail = -1;
        private int increaseCapacityCoefficient = 2;
        private bool isCollectionModified;

        public CustomQueueClass()
        {
            queueElements = new T[capacity];
        }

        public CustomQueueClass(int startCapacity)
        {
            if (startCapacity > 0)
            {
                capacity = startCapacity;
            }
            queueElements = new T[capacity];
        }

        public int Capacity { get { return capacity; } }
        public int Count { get { return count; } }

        public void Enqueue(T element)
        {
            isCollectionModified = true;

            if (tail + 1 == capacity)
            {
                capacity *= increaseCapacityCoefficient;
                T[] tempArray = new T[capacity];
                queueElements.CopyTo(tempArray, 0);
                queueElements = tempArray;
            }
            tail++;
            queueElements[tail] = element;
            count++;
        }

        public T Dequeue()
        {
            if (count == 0)
            {
                throw new Exception("The queue is empty");
            }

            isCollectionModified = true;

            T removedElement = queueElements[head];
            head++;
            count--;

            if (count / increaseCapacityCoefficient <= head)
            {
                for (int i = 0; i < count; i++)
                {
                    queueElements[i] = queueElements[i + head];
                }

                head = 0;
                tail = count - 1;
            }

            return removedElement;
        }

        public T Peek()
        {
            if (count == 0)
            {
                throw new Exception("The queue is empty");
            }

            return queueElements[head];
        }

        public bool Contains(T element)
        {
            bool isContains = false;

            for (int i = head; i <= tail; i++)
            {
                if (queueElements[i].Equals(element))
                {
                    isContains = true;
                    break;
                }
            }
            return isContains;
        }

        public void Clear()
        {
            capacity = 4;
            count = 0;
            queueElements = new T[capacity];
        }

        public IEnumerator<T> GetEnumerator()
        {
            isCollectionModified = false;
            return new CustomQueueIterater(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private class CustomQueueIterater : IEnumerator<T>
        {
            private CustomQueueClass<T> iteratedQueue;
            private int index;

            public T Current { get; private set; }

            public CustomQueueIterater(CustomQueueClass<T> queue)
            {
                iteratedQueue = queue;
                index = iteratedQueue.head;
            } 

            public void Dispose()
            {
                iteratedQueue = new CustomQueueClass<T>();
            }

            public bool MoveNext()
            {
                if (iteratedQueue.isCollectionModified)
                {
                    throw new InvalidOperationException("The collection was modified after enumerator was created");
                }

                if (index != iteratedQueue.Count)
                {
                    Current = iteratedQueue.queueElements[index];
                    index++;
                    return true;
                }

                return false;
            }

            public void Reset()
            {
                index = iteratedQueue.head;
            }

            object IEnumerator.Current
            {
                get { return Current; }
            }
        }
    }
}
