using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BubbleSortLib
{
    public static class BubbleSort<T>
    {
        public delegate int Comparator(T x, T y);

        static public void Sort(T[] sourceArray, Comparator comparator)
        {
            if (sourceArray == null)
            {
                throw new ArgumentNullException(nameof(sourceArray));
            }

            if (comparator == null)
            {
                if (typeof(T).GetInterface("IComparable") != null)
                {
                    Comparer<T> comparer = Comparer<T>.Default;
                    comparator = comparer.Compare;
                }
                else
                {
                    throw new ArgumentNullException(nameof(comparator));
                }
            }

            for (int i = 0; i < sourceArray.Length - 1; i++)
            {
                for (int j = 0; j < sourceArray.Length - 1; j++)
                {
                    if (comparator(sourceArray[j], sourceArray[j + 1]) > 0)
                    {
                        Swap(ref sourceArray[j], ref sourceArray[j + 1]);
                    }
                }
            }
        }

        static public void Sort(T[] sourceArray, IComparer<T> comparator)
        {
            if (comparator == null)
            {
                if (typeof(T).GetInterface("IComparable") != null)
                {
                    Comparer<T> comparer = Comparer<T>.Default;
                    Sort(sourceArray, comparer.Compare);
                }
                else
                {
                    throw new ArgumentNullException(nameof(comparator));
                }
            }
            else
            {
                Sort(sourceArray, comparator.Compare);
            }
        }

        static private void Swap(ref T value1, ref T value2)
        {
            T temp = value2;
            value2 = value1;
            value1 = temp;
        }
    }
}
