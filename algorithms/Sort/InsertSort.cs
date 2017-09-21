using System;

namespace algorithms
{
    /// <summary>
    /// 1.assume first index of unsorted array is mini index 
    /// 2.get the mini's index from unsorted array
    /// 3.swap with first element of unsorted array
    /// </summary>
    public class InsertSort
    {
        public static int[] Execute(int[] arr)
        {
            if(arr == null)
            {
                throw new ArgumentNullException();
            }

                        
            for (int i = 1; i < arr.Length; i++)
            {
                int tempValue = arr[i];
                int j = i;
                while (j > 0 && arr[j-1] > tempValue)
                {
                    arr[j] = arr[j - 1];
                    j--;
                }
                
                arr[j] = tempValue;
            }
            return arr;
        }
    }
}