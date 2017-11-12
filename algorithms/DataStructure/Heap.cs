using System;
using System.Collections.Generic;
using System.Text;
using algorithms;

namespace algorithms.DataStructure
{
    public class Heap
    {
        private int _count;
        private int[] _array;
        public Heap(int size)
        {
            _count = 0;
            _array = new int[size];
        }
        
        public int ValueAtIndex(int index)
        {
            if(index > _count)
            {
                return 0;
            }
            return _array[index];

        }
        public void Add(int value)
        {
            if(_count <= _array.Length)
            {
                ++_count;
                _array[_count-1] = value;

                ResortHeap();
            }
        }

        private void ResortHeap()
        {
            int childIndex = _count - 1;
            int parentIndex = GetParentIndexByChildIndex(childIndex);

            while (parentIndex >= 0)
            {
                if(_array[childIndex] < _array[parentIndex])
                {
                    Helper.Swap(_array, childIndex, parentIndex);

                    childIndex = parentIndex;
                    parentIndex = GetParentIndexByChildIndex(childIndex);
                }
                else
                {
                    parentIndex = -1;
                }
            }
        }

        public bool Delete(int value)
        {
            int index = -1;
            for (int i = 0; i < _array.Length; i++)
            {
                if (value == _array[i])
                {
                    index = i;
                }
            }

            if (index == -1)
            {
                return false;
            }

            _count = _count - 1;
            _array[index] = _array[_count];

            int leftChidIndex = GetLeftChidIndexByParentIndex(index);
            int rightChildIndex = GetRightChidIndexByParentIndex(index);

            while (leftChidIndex < _count || rightChildIndex < _count)
            {
                if (_array[index] > _array[leftChidIndex])
                {
                    Helper.Swap(_array, leftChidIndex, index);

                    index = leftChidIndex;
                    leftChidIndex = GetLeftChidIndexByParentIndex(index);
                    rightChildIndex = GetRightChidIndexByParentIndex(index);
                }

                else if (_array[index] > _array[rightChildIndex])
                {
                    Helper.Swap(_array, rightChildIndex, index);

                    index = rightChildIndex;
                    leftChidIndex = GetLeftChidIndexByParentIndex(index);
                    rightChildIndex = GetRightChidIndexByParentIndex(index);
                }
                else
                {
                    leftChidIndex = _count;
                    rightChildIndex = _count;
                }
            }
            return true;
        }

        public bool Contains(int value)
        {
            int startIndex = 0;
            int nodes = 1;
            
            while(startIndex < _count)
            {
                int endIndex = nodes + startIndex;
                int count = 0;

                while (startIndex < _count && startIndex < endIndex)
                {
                    if (_array[startIndex] == value)
                    {
                        return true;
                    }
                    else if (_array[GetParentIndexByChildIndex(startIndex)] < value && _array[startIndex] > value)
                    {
                        count++;
                    }
                    else
                    {
                        startIndex++;
                    }
                }

                if(count == nodes)
                {
                    return false;
                }
                nodes = nodes * 2;
            }
            return false; 
        }
        private int GetParentIndexByChildIndex(int childIndex)
        {
            return (childIndex - 1) / 2;
        }

        private int GetLeftChidIndexByParentIndex(int parentIndex)
        {
            return  2 * parentIndex + 1;

        }

        private int GetRightChidIndexByParentIndex(int parentIndex)
        {
            return 2 * parentIndex + 2;

        }

    }
}
