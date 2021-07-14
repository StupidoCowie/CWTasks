using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWTasks.TasksClasses
{
    class TaskTwo
    {
        /*The goal of this exercise is to convert a string to a new string where each character 
         * in the new string is "(" if that character appears only once in the original string, 
         * or ")" if that character appears more than once in the original string. 
         * Ignore capitalization when determining if a character is a duplicate.*/
        public string DuplicateEncode(string word)
        {
            word = word.ToLower();
            var isThere = new List<char>() { word[0] };
            var result = new StringBuilder("(");
            for (var i = 1; i < word.Length; i++)
            {
                if (!isThere.Contains(word[i]))
                {
                    isThere.Add(word[i]);
                    result.Append("(");
                }
                else
                {
                    var index = word.IndexOf(word[i]);
                    result = new StringBuilder(result.ToString()) { [index] = ')' };
                    result.Append(")");
                }
            }
            return result.ToString();
        }
    }
}
