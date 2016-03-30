using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FibonachyLib
{
    public static class Fibonachy
    {
        public static IEnumerable<int> GetSequenceOfFibonachy(int nElement)
        {
            int previousElement = 0, nowElement = 1, temp;

            if (nElement <= 0)
            {
                yield return 0;
            }
            else
            {
                yield return nowElement;

                for (int i = 1; i < nElement; i++)
                {
                    temp = nowElement;
                    nowElement += previousElement;
                    previousElement = temp;
                    yield return nowElement;
                }
            }
        }
    }
}
