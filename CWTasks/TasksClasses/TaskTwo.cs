using System;
using System.Linq;
using System.Text;

namespace CWTasks.TasksClasses
{
    class TaskTwo
    {
        //Task 2:
        // The goal of this exercise is to convert a string to a new string where each character 
        // in the new string is "(" if that character appears only once in the original string, 
        // or ")" if that character appears more than once in the original string. 
        // Ignore capitalization when determining if a character is a duplicate.

        private const string _zeroLengthException = "Input string is empty";
        public string DuplicateEncode(string word)
        {
            if (word.Length == 0)
            {
                throw new Exception(_zeroLengthException);
            }
            word = word.ToLower();
            var result = new StringBuilder();
            foreach (var w in word)
            {
                result.Append(word.Count(x => x == w) > 1 ? ')' : '(');
            }
            return result.ToString();
        }
    }
}
