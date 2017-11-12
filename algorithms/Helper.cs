using System;
using System.Collections.Generic;
using System.Text;

namespace algorithms
{
    public static class Helper
    {
        public static void Swap(int[] array, int i, int j)
        {
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
    }
}
