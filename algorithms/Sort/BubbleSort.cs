using System;

namespace algorithms
{
    /// <summary>
    /// 1. compare two items
    /// 2. if the one on the left is bigger, swap them
    /// 3. move one postion right
    /// </summary>
    public class BubbleSort
    {
        public static int[] Execute(int[] arr)
        {
            if(arr == null)
            {
                throw new ArgumentNullException();
            }
            for (int i = arr.Length -1; i > 0; i--)
            {
                for(int j = 0; j < i; j++)
                {
                    if(arr[j] > arr[j + 1])
                    {
                        Helper.Swap(arr, j, j + 1);
                    }
                }
            }
            return arr;
        }
    }
}
