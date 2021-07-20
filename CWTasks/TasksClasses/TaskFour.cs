using System.Collections.Generic;

namespace CWTasks.TasksClasses
{
    class TaskFour
    {
        //Task 4:
        //You will be given an array of numbers.You have to sort the odd numbers in ascending order while leaving the even numbers at their original positions.

        private List<int> _indices, _oddNumbers;
        public int[] SortArray(int[] array)
        {
            _indices = new List<int>();
            _oddNumbers = new List<int>();
            for (int i = 0; i < array.Length; i++)
            {
                var element = array[i];
                if (element % 2 != 0)
                {
                    _indices.Add(i);
                    _oddNumbers.Add(element);
                }
            }
            _oddNumbers.Sort();
            for (int i = 0; i < _indices.Count; i++)
            {
                array[_indices[i]] = _oddNumbers[i];
            }

            return array;
        }
    }
}
