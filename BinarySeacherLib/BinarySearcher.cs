using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySeacherLib
{
    public static class BinarySearcher<T>
    {
        private static int indexOfAbsentElement = -1;

        public static int Search(List<T> sourceList, T searchedElement, IComparer<T> comparer)
        {
            if (sourceList == null)
            {
                throw new ArgumentNullException(nameof(sourceList));
            }

            bool isFinded = false;
            int index, rightIndex, leftIndex, tempRightIndex, tempLeftIndex, compareResult;

            if (sourceList.Count == 0)
            {
                return indexOfAbsentElement;
            }

            rightIndex = sourceList.Count;
            leftIndex = 0;
            index = (rightIndex + leftIndex) / 2;
            tempLeftIndex = leftIndex;
            tempRightIndex = rightIndex;

            compareResult = comparer.Compare(sourceList[index], searchedElement);

            while (!isFinded)
            {
                if (compareResult == 0)
                {
                    break;
                }

                if (compareResult == 1)
                {
                    leftIndex = index;
                }
                else
                {
                    rightIndex = index;
                }

                if ((tempLeftIndex == leftIndex) && (tempRightIndex == rightIndex))
                {
                    return indexOfAbsentElement;
                }
                index = (rightIndex + leftIndex) / 2;
                compareResult = comparer.Compare(sourceList[index], searchedElement);

                tempLeftIndex = leftIndex;
                tempRightIndex = rightIndex;
            }

            return index;
        }
    }
}
