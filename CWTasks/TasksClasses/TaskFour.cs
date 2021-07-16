using System.Collections.Generic;

namespace CWTasks.TasksClasses
{
    class TaskFour
    {
        //Task 4:
        //You will be given an array of numbers.You have to sort the odd numbers in ascending order while leaving the even numbers at their original positions.

        private List<int> _index, _odds;
        public int[] SortArray(int[] array)
        {
            _index = new List<int>();
            _odds = new List<int>();
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 != 0)
                {
                    _index.Add(i);
                    _odds.Add(array[i]);
                }
            }
            _odds.Sort();
            for (int i = 0; i < _index.Count; i++)
            {
                array[_index[i]] = _odds[i];
            }

            return array;
        }
    }
}
