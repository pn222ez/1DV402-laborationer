using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laboration1_3
{
    static class MyExtensions
    {
        public static int Median(int[] source)
        {
            int medianReturn = 0;
            
            Array.Sort(source);

            if (source.Length % 2 == 0)
            {
                int num1 = 0;
                int num2 = 0;
                num1 = source[source.Length / 2];
                num2 = source[(source.Length / 2) - 1];
                medianReturn = (num1 + num2) / 2;
            }
            else
            {
                medianReturn = source[(source.Length - 1) / 2];
            }

            return medianReturn;
        }

        public static int Dispertion(int[] source)
        {
            int spread = 0;
            spread = source[source.Length - 1] - source[0];
            return spread;
        }
    }
}
