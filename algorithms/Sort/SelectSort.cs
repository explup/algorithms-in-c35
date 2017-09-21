using System;

namespace algorithms
{
    /// <summary>
    /// 1. assume first index of unsorted array is mini index 
    /// 2. get the mini's index from unsorted array
    /// 3. swap with first element of unsorted array
    /// </summary>
    public class SelectSort
    {
        public static int[] Execute(int[] arr)
        {
            if(arr == null)
            {
                throw new ArgumentNullException();
            }
            int miniIndex;

            for (int i = 0; i < arr.Length -1; i++)
            {
                miniIndex = i;
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if(arr[miniIndex] > arr[j])
                    {
                        miniIndex = j;
                    }
                }
                Helper.Swap(arr, i, miniIndex);

            }
            return arr;
        }
    }
}
